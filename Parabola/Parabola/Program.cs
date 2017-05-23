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

        public static string Calculate(string[] args)
        {
             //throw new NotImplementedException();
            
            CultureInfo customCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            customCulture.NumberFormat.NumberNegativePattern = 1;
            customCulture.NumberFormat.NumberGroupSeparator = "";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;


            //-1
            //- 1
            //1-
            //1 -
            string output = String.Empty;
            switch (args.Length)
            {
                case 0:
                    {
                        output = "Nie podano żadnych współczynników.";
                        break;
                    }
                case 1:
                    {
                        output = "Podano 1 zamiast 3 współczynników.";
                        break;
                    }
                case 2:
                    {
                        output = "Podano 2 zamiast 3 współczynników.";
                        break;
                    }
                case 3:
                    {
                        try
                        {
//                            double result;
//                            if (double.TryParse("12", out result))
//                            {
//                                output = "niepoprawna....";
//                            }

                            double a = Convert.ToDouble(args[0]);
                            try
                            {
                                double b = Convert.ToDouble(args[1]);
                                try
                                {
                                    double c = Convert.ToDouble(args[2]);
                                    output = ComputeRoots(a, b, c);
                                }
                                catch (FormatException)
                                {
                                    output = "Niepoprawna wartość współczynnika 'c' funkcji.";
                                }
                            }
                            catch (FormatException)
                            {
                                output = "Niepoprawna wartość współczynnika 'b' funkcji.";
                            }
                        }
                        catch (FormatException)
                        {
                            output = "Niepoprawna wartość współczynnika 'a' funkcji.";
                        }
                        break;
                    }
                default:
                    {
                        output = "Podano więcej niż 3 współczynniki.";
                        break;
                    }
            }
            return output;

            throw new NotImplementedException();
        }

        private static string ComputeRoots(double a, double b, double c)
        {
            String roots = String.Empty;
            if (a != 0)
            {
                Double delta = (b * b) - (4 * a * c);
                if (delta < 0)
                {
                    roots = "Brak miejsc zerowych.";
                }
                if (delta == 0)
                {
                    roots = "Jedno miejsce zerowe: x0 = " + Convert.ToString(Math.Round(-1 * b / (2 * a), 2));
                }
                if (delta > 0)
                {
                    roots = "Dwa miejsca zerowe: x1 = " + Convert.ToString(Math.Round((-1 * b - Math.Sqrt(delta)) / (2 * a), 2))
                        + ", x2 = " + Convert.ToString(Math.Round((-1 * b + Math.Sqrt(delta)) / (2 * a), 2));
                }
            }
            else
            {
                if (b != 0)
                {
                    roots = "Jedno miejsce zerowe: x0 = " + Convert.ToString(Math.Round(-1 * c / b, 2));
                }
                else
                {
                    if (c != 0)
                    {
                        roots = "Brak miejsc zerowych.";
                    }
                    else
                    {
                        roots = "Nieskończenie wiele miejsc zerowych.";
                    }
                }
            }
            return roots;
        }
    }
}