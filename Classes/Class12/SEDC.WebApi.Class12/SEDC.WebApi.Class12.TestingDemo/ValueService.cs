using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Class12.TestingDemo
{
    public class ValueService
    {
        public int? Sum(int num, int num1)
        {
            var result = num + num1;
            if(num < 0 && num1 < 0 && result < 0)
            {
                return null;
            }
            return result;
        }

        public bool IsFirstLarger(int first, int second)
        {
            return first > second;
        }
        
        public string GetDigitName(int digit)
        {
            var digitNames = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            return digitNames[digit];
        }

        [TestClass]
        public class ValueTests
        {
            private ValueService _service;

            public ValueTests()
            {
                _service = new ValueService();
            }

            [TestMethod]
            public void Sum_PositiveIntegers_ResutNumber()
            {
                // Arange
                var num1 = 5;
                var num2 = 5;
                var expectedResult = 10;

                //Act
                var result = _service.Sum(num1, num2);

                //Assert
                Assert.AreEqual(expectedResult, result);
            }

            [TestMethod]
            public void Sum_NegativeIntegers_ResultNull()
            {
                //Arrange
                var num1 = -10;
                var num2 = -5;
                var expectedResult = -15;

                //Act
                var result = _service.Sum(num1, num2);

                //Assert
                Assert.IsNull(result);
            }

            [TestMethod]
            public void GetDigitName_ValidDigit()
            {
                //Arange
                var digit = 1;
                var expectedResult = "One";

                //Act
                var result = _service.GetDigitName(digit);

                //Assert
                Assert.AreEqual(expectedResult, result);
            }

            [TestMethod]
            public void GetDigitName_NotValidGigit()
            {
                //Arange
                var digit = 15;

                //Act

                //Assert
                Assert.ThrowsException<IndexOutOfRangeException>(() =>
                {
                    _service.GetDigitName(digit);
                });
            }


        }

    }
}
