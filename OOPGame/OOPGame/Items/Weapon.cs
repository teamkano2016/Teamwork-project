using OOPGame.GameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPGame
{
    public abstract class Weapon : IDrawable
    {
        // Fields.
        private int weaponRow = 3;
        private int weaponCol = 1;
        private string weaponFigure = ">";
        private ConsoleColor weaponColor = ConsoleColor.DarkYellow;
        private ICollection<Bullet> bullets;

        // Constructor.
        public Weapon()
        {
            PrintOnPosition(weaponRow, weaponCol, weaponFigure, weaponColor);
            this.bullets = new List<Bullet>();
        }
        public ICollection<Bullet> Bullets { get { return this.bullets; } set { this.bullets = value; } }
        // Methods.
        public void Draw()
        {
            PrintOnPosition(weaponRow, weaponCol, weaponFigure, weaponColor);
        }
        public void Clear()
        {
            PrintOnPosition(weaponRow, weaponCol, " ", weaponColor);
        }
        public void Move(ConsoleKeyInfo userInput)
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
            if (userInput.Key.Equals(ConsoleKey.LeftArrow) && weaponCol > 1)
            {
                weaponCol--;
            }
            else if (userInput.Key == ConsoleKey.RightArrow && weaponCol < Field.windowWidth - 2)
            {
                weaponCol++;
            }
            else if (userInput.Key == ConsoleKey.UpArrow && weaponRow > Field.screenUpperBorder)
            {
                weaponRow--;
            }
            else if (userInput.Key == ConsoleKey.DownArrow && weaponRow < Field.windowHeight - 2)
            {
                weaponRow++;
            }
            else if (userInput.Key == ConsoleKey.Spacebar)
            {
                bullets.Add(new Bullet(this.weaponRow, this.weaponCol + 1));
            }
        }
        public void PrintOnPosition(int row, int col, string figure, ConsoleColor color)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.WriteLine(figure);
        }
    }
}