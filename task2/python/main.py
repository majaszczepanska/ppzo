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