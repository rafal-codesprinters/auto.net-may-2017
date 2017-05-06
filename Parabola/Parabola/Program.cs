using System;
using System.Globalization;

namespace Parabola
{
    public class Program
    {
        public static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                Console.Write("Podaj wartość współczynnika: a = ");
                string a = Console.ReadLine();

                Console.Write("Podaj wartość współczynnika: b = ");
                string b = Console.ReadLine();

                Console.Write("Podaj wartość współczynnika: c = ");
                string c = Console.ReadLine();

                Console.WriteLine(Calculate(new string[] {a, b, c}));
            }
            else
            {
                Console.WriteLine(Calculate(args));
            }
            Console.WriteLine("Naciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }

        private static bool Calculate(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}