def main():
    while True:
        print("\nMenu programu:")
        print("1. Prosty kalkulator dwóch liczb")
        print("2. Konweter temperatury (Celsjusz <->Fahrenheit)")
        print("3. Wyliczanie średniej ocen ucznia")
        print("4. Zakończ program")
        choice = input("Wybierz opcję (1-4): ")

        if choice == '1':
            print("\nZadanie 1: Prosty kalkulator dwóch liczb.")
            a = float(input("Podaj pierwszą liczbę: "))
            b = float(input("Podaj drugą liczbę: "))
            operation = input("Wybierz operację (+, -, *, /): ")
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

        elif choice == '2':
            print("\nZadanie 2: Konweter temperatury (Celsjusz <-> Fahrenheit).")
            conversion = input("Wybierz konwersję:"
                              "\n- napisz c jeżeli chcesz zamienić Celsjusza na Fahrenheita"
                              "\n- napisz f jeżeli chcesz zamienić Fahrenheita na Celsjusza): ")
            temp = float(input("Podaj temperaturę: "))
            if conversion == "c":
                result = round((temp * 1.8) + 32, 2)
                print(temp, "°C to", result, "°F")
            elif conversion == "f":
                result = round((temp - 32) / 1.8, 2)
                print(temp, "°F to", result, "°C")

        elif choice == '3':
            print("\nZadanie 3: Wyliczanie średniej ocen ucznia.")
            number_of_grades = int(input("Podaj liczbę ocen: "))
            sum_of_grades = 0
            for i in range(number_of_grades):
                grade = float(input(f"Podaj ocenę: "))
                if grade >= 1 and grade <= 6:
                    sum_of_grades += grade
                else:
                    print("Nieprawidłowa ocena. Podaj ocenę od 1 do 6.")
                    continue
            average = sum_of_grades / number_of_grades
            print(f"Średnia: {round(average, 2)}")
            if (average >= 3.0):
                print("Uczeń zdał.")
            else:
                print("Uczeń nie zdał.")
        elif choice == '4':
            print("Zakończenie programu.")
            break
        else:
            print("Nieprawidłowy wybór. Wybierz opcję od 1 do 4.")

main()