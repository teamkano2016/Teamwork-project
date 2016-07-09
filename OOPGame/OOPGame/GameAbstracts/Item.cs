namespace OOPGame.GameAbstracts
{
	using System;

	using GameInterfaces;
	using OOPGame.GameStructure;

	public abstract class Item : IGameObject //ICollectable, ITransformable
	{
		private static Random randomCoordinate = new Random();

		protected Item()
		{
			this.Row = randomCoordinate.Next(Constants.ScreenUpperBorder + 1, Constants.WindowHeight - 4);
			this.Col = randomCoordinate.Next(1, Constants.WindowWidth - 3);
			this.Figure = Constants.Potion;
			this.Color = ConsoleColor.Red;
		}

		public int Row { get; set; }

		public int Col { get; set; }

		public ConsoleColor Color { get; set; }

		public string Figure { get; set; }
	}
}