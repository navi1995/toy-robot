using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobot.Test
{
	[TestClass]
	public class ReportTests
	{
		[TestMethod]
		public void Report_CorrectPosition_North()
		{
			//arrange
			Robot toy = new Robot(3, 2, Direction.NORTH);

			//act
			string reportResult = toy.Report();

			//assert
			Assert.AreEqual("3,2,NORTH", reportResult);
		}

		[TestMethod]
		public void Report_CorrectPosition_South()
		{
			//arrange
			Robot toy = new Robot(3, 2, Direction.SOUTH);

			//act
			string reportResult = toy.Report();

			//assert
			Assert.AreEqual("3,2,SOUTH", reportResult);
		}

		[TestMethod]
		public void Report_CorrectPosition_East()
		{
			//arrange
			Robot toy = new Robot(3, 4, Direction.EAST);

			//act
			string reportResult = toy.Report();

			//assert
			Assert.AreEqual("3,4,EAST", reportResult);
		}


		[TestMethod]
		public void Report_CorrectPosition_West()
		{
			//arrange
			Robot toy = new Robot(4, 2, Direction.WEST);

			//act
			string reportResult = toy.Report();

			//assert
			Assert.AreEqual("4,2,WEST", reportResult);
		}

		[TestMethod]
		public void Report_CorrectPosition_ThenPlaceAgain()
		{
			//arrange
			Robot toy = new Robot(3, 2, Direction.SOUTH);
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
				Direction = Direction.SOUTH,
				Position = new Position(6, 2)
			};

			//act
			string reportResult = toy.Report();

			//assert
			Assert.AreEqual(string.Empty, reportResult);
		}
	}
}
