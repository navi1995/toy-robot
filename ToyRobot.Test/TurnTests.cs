using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace ToyRobot.Test
{
	[TestClass]
	public class TurnTests
	{
		[TestMethod]
		public void Turn_Left_StartingNorth()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "NORTH",
				xPos = 0,
				yPos = 0
			};

			//act
			toy.TurnLeft(); //Direction = WEST

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual("WEST", toy.direction);
		}

		[TestMethod]
		public void Turn_Right_StartingNorth()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "NORTH",
				xPos = 0,
				yPos = 0
			};

			//act
			toy.TurnRight(); //Direction = EAST

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual("EAST", toy.direction);
		}

		[TestMethod]
		public void Turn_Left_StartingEast()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "EAST",
				xPos = 0,
				yPos = 0
			};

			//act
			toy.TurnLeft(); //Direction = NORTH

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual("NORTH", toy.direction);
		}

		[TestMethod]
		public void Turn_Right_StartingEast()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "EAST",
				xPos = 0,
				yPos = 0
			};

			//act
			toy.TurnRight(); //Direction = SOUTH

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual("SOUTH", toy.direction);
		}

		[TestMethod]
		public void Turn_Left_StartingSouth()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "SOUTH",
				xPos = 0,
				yPos = 0
			};

			//act
			toy.TurnLeft(); //Direction = EAST

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual("EAST", toy.direction);
		}

		[TestMethod]
		public void Turn_Right_StartingSouth()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "SOUTH",
				xPos = 0,
				yPos = 0
			};

			//act
			toy.TurnRight(); //Direction = WEST

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual("WEST", toy.direction);
		}

		[TestMethod]
		public void Turn_Left_StartingWest()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "WEST",
				xPos = 0,
				yPos = 0
			};

			//act
			toy.TurnLeft(); //Direction = SOUTH

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual("SOUTH", toy.direction);
		}

		[TestMethod]
		public void Turn_Right_StartingWest()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "WEST",
				xPos = 0,
				yPos = 0
			};

			//act
			toy.TurnRight(); //Direction = NORTH

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual("NORTH", toy.direction);
		}

		[TestMethod]
		public void Turn_Right_TwoTimes_StartingNorth()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "NORTH",
				xPos = 0,
				yPos = 0
			};

			//act
			toy.TurnRight(); //Direction = EAST
			toy.TurnRight(); //Direction = SOUTH

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual("SOUTH", toy.direction);
		}

		[TestMethod]
		public void Turn_Right_ThreeTimes_StartingNorth()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "NORTH",
				xPos = 0,
				yPos = 0
			};

			//act
			toy.TurnRight(); //Direction = EAST
			toy.TurnRight(); //Direction = SOUTH
			toy.TurnRight(); //Direction = WEST

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual("WEST", toy.direction);
		}

		[TestMethod]
		public void Turn_Right_FourTimes_StartingNorth()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "NORTH",
				xPos = 0,
				yPos = 0
			};

			//act
			toy.TurnRight(); //Direction = EAST
			toy.TurnRight(); //Direction = SOUTH
			toy.TurnRight(); //Direction = WEST
			toy.TurnRight(); //Direction = NORTH

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual("NORTH", toy.direction);
		}

		[TestMethod]
		public void Turn_Right_FiveTimes_StartingNorth()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "NORTH",
				xPos = 0,
				yPos = 0
			};

			//act
			toy.TurnRight(); //Direction = EAST
			toy.TurnRight(); //Direction = SOUTH
			toy.TurnRight(); //Direction = WEST
			toy.TurnRight(); //Direction = NORTH
			toy.TurnRight(); //Direction = EAST

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual("EAST", toy.direction);
		}

		[TestMethod]
		public void Turn_Right_TwoTimes_StartingNorth_ThenLeft_OneTimes()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "NORTH",
				xPos = 0,
				yPos = 0
			};

			//act
			toy.TurnRight(); //Direction = EAST
			toy.TurnRight(); //Direction = SOUTH
			toy.TurnLeft(); //Direction = EAST

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual("EAST", toy.direction);
		}

		[TestMethod]
		public void Turn_Right_TwoTimes_StartingNorth_ThenLeft_TwoTimes()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "NORTH",
				xPos = 0,
				yPos = 0
			};

			//act
			toy.TurnRight(); //Direction = EAST
			toy.TurnRight(); //Direction = SOUTH
			toy.TurnLeft(); //Direction = EAST
			toy.TurnLeft(); //Direction = NORTH

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual("NORTH", toy.direction);
		}

		[TestMethod]
		public void Turn_SporadicTurning_StartingNorth()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "NORTH",
				xPos = 0,
				yPos = 0
			};

			//act
			toy.TurnRight(); //Direction = EAST
			toy.TurnRight(); //Direction = SOUTH
			toy.TurnLeft(); //Direction = EAST
			toy.TurnRight(); //Direction = SOUTH
			toy.TurnLeft(); //Direction = EAST
			toy.TurnRight(); //Direction = SOUTH
			toy.TurnRight(); //Direction = WEST

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual("WEST", toy.direction);
		}
	}
}
