using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
using Moq;
using NUnit.Framework;

namespace UnitTest
{
    // Lab 4 Q10
    public class AdditionalCalculatorTests
    {
        private Calculator _calculator;
        private Mock<IFileReader> _mockFileReader;

        [SetUp]
        public void Setup()
        {
            _mockFileReader = new Mock<IFileReader>();
            _mockFileReader.Setup(fr =>
            fr.Read(@"D:\final_3101_lab4\ConsoleApp1\ConsoleApp1\MagicNumbers.txt")).Returns(new string[9] { "-11", "17", "9", "4", "-8", "-2", "3", "5", "0" });
            _calculator = new Calculator();
        }

        [Test]
        public void MagicNumberMock_WithChoiceNegative_ResultIsZero()
        {
            // Act
            double result = _calculator.GenMagicNum(-1, _mockFileReader.Object);
            // Assert
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void MagicNumberMock_StringRetrievedIsPositiveNumber_ResultIsDoubleTheNumber()
        {
            // Act
            double result = _calculator.GenMagicNum(1, _mockFileReader.Object);
            // Assert
            Assert.That(result, Is.EqualTo(34));
        }

        [Test]
        public void MagicNumberMock_WithStringRetrievedIsNegativeNumber_ResultIsPositiveAndDoubleTheNumber()
        {
            // Act
            double result = _calculator.GenMagicNum(0, _mockFileReader.Object);
            // Assert
            Assert.That(result, Is.EqualTo(22));
        }

        [Test]
        public void MagicNumberMock_WithStringRetrievedIsZero_ResultIsZero()
        {
            // Act
            double result = _calculator.GenMagicNum(8, _mockFileReader.Object);
            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void MagicNumberMock_WithChoiceNumberEqualsToNumberOfLines_ResultIsZero()
        {
            // Act
            double result = _calculator.GenMagicNum(9, _mockFileReader.Object);
            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void MagicNumberMock_WithChoiceMoreThanNumberOfLines_ResultIsZero()
        {
            // Act
            double result = _calculator.GenMagicNum(10, _mockFileReader.Object);
            // Assert
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
