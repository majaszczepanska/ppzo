def main():
    while True:
        print("\nMenu programu:")
        print("1. Prosty kalkulator dwóch liczb")
        print("2. Konweter temperatury (Celsjusz <->Fahrenheit)")
        print("3. Wyliczanie średniej ocen ucznia")
        print("4. Zakończ program")
        choice = input("Wybierz opcję (1-4): ")

        #Calculator
        if choice == '1':
            print("\nZadanie 1: Prosty kalkulator dwóch liczb.")
            try:
                a = float(input("Podaj pierwszą liczbę: "))
                b = float(input("Podaj drugą liczbę: "))
            except ValueError:
                print("Nieprawidłowe dane. Musisz podać liczby.")
                continue

            operation = input("Wybierz operację (+, -, *, /): ")
            #Prevent division by zero
            if operation == '/' and b == 0:
                print("Nie można dzielić przez zero.")
                continue

            if operation == '+':
                result = a + b
            elif operation == '-':
                result = a - b
            elif operation == '*':  
                result = a * b
            elif operation == '/':
                result = a / b
            else:                
                print("Nieprawidłowa operacja.")
                continue
            print(f"Wynik: {round(result, 2)}")

        #Temperature converter
        elif choice == '2':
            print("\nZadanie 2: Konweter temperatury (Celsjusz <-> Fahrenheit).")
            conversion = input("Wybierz konwersję:"
                              "\n- napisz c jeżeli chcesz zamienić Celsjusza na Fahrenheita"
                              "\n- napisz f jeżeli chcesz zamienić Fahrenheita na Celsjusza): ").lower()
            #Validate user input (c or f)
            if conversion != "c" and conversion != "f":
                print("Nieprawidłowy wybór konwersji.")
                continue

            try:
                temp = float(input("Podaj temperaturę: "))
            except ValueError:
                print("Nieprawidłowe dane. Musisz podać liczbę.")
                continue

            if conversion == "c":
                result = round((temp * 1.8) + 32, 2)
                print(temp, "°C to", result, "°F")
            elif conversion == "f":
                result = round((temp - 32) / 1.8, 2)
                print(temp, "°F to", result, "°C")

        #Average grade calculator
        elif choice == '3':
            print("\nZadanie 3: Wyliczanie średniej ocen ucznia.")
            try:
                number_of_grades = int(input("Podaj liczbę ocen: "))
            except ValueError:
                print("Nieprawidłowe dane. Musisz podać liczbę całkowitą.")
                continue

            if number_of_grades <= 0:
                print("Liczba ocen musi być większa od 0.")
                continue
            sum_of_grades = 0

            for i in range(number_of_grades):
                #Keep asking for grade until user inputs a valid one (between 1 and 6)
                while True:
                    try:
                        grade = float(input(f"Podaj ocenę: "))
                    except ValueError:
                        print("Nieprawidłowe dane. Musisz podać liczbę.")
                        continue

                    #Validate grade (1-6)
                    if grade >= 1 and grade <= 6:
                        sum_of_grades += grade
                        break
                    else:
                        print("Nieprawidłowa ocena. Podaj ocenę od 1 do 6.")
                
            average = round(sum_of_grades / number_of_grades, 2)
            print(f"Średnia: {average}")

            if (average >= 3.0):
                print("Uczeń zdał.")
            else:
                print("Uczeń nie zdał.")

        #Exit program
        elif choice == '4':
            print("Zakończenie programu.")
            break

        #Invalid choice (other than 1-4)
        else:
            print("Nieprawidłowy wybór. Wybierz opcję od 1 do 4.")

main()