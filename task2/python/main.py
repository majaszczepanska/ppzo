import sqlite3

# Extra: Database logging for valid moves, at the end of the game - read the chess.db file to show logged moves
def init_db(db_path="chess.db"):
    """Initializes the SQLite database and creates the necessary table for logging moves."""
    conn = sqlite3.connect(db_path)
    cur = conn.cursor()
    # Create a table to log valid moves
    cur.execute("""
        CREATE TABLE IF NOT EXISTS moves (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            piece_name TEXT NOT NULL,
            color TEXT NOT NULL,
            to_x INTEGER NOT NULL,
            to_y INTEGER NOT NULL
        )
    """)
    conn.commit()
    return conn

def log_move_to_db(conn, piece, x, y):
    """Logs a valid move to the database."""
    cur = conn.cursor()
    cur.execute(
        "INSERT INTO moves (piece_name, color, to_x, to_y) VALUES (?, ?, ?, ?)",
        (piece.name, piece.color, x, y)
    )
    conn.commit()


class Player:
    def __init__(self, name: str, color: str):
        self.name = name
        self.color = color
    
class Piece:
    def __init__(self, name: str, color: str, x: int, y: int):
        self.name = name
        self.color = color
        self.x = x
        self.y = y

    def check_move(self, new_x: int, new_y: int) -> bool:
        #logic will be implemented in child classes
        pass

# --- FIGURES ---
class Pawn(Piece):
    def __init__(self, color: str, x: int, y: int):
        super().__init__("Pawn", color, x, y)
    
    def check_move(self, new_x: int, new_y: int) -> bool:
        if self.color == "white":
            if self.y == 1: 
                return (new_x == self.x and new_y == self.y + 1) or (new_x == self.x and new_y == self.y + 2)
            else:
                return new_x == self.x and new_y == self.y + 1
        elif self.color == "black":
            if self.y == 6:
                return (new_x == self.x and new_y == self.y - 1) or (new_x == self.x and new_y == self.y - 2)
            else:
                return new_x == self.x and new_y == self.y - 1
        else:
            return False
        

class Rook(Piece):
    def __init__(self, color: str, x: int, y: int):
        super().__init__("Rook", color, x, y)
    
    def check_move(self, new_x: int, new_y: int) -> bool:
        dx = abs(new_x - self.x)
        dy = abs(new_y - self.y)
        return (dx == 0 and dy != 0) or (dx != 0 and dy == 0)
    

class Knight(Piece):
    def __init__(self, color: str, x: int, y: int):
        super().__init__("Knight", color, x, y)
    
    def check_move(self, new_x: int, new_y: int) -> bool:
        dx = abs(new_x - self.x)
        dy = abs(new_y - self.y)
        return (dx == 2 and dy == 1) or (dx == 1 and dy == 2)


class Bishop(Piece):
    def __init__(self, color: str, x: int, y: int):
        super().__init__("Bishop", color, x, y)

    def check_move(self, new_x: int, new_y: int) -> bool:
        dx = abs(new_x - self.x)
        dy = abs(new_y - self.y)
        return dx == dy and dx > 0


class Queen(Piece):
    def __init__(self, color: str, x: int, y: int):
        super().__init__("Queen", color, x, y)

    def check_move(self, new_x: int, new_y: int) -> bool:
        dx = abs(new_x - self.x)
        dy = abs(new_y - self.y)
        return (dx == 0 and dy > 0) or (dx > 0 and dy == 0) or (dx == dy and dx > 0)


class King(Piece):
    def __init__(self, color: str, x: int, y: int):
        super().__init__("King", color, x, y)

    def check_move(self, new_x: int, new_y: int) -> bool:
        dx = abs(new_x - self.x)
        dy = abs(new_y - self.y)
        return dx <= 1 and dy <= 1 and (dx > 0 or dy > 0)
    
# --- GAME LOGIC ---
class MoveValidator:
    @staticmethod
    def is_move_valid(piece: Piece, new_x: int, new_y: int) -> bool:
        if new_x < 0 or new_x > 7 or new_y < 0 or new_y > 7:
            return False
        return piece.check_move(new_x, new_y)
    
