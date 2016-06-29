using OOPGame.GameObject;
using OOPGame.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPGame
{
	public abstract class Item : IGameObject //ICollectable, ITransformable
	{
		private static Random randomCoordinate = new Random();

		public Item()
		{
			this.Row = randomCoordinate.Next(Constants.ScreenUpperBorder + 1, Constants.WindowHeight - 4);
			this.Col = randomCoordinate.Next(1, Constants.WindowWidth - 2);
			this.Figure = "u";
			this.Color = ConsoleColor.Red;
		}

		public int Row { get; set; }

		public int Col { get; set; }

		public ConsoleColor Color { get; set; }

		public string Figure { get; set; }
	}
}