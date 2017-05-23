using Xunit;

namespace Cwiczenie1.Tests
{
    public class CalcTestsRefactored
    {
        private Calc _calculator;

        public CalcTestsRefactored()
        {
            _calculator = new Calc(9, 3);
        }
        
        [Fact]
        public void Dodawanie_zwraca_sume_dwoch_liczb()
        {
            var result = _calculator.Add();
            Assert.Equal(12, result);
        }

        [Fact]
        public void Odejmowanie_zwraca_roznice_dwoch_liczb()
        {
            var result = _calculator.Substract();
            Assert.Equal(6, result);
        }

        [Fact]
        public void Mnozenie_zwraca_iloczyn_dwoch_liczb()
        {
            var result = _calculator.Multiply();
            Assert.Equal(27, result);
        }

        [Fact]
        public void Dzielenie_zwraca_dzielenie_dwoch_liczb()
        {
            var result = _calculator.Divide();
            Assert.Equal(3, result);
        }
    }
}
