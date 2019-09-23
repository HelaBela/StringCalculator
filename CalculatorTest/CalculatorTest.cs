using System;
using NUnit.Framework;
using StringCalculator;

namespace Tests
{
    public class CalculatorTest
    {
        private  KataCalculator stringCalc;
        [SetUp]
        public void Setup()
        {
            stringCalc = new KataCalculator();

        }
        
        //arrange act assert

        [Test]
        public void AddsEmptyReturnsZero()
        {

            var result = stringCalc.Add("");
            
            Assert.AreEqual(0, result);
        }
        
        [Test]
        public void CalculatorTakesNumberAndReturnsThatNumber()
        {
            Assert.AreEqual(2, stringCalc.Add("2"));
        }
        
        [Test]
        public void CalculatorTakesIn1And2AndReturnsSum()
        {
            Assert.AreEqual(3, stringCalc.Add("1,2"));
        }
        
        [Test]
        public void CalculatorTakesIn3And5AndReturnsSum()
        {
            Assert.AreEqual(8, stringCalc.Add("3,5"));
        }

        [Test]
        public void CalculatorTakesInOneTwoThreeAndReturnsSum()
        {
            Assert.AreEqual(6, stringCalc.Add("1,2,3"));
        }
        [Test]
        public void CalculatorTakesInThreeFiveThreeNineAndReturnsSum()
        {
            Assert.AreEqual(20, stringCalc.Add("3,5,3,9"));
        }

        [Test]
        public void CalculatorTakesInOneTwoLineBreakerAndThreeAndReturnsSum()
        {
            Assert.AreEqual(6, stringCalc.Add("1,2\n3"));
        }
        [Test]
        public void CalculatorTakesInThreeLineBreakFiveLineBreakThreeAndNineSum()
        {
            Assert.AreEqual(20, stringCalc.Add("3\n5\n3,9"));
        }
        [Test]
        public void CalculatorTakesInDifferentDiametersAndNumbersAndReturnsSum()
        {
            Assert.AreEqual(3, stringCalc.Add("//;\n1;2"));
        }
        [Test]
        public void CalculatorTakesInNegativeNumberAndThrowsExceptionWithAMessageWhichNumberWasNegative()
        {
            var exception = Assert.Throws<Exception>(()=>stringCalc.Add("-1,2,-3"));

            Assert.AreEqual("-1, -3", exception.Message);
        }
        
        [Test]
        public void Should_Return_Sum_With_Numbers_Greater_Than_999_Ignored()
        {
            Assert.AreEqual(2, stringCalc.Add("1000,1001,2"));
        }
        
        [Test]
        public void ShouldAcceptCustomDelimeterAndReturnSum()
        {
            Assert.AreEqual(6, stringCalc.Add("//[***]\n1***2***3"));
        }
        
        [Test]
        public void ShouldAcceptCustomDelimeterWithDigitInItThatIsIgnoredAndRestIsReturnedAsSum()
        {
            Assert.AreEqual(6, stringCalc.Add("//[*1*][%]\n1*1*2%3"));
        }
        
    }
}