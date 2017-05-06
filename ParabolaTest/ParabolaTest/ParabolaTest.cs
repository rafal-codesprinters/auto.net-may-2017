using System;
using Xunit;
using System.IO;
using System.Diagnostics;

namespace ParabolaTest
{
    public class ParabolaTest
    {
        string a;
        string b;
        string c;
        string PromptWcisnijKlawisz = Environment.NewLine + "Naciśnij dowolny klawisz aby zakończyć...";

        // ----------------------------------- POSITIVE SCENARIOS -----------------------------------

        [Fact]
        public void BrakMiejscZerowych()
        {
            a = "1";
            b = "2";
            c = "3";
            string OczekiwanyWynik = "Brak miejsc zerowych." + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void JednoMiejsceZerowe()
        {
            a = "2";
            b = "-4";
            c = "2";
            string OczekiwanyWynik = "Jedno miejsce zerowe: x0 = 1" + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void DwaMiejscaZerowe()
        {
            a = "-1";
            b = "3";
            c = "4";
            string OczekiwanyWynik = "Dwa miejsca zerowe: x1 = 4, x2 = -1" + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void ZeroweWspolczynnikiAiB()
        {
            a = "0";
            b = "0";
            c = "5";
            string OczekiwanyWynik = "Brak miejsc zerowych." + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void ZeroweWspolczynnikiAiC()
        {
            a = "0";
            b = "2";
            c = "0";
            string OczekiwanyWynik = "Jedno miejsce zerowe: x0 = 0" + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void ZeroweWspolczynnikiBiC()
        {
            a = "-5";
            b = "0";
            c = "0";
            string OczekiwanyWynik = "Jedno miejsce zerowe: x0 = 0" + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void ZeroweWspolczynnikiFukncji()
        {
            a = "0";
            b = "0";
            c = "0";
            string OczekiwanyWynik = "Nieskończenie wiele miejsc zerowych." + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        // ----------------------------------- NEGATIVE SCENARIOS -----------------------------------

        [Fact]
        public void LiteraJakoWspolczynnikA()
        {
            a = "A";
            b = "1";
            c = "15";
            string OczekiwanyWynik = "Niepoprawna wartość współczynnika 'a' funkcji." + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void LiteraJakoWspolczynnikB()
        {
            a = "7";
            b = "B";
            c = "15";
            string OczekiwanyWynik = "Niepoprawna wartość współczynnika 'b' funkcji." + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void LiteraJakoWspolczynnikC()
        {
            a = "3";
            b = "1";
            c = "C";
            string OczekiwanyWynik = "Niepoprawna wartość współczynnika 'c' funkcji." + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void BrakJednegoWspółczynnika()
        {
            a = "3";
            b = "1";
            c = "";
            string OczekiwanyWynik = "Podano 2 zamiast 3 współczynników." + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void BrakDwochWspółczynnikow()
        {
            a = "3";
            b = "";
            c = "";
            string OczekiwanyWynik = "Podano 1 zamiast 3 współczynników." + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void BrakWspółczynnikow()
        {
            a = "";
            b = "";
            c = "";
            string OczekiwanyWynik = "Nie podano żadnych współczynników." + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }


        [Fact]
        public void ZaDuzoWspolczynnikow()
        {
            a = "1";
            b = "2";
            c = "3 4";
            string OczekiwanyWynik = "Podano więcej niż 3 współczynniki." + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        // ----------------------------------- ADVANCED SCENARIOS -----------------------------------

        [Fact]
        public void UlamkoweMiejscaZerowe()
        {
            a = "-1.08";
            b = "77.25";
            c = "-11.5";
            string OczekiwanyWynik = "Dwa miejsca zerowe: x1 = 71.38, x2 = 0.15" + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void UlamkoweWspolczynnikiFunkcji()
        {
            a = "-1.15";
            b = "-3.35";
            c = "99.7";
            string OczekiwanyWynik = "Dwa miejsca zerowe: x1 = 7.97, x2 = -10.88" + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void ZerowyWspolczynnikA()
        {
            a = "0";
            b = "1";
            c = "2";
            string OczekiwanyWynik = "Jedno miejsce zerowe: x0 = -2" + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void ZerowyWspolczynnikB()
        {
            a = "-11";
            b = "0";
            c = "2";
            string OczekiwanyWynik = "Dwa miejsca zerowe: x1 = 0.43, x2 = -0.43" + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void ZerowyWspolczynnikC()
        {
            a = "4";
            b = "1";
            c = "0";
            string OczekiwanyWynik = "Dwa miejsca zerowe: x1 = -0.25, x2 = 0" + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }
        
        [Fact]
        public void NiepoprawnyFormatUlamkaJakoWspolczynnikA()
        {
            a = "-20,3";
            b = "1.1";
            c = "15";
            string OczekiwanyWynik = "Niepoprawna wartość współczynnika 'a' funkcji." + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void NiepoprawnyFormatUlamkaJakoWspolczynnikB()
        {
            a = "7.2";
            b = "1,33";
            c = "15";
            string OczekiwanyWynik = "Niepoprawna wartość współczynnika 'b' funkcji." + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }

        [Fact]
        public void NiepoprawnyFormatUlamkaJakoWspolczynnikC()
        {
            a = "0.3";
            b = "1";
            c = "15,34";
            string OczekiwanyWynik = "Niepoprawna wartość współczynnika 'c' funkcji." + PromptWcisnijKlawisz;

            string OtrzymanyWynik = Oblicz(a, b, c);

            Assert.Equal(OczekiwanyWynik, OtrzymanyWynik);
        }
        
        // ------------------------------------- HELPING METHOD -------------------------------------

        private string Oblicz(string a, string b, string c)
        {
            Process aplikacja = new Process();
            aplikacja.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "\\Executable.exe";
            aplikacja.StartInfo.Arguments = (a + " " + b + " " + c).Trim();
            aplikacja.StartInfo.RedirectStandardInput = true;
            aplikacja.StartInfo.RedirectStandardOutput = true;
            aplikacja.StartInfo.UseShellExecute = false;
            aplikacja.StartInfo.CreateNoWindow = false;

            aplikacja.Start();
            StreamReader reader = aplikacja.StandardOutput;
            StreamWriter writer = aplikacja.StandardInput;

            writer.WriteLine("q");
            string LogKonsoli = reader.ReadToEnd().Trim();

            aplikacja.WaitForExit(5000);
            try
            {
                aplikacja.Kill();
            }
            catch
            {
                //
            }

            return LogKonsoli;
        }
    }
}