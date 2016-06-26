using OOPGame.GameInterfaces;
using OOPGame.GameObject;
using System;
using OOPGame.GameStructure;

namespace OOPGame
{
    public class Bullet : IGameObject
    {
        // Fields.
        private string bulletFigure = ".";
        private ConsoleColor bulletColor = ConsoleColor.Cyan;

        // Constructor.
        public Bullet(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        // Properties.
        public int Row { get; set; }
        public int Col { get; set; }

        public string Figure { get { return this.bulletFigure; } }

        public ConsoleColor Color { get { return this.bulletColor; } }

        // Methods.
        public void Move()
        {
            this.Col++;
        }

		public void MoveBullet()
		{
			Engine.Clear(this);
			this.Move();
			Engine.Clear(this);
			Engine.Draw(this);
		}
    }
}