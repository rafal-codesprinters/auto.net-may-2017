using Xunit;

namespace Cwiczenie1.Tests
{
    public class CalcTests
    {
        // JEZELI_podam_liczbe_5_i_10_WOWCZAS_add_zwraca_15
        // When_given_5_and_10_Should_return_15
        
        [Fact]
        public void Dodawanie_zwraca_sume_dwoch_liczb()
        {
            // arrange
            var calculator = new Calc(20, 15);

            // act
            var result = calculator.Add();

            //assert
            Assert.Equal(35, result);
        }

        [Fact]
        public void Odejmowanie_zwraca_roznice_dwoch_liczb()
        {
            var calculator = new Calc(9, 15);
            var result = calculator.Substract();
            Assert.Equal(-6, result);
        }

        [Fact]
        public void Mnozenie_zwraca_iloczyn_dwoch_liczb()
        {
            var calculator = new Calc(9, 3);
            var result = calculator.Multiply();
            Assert.Equal(27, result);
        }

        [Fact]
        public void Dzielenie_zwraca_dzielenie_dwoch_liczb()
        {
            var calculator = new Calc(9, 3);
            var result = calculator.Divide();
            Assert.Equal(3, result);
        }
    }
}
