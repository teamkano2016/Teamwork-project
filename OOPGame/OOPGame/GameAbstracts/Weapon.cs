namespace OOPGame
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using OOPGame.GameInterfaces;
	using OOPGame.GameObject;
	using OOPGame.GameStructure;

	public abstract class Weapon : IGameObject
	{
		// Fields.

		// Constructor.
		public Weapon(int row, int col, string figure, ConsoleColor color)
		{
			this.Row = row;
			this.Col = col;
			this.Figure = figure;
			this.Color = color;
			this.Bullets = new List<Bullet>();
		}

		public int Row { get; set; }

		public int Col { get; set; }

		public string Figure { get; set; }

		public ConsoleColor Color { get; set; }

		public IList<Bullet> Bullets { get; set; }

		public void Move(ConsoleKey userInput)
		{
			if (userInput == ConsoleKey.LeftArrow && this.Col > 2)
			{
				this.Col--;
			}
			else if (userInput == ConsoleKey.RightArrow && this.Col < Constants.WindowWidth - 2)
			{
				this.Col++;
			}
			else if (userInput == ConsoleKey.UpArrow && this.Row > Constants.ScreenUpperBorder + 1)
			{
				this.Row--;
			}
			else if (userInput == ConsoleKey.DownArrow && this.Row < Constants.WindowHeight - 5)
			{
				this.Row++;
			}
		}
	}
}