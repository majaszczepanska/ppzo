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

**Zrealizowany projekt (Gra Strategia turowa – model szachów):**
W pełni zorientowana obiektowo (OOP) implementacja uproszczonej logiki gry w szachy.
* **Klasy i Dziedziczenie:** Stworzenie klasy bazowej `Piece` oraz podklas dla poszczególnych figur (`Pawn`, `Rook`, `Knight`, `Bishop`, `Queen`, `King`). Każda z nich hermetyzuje własną logikę dopuszczalnych ruchów.
* **Logika gry (Board i MoveValidator):** Klasy odpowiedzialne za zarządzanie stanem planszy (`Player`, `Board`), walidację współrzędnych (plansza 8x8) oraz weryfikację zasad ruchu.
* **Bicie i Szach:** Mechanizm usuwania z planszy figur przeciwnika (bicie) w przypadku prawidłowego ataku, oraz sprawdzanie stanu zagrożenia Króla w danej turze (szach).
* **Zapis danych (Bonus SQLite):** Trwały zapis logów (historii poprawnych ruchów) do lokalnej bazy danych `chess.db` przy użyciu wbudowanego modułu `sqlite3` (Python) oraz pakietu `Microsoft.Data.Sqlite` (C#).

---

## Zestaw 3


---

## Zestaw 4

---