# Toy Robot Simulator
This is a C# Console application which simulates a toy robot moving on a 5 x 5 square tabletop. Movements are driven by user input, 
however any commands that would lead to the robot falling off the play area are discarded. In this implementation 0,0 coordinates are assumed to be the SOUTH WEST most corner.

The square tabletop can be visualised as below:
| 0,4  | 1,4 | 2,4  | 3,4 | 4,4 |
| ---- | ---- | ---- | --- | --- |
| 0,3  | 1,3  | 2,3  | 3,3  | 4,3  | 
| 0,2  | 1,2  | 2,2  | 3,2  | 4,2  | 
| 0,1  | 1,1  | 2,1  | 3,1  | 4,1  | 
| 0,0  | 1,0  | 2,0  | 3,0  | 4,0  | 

## Approach

### Commands
Commands are NOT case sensitive. The Console will accept the following commands as valid:
- PLACE X,Y,F where X and Y are coordinates on the table and F is a direction (NORTH,EAST,SOUTH,WEST)
- MOVE: This will move the Robot one unit forward in whichever direction it was facing
- LEFT: This will rotate the Robot 90 degrees to the left
- RIGHT: This will rotate the Robot 90 degrees to the right
- REPORT: This will print the current status of the Robot in the format: X,Y,F e.g 0,1,NORTH

The FIRST command user enters should be a PLACE command. No other commands will be considered valid until the Robot has been PLACED!
### Running Application
The application can be run from the executable file found here: [ToyRobot.exe](https://github.com/navi1995/toy-robot/blob/master/ToyRobot/bin/Debug/ToyRobot.exe)

Running this will open a command prompt, ensure the first command ran is a PLACE command.

### Testing and Development
This application was developed using TDD fundamentals where [unit tests](https://github.com/navi1995/toy-robot/tree/master/ToyRobot.Test) were created before
core development of the application began. 
OOP principles were also followed primarily through the usage of Classes and Encapsulation. 

In the context of this application our primary functionality revolves around the Robot class.

The Robot Class has the following attributes:
- Position (Class which represents X and Y coordinates of the Robot on the Table): PUBLIC
- Direction (Enum which represents all cardinal directions NORTH, EAST, SOUTH and WEST): PUBLIC
- TableTop (Class which represents the table area that the Robot can move on)
- Placed (Represents whether Robot has been PLACED onto the Table using PLACE command)

Commands are passed through to the Robot class to be handled, which will then return a string if required to be displayed to the user.

### Notes
The following online resources and documentation was used to follow TDD fundamentals and for creating my unit tests due to limited exposure:
- https://docs.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019
- https://www.pluralsight.com/tech-blog/test-driven-development-fundamentals/
