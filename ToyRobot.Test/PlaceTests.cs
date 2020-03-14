using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobot.Test
{
	[TestClass]
	public class PlaceTests
	{
		[TestMethod]
		public void Place_InBounds()
		{
			//arrange
			Robot toy = new Robot();
			string reportResult;

			//act
			toy.Place("1,4,NORTH");
			reportResult = toy.Report();

			//assert
			Assert.AreEqual("1,4,NORTH", reportResult);
			Assert.AreEqual(1, toy.Position.X);
			Assert.AreEqual(4, toy.Position.Y);
			Assert.AreEqual(Direction.NORTH, toy.Direction);
		}

		[TestMethod]
		public void Place_OutOfBounds()
		{
			//arrange
			Robot toy = new Robot();
			string reportResult;

			//act
			toy.Place("6,4,NORTH");
			reportResult = toy.Report();

			//assert
			Assert.AreEqual(String.Empty, reportResult);
		}

		[TestMethod]
		public void Place_InBounds_ThenOutOfBounds()
		{
			//arrange
			Robot toy = new Robot();
			string reportResult;

			//act
			toy.Place("1,4,NORTH");
			reportResult = toy.Report();

			//assert
			Assert.AreEqual("1,4,NORTH", reportResult);
			Assert.AreEqual(1, toy.Position.X);
			Assert.AreEqual(4, toy.Position.Y);
			Assert.AreEqual(Direction.NORTH, toy.Direction);

			//act
			toy.Place("6,6,NORTH"); //Should be ignored since out of bounds.
			reportResult = toy.Report();

			//assert
			Assert.AreEqual("1,4,NORTH", reportResult);
			Assert.AreEqual(1, toy.Position.X);
			Assert.AreEqual(4, toy.Position.Y);
			Assert.AreEqual(Direction.NORTH, toy.Direction);
		}
	}
}
