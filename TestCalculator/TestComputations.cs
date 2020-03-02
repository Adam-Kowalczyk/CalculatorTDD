using System;
using Xunit;
using Calculator;

namespace TestCalculator
{
    public class TestComputations
    {
        [Fact]
        public void TestZeroIfEmpty()
        {
            var computator = new Computations();
            //Given
            string emptyString = string.Empty;
            //When
            var result = computator.Calculate(emptyString);
            //Than
            Assert.Equal(0, result, 5);
        }

        [Fact]
        public void TestReturnWithoutChange()
        {
            var computator = new Computations();
            //Given
            string argument1 = "4";
            //When
            var result = computator.Calculate(argument1);
            //Than
            Assert.Equal(4, result, 5);
        }


        [Fact]
        public void TestSplitAndAdd2()
        {
            var computator = new Computations();
            //Given
            string argument1 = "3,75";
            //When
            var result = computator.Calculate(argument1);
            //Than
            Assert.Equal(78, result, 5);
        }

        [Fact]
        public void TestSplitAndAdd3()
        {
            var computator = new Computations();
            //Given
            string argument1 = "3,45,7";
            //When
            var result = computator.Calculate(argument1);
            //Than
            Assert.Equal(55, result, 5);
        }

        [Fact]
        public void TestNegativeNumber()
        {
            var computator = new Computations();
            //Given
            string argument1 = "-3,4,5";
            //When

            //Than
            Assert.Throws<ArgumentException>(() => computator.Calculate(argument1));
        }

        [Fact]
        public void TestIgnoreBig()
        {
            var computator = new Computations();
            //Given
            string argument1 = "3000,1000,7";
            //When
            var result = computator.Calculate(argument1);
            //Than
            Assert.Equal(1007, result, 5);
        }

        [Fact]
        public void TestCustomSeparator()
        {
            var computator = new Computations();
            //Given
            string argument1 = "//#\n4#6#2";
            //When
            var result = computator.Calculate(argument1);
            //Than
            Assert.Equal(12, result, 5);
        }

        [Fact]
        public void TestSeparatorBig()
        {
            var computator = new Computations();
            //Given
            string argument1 = "//[###]\n2###3###3";
            //When
            var result = computator.Calculate(argument1);
            //Than
            Assert.Equal(8, result, 5);
        }

        [Fact]
        public void TestManySeparators()
        {
            var computator = new Computations();
            //Given
            string argument1 = "//[##],[,],[???]\n5##88???2";
            //When
            var result = computator.Calculate(argument1);
            //Than
            Assert.Equal(95, result, 5);
        }

        [Fact]
        public void TestNSeparator()
        {
            var computator = new Computations();
            //Given
            string argument1 = "3\n5\n2";
            //When
            var result = computator.Calculate(argument1);
            //Than
            Assert.Equal(10, result, 5);
        }
    }
}
