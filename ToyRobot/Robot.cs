﻿using System;

namespace ToyRobot
{
	public class Robot
	{
		//ERROR MESSAGES
		public const string NOT_PLACED_ERROR = "Robot has not yet been placed - Command Discarded.";
		public const string ROBOT_OUT_OF_BOUNDS = "Command would result in Robot falling off table - Command Discarded.";
		public const string INVALID_COMMAND = "Invalid command. Please follow correct formatting - Command Discarded";
		public const string INVALID_COMMAND_DIRECTION = "Invalid direction. Please use NORTH, SOUTH, EAST or WEST. - Command Discarded";

		//Robot attributes : TODO: change x/y to a Class of Position.
		public Position Position { get; set; }
		public Direction Direction { get; set; }
		private bool Placed = false;
		private Table TableTop = new Table(5, 5);

		public Robot() {
			Position = new Position(-1, -1);
			Direction = Direction.NORTH;
		}

		public Robot(int x, int y, Direction direction)
		{
			Direction = direction;
			Position = new Position(x, y);

			//Constructor used by tests, if position is valid then assume robot has already been placed.
			if (TableTop.IsValidPosition(x, y))
			{
				Placed = true;
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

			//Explicitly doing this here rather than in at the end as this error message should take priority. 
			if (!(userCommand.Contains("PLACE") || userCommand == "MOVE" || userCommand == "RIGHT" || userCommand == "LEFT" || userCommand == "REPORT"))
			{
				responseMessage = INVALID_COMMAND;
			} 
			else if (userCommand.Contains("PLACE"))
			{
				responseMessage = Place(userCommand.Replace("PLACE", "").Trim());
			}
			else if (!Placed)
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
		/// <param name="placeCommand">Expects string input in form "X,Y,F", these are then associated to the relevant attributes</param>
		/// <returns>Error message to be displayed to user.</returns>
		public string Place(string placeCommand)
		{
			string responseMessage = "";
			string[] splitCommand = placeCommand.Split(',');
			int extractedX, extractedY;
			Direction extractedDirection;

			//Checks if command is valid by trying to parse values the user has entered. 
			//Improvement here could be to present a specific message to user e.g you entered incorrect X value or incorrect direction etc.
			if (splitCommand.Length != 3  || (!int.TryParse(splitCommand[0], out extractedX) || !int.TryParse(splitCommand[1], out extractedY)))
			{
				responseMessage = INVALID_COMMAND;
			}
			else if (!Enum.TryParse<Direction>(splitCommand[2].ToUpper(), out extractedDirection))
			{
				responseMessage = INVALID_COMMAND_DIRECTION;
			}
			else if (!TableTop.IsValidPosition(extractedX, extractedY))
			{
				responseMessage = ROBOT_OUT_OF_BOUNDS;
			} 
			else
			{
				Position = new Position(extractedX, extractedY);
				Direction = extractedDirection;
				Placed = true;
			}

			return responseMessage;
		}

		/// <summary>
		/// Moves robot forward in whichever direction it was facing. If movement would put the robot out of bounds of the playing area, command is ignored.
		/// </summary>
		/// <returns>Error message to be displayed to user if Robot would be out of bounds.</returns>
		public string Move()
		{
			int x = Position.X;
			int y = Position.Y;
			string responseMessage = "";

			switch (Direction)
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

			//We only update robots position if coordinates are in the table top.
			if (TableTop.IsValidPosition(x, y))
			{
				Position = new Position(x, y);
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
			return  Placed ? Position.X + "," + Position.Y + "," + Direction : "";
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

		//Set new direction of the Robot depending on what the current direction is.
		private void Turn(string turnDirection)
		{
			switch (Direction)
			{
				case Direction.NORTH:
					Direction = turnDirection == "RIGHT" ? Direction.EAST : Direction.WEST;
					break;
				case Direction.EAST:
					Direction = turnDirection == "RIGHT" ? Direction.SOUTH : Direction.NORTH;
					break;
				case Direction.SOUTH:
					Direction = turnDirection == "RIGHT" ? Direction.WEST : Direction.EAST;
					break;
				case Direction.WEST:
					Direction = turnDirection == "RIGHT" ? Direction.NORTH : Direction.SOUTH;
					break;
			}
		}
	}
}