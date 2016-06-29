namespace OOPGame
{
	using System;
	using System.Collections.Generic;
	using OOPGame.GameObject;
	using OOPGame.GameStructure;

	public abstract class Enemy : IEnemy, IGameObject
	{
		private static Random randomCoordinate = new Random();

		public Enemy()
		{
			this.Row = randomCoordinate.Next(Constants.ScreenUpperBorder + 1, Constants.WindowHeight - 4);
			this.Col = Constants.WindowWidth - 1;
			this.Figure = "@";
			this.Color = ConsoleColor.Magenta;
		}

		public int Row { get; set; }

		public int Col { get; set; }

		public ConsoleColor Color { get; set; }

		public string Figure { get; set; }

		public void MoveEnemies()
		{
			throw new NotImplementedException();
		}
	}
}