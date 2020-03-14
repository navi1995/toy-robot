using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace ToyRobot.Test
{
	[TestClass]
	public class ReportTests
	{
		[TestMethod]
		public void Report_CorrectPosition_North()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "NORTH",
				xPos = 3,
				yPos = 2
			};

			//act
			string reportResult = toy.Report();

			//assert
			Assert.AreEqual("3,2,NORTH", reportResult);
		}

		[TestMethod]
		public void Report_CorrectPosition_South()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "SOUTH",
				xPos = 3,
				yPos = 2
			};

			//act
			string reportResult = toy.Report();

			//assert
			Assert.AreEqual("3,2,SOUTH", reportResult);
		}

		[TestMethod]
		public void Report_CorrectPosition_ThenPlaceAgain()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "SOUTH",
				xPos = 3,
				yPos = 2
			};
			string reportResult;

			//act
			reportResult = toy.Report();

			//assert
			Assert.AreEqual("3,2,SOUTH", reportResult);

			//act
			toy.Place("1,4,NORTH");
			reportResult = toy.Report();

			//assert
			Assert.AreEqual("1,4,NORTH", reportResult);
		}

		//According to PROBLEM.md a robot that is not on the table can choose to ignore commands.
		[TestMethod]
		public void Report_OutOfBounds_DoNotRespond()
		{
			//arrange
			Robot toy = new Robot
			{
				direction = "SOUTH",
				xPos = 6,
				yPos = 2
			};

			//act
			string reportResult = toy.Report();

			//assert
			Assert.AreEqual(string.Empty, reportResult);
		}
	}
}
