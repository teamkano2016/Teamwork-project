using OOPGame.GameInterfaces;
using System;

namespace OOPGame
{
    public class Bullet : IDrawable
    {
        // Fields.
        private string bulletFigure = ".";
        private ConsoleColor bulletColor = ConsoleColor.DarkBlue;

        // Constructor.
        public Bullet(int row, int col)
        {
            this.BulletRow = row;
            this.BulletCol = col;
        }

        // Properties.
        public int BulletRow { get; set; }
        public int BulletCol { get; set; }

        // Methods.
        public void Move()
        {
            this.BulletCol++;
        }
        public void Draw()
        {
            PrintOnPosition(this.BulletRow, this.BulletCol, bulletFigure, bulletColor);
        }
        public void Clear()
        {
            PrintOnPosition(this.BulletRow, this.BulletCol, " ", bulletColor);
        }
        public void PrintOnPosition(int row, int col, string figure, ConsoleColor color)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.WriteLine(figure);
        }
    }
}