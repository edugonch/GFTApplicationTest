using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GFTApplication.Tests
{
    [TestClass]
    public class TokenReaderTest
    {
        [TestMethod]
        public void ShouldReturnACorrectIdWhenUsingReadId()
        {
            Assert.AreEqual(2, GFTApplication.Interpreter.TokenReader.ReadId("2"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Id not valid, please enter a valid id")]
        public void ShouldThrowExceptionWhenUsingReadIdAndTheInputIsNotInCorrectFormat()
        {
            GFTApplication.Interpreter.TokenReader.ReadId("df");
        }


        [TestMethod]
        public void ShopuldReadAPoint()
        {
            var expected = new float[] { 0.5f, -9 };
            var real = GFTApplication.Interpreter.TokenReader.ReadPoint("0.5 -9");
            Assert.AreEqual(expected[0], real[0]);
            Assert.AreEqual(expected[1], real[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Wrong format of arguments, params x of the point shold be of type float. 'x y'")]
        public void ShouldThrowAnExceptionIfXIsInBadFormat()
        {
            GFTApplication.Interpreter.TokenReader.ReadPoint("a -9");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Wrong format of arguments, params y of the point shold be of type float. 'x y'")]
        public void ShouldThrowAnExceptionIfYIsInBadFormat()
        {
            GFTApplication.Interpreter.TokenReader.ReadPoint("0.5 b");
        }

        [TestMethod]
        public void ShopuldReturnACircle()
        {
            GFTApplication.Models.Circle circle = new Models.Circle(1.7f, -5.05f, 6.9f);
            var real = GFTApplication.Interpreter.TokenReader.ReadToken("circle 1.7 -5.05 6.9");
            circle.Id = 1;
            real.Id = 1;
            Assert.AreEqual(circle.ToString(), real.ToString());
        }


        [TestMethod]
        public void ShopuldReturnARectangle()
        {
            GFTApplication.Models.Rectangle rectangle = new Models.Rectangle(3.5f, 2.0f, 5.6f, 7.2f);
            var real = GFTApplication.Interpreter.TokenReader.ReadToken("rectangle 3.5 2.0 5.6 7.2");
            rectangle.Id = 1;
            real.Id = 1;
            Assert.AreEqual(rectangle.ToString(), real.ToString());
        }

        [TestMethod]
        public void ShopuldReturnASquare()
        {
            GFTApplication.Models.Square square = new Models.Square(3.55f, 4.1f, 2.77f);
            var real = GFTApplication.Interpreter.TokenReader.ReadToken("square 3.55 4.1 2.77");
            square.Id = 1;
            real.Id = 1;
            Assert.AreEqual(square.ToString(), real.ToString());
        }

        [TestMethod]
        public void ShopuldReturnATriangle()
        {
            GFTApplication.Models.Triangle triangle = new Models.Triangle(4.5f, 1, -2.5f, -33, 23f, 0.3f);
            var real = GFTApplication.Interpreter.TokenReader.ReadToken("triangle 4.5 1 -2.5 -33 23 0.3");
            triangle.Id = 1;
            real.Id = 1;
            Assert.AreEqual(triangle.ToString(), real.ToString());
        }

        [TestMethod]
        public void ShopuldReturnADonut()
        {
            GFTApplication.Models.Donut donut = new Models.Donut(4.5f, 7.8f, 1.5f, 1.8f);
            var real = GFTApplication.Interpreter.TokenReader.ReadToken("donut 4.5 7.8 1.5 1.8");
            donut.Id = 1;
            real.Id = 1;
            Assert.AreEqual(donut.ToString(), real.ToString());
        }
    }
}
