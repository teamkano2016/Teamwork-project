namespace OOPGame
{
	using System;
	using System.Collections.Generic;
	using OOPGame.GameObject;
	using OOPGame.GameStructure;

	public abstract class Enemy : IEnemy, IGameObject
	{
		private static Random randomCoordinate = new Random();

		private int enemyRow = randomCoordinate.Next(Constants.screenUpperBorder, Constants.windowHeight - 2);
		private int enemyCol = Constants.windowWidth - 1;//randomCoordinate.Next(0, Constants.windowWidth - 2);
		private string enemyFigure = "@";
		private ConsoleColor enemyColor = ConsoleColor.Magenta;

		public int Row
		{
			get { return this.enemyRow; }
		}

		public int Col
		{
			get { return this.enemyCol; }
		}

		public ConsoleColor Color
		{
			get { return this.enemyColor; }
		}

		public string Figure
		{
			get { return this.enemyFigure; }
		}

		public void MoveEnemies()
		{
			throw new NotImplementedException();
		}
	}
}