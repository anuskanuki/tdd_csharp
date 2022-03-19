using NUnit.Framework;

namespace Application.Domain.Tests
{
    [TestFixture]
    public class CalculatorTest
    {
        // sum ---------------------------------------------------
        [Test]
        public void ShouldSumTwoIntNumbers()
        {
            var sut = new Calculator();
            // the sut (named after pattern, meaning System Under Test) variable defines WHAT are we testing.

            var result = sut.IntSum(1, 2);
            // the result (named after pattern) variable defines the result we have.

            Assert.That(result, Is.EqualTo(3));
            // the assert key identify if the test was successfull or not, 
            // by the following params (real result, expected result in order to pass).
        }

        [Test]
        public void ShouldSumTwoDoubleNumbers()
        {
            var sut = new Calculator();

            var result = sut.DoubleSum(1.5435, 2.88);

            Assert.That(result, Is.EqualTo(4.4235));
        }

        // multiply ---------------------------------------------------

        [Test]
        public void ShouldMultiplyTwoIntNumbers()
        {
            var sut = new Calculator();

            var result = sut.MultiplyInt(2, 10);

            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void ShouldMultiplyTwoDoubleNumbers()
        {
            var sut = new Calculator();

            var result = sut.MultiplyDouble(2.5, 70.42);

            Assert.That(result, Is.EqualTo(176.05));
        }

        // sub ---------------------------------------------------
        [Test]
        public void ShouldSubtractTwoIntNumbers()
        {
            var sut = new Calculator();

            var result = sut.SubtractInt(10, 6);

            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void ShouldSubtractTwoDoubleNumbers()
        {
            var sut = new Calculator();

            var result = sut.SubtractDouble(10.5, 5.5);

            Assert.That(result, Is.EqualTo(5));
        }

        // divide ---------------------------------------------------
        [Test]
        public void ShouldDivideTwoIntNumbers()
        {
            var sut = new Calculator();

            var result = sut.DivideInt(10, 2);

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void ShouldDivideTwoDoubleNumbers()
        {
            var sut = new Calculator();

            var result = sut.DivideDouble(10.5, 2.5);

            Assert.That(result, Is.EqualTo(4.2));
        }
    }
}
