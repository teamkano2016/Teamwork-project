using OOPGame.GameInterfaces;
using OOPGame.GameStructure;
using System;

namespace OOPGame
{
    public class SpecialWeapon : IBullet
    {
        public SpecialWeapon(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.Color = ConsoleColor.Cyan;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public ConsoleColor Color { get; set; }

        public string Figure
        {
            get
            {
                return Constants.EnemySpecialWeapon;
            }
        }

        public void Move()
        {
            this.Col--;
        }
        public void MoveBullet()
        {
            Engine.Clear(this);
            this.Move();
            Engine.Draw(this);
        }
    }
}