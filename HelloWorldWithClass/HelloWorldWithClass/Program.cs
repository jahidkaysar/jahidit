using System;

namespace HelloWorldWithClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter First Number: ");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Number: ");
            int number2 = Convert.ToInt32(Console.ReadLine());

            Calculator calculator = new Calculator();

            int res_plus = calculator.plus(number1, number2);
            Console.WriteLine("\nSum is: " + res_plus);

            int res_minus = calculator.minus(number1, number2);
            Console.WriteLine("Subtraction is: " + res_minus);

            int res_intu = calculator.intu(number1, number2);
            Console.WriteLine("Multiplication is: " + res_intu);

            int res_division = calculator.division(number1, number2);
            Console.WriteLine("Division is: " + res_division);
        }
    }
}
