namespace OOPGame
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using OOPGame.GameInterfaces;
	using OOPGame.GameStructure;

	public static class Field //: IDrawable
	{
		// Fields.
		private const int width = Constants.WindowWidth;
		private const int height = Constants.WindowHeight;
		private const int screenUpperBorder = Constants.ScreenUpperBorder;

		// Methods.
		public static void InitialiseSettings()
		{
			Console.CursorVisible = false;
			Console.WindowWidth = width;
			Console.WindowHeight = height;
			Console.BufferWidth = width;
			Console.BufferHeight = height;

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
		}
	}
}