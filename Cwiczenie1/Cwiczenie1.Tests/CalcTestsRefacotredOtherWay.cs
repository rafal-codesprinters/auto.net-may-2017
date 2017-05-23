using Xunit;

namespace Cwiczenie1.Tests
{
    public class CalcTestsRefactoredOtherWay
    {
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(9000000, 9000000, 18000000)]
        public void Dodawanie_zwraca_sume_dwoch_liczb(int x, int y, int expected)
        {
            var calculator = new Calc(x, y);
            var result = calculator.Add();
            Assert.Equal(expected, result);
        }
       
        [Theory]
        [InlineData(9,3,3)]
        [InlineData(1, 2, 0.5)]
        public void Dzielenie_zwraca_dzielenie_dwoch_liczb(int x, int y, int expected)
        {
            var calculator = new Calc(x, y);
            var result = calculator.Divide();
            Assert.Equal(expected, result);
        }
    }
}
