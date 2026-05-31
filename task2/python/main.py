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
    

class MoveValidator:
    @staticmethod
    def is_move_valid(piece: Piece, new_x: int, new_y: int) -> bool:
        if new_x < 0 or new_x > 7 or new_y < 0 or new_y > 7:
            return False
        return piece.check_move(new_x, new_y)
    
class Board:
    def __init__(self):
        self.pieces = []

    def add_piece(self, piece: Piece):
        self.pieces.append(piece)
    
    def display_status(self):
        print("Aktualna pozycja figur:")
        for piece in self.pieces:
            print(f"{piece.name} ({piece.color}) - pozycja: ({piece.x}, {piece.y})")
        print("-------------------------------")

    def move_piece(self, piece: Piece, new_x: int, new_y: int) -> bool:
        print(f"Próba przesunięcia {piece.name} ({piece.color}) z ({piece.x}, {piece.y}) na ({new_x}, {new_y})")
        if MoveValidator.is_move_valid(piece, new_x, new_y):
            print("Ruch jest prawidłowy.")
            piece.x = new_x
            piece.y = new_y
            return True
        else:
            print("Ruch jest nieprawidłowy.")
            return False
    
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
        if self.is_in_check("black"):
            print("UWAGA: Czarny król jest w szachu!")
        else:
            print("Okej, brak szachów.")