# --- BOARD ---
class Board:
    def __init__(self, db_conn=None):
        self.pieces = []
        self.db_conn = db_conn

    def add_piece(self, piece: Piece):
        self.pieces.append(piece)
    
    def display_status(self):
        print("Aktualna pozycja figur:")
        for piece in self.pieces:
            print(f"{piece.name} ({piece.color}) - pozycja: ({piece.x}, {piece.y})")
        print("-------------------------------")

    # Move a piece if the move is valid
    def move_piece(self, piece: Piece, new_x: int, new_y: int) -> bool:
        print(f"Próba przesunięcia {piece.name} ({piece.color}) z ({piece.x}, {piece.y}) na ({new_x}, {new_y})")
        if MoveValidator.is_move_valid(piece, new_x, new_y):
            # add logic for capturing pieces
            target_piece = None
            for p in self.pieces:
                if p.x == new_x and p.y == new_y:
                    target_piece = p
                    break
            
            if target_piece:
                if target_piece.color == piece.color:
                    print("Status: BŁĄD! Nie możesz stanąć na polu zajętym przez własną figurę.")
                    return False
                else:
                    print(f"Status: BICIE! Figura {target_piece.name} ({target_piece.color}) została usunięta z planszy.")
                    self.pieces.remove(target_piece)

            print("Status: Ruch jest prawidłowy.")
            piece.x = new_x
            piece.y = new_y
            if self.db_conn:
                log_move_to_db(self.db_conn, piece, new_x, new_y)
                print("Zapisano log ruchu w bazie danych (SQLite).")
        else:
            print("Status: BŁĄD! Ruch jest nieprawidłowy.")
    
    # Check if the king of the given color is in check
    def is_in_check(self, color: str) -> bool:
        king = None
        for piece in self.pieces:
            if isinstance(piece, King) and piece.color == color:
                king = piece
                break
        if not king:
            return False
        for piece in self.pieces:
            if piece.color != color:
                if piece.check_move(king.x, king.y):
                    return True
        return False

    def check_game_state(self):
        print("Sprawdzanie stanu gry...")
        if self.is_in_check("white"):
            print("UWAGA: Biały król jest w szachu!")
        elif self.is_in_check("black"):
            print("UWAGA: Czarny król jest w szachu!")
        else:
            print("Jest dobrze, brak szachów.")
    
if __name__ == "__main__":
    # Initialize the database connection
    conn = init_db("chess.db")
    
    # 1. Creating players and board
    player1 = Player("Jan", "white")
    player2 = Player("Anna", "black")
    board = Board(db_conn=conn)

    # 2. Creating pieces for both players
    white_king = King("white", 4, 0)
    white_pawn = Pawn("white", 4, 1)
    black_rook = Rook("black", 0, 7)
    black_bishop = Bishop("black", 2, 7)

    # 3. Adding pieces to the board
    board.add_piece(white_king)
    board.add_piece(white_pawn)
    board.add_piece(black_rook)
    board.add_piece(black_bishop)

    # 4. Initial state
    board.display_status()
    board.check_game_state()

    # --- Sequence of Moves ---

    # VALID: Pawn moves 2 squares forward from the starting position
    board.move_piece(white_pawn, 4, 3)

    # INVALID: Rook tries to move diagonally (violates Rook logic)
    board.move_piece(black_rook, 1, 6)

    # INVALID: Rook tries to move out of the board bounds (y=8)
    board.move_piece(black_rook, 0, 8)

    # VALID ATTACK: Rook moves straight down to the White King's row (y=0)
    board.move_piece(black_rook, 0, 0)

    # Check game state - should result in a CHECK!
    board.check_game_state()

    # VALID DEFENSIVE MOVE: King escapes upwards from the Rook's line of attack
    board.move_piece(white_king, 4, 1)
    
    # Check game state after the escape - check should be cleared
    board.check_game_state()

    # VALID MOVE: Black Rook moves under the White King
    board.move_piece(black_rook, 4, 0)

    # VALID CAPTURE: White King captures the Black Rook!
    board.move_piece(white_king, 4, 0)
    board.display_status()

    # Display final status of the board - read chess.db file to show logged moves
    print("\n--- ZAWARTOŚĆ BAZY DANYCH ---")
    cursor = conn.cursor()
    cursor.execute("SELECT * FROM moves")
    rows = cursor.fetchall()
    for row in rows:
        print(row)