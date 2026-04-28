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
                        
                    case "2":
                        Console.WriteLine("\nZadanie 2: Konweter temperatury (Celsjusz <-> Fahrenheit).");
                        Console.WriteLine("Wybierz konwersję:" +
                              "\n- napisz c jeżeli chcesz zamienić Celsjusza na Fahrenheita" +
                              "\n- napisz f jeżeli chcesz zamienić Fahrenheita na Celsjusza): ");
                        string conversion = Console.ReadLine().ToLower();
                        if (conversion != "c" && conversion != "f")
                        {
                            Console.WriteLine("Nieprawidłowy wybór konwersji.");
                            continue;
                        }
                        Console.WriteLine("Podaj temperaturę: ");
                        double temp = Convert.ToDouble(Console.ReadLine());
                        if (conversion == "c")
                        {
                            double result2 = Math.Round((temp * 1.8) + 32, 2);
                            Console.WriteLine($"{temp}°C = {result2}°F");
                        }
                        else
                        {
                            double result2 = Math.Round((temp - 32) / 1.8, 2);
                            Console.WriteLine($"{temp}°F = {result2}°C");
                        }
                        break;
                    
                    case "4":
                        Console.WriteLine("Zakończenie programu.");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Wybierz opcję od 1 do 4.");
                        break; 
                    
                }
            }
        }
        
    }

}