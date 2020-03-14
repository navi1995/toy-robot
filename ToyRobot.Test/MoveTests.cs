using Microsoft.VisualStudio.TestTools.UnitTesting;

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
				Direction = Direction.NORTH,
				X = 0,
				Y = 0
			};

			//act
			toy.Move();
			toy.Move();
			toy.Move();

			//assert
			Assert.AreEqual(0, toy.X);
			Assert.AreEqual(3, toy.Y);
			Assert.AreEqual(Direction.NORTH, toy.Direction);
		}

		[TestMethod]
		public void Move_North_FiveSteps()
		{
			//arrange
			Robot toy = new Robot
			{
				Direction = Direction.NORTH,
				X = 0,
				Y = 0
			};

			//act
			toy.Move();
			toy.Move();
			toy.Move();
			toy.Move();
			toy.Move(); //This move should not actually increment position since it would place the robot off the board.

			//assert
			Assert.AreEqual(0, toy.X);
			Assert.AreEqual(4, toy.Y);
			Assert.AreEqual(Direction.NORTH, toy.Direction);
		}

		[TestMethod]
		public void Move_South_ThreeSteps()
		{
			//arrange
			Robot toy = new Robot
			{
				Direction = Direction.SOUTH,
				X = 0,
				Y = 4
			};

			//act
			toy.Move();
			toy.Move();
			toy.Move();

			//assert
			Assert.AreEqual(0, toy.X);
			Assert.AreEqual(1, toy.Y);
			Assert.AreEqual(Direction.SOUTH, toy.Direction);
		}

		[TestMethod]
		public void Move_South_FiveSteps()
		{
			//arrange
			Robot toy = new Robot
			{
				Direction = Direction.SOUTH,
				X = 0,
				Y = 4
			};

			//act
			toy.Move();
			toy.Move();
			toy.Move();
			toy.Move();
			toy.Move(); //This move should not actually increment position since it would place the robot off the board.

			//assert
			Assert.AreEqual(0, toy.X);
			Assert.AreEqual(0, toy.Y);
			Assert.AreEqual(Direction.SOUTH, toy.Direction);
		}

		[TestMethod]
		public void Move_East_ThreeSteps()
		{
			//arrange
			Robot toy = new Robot
			{
				Direction = Direction.EAST,
				X = 0,
				Y = 0
			};

			//act
			toy.Move();
			toy.Move();
			toy.Move();

			//assert
			Assert.AreEqual(3, toy.X);
			Assert.AreEqual(0, toy.Y);
			Assert.AreEqual(Direction.EAST, toy.Direction);
		}

		[TestMethod]
		public void Move_East_FiveSteps()
		{
			//arrange
			Robot toy = new Robot 
			{
				Direction = Direction.EAST,
				X = 0,
				Y = 0
			};

			//act
			toy.Move();
			toy.Move();
			toy.Move();
			toy.Move();
			toy.Move(); //This move should not actually increment position since it would place the robot off the board.

			//assert
			Assert.AreEqual(4, toy.X);
			Assert.AreEqual(0, toy.Y);
			Assert.AreEqual(Direction.EAST, toy.Direction);
		}

		[TestMethod]
		public void Move_West_ThreeSteps()
		{
			//arrange
			Robot toy = new Robot
			{
				Direction = Direction.WEST,
				X = 4,
				Y = 0
			};

			//act
			toy.Move();
			toy.Move();
			toy.Move();

			//assert
			Assert.AreEqual(1, toy.X);
			Assert.AreEqual(0, toy.Y);
			Assert.AreEqual(Direction.WEST, toy.Direction);
		}

		[TestMethod]
		public void Move_West_FiveSteps()
		{
			//arrange
			Robot toy = new Robot
			{
				Direction = Direction.WEST,
				X = 4,
				Y = 0
			};

			//act
			toy.Move();
			toy.Move();
			toy.Move();
			toy.Move();
			toy.Move(); //This move should not actually increment position since it would place the robot off the board.

			//assert
			Assert.AreEqual(0, toy.X);
			Assert.AreEqual(0, toy.Y);
			Assert.AreEqual(Direction.WEST, toy.Direction);
		}

		[TestMethod]
		public void Move_ThreeWest_ThenTurnRight_MoveTwo_Valid()
		{
			//arrange
			Robot toy = new Robot
			{
				Direction = Direction.WEST,
				X = 4,
				Y = 0
			};

			//act
			toy.Move(); //3,0
			toy.Move(); //2,0
			toy.Move(); //1,0
			toy.TurnRight(); //Direction = NORTH
			toy.Move(); //1,1
			toy.Move(); //1,2

			//assert
			Assert.AreEqual(1, toy.X);
			Assert.AreEqual(2, toy.Y);
			Assert.AreEqual(Direction.NORTH, toy.Direction);
		}

		[TestMethod]
		public void Move_ThreeWest_ThenTurnLeft_MoveTwo_OutOfBounds()
		{
			//arrange
			Robot toy = new Robot
			{
				Direction = Direction.WEST,
				X = 4,
				Y = 0
			};

			//act
			toy.Move(); //3,0
			toy.Move(); //2,0
			toy.Move(); //1,0
			toy.TurnLeft(); //Direction = SOUTH
			toy.Move(); //1,0 - Movement will not proceed
			toy.Move(); //1,0 - Movement will not proceed

			//assert
			Assert.AreEqual(1, toy.X);
			Assert.AreEqual(0, toy.Y);
			Assert.AreEqual(Direction.SOUTH, toy.Direction);
		}



		[TestMethod]
		public void Move_ThreeWest_ThenTurnRight_MoveSix_OutOfBounds()
		{
			//arrange
			Robot toy = new Robot
			{
				Direction = Direction.WEST,
				X = 4,
				Y = 0
			};

			//act
			toy.Move(); //3,0
			toy.Move(); //2,0
			toy.Move(); //1,0
			toy.TurnRight(); //Direction = NORTH
			toy.Move(); //1,1
			toy.Move(); //1,2
			toy.Move(); //1,3
			toy.Move(); //1,4
			toy.Move(); //1,4 - Movement will not proceed
			toy.Move(); //1,4 - Movement will not proceed


			//assert
			Assert.AreEqual(1, toy.X);
			Assert.AreEqual(4, toy.Y);
			Assert.AreEqual(Direction.NORTH, toy.Direction);
		}
	}
}
