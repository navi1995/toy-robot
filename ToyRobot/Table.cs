namespace ToyRobot
{
	/// <summary>
	/// Represents the play area for our Robot. Can be set to  any valid combination of rows/columns.
	/// </summary>
	public class Table
	{
		public int Rows;
		public int Columns;

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
			if ((x < 0 || y < 0) || (x >= this.Rows || y >= this.Columns))
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
