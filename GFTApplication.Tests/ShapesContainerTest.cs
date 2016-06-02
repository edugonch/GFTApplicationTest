using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GFTApplication.Tests
{
    [TestClass]
    public class ShapesContainerTest
    {
        [TestMethod]
        public void ShouldAddAShapeAndReturnTheCorrectPrint()
        {
            GFTApplication.ShapesContainer container = new ShapesContainer();
            GFTApplication.Models.Rectangle rectangle = new Models.Rectangle(3.5f, 2.0f, 5.6f, 7.2f);

            rectangle.Id = 1;

            var ans = container.AddShape(rectangle);

            Assert.AreEqual("shape 1: rectangle with center at (3.5, 2) and side1 5.6, side2 7.2", ans);
        }


        [TestMethod]
        public void ShouldBeAbleToDeleteAShapeById()
        {
            GFTApplication.ShapesContainer container = new ShapesContainer();
            GFTApplication.Models.Rectangle rectangle = new Models.Rectangle(3.5f, 2.0f, 5.6f, 7.2f);

            rectangle.Id = 1;

            container.AddShape(rectangle);

            var ans = container.deleteShape(1);

            Assert.AreEqual("String with id 1 was removed.", ans);
        }


        [TestMethod]
        public void ShouldReturnAnErrorMessageIfTheIdDoesntExists()
        {
            GFTApplication.ShapesContainer container = new ShapesContainer();

            var ans = container.deleteShape(1);

            Assert.AreEqual("Shape with id 1 was not found.", ans);
        }

        [TestMethod]
        public void ShouldReturnReturnAStringListWithAllTheShapes()
        {
            GFTApplication.ShapesContainer container = new ShapesContainer();

            GFTApplication.Models.Circle circle = new Models.Circle(1.7f, -5.05f, 6.9f);
            GFTApplication.Models.Square square = new Models.Square(3.55f, 4.1f, 2.77f);
            GFTApplication.Models.Rectangle rectangle = new Models.Rectangle(3.5f, 2.0f, 5.6f, 7.2f);
            GFTApplication.Models.Triangle triangle = new Models.Triangle(4.5f, 1, -2.5f, -33, 23, 0.3f);
            GFTApplication.Models.Donut donut = new Models.Donut(4.5f, 7.8f, 1.5f, 1.8f);

            circle.Id = 1;
            square.Id = 2;
            rectangle.Id = 3;
            triangle.Id = 4;
            donut.Id = 5;

            container.AddShape(circle);
            container.AddShape(square);
            container.AddShape(rectangle);
            container.AddShape(triangle);
            container.AddShape(donut);

            List<string> shouldBe = new List<string>();
            shouldBe.Add("shape 1: circle with center at (1.7, -5.05) and radius 6.9");
            shouldBe.Add("shape 2: square with center at (3.55, 4.1) and side 2.77");
            shouldBe.Add("shape 3: rectangle with center at (3.5, 2) and side1 5.6, side2 7.2");
            shouldBe.Add("shape 4: triangle with coordinates at (4.5 1, -2.5 -33, 23 0.3)");
            shouldBe.Add("shape 5: donut with center at (4.5, 7.8) and radius1 1.5, radius2 1.8");

            CollectionAssert.AreEqual(shouldBe, container.GetShapeList().ToList());
        }


        [TestMethod]
        public void ShouldFindShapesThatContainsTheSpecifiedPoint()
        {
            GFTApplication.ShapesContainer container = new ShapesContainer();

            GFTApplication.Models.Circle circle = new Models.Circle(1.7f, -5.05f, 6.9f);
            GFTApplication.Models.Square square = new Models.Square(3.55f, 4.1f, 2.77f);
            GFTApplication.Models.Rectangle rectangle = new Models.Rectangle(3.5f, 2.0f, 5.6f, 7.2f);
            GFTApplication.Models.Triangle triangle = new Models.Triangle(4.5f, 1, -2.5f, -33, 23, 0.3f);
            GFTApplication.Models.Donut donut = new Models.Donut(4.5f, 7.8f, 1.5f, 1.8f);

            circle.Id = 1;
            square.Id = 2;
            rectangle.Id = 3;
            triangle.Id = 4;
            donut.Id = 5;

            container.AddShape(circle);
            container.AddShape(square);
            container.AddShape(rectangle);
            container.AddShape(triangle);
            container.AddShape(donut);

            List<string> shouldBe = new List<string>();
            shouldBe.Add("shape 1: circle with center at (1.7, -5.05) and radius 6.9 | Area: 149.571230371968");
            shouldBe.Add("shape 4: triangle with coordinates at (4.5 1, -2.5 -33, 23 0.3) | Area: 316.950012207031");
            shouldBe.Add("Total Area of shapes: 466.521242578999");

            CollectionAssert.AreEqual(shouldBe, container.FindInPoint(1.5f, -5).ToList());
        }
    }
}
