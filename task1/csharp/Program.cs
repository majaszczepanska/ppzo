using System;
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("\nMenu programu:");
                Console.WriteLine("1. Prosty kalkulator dwóch liczb");
                Console.WriteLine("2. Konweter temperatury (Celsjusz <->Fahrenheit)");
                Console.WriteLine("3. Wyliczanie średniej ocen ucznia");
                Console.WriteLine("4. Zakończ program");
                Console.Write("Wybierz opcję (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nZadanie 1: Prosty kalkulator dwóch liczb.");
                        Console.Write("Podaj pierwszą liczbę: ");
                        double a = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Podaj drugą liczbę: ");
                        double b = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Wybierz operację (+, -, *, /): ");
                        string operation = Console.ReadLine();
                        double result = 0;
                        if (operation == "/" && b == 0)
                        {
                            Console.WriteLine("Nie można dzielić przez zero.");
                            continue;
                        }
                        switch (operation)
                        {
                            case "+":
                                result = a + b;
                                break;
                            case "-":
                                result = a - b;
                                break;
                            case "*":
                                result = a * b;
                                break;
                            case "/":
                                result = a / b;
                                break;
                            default:
                                Console.WriteLine("Nieprawidłowa operacja.");
                                continue;
                        }
                        Console.WriteLine($"Wynik: {Math.Round(result, 2)}");
                        break;
                        
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Wybierz opcję od 1 do 4.");
                        break; 
                    
                }
            }
        }
        
    }

}