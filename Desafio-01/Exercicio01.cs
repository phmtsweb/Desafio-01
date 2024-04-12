using System.Text.RegularExpressions;

namespace Desafio_01;
public class Exercicio01
{
    public static string Greetings(string? name) => name is not null ? $"Olá, {name}! Seja muito bem-vindo!" : "Name is not typed";

    public static string FullName(string firstName, string lastName) => $"{firstName} {lastName}";

    public static double Add(double a, double b) => a + b;

    public static double Subtract(double a, double b) => a - b;

    public static double Multiply(double a, double b) => a * b;

    public static double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("It's not possible to divide by 0.");
        }
        return a / b;
    }

    public static double Average(double a, double b) => (a + b) / 2;

    public static int WordSize(string word) => word.Length;

    public static bool IsValidPlate(string plate) => Regex.IsMatch(plate, @"^[a-zA-Z]{3}\d{4}$");

    public static void PrintDate(int option)
    {
        var date = DateTime.Now;
        switch (option)
        {
            case 1:
                Console.WriteLine(date.ToString("F"));
                break;
            case 2:
                Console.WriteLine(date.ToString("dd/MM/yyyy"));
                break;
            case 3:
                Console.WriteLine(date.ToString("HH:mm:ss"));
                break;
            case 4:
                Console.WriteLine(date.ToString("m"));
                break;
        }
    }
}
