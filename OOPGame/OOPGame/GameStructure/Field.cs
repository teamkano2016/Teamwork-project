namespace OOPGame
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using OOPGame.GameInterfaces;
	using OOPGame.GameStructure;

	public struct Field //: IDrawable
    {
        // Fields.
        private const int width = Constants.windowWidth;
        private const int height = Constants.windowHeight;
        private const int screenUpperBorder = Constants.screenUpperBorder;
        private const string ExitPoint = Constants.ExitPoint;

		public Field(ScoreBoard scoreBoard)
		{
			this.Scores = scoreBoard;
		}

		public ScoreBoard Scores { get; set; }

		// Methods.
		private void InitializeScoreBoard()
		{
			Console.SetCursorPosition(0, 0);
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine(this.Scores.ToString());
		}

		public void InitialiseSettings()
        {
			InitializeScoreBoard();
            Console.WindowWidth = width;
            Console.WindowHeight = height;
            Console.BufferWidth = width;
            Console.BufferHeight = height;
            PrintOnPosition(screenUpperBorder, width - 1, ExitPoint, ConsoleColor.Blue);
            Console.CursorVisible = false;
        }
        // Draw exit point of the game.
        public void PrintOnPosition(int row, int col, string text, ConsoleColor color)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }
    }
}