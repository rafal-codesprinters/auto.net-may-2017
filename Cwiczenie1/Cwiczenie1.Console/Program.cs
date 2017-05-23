using System;

namespace Cwiczenie1.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // arrange
            var calculator = new Calc(20,15);

            // act
            var result = calculator.Add();

            //assert
            if(result == 35)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OK");
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Blad");
            }

            Console.ReadLine();
        }
    }
}
