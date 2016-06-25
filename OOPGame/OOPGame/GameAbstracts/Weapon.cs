using OOPGame.GameInterfaces;
using OOPGame.GameObject;
using OOPGame.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPGame
{
    public abstract class Weapon : IGameObject
    {
        // Fields.
        private int weaponRow = Constants.screenUpperBorder;
        private int weaponCol = 1;
        private string weaponFigure = ">";
        private ConsoleColor weaponColor = ConsoleColor.DarkYellow;
        private ICollection<Bullet> bullets;

        // Constructor.
        public Weapon()
        {
            this.bullets = new List<Bullet>();
        }
        public ICollection<Bullet> Bullets { get { return this.bullets; } set { this.bullets = value; } }

        public int Row { get { return this.weaponRow; } }

        public int Col { get { return this.weaponCol; } }

        public string Figure { get { return this.weaponFigure; } }

        public ConsoleColor Color { get { return this.weaponColor; } }

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
            else if (userInput.Key == ConsoleKey.RightArrow && weaponCol < Constants.windowWidth - 2)
            {
                weaponCol++;
            }
            else if (userInput.Key == ConsoleKey.UpArrow && weaponRow > Constants.screenUpperBorder)
            {
                weaponRow--;
            }
            else if (userInput.Key == ConsoleKey.DownArrow && weaponRow < Constants.windowHeight - 2)
            {
                weaponRow++;
            }
            else if (userInput.Key == ConsoleKey.Spacebar)
            {
                bullets.Add(new Bullet(this.weaponRow, this.weaponCol + 1));
            }
        }
    }
}