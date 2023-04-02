using FluentAssertions;
using Xunit;

namespace EmployeeServiceTests
{
    public class ProtectionAgainstRegressionTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(50, 50.1, 100)]
        [InlineData(10, -10, 0)]
        public void Test(int num1, int num2, int expectedResult)
        {
            // Arrange
            var sut = new Calculator();

            //Act
            var result = sut.Add(num1, num2);

            //Assert
            result.Should().Be(expectedResult);
        }
    }

    internal class Calculator
    {
        public Calculator()
        {
        }

        internal int Add(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}