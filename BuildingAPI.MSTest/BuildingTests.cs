using BuildingAPI.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BuildingAPI.MSTest
{
    [TestClass]
    public class BuildingTests
    {
        [TestMethod]
        public void FloorCalculateHeight()
        {
            // Arrange
            var floor = new Floor();
            var room1 = new Room();
            var room2 = new Room();
            // Act
            floor.HeightOfCeiling = 0.5M;
            room1.Height = 2.3M;
            room2.Height = 2.1M;
            floor.Rooms.Add(room1);
            floor.Rooms.Add(room2);
            // Assert
            Assert.AreEqual(2.8M, floor.calculateHeight());
        }

        [TestMethod]
        public void BuildingCalculateHeight()
        {
            // Arrange
            var building = new Building();

            var floor1 = new Floor();
            var room11 = new Room();
            var room12 = new Room();

            var floor2 = new Floor();
            var room21 = new Room();
            var room22 = new Room();
            // Act
            floor1.HeightOfCeiling = 0.5M;
            room11.Height = 2.3M;
            room12.Height = 2.1M;
            floor1.Rooms.Add(room11);
            floor1.Rooms.Add(room12);

            floor2.HeightOfCeiling = 0.6M;
            room21.Height = 2.3M;
            room22.Height = 2.5M;
            floor2.Rooms.Add(room21);
            floor2.Rooms.Add(room22);

            building.AboveSurface = 1.2M;
            building.Floors.Add(floor1);
            building.Floors.Add(floor2);


            // Assert
            Assert.AreEqual(7.1M, building.calculateHeight());
        }


        [TestMethod]
        public void FloorCalculateSurface()
        {
            // Arrange
            var floor = new Floor();
            var room1 = new Room();
            var room2 = new Room();
            // Act
            room1.Surface = 52.3M;
            room2.Surface = 47.2M;
            floor.Rooms.Add(room1);
            floor.Rooms.Add(room2);
            // Assert
            Assert.AreEqual(99.5M, floor.calculateSurface());
        }

        [TestMethod]
        public void BuildingCalculateSurface()
        {
            // Arrange
            var building = new Building();

            var floor1 = new Floor();
            var room11 = new Room();
            var room12 = new Room();

            var floor2 = new Floor();
            var room21 = new Room();
            var room22 = new Room();
            // Act
            room11.Surface = 52.3M;
            room12.Surface = 47.2M;
            floor1.Rooms.Add(room11);
            floor1.Rooms.Add(room12);

            room21.Surface = 67.2M;
            room22.Surface = 111.2M;
            floor2.Rooms.Add(room21);
            floor2.Rooms.Add(room22);

            building.Floors.Add(floor1);
            building.Floors.Add(floor2);


            // Assert
            Assert.AreEqual(277.9M, building.calculateSurface());
        }
    }
}