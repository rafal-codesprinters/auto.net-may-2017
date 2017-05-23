namespace Cwiczenie1
{
    public class Calc
    {
        private int x;
        private int y;

        public Calc(int a, int b)
        {
            x = a;
            y = b;
        }

        public int Add()
        {
            return x + y;
        }

        public int Substract()
        {
            return x - y;
        }

        public int Multiply()
        {
            return x * y;
        }

        public double Divide()
        {
            return x / y;
        }
    }
}
