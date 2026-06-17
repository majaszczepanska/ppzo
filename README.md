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
# Projekt: System Zarządzania Wirtualnym Schroniskiem

## 1. Opis tematu aplikacji
Aplikacja jest modelem systemu zarządzania wirtualnym schroniskiem dla zwierząt. Jej głównym celem jest ewidencja podopiecznych (psów i kotów), rejestracja osób chętnych do adopcji oraz bezpieczne i logiczne procesowanie samego aktu adopcji. Temat ten idealnie nadaje się do demonstracji zasad OOP, ponieważ naturalnie wymusza mapowanie obiektów świata rzeczywistego na struktury danych i relacje w kodzie.

## 2. Lista klas i ich odpowiedzialność (Single Responsibility Principle)
Aby uniknąć tworzenia "Boskiej Klasy" (zgodnie z zasadą SRP), system został podzielony na wyspecjalizowane obiekty:
* **Animal (Klasa abstrakcyjna)** – Wzorzec określający podstawowy stan i kontrakt dla każdego zwierzęcia. Odpowiada za przechowywanie danych (id, wiek, status adopcji).
* **Dog / Cat (Klasy pochodne)** – Reprezentują konkretne gatunki. Ich wyłączną odpowiedzialnością jest definiowanie unikalnych zachowań (implementacja metody interact()).
* **Adopter** – Reprezentuje klienta. Przechowuje jego dane oraz historię zaadoptowanych zwierząt.
* **Shelter** – Klasa-kolekcja zarządzająca stanem schroniska (dostępnymi zwierzętami) oraz posiadająca metody do dodawania i wyświetlania zwierząt.
* **AdoptionRecord (Klasa asocjacyjna)** – Odpowiada wyłącznie za logikę powiązania Adopter z Animal w procesie adopcji oraz zapisanie daty tego zdarzenia.
* **Playable (Interfejs)** – Dodatkowy kontrakt definiujący abstrakcyjną metodę play().

## 3. Relacje między klasami w systemie
Projekt demonstruje różnorodne połączenia obiektów omawiane w kursie:
1. **Agregacja (Relacja "ma", ale niezależna):** Shelter posiada kolekcję obiektów Animal (List<Animal>). Zwierzęta mogą istnieć niezależnie od schroniska (np. po adopcji).
2. **Kompozycja z perspektywy domeny:** Adopter posiada własną listę zaadoptowanych zwierząt.
3. **Przekazanie obiektu jako parametr metody:** Konstruktor w klasie AdoptionRecord przyjmuje jako parametry obiekty typu Animal oraz Adopter, łącząc je ze sobą.
4. **Identyfikatory (ID):** Klasy główne (Animal, Adopter) nie polegają wyłącznie na referencjach w pamięci, ale posiadają unikalne UUID imitujące klucze główne z bazy danych.

## 4. Realizacja czterech zasad OOP w praktyce
1. **Enkapsulacja:** Pola we wszystkich klasach są ukryte (private). Nie można z zewnątrz przypadkowo zmienić statusu adopcji zwierzęcia. Odbywa się to w kontrolowany sposób wyłącznie poprzez specjalną metodę adopt(). Zastosowano również gettery, blokując bezpośredni dostęp do stanu obiektów.
2. **Abstrakcja:** Ukryto szczegóły implementacji, tworząc klasę abstrakcyjną Animal z abstrakcyjną metodą interact(). Dodatkowo, system określa kontrakt zachowania poprzez interfejs Playable.
3. **Dziedziczenie:** Klasy szczegółowe Dog i Cat dziedziczą (extends) po klasie ogólnej Animal, co realizuje poprawną relację "jest rodzajem" (IS-A).
4. **Polimorfizm:** Mimo że klasa Shelter przechowuje listę ogólnego typu Animal, pętla wywołująca metodę interact() skutkuje różnym zachowaniem. Maszyna wirtualna Javy dynamicznie decyduje, czy wywołać szczekanie psa, czy mruczenie kota. Polimorfizm wykorzystano również przy implementacji interfejsu Playable.

## 5. Wykorzystanie narzędzi AI (Generative AI Disclosure)
Zgodnie z wytycznymi, oświadczam, że podczas tworzenia projektu wspomagałam się modelami AI. Sztuczna inteligencja posłużyła mi w procesie burzy mózgów przy doborze tematu, upewnieniu się co do poprawności implementacji interfejsów w Javie oraz do sformatowania opisów relacji w pliku README. Cała struktura logiczna, zasady powiązań i odpowiedzialność za poprawność kodu leży po mojej stronie.

---

