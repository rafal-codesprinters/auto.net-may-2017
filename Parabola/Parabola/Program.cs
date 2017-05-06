using System;
using System.Globalization;

namespace Parabola
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            customCulture.NumberFormat.NumberNegativePattern = 1;
            customCulture.NumberFormat.NumberGroupSeparator = "";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            switch (args.Length)
            {
                case 0:
                    {
                        Console.WriteLine("Nie podano żadnych współczynników.");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Podano 1 zamiast 3 współczynników.");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Podano 2 zamiast 3 współczynników.");
                        break;
                    }
                case 3:
                    {
                        try
                        {
                            double a = Convert.ToDouble(args[0]);
                            try
                            {
                                double b = Convert.ToDouble(args[1]);
                                try
                                {
                                    double c = Convert.ToDouble(args[2]);
                                    Console.WriteLine(Calculate(a, b, c));
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Niepoprawna wartość współczynnika 'c' funkcji.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Niepoprawna wartość współczynnika 'b' funkcji.");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Niepoprawna wartość współczynnika 'a' funkcji.");
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Podano więcej niż 3 współczynniki.");
                        break;
                    }
            }
            Console.WriteLine("Naciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }

        private static string Calculate(double a, double b, double c)
        {
            String result = "";
            if (a != 0)
            {
                Double delta = (b * b) - (4 * a * c);
                if (delta < 0)
                {
                    result = "Brak miejsc zerowych.";
                }
                if (delta == 0)
                {
                    result = "Jedno miejsce zerowe: x0 = " + Convert.ToString(Math.Round(-1 * b / (2 * a), 2));
                }
                if (delta > 0)
                {
                    result = "Dwa miejsca zerowe: x1 = " + Convert.ToString(Math.Round((-1 * b - Math.Sqrt(delta)) / (2 * a), 2))
                        + ", x2 = " + Convert.ToString(Math.Round((-1 * b + Math.Sqrt(delta)) / (2 * a), 2));
                }
            }
            else
            {
                if (b != 0)
                {
                    result = "Jedno miejsce zerowe: x0 = " + Convert.ToString(Math.Round(-1 * c / b, 2));
                }
                else
                {
                    if (c != 0)
                    {
                        result = "Brak miejsc zerowych.";
                    }
                    else
                    {
                        result = "Nieskończenie wiele miejsc zerowych.";
                    }
                }
            }
            return result;
        }
    }
}