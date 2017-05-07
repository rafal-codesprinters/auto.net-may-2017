using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MiejscaZerowe
{
    [TestClass]
    public class TestCases
    {
        [TestClass]
        public class ParabolaTest
        {
            string a = String.Empty;
            string b = String.Empty;
            string c = String.Empty;
            string d = String.Empty;

            // ----------------------------------- POSITIVE SCENARIOS -----------------------------------

            [TestMethod]
            public void BrakMiejscZerowych()
            {
                a = "1";
                b = "2";
                c = "3";
                string OczekiwanyWynik = "Brak miejsc zerowych.";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void JednoMiejsceZerowe()
            {
                a = "2";
                b = "-4";
                c = "2";
                string OczekiwanyWynik = "Jedno miejsce zerowe: x0 = 1";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void DwaMiejscaZerowe()
            {
                a = "-1";
                b = "3";
                c = "4";
                string OczekiwanyWynik = "Dwa miejsca zerowe: x1 = 4, x2 = -1";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void ZeroweWspolczynnikiAiB()
            {
                a = "0";
                b = "0";
                c = "5";
                string OczekiwanyWynik = "Brak miejsc zerowych.";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void ZeroweWspolczynnikiAiC()
            {
                a = "0";
                b = "2";
                c = "0";
                string OczekiwanyWynik = "Jedno miejsce zerowe: x0 = 0";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void ZeroweWspolczynnikiBiC()
            {
                a = "-5";
                b = "0";
                c = "0";
                string OczekiwanyWynik = "Jedno miejsce zerowe: x0 = 0";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void ZeroweWspolczynnikiFukncji()
            {
                a = "0";
                b = "0";
                c = "0";
                string OczekiwanyWynik = "Nieskończenie wiele miejsc zerowych.";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            // ----------------------------------- NEGATIVE SCENARIOS -----------------------------------

            [TestMethod]
            public void LiteraJakoWspolczynnikA()
            {
                a = "A";
                b = "1";
                c = "15";
                string OczekiwanyWynik = "Niepoprawna wartość współczynnika 'a' funkcji.";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void LiteraJakoWspolczynnikB()
            {
                a = "7";
                b = "B";
                c = "15";
                string OczekiwanyWynik = "Niepoprawna wartość współczynnika 'b' funkcji.";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void LiteraJakoWspolczynnikC()
            {
                a = "3";
                b = "1";
                c = "C";
                string OczekiwanyWynik = "Niepoprawna wartość współczynnika 'c' funkcji.";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void BrakJednegoWspolczynnika()
            {
                a = "3";
                b = "1";
                c = String.Empty;
                string OczekiwanyWynik = "Podano 2 zamiast 3 współczynników.";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void BrakDwochWspolczynnikow()
            {
                a = "3";
                b = String.Empty;
                c = String.Empty;
                string OczekiwanyWynik = "Podano 1 zamiast 3 współczynników.";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void BrakWspolczynnikow()
            {
                a = String.Empty;
                b = String.Empty;
                c = String.Empty;
                string OczekiwanyWynik = "Nie podano żadnych współczynników.";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }


            [TestMethod]
            public void ZaDuzoWspolczynnikow()
            {
                a = "1";
                b = "2";
                c = "3";
                d = "7";
                string OczekiwanyWynik = "Podano więcej niż 3 współczynniki.";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            // ----------------------------------- ADVANCED SCENARIOS -----------------------------------

            [TestMethod]
            public void UlamkoweMiejscaZerowe()
            {
                a = "-1.08";
                b = "77.25";
                c = "-11.5";
                string OczekiwanyWynik = "Dwa miejsca zerowe: x1 = 71.38, x2 = 0.15";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void UlamkoweWspolczynnikiFunkcji()
            {
                a = "-1.15";
                b = "-3.35";
                c = "99.7";
                string OczekiwanyWynik = "Dwa miejsca zerowe: x1 = 7.97, x2 = -10.88";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void ZerowyWspolczynnikA()
            {
                a = "0";
                b = "1";
                c = "2";
                string OczekiwanyWynik = "Jedno miejsce zerowe: x0 = -2";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void ZerowyWspolczynnikB()
            {
                a = "-11";
                b = "0";
                c = "2";
                string OczekiwanyWynik = "Dwa miejsca zerowe: x1 = 0.43, x2 = -0.43";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void ZerowyWspolczynnikC()
            {
                a = "4";
                b = "1";
                c = "0";
                string OczekiwanyWynik = "Dwa miejsca zerowe: x1 = -0.25, x2 = 0";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void NiepoprawnyFormatUlamkaJakoWspolczynnikA()
            {
                a = "-20,3";
                b = "1.1";
                c = "15";
                string OczekiwanyWynik = "Niepoprawna wartość współczynnika 'a' funkcji.";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void NiepoprawnyFormatUlamkaJakoWspolczynnikB()
            {
                a = "7.2";
                b = "1,33";
                c = "15";
                string OczekiwanyWynik = "Niepoprawna wartość współczynnika 'b' funkcji.";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            [TestMethod]
            public void NiepoprawnyFormatUlamkaJakoWspolczynnikC()
            {
                a = "0.3";
                b = "1";
                c = "15,34";
                string OczekiwanyWynik = "Niepoprawna wartość współczynnika 'c' funkcji.";

                string OtrzymanyWynik = Oblicz();

                Assert.AreEqual(OczekiwanyWynik, OtrzymanyWynik);
            }

            // ------------------------------------- HELPING METHOD -------------------------------------

            private string Oblicz()
            {
                string[] args = new string[] { };
                if (a != String.Empty)
                {
                    Array.Resize(ref args, args.Length + 1);
                    args[args.Length - 1] = a;
                }
                if (b != String.Empty)
                {
                    Array.Resize(ref args, args.Length + 1);
                    args[args.Length - 1] = b;
                }
                if (c != String.Empty)
                {
                    Array.Resize(ref args, args.Length + 1);
                    args[args.Length - 1] = c;
                }
                if (d != String.Empty)
                {
                    Array.Resize(ref args, args.Length + 1);
                    args[args.Length - 1] = d;
                }
                return Program.Calculate(args);
            }
        }
    }
}
