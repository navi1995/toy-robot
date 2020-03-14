﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace ToyRobot.Test
{
	[TestClass]
	public class CommandTests
	{
		// INVALID COMMANDS
		[TestMethod]
		public void Command_Invalid_NotYetPlaced()
		{
			//arrange
			Robot toy = new Robot();

			//act
			string commandResult = toy.Command("MOVE");

			//assert
			Assert.AreEqual("Robot not yet PLACED - Command discarded.", commandResult);
		}

		[TestMethod]
		public void Command_Invalid_PlaceOffTable_NegativeX()
		{
			//arrange
			Robot toy = new Robot();

			//act
			string commandResult = toy.Command("PLACE -1,0,NORTH");

			//assert
			Assert.AreEqual("Robot cannot be placed off table - Command discarded.", commandResult);
		}

		[TestMethod]
		public void Command_Invalid_PlaceOffTable_NegativeY()
		{
			//arrange
			Robot toy = new Robot();

			//act
			string commandResult = toy.Command("PLACE 0,-1,EAST");

			//assert
			Assert.AreEqual("Robot cannot be placed off table - Command discarded.", commandResult);
		}

		[TestMethod]
		public void Command_Invalid_PlaceOffTable_NegativeXAndY()
		{
			//arrange
			Robot toy = new Robot();

			//act
			string commandResult = toy.Command("PLACE -1,-1,NORTH");

			//assert
			Assert.AreEqual("Robot cannot be placed off table - Command discarded.", commandResult);
		}

		[TestMethod]
		public void Command_Invalid_PlaceOffTable_XValue()
		{
			//arrange
			Robot toy = new Robot();

			//act
			string commandResult = toy.Command("PLACE 6,1,WEST");

			//assert
			Assert.AreEqual("Robot cannot be placed off table - Command discarded.", commandResult);
		}

		[TestMethod]
		public void Command_Invalid_PlaceOffTable_YValue()
		{
			//arrange
			Robot toy = new Robot();

			//act
			string commandResult = toy.Command("PLACE 1,6,SOUTH");

			//assert
			Assert.AreEqual("Robot cannot be placed off table - Command discarded.", commandResult);
		}

		[TestMethod]
		public void Command_Invalid_PlaceOffTable_XAndYValues()
		{
			//arrange
			Robot toy = new Robot();

			//act
			string commandResult = toy.Command("PLACE 6,6,SOUTH");

			//assert
			Assert.AreEqual("Robot cannot be placed off table - Command discarded.", commandResult);
		}

		[TestMethod]
		public void Command_Invalid_RandomInput()
		{
			//arrange
			Robot toy = new Robot();

			//act
			string commandResult = toy.Command("qwerty");

			//assert
			Assert.AreEqual("Unrecognised input - Command discarded.", commandResult);
		}

		[TestMethod]
		public void Command_Invalid_IgnoreRandomInput()
		{
			//arrange
			Robot toy = new Robot();
			string commandResult;
			string expectedResult = "0,1,NORTH";

			//act
			commandResult = toy.Command("PLACE 0,0,NORTH");
			commandResult = toy.Command("qwerty");
			commandResult = toy.Command("MOVE");
			commandResult = toy.Command("REPORT");

			//assert
			Assert.AreEqual(expectedResult, commandResult);
			Assert.AreEqual(0, toy.xPos);
			Assert.AreEqual(1, toy.yPos);
		}

		//REPORT COMMANDS
		[TestMethod]
		public void Command_Report_CorrectLocation()
		{
			//arrange
			Robot toy = new Robot 
			{ 
				direction = "NORTH",
				xPos = 4,
				yPos = 3
			};
			string expectedResult = "4,3,NORTH";

			//act
			string commandResult = toy.Command("REPORT");

			//assert
			Assert.AreEqual(expectedResult, commandResult);
		}

		[TestMethod]
		public void Command_ValidCommands_PrintNothing_NoReport()
		{
			//arrange
			Robot toy = new Robot();
			string commandResult;

			//act
			commandResult = toy.Command("PLACE 0,0,NORTH");
			commandResult = toy.Command("MOVE");
			commandResult = toy.Command("MOVE");

			//assert
			Assert.AreEqual(String.Empty, commandResult);
		}

		[TestMethod]
		public void Command_ValidCommands_A()
		{
			//arrange
			Robot toy = new Robot();
			string commandResult;

			//act
			commandResult = toy.Command("PLACE 0,0,NORTH");
			commandResult = toy.Command("MOVE");
			commandResult = toy.Command("REPORT");

			//assert
			Assert.AreEqual("0,1,NORTH", commandResult);
		}

		[TestMethod]
		public void Command_ValidCommands_B()
		{
			//arrange
			Robot toy = new Robot();
			string commandResult;

			//act
			commandResult = toy.Command("PLACE 0,0,NORTH");
			commandResult = toy.Command("LEFT");
			commandResult = toy.Command("REPORT");

			//assert
			Assert.AreEqual("0,0,WEST", commandResult);
		}

		[TestMethod]
		public void Command_ValidCommands_C()
		{
			//arrange
			Robot toy = new Robot();
			string commandResult;

			//act
			commandResult = toy.Command("PLACE 1,2,EAST");
			commandResult = toy.Command("MOVE");
			commandResult = toy.Command("MOVE");
			commandResult = toy.Command("LEFT");
			commandResult = toy.Command("MOVE");
			commandResult = toy.Command("REPORT");

			//assert
			Assert.AreEqual("3,3,NORTH", commandResult);
		}

		[TestMethod]
		public void Command_PlaceAgain_OutOfBounds_ThenReport()
		{
			//arrange
			Robot toy = new Robot();
			string commandResult;

			//act
			commandResult = toy.Command("PLACE 1,2,EAST");
			commandResult = toy.Command("MOVE");
			commandResult = toy.Command("MOVE");
			commandResult = toy.Command("LEFT");
			commandResult = toy.Command("MOVE");
			commandResult = toy.Command("PLACE 6,6,EAST"); //Ignored according to PROBLEM.md
			commandResult = toy.Command("REPORT");

			//assert
			Assert.AreEqual("3,3,NORTH", commandResult);
		}
	}
}