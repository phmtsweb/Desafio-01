using System.ComponentModel.Design;

namespace Desafio_01
{
    class Program
    {
        static readonly string CODE_EXIT = "/q";
        static string? CommonAsk(string message)
        {
            string? input;
            do
            {
                Console.Write($"{message}({CODE_EXIT} - Exit): ");
                input = Console.ReadLine();
            } while (IsNotFinalAnswer(input));

            return input?.Trim();
        }

        static double CommonAskDouble(string message)
        {
            string? input;
            double result;
            bool isValid;
            do
            {
                Console.Write($"{message}({CODE_EXIT} - Exit): ");
                input = Console.ReadLine();
                isValid = IsNumber(input, out result);
                if (!isValid)
                    Console.WriteLine("Invalid number");
            } while (IsNotFinalAnswer(input) || !isValid);

            return result;
        }
        static bool IsNotFinalAnswer(string? input) => (input is null || input?.Trim() == "") && !CheckExit(input);
        static bool IsValidAnswer(string? input) => input is not null && input.Trim() != "" && !CheckExit(input);
        static bool CheckExit(string? input) => input?.Trim().ToLower() == CODE_EXIT;
        static bool IsNumber(string? input, out double result) => double.TryParse(input, out result);

        static void ExecuteOption(int option)
        {
            switch(option)
            {
                case 1:
                    GreetingsView();
                    break;
                case 2:
                    FullnameView();
                    break;
                case 3:
                    AddView();
                    break;
                case 4:
                    SubtractView();
                    break;
                case 5:
                    MultiplyView();
                    break;
                case 6:
                    DivideView();
                    break;
                case 7:
                    AverageView();
                    break;
                case 8:
                    WordLengthView();
                    break;
                case 9:
                    PlateView();
                    break;
                case 10:
                    DateView(2);
                    break;
                case 11:
                    DateView(3);
                    break;
                case 12:
                    DateView(1);
                    break;
                case 13:
                    DateView(4);
                    break;
            }
        }
        static void GreetingsView()
        {
            string? name = CommonAsk("Type your name");
            if (IsValidAnswer(name))
                Console.WriteLine(Exercicio01.Greetings(name));
        }

        static void FullnameView()
        {
            string? firstName = CommonAsk("Type your first name");
            string? lastName = CommonAsk("Type your last name");
            if (IsValidAnswer(firstName) && IsValidAnswer(lastName))
                Console.WriteLine(Exercicio01.FullName(firstName!, lastName!));
        }

        static void AddView()
        {
            double a = CommonAskDouble("Type the first number");
            double b = CommonAskDouble("Type the second number");
            Console.WriteLine($"{a} + {b} = {Exercicio01.Add(a, b)}");
        }

        static void SubtractView()
        {
            double a = CommonAskDouble("Type the first number");
            double b = CommonAskDouble("Type the second number");
            Console.WriteLine($"{a} - {b} = {Exercicio01.Subtract(a, b)}");
        }
        static void MultiplyView()
        {
            double a = CommonAskDouble("Type the first number");
            double b = CommonAskDouble("Type the second number");
            Console.WriteLine($"{a} x {b} = {Exercicio01.Multiply(a, b)}");
        }
        static void DivideView()
        {
            double a = CommonAskDouble("Type the first number");
            double b = CommonAskDouble("Type the second number");
            try
            {
                Console.WriteLine($"{a} / {b} = {Exercicio01.Divide(a, b)}");
            } catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void AverageView()
        {
            double a = CommonAskDouble("Type the first number");
            double b = CommonAskDouble("Type the second number");
            Console.WriteLine($"Average between {a} and {b} is {Exercicio01.Average(a, b)}");
        }
        static void WordLengthView()
        {
            string? word = CommonAsk("Type a word");
            if (IsValidAnswer(word))
                Console.WriteLine($"The word length is {Exercicio01.WordSize(word!)}");
        }
        static void PlateView()
        {
            string? plate = CommonAsk("Type a plate");
            if (IsValidAnswer(plate))
                Console.WriteLine(Exercicio01.IsValidPlate(plate!) ? "Valid plate" : "Invalid plate");
        }
        static void DateView(int option)
        {
            Exercicio01.PrintDate(option);
        }
        static void View()
        {
            string? option;
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1\tType your name");
                Console.WriteLine("2\tType your fullname");
                Console.WriteLine("3\tAdd two numbers");
                Console.WriteLine("4\tSubtract two numbers");
                Console.WriteLine("5\tMultiply two numbers");
                Console.WriteLine("6\tDivide two numbers");
                Console.WriteLine("7\tAverage between two numbers");
                Console.WriteLine("8\tFind out word length");
                Console.WriteLine("9\tCheck valid plate");
                Console.WriteLine("10\tShow current date");
                Console.WriteLine("11\tShow current hour");
                Console.WriteLine("12\tShow current full date and time");
                Console.WriteLine("13\tShow date with nominal month");
                Console.WriteLine($"{CODE_EXIT}\tExit");
                option = Console.ReadLine();
                if (CheckExit(option))
                {
                    Console.WriteLine("Bye bye...");
                    break;
                }
                int optionNumber;
                try
                {
                    if (option is not null)
                    {
                        optionNumber = int.Parse(option);
                        if (optionNumber >= 1 && optionNumber <= 13)
                            ExecuteOption(optionNumber);
                        else
                        {
                            Console.WriteLine("Invalid option");
                        }
                    } else
                    {
                        Console.WriteLine("Invalid option");
                    }
                } catch (FormatException)
                {
                    Console.WriteLine("Invalid option");
                }
            } while (option != CODE_EXIT);
        }
        static void Main()
        {
            View();
        }
    }
}