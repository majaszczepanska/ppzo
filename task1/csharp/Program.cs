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
                Console.WriteLine("2. Konweter temperatury (Celsjusz <-> Fahrenheit)");
                Console.WriteLine("3. Wyliczanie średniej ocen ucznia");
                Console.WriteLine("4. Zakończ program");
                Console.Write("Wybierz opcję (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    //Calculator
                    case "1":
                        Console.WriteLine("\nZadanie 1: Prosty kalkulator dwóch liczb.");
                        double a = 0, b = 0;
                        try
                        {
                            Console.Write("Podaj pierwszą liczbę: ");
                            a = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Podaj drugą liczbę: ");
                            b = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Nieprawidłowe dane. Musisz podać liczby.");
                            continue;
                        }

                        Console.Write("Wybierz operację (+, -, *, /): ");
                        string operation = Console.ReadLine();
                        double result = 0;
                        //Prevent division by zero
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
                        
                    //Temperature converter
                    case "2":
                        Console.WriteLine("\nZadanie 2: Konweter temperatury (Celsjusz <-> Fahrenheit).");
                        Console.WriteLine("Wybierz konwersję:" +
                              "\n- napisz c jeżeli chcesz zamienić Celsjusza na Fahrenheita" +
                              "\n- napisz f jeżeli chcesz zamienić Fahrenheita na Celsjusza): ");
                        string conversion = Console.ReadLine().ToLower();
                        //Validate user input (c or f)
                        if (conversion != "c" && conversion != "f")
                        {
                            Console.WriteLine("Nieprawidłowy wybór konwersji.");
                            continue;
                        }
                        
                        double temp = 0;
                        try
                        {
                            Console.WriteLine("Podaj temperaturę: ");
                            temp = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Nieprawidłowe dane. Musisz podać liczbę.");
                            continue;
                        }

                        //Perform conversion
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
                    
                    //Average grade calculator
                    case "3":
                        Console.WriteLine("\nZadanie 3: Wyliczanie średniej ocen ucznia.");
                        int numberOfGrades = 0;
                        try
                        {
                            Console.Write("Podaj liczbę ocen: ");
                            numberOfGrades = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Nieprawidłowe dane. Musisz podać liczbę całkowitą.");
                            continue;
                        }
                        double sumOfGrades = 0;
                        for (int i = 0; i < numberOfGrades; i++)
                        {
                            //Keep asking for grade until user inputs a valid one (between 1 and 6)
                            while (true)
                            {
                                double grade = 0;
                                try
                                {
                                    Console.Write("Podaj ocenę: ");
                                    grade = Convert.ToDouble(Console.ReadLine());
                                } 
                                catch (FormatException)
                                {
                                    Console.WriteLine("Nieprawidłowe dane. Musisz podać liczbę.");
                                    continue;
                                }
                                //Validate grade (1-6)
                                if (grade >= 1 && grade <= 6)
                                {
                                    sumOfGrades += grade;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Nieprawidłowa ocena. Musisz podać liczbę od 1 do 6.");
                                }
                            }
                        }
                        double average = Math.Round(sumOfGrades / numberOfGrades, 2);
                        Console.WriteLine($"Średnia: {average}");

                        if (average >= 3.0)
                        {
                            Console.WriteLine("Uczeń zdał.");
                        }
                        else
                        {
                            Console.WriteLine("Uczeń nie zdał.");
                        }
                        break;

                    //Exit program
                    case "4":
                        Console.WriteLine("Zakończenie programu.");
                        return;
                    //Invalid choice (other than 1-4)
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Wybierz opcję od 1 do 4.");
                        break; 
                    
                }
            }
        }
        
    }

}