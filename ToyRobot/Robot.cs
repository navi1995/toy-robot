using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
	public class Robot
	{
		//ERROR MESSAGES
		public const string NOT_PLACED_ERROR = "Robot has not yet been placed - Command Discarded.";
		public const string ROBOT_OUT_OF_BOUNDS = "Command would result in Robot falling off table - Command Discarded.";
		public const string INVALID_COMMAND = "Invalid command. Please follow correct formatting - Command Discarded";
		//Robot attributes
		public int xPos = -1;
		public int yPos = -1;
		public Direction direction = Direction.NORTH;
		private bool placed = false;
		private Table tableTop = new Table(5, 5);

		public Robot() { }

		public Robot(int x, int y, Direction direction)
		{
			xPos = x;
			yPos = y;
			this.direction = direction;

			if (tableTop.IsValidPosition(x, y))
			{
				placed = true;
			}
		}

		/// <summary>
		/// Processes commands that the user has entered. If return value is not empty or null, this means an error has occured or REPORT command was run.
		/// </summary>
		/// <param name="input">Value user enters in console. Valid commands are as follows: PLACE X,Y,F (E.g PLACE 0,0,NORTH), MOVE, LEFT, RIGHT, REPORT</param>
		/// <returns>String to be displayed to user, either an error has occured or the user requested a REPORT.</returns>
		public string Command(string input)
		{
			string userCommand = input.ToUpper().Trim();
			string responseMessage = "";

			//Explicitly doing this here rather than in an else so that NOT_PLACED_ERROR doesnt occur if user starts off with incorrect input.
			if (!(userCommand.Contains("PLACE") || userCommand == "MOVE" || userCommand == "RIGHT" || userCommand == "LEFT" || userCommand == "REPORT"))
			{
				responseMessage = INVALID_COMMAND;
			} 
			else if (userCommand.Contains("PLACE"))
			{
				responseMessage = Place(userCommand.Replace("PLACE", "").Trim());
			}
			else if (!placed)
			{
				responseMessage = NOT_PLACED_ERROR;
			} 
			else if (userCommand == "MOVE")
			{
				responseMessage = Move();
			}
			else if (userCommand == "RIGHT")
			{
				TurnRight();
			}
			else if (userCommand == "LEFT")
			{
				TurnLeft();
			} 
			else if (userCommand == "REPORT")
			{
				responseMessage = Report();
			}

			return responseMessage;
		}

		/// <summary>
		/// Places the Robot onto the tabletop using input the user provides. If return value is not empty or null, then an error has occured.
		/// </summary>
		/// <param name="placeCommand">Expects string input in form X,Y,F, these are then associated to the relevant attributes</param>
		/// <returns>Error message to be displayed to user.</returns>
		public string Place(string placeCommand)
		{
			string responseMessage = "";
			string[] splitCommand = placeCommand.Split(',');
			int extractedX;
			int extractedY;
			Direction extractedDirection;

			//Checks if command is valid by trying to parse values the user has entered. 
			//Improvement here could be to present a specific message to user e.g you entered incorrect X value or incorrect direction etc.
			if (splitCommand.Length != 3 
				|| (!int.TryParse(splitCommand[0], out extractedX) || !int.TryParse(splitCommand[1], out extractedY)) 
				|| !Enum.TryParse<Direction>(splitCommand[2], out extractedDirection))
			{
				responseMessage = INVALID_COMMAND;
			}
			else if (!tableTop.IsValidPosition(extractedX, extractedY))
			{
				responseMessage = ROBOT_OUT_OF_BOUNDS;
			} 
			else
			{
				xPos = extractedX;
				yPos = extractedY;
				direction = extractedDirection;
				placed = true;
			}

			return responseMessage;
		}

		/// <summary>
		/// Moves robot forward in whichever direction it was facing. If movement would put the robot out of bounds of the playing area, command is ignored.
		/// </summary>
		/// <returns>Error message to be displayed to user if Robot would be out of bounds.</returns>
		public string Move()
		{
			int x = xPos;
			int y = yPos;
			string responseMessage = "";

			switch (direction)
			{
				case Direction.NORTH:
					y++;
					break;
				case Direction.EAST:
					x++;
					break;
				case Direction.SOUTH:
					y--;
					break;
				case Direction.WEST:
					x--;
					break;
			}

			if (tableTop.IsValidPosition(x, y))
			{
				xPos = x;
				yPos = y;
			} 
			else
			{
				responseMessage = ROBOT_OUT_OF_BOUNDS;
			}

			return responseMessage;
		}

		/// <summary>
		/// Returns string with current position and direction of Robot in form X,Y,F
		/// </summary>
		/// <returns>String with current position and direction of Robot in form X,Y,F</returns>
		public string Report()
		{
			//Return empty string if robot not yet placed.
			return  placed ? xPos + "," + yPos + "," + direction : "";
		}

		/// <summary>
		/// Turns Robot 90 degrees right.
		/// </summary>
		public void TurnRight()
		{
			Turn("RIGHT");
		}

		/// <summary>
		/// Turns Robot 90 degrees left.
		/// </summary>
		public void TurnLeft()
		{
			Turn("LEFT");
		}

		private void Turn(string turnDirection)
		{
			switch (direction)
			{
				case Direction.NORTH:
					direction = turnDirection == "RIGHT" ? Direction.EAST : Direction.WEST;
					break;
				case Direction.EAST:
					direction = turnDirection == "RIGHT" ? Direction.SOUTH : Direction.NORTH;
					break;
				case Direction.SOUTH:
					direction = turnDirection == "RIGHT" ? Direction.WEST : Direction.EAST;
					break;
				case Direction.WEST:
					direction = turnDirection == "RIGHT" ? Direction.NORTH : Direction.SOUTH;
					break;
			}
		}
	}

	public class Table
	{
		public int tableX { get; set; }
		public int tableY { get; set; }


		public Table(int x, int y)
		{
			tableX = x;
			tableY = y;
		}

		/// <summary>
		/// Checks if coordinates provided would be within the play area of the table.
		/// </summary>
		/// <param name="x">X Coordinate</param>
		/// <param name="y">Y Coordinate</param>
		/// <returns></returns>
		public bool IsValidPosition(int x, int y)
		{
			if ((x < 0 || y < 0) || (x >= this.tableX || y >= this.tableY))
			{
				return false;
			} 
			else
			{
				return true;
			}
		}
	}

	public enum Direction
	{
		NORTH,
		EAST,
		SOUTH,
		WEST
	}
}
