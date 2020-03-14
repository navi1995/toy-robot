using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace ToyRobot.Test
{
	[TestClass]
	public class MoveTests
	{
		[TestMethod]
		public void Move_North_ThreeSteps()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = Direction.NORTH,
				xPos = 0,
				yPos = 0
			};

			//act
			toy.Move();
			toy.Move();
			toy.Move();

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(3, toy.yPos);
			Assert.AreEqual(Direction.NORTH, toy.direction);
		}

		[TestMethod]
		public void Move_North_FiveSteps()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = Direction.NORTH,
				xPos = 0,
				yPos = 0
			};

			//act
			toy.Move();
			toy.Move();
			toy.Move();
			toy.Move();
			toy.Move(); //This move should not actually increment position since it would place the robot off the board.

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(4, toy.yPos);
			Assert.AreEqual(Direction.NORTH, toy.direction);
		}

		[TestMethod]
		public void Move_South_ThreeSteps()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = Direction.SOUTH,
				xPos = 0,
				yPos = 4
			};

			//act
			toy.Move();
			toy.Move();
			toy.Move();

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(1, toy.yPos);
			Assert.AreEqual(Direction.SOUTH, toy.direction);
		}

		[TestMethod]
		public void Move_South_FiveSteps()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = Direction.SOUTH,
				xPos = 0,
				yPos = 4
			};

			//act
			toy.Move();
			toy.Move();
			toy.Move();
			toy.Move();
			toy.Move(); //This move should not actually increment position since it would place the robot off the board.

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual(Direction.SOUTH, toy.direction);
		}

		[TestMethod]
		public void Move_East_ThreeSteps()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = Direction.EAST,
				xPos = 0,
				yPos = 0
			};

			//act
			toy.Move();
			toy.Move();
			toy.Move();

			//assert
			Assert.AreEqual(3, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual(Direction.EAST, toy.direction);
		}

		[TestMethod]
		public void Move_East_FiveSteps()
		{
			//arrange
			Robot toy = new Robot 
			{
				direction = Direction.EAST,
				xPos = 0,
				yPos = 0
			};

			//act
			toy.Move();
			toy.Move();
			toy.Move();
			toy.Move();
			toy.Move(); //This move should not actually increment position since it would place the robot off the board.

			//assert
			Assert.AreEqual(4, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual(Direction.EAST, toy.direction);
		}

		[TestMethod]
		public void Move_West_ThreeSteps()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = Direction.WEST,
				xPos = 4,
				yPos = 0
			};

			//act
			toy.Move();
			toy.Move();
			toy.Move();

			//assert
			Assert.AreEqual(1, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual(Direction.WEST, toy.direction);
		}

		[TestMethod]
		public void Move_West_FiveSteps()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = Direction.WEST,
				xPos = 4,
				yPos = 0
			};

			//act
			toy.Move();
			toy.Move();
			toy.Move();
			toy.Move();
			toy.Move(); //This move should not actually increment position since it would place the robot off the board.

			//assert
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual(Direction.WEST, toy.direction);
		}

		[TestMethod]
		public void Move_ThreeWest_ThenTurnRight_MoveTwo_Valid()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = Direction.WEST,
				xPos = 4,
				yPos = 0
			};

			//act
			toy.Move(); //3,0
			toy.Move(); //2,0
			toy.Move(); //1,0
			toy.TurnRight(); //direction = NORTH
			toy.Move(); //1,1
			toy.Move(); //1,2

			//assert
			Assert.AreEqual(1, toy.xPos);
			Assert.AreEqual(2, toy.yPos);
			Assert.AreEqual(Direction.NORTH, toy.direction);
		}

		[TestMethod]
		public void Move_ThreeWest_ThenTurnLeft_MoveTwo_OutOfBounds()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = Direction.WEST,
				xPos = 4,
				yPos = 0
			};

			//act
			toy.Move(); //3,0
			toy.Move(); //2,0
			toy.Move(); //1,0
			toy.TurnLeft(); //direction = SOUTH
			toy.Move(); //1,0 - Movement will not proceed
			toy.Move(); //1,0 - Movement will not proceed

			//assert
			Assert.AreEqual(1, toy.xPos);
			Assert.AreEqual(0, toy.yPos);
			Assert.AreEqual(Direction.SOUTH, toy.direction);
		}



		[TestMethod]
		public void Move_ThreeWest_ThenTurnRight_MoveSix_OutOfBounds()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = Direction.WEST,
				xPos = 4,
				yPos = 0
			};

			//act
			toy.Move(); //3,0
			toy.Move(); //2,0
			toy.Move(); //1,0
			toy.TurnRight(); //direction = NORTH
			toy.Move(); //1,1
			toy.Move(); //1,2
			toy.Move(); //1,3
			toy.Move(); //1,4
			toy.Move(); //1,4 - Movement will not proceed
			toy.Move(); //1,4 - Movement will not proceed


			//assert
			Assert.AreEqual(1, toy.xPos);
			Assert.AreEqual(4, toy.yPos);
			Assert.AreEqual(Direction.NORTH, toy.direction);
		}
	}
}
