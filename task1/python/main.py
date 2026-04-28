def main():
    while True:
        
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
        print(f"Wynik: {result}")
            
        
main()