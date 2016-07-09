namespace OOPGame.GameAbstracts
{
	using System;

	using GameInterfaces;
	using OOPGame.GameStructure;

	public abstract class Bullet : IBullet
	{
		// Fields.

		// Constructor.
		protected Bullet(int row, int col, string figure, ConsoleColor color)
		{
			this.Row = row;
			this.Col = col;
			this.Figure = figure; //Constants.Bullet; these are for hero
			this.Color = color; //ConsoleColor.Cyan;
		}

		// Properties.
		public int Row { get; set; }

		public int Col { get; set; }

		public virtual string Figure { get; protected set; }

		public ConsoleColor Color { get; set; }

		// Methods.
		public void Move(int leftRight)
		{
			this.Col += leftRight;
		}

		public void MoveBullet(int leftRight)
		{
			Engine.Clear(this);
			this.Move(leftRight);
			Engine.Draw(this);
		}
	}
}