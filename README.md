# Podstawy programowania zorientowane obiektowo - zadania

Repozytorium zawiera rozwiązania zadań w językach: Python i C#.

## Technologie
* C# (.NET)
* Python 3

---

## Zestaw 1

**Rozwiązania:**
* **Python:** `task1/python/main.py`
* **C#:** `task1/csharp/Program.cs`


**Zrealizowane programy (dostępne z poziomu głównego menu):**
1. **Prosty kalkulator:** Dodawanie, odejmowanie, mnożenie i dzielenie dwóch liczb (zabezpieczone przed błędami wejścia i dzieleniem przez zero).
2. **Konwerter temperatur:** Przeliczanie stopni Celsjusza na Fahrenheita i odwrotnie (nieprawidłowy wybór opcji cofa do menu).
3. **Kalkulator średniej ocen:** Wyliczanie średniej z podanych ocen (weryfikacja skali 1-6) oraz sprawdzanie warunku zaliczenia przedmiotu (średnia >= 3.0).

---

## Zestaw 2

**Rozwiązania:**
* **Python:** `task2/python/main.py`
* **C#:** `task2/csharp/Program.cs`

**Zrealizowany projekt (Model Szachownicy):**
Implementacja uproszczonej gry w szachy, nastawiona na demonstrację paradygmatów programowania obiektowego (OOP).
* **Klasy i Dziedziczenie:** Stworzenie klasy bazowej `Piece` oraz klas po niej dziedziczących (`Pawn`, `Rook`, `Knight`, `Bishop`, `Queen`, `King`). Każda figura posiada własną logikę poruszania się.
* **Walidacja ruchu:** Klasa `MoveValidator` sprawdzająca, czy ruch jest zgodny z zasadami danej figury i czy nie wykracza poza planszę 8x8.
* **Stan gry:** Detekcja sytuacji, w której jakikolwiek Król znajduje się w szachu.
* **Zapis danych (Bonus):** Integracja z lokalną bazą danych **SQLite** (`chess.db`). Zapisywanie historii poprawnych ruchów z poziomu kodu (przy użyciu modułu `sqlite3` w Pythonie oraz `Microsoft.Data.Sqlite` w C#).

---

## Zestaw 3


---

## Zestaw 4

---