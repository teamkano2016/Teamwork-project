namespace OOPGame.GameStructure
{
	using System;
    using Items;
	public struct Field
	{
		// Fields.
		private const int width = Constants.WindowWidth;
		private const int height = Constants.WindowHeight;
		private const int screenUpperBorder = Constants.ScreenUpperBorder;
        private static ExitPointItem exitPoint = new ExitPointItem();
		//private const string exitPoint = Constants.ExitPoint;

		// Property
		public static ExitPointItem ExitPoint { get { return exitPoint; } }

		// Methods.
		public static void InitialiseSettings()
		{
			Console.CursorVisible = false;
			Console.WindowWidth = width;
			Console.WindowHeight = height;
			Console.BufferWidth = width;
			Console.BufferHeight = height;
            //Engine.PrintOnPosition(height - 5, width - 1, exitPoint, ConsoleColor.Blue);
            Engine.Draw(exitPoint);
			PrintFieldBorders();
		}

		private static void PrintFieldBorders()
		{
			for (int row = 1; row < height - 3; row++)
			{
				for (int col = 0; col < width; col++)
				{
					if (row == 1)
					{
						Engine.PrintOnPosition(row, col, Constants.UpBorder, Constants.BorderColor);
					}
					else if (col == 0)
					{
						Engine.PrintOnPosition(row, col, Constants.LeftBorder, Constants.BorderColor);
					}
					else if (row == height - 4)
					{
						Engine.PrintOnPosition(row, col, Constants.DownBorder, Constants.BorderColor);
					}
				}
			}
		}

		public static void UpdateField()
		{
			// Update items so bullets don't clear them
			foreach (var potion in GameObjects.Potions)
			{
				Engine.Draw(potion);
			}
            Engine.Draw(exitPoint);
        }
	}
}