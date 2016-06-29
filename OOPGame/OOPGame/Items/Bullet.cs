using OOPGame.GameInterfaces;
using OOPGame.GameObject;
using System;
using OOPGame.GameStructure;
using System.Linq;

namespace OOPGame
{
	public class Bullet : IGameObject
	{
		// Fields.

		// Constructor.
		public Bullet(int row, int col)
		{
			this.Row = row;
			this.Col = col;
			this.Figure = ".";
			this.Color = ConsoleColor.Cyan;
		}

		// Properties.
		public int Row { get; set; }

		public int Col { get; set; }

		public string Figure { get; set; }

		public ConsoleColor Color { get; set; }

		// Methods.
		public void Move()
		{
			this.Col++;
		}

		public void MoveBullet()
		{
			Engine.Clear(this);
			this.Move();
			Engine.Draw(this);
		}
	}
}