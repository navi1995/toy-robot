namespace ToyRobot
{
	/// <summary>
	/// Represents the play area for our Robot. Can be set to  any valid combination of rows/columns.
	/// </summary>
	public class Table
	{
		public int Rows { get; private set; }
		public int Columns { get; private set; }

		public Table(int rows, int columns)
		{
			Rows = rows;
			Columns = columns;
		}

		/// <summary>
		/// Checks if coordinates provided would be within the play area of the table.
		/// </summary>
		/// <param name="x">X Coordinate</param>
		/// <param name="y">Y Coordinate</param>
		/// <returns></returns>
		public bool IsValidPosition(int x, int y)
		{
			return x >= 0 && x < Rows && y >= 0 && y < Columns;
		}
	}
}
