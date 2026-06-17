# Podstawy programowania zorientowane obiektowo - zadania

Repozytorium zawiera rozwiązania zadań w językach: Python, C# i Java.

## Technologie
* C# (.NET)
* Python 3
* Java

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
# Projekt: System Zarządzania Schroniskiem

**Rozwiązania:**
* **Java:** `task3/java/`


## 1. Opis tematu aplikacji
Aplikacja jest modelem systemu zarządzania wirtualnym schroniskiem dla zwierząt. Głównym celem jest ewidencja zwierząt (psów i kotów), rejestracja osób chętnych do adopcji oraz bezpieczne procesowanie aktu adopcji. System demonstruje mapowanie obiektów świata rzeczywistego na struktury danych.

## 2. Lista klas i ich odpowiedzialność
Zgodnie z zasadą Single Responsibility Principle (SRP):
* **Animal (Klasa abstrakcyjna)** – Główny kontrakt dla zwierząt. Przechowuje stan (id, name, age, isAdopted).
* **Dog / Cat (Klasy pochodne)** – Implementują unikalne zachowania (`interact()`, `play()`).
* **Adopter** – Przechowuje dane adoptującego oraz listę jego zwierzaków.
* **Shelter** – Odpowiada za zarządzanie listą `availableAnimals`.
* **AdoptionRecord** – Klasa asocjacyjna realizująca logikę biznesową adopcji (łączy `Adopter` z `Animal`).
* **Playable (Interfejs)** – Definiuje kontrakt dla zwierząt zdolnych do zabawy.

## 3. Relacje między klasami
* **Agregacja:** `Shelter` posiada `List<Animal>`. Schronisko przechowuje zwierzęta, ale zwierzę może istnieć poza schroniskiem.
* **Kompozycja:** `Adopter` posiada `List<Animal>`. Adoptowane zwierzęta stają się "częścią" inwentarza adoptującego.
* **Parametry metod:** Metoda `processAdoption` w klasie `AdoptionRecord` przyjmuje `(Animal animal, Adopter adopter)`, co realizuje przekazanie zależności (Dependency Injection).
* **Identyfikatory:** Każdy obiekt `Animal` i `Adopter` posiada unikalny `UUID`, co symuluje klucz główny bazy danych.

## 4. Realizacja zasad OOP – wskazanie implementacji
Gdzie w kodzie znajdują się konkretne zasady OOP:

### Enkapsulacja
* **Gdzie:** Wszystkie pola (np. `private String id`, `private List<Animal> availableAnimals`) są prywatne.
* **Uzasadnienie:** Dostęp do danych odbywa się tylko przez publiczne metody (`getName()`, `adopt()`). Status `isAdopted` nie może zostać zmieniony z zewnątrz bez wywołania metody `adopt()`, co chroni integralność stanu obiektu.

### Abstrakcja
* **Gdzie:** Klasa abstrakcyjna `Animal` oraz interfejs `Playable`.
* **Uzasadnienie:** Klasa `Animal` posiada metodę `public abstract void interact()`. Nie definiujemy w niej *jak* zwierzę interaguje, tylko *że musi* to robić. Interfejs `Playable` wymusza na klasach `Dog` i `Cat` posiadanie metody `play()`.

### Dziedziczenie
* **Gdzie:** `public class Dog extends Animal`, `public class Cat extends Animal`.
* **Uzasadnienie:** Klasy `Dog` i `Cat` otrzymują wszystkie cechy (id, name, age) po klasie `Animal`, realizując relację "jest rodzajem" (IS-A). Dzięki temu unikamy duplikacji kodu dla każdej rasy.

### Polimorfizm
* **Gdzie:** Metoda `interact()` wywoływana w pętli w klasie `Shelter` (metoda `showAnimals`).
* **Uzasadnienie:** Mimo że lista przechowuje typ `Animal`, wywołanie `animal.interact()` skutkuje wykonaniem różnych wersji kodu (szczekanie dla psa, mruczenie dla kota). System jest odporny na rozszerzenia – jeśli dodasz `Bird`, wystarczy, że zaimplementuje `interact()`, a `Shelter` obsłuży to bez zmiany kodu.

## 5. Wykorzystanie narzędzi AI
Zgodnie z wymogami kursu oświadczam, że podczas tworzenia projektu wspomagałam się modelami AI (LLM). Zakres wsparcia obejmował:
1. **Burzę mózgów:** Wybór tematu projektu (Schronisko dla zwierząt).
2. **Weryfikację poprawności:** Konsultacje dotyczące poprawności implementacji interfejsów, metod abstrakcyjnych oraz struktury pakietów w Javie.
3. **Strukturę dokumentacji:** Pomoc przy formatowaniu i uporządkowaniu treści w pliku README.

**Wkład własny:** Cała logika biznesowa aplikacji, analiza zasad OOP, przygotowanie implementacji oraz finalna weryfikacja zgodności projektu z wymaganiami kursu zostały wykonane przeze mnie. Kod został przeanalizowany pod kątem zrozumienia każdej zastosowanej konstrukcji (enkapsulacja, polimorfizm, dziedziczenie, abstrakcja), co potwierdza merytoryczna zawartość sekcji 4 dokumentacji.

---

