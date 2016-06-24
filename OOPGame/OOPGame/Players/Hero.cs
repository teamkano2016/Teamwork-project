using OOPGame.GameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPGame
{
    public abstract class Hero : IDrawable //IHero, ITransformable, ICollectable, IAttackable
    {
        // Fiedls.
        private int lives;
        private int playerRow = 3;
        private int playerCol;
        private string playerFigure = "Q";
        private ConsoleColor playerColor = ConsoleColor.DarkYellow;
        private GameKeyBoardKeys playerKeyBoardKeys;
        private Weapon weapon = new Gun();

        // Constructor.
        public Hero(int lives)
        {
            this.Lives = lives;
            this.Weapon = weapon;
            PrintOnPosition(playerRow, playerCol, playerFigure, playerColor);
        }

        // Properties.
        public Weapon Weapon { get { return this.weapon; } private set { this.weapon = value; } }
        //public double AttackPoints
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public double DefencePoints
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public double HealthPoints
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        public int Lives
        {
            get
            {
                return this.lives;
            }
            private set
            {
                this.lives = value;
            }
        }

        // Methods.
        public void AddLive()
        {
            this.Lives++;
        }

        //public bool IsAlive()
        //{
        //    throw new NotImplementedException();
        //}

        public void RemoveLive()
        {
            this.Lives--;
        }
        public void Move(ConsoleKeyInfo userInput)
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
            if (userInput.Key.Equals(ConsoleKey.LeftArrow) && playerCol > 0)
            {
                playerCol--;
            }
            else if (userInput.Key == ConsoleKey.RightArrow && playerCol < Field.windowWidth - 2)
            {
                playerCol++;
            }
            else if (userInput.Key == ConsoleKey.UpArrow && playerRow > Field.screenUpperBorder)
            {
                playerRow--;
            }
            else if (userInput.Key == ConsoleKey.DownArrow && playerRow < Field.windowHeight - 2)
            {
                playerRow++;
            }
        }
        public void Draw()
        {
            PrintOnPosition(playerRow, playerCol, playerFigure, playerColor);
        }
        public void Clear()
        {
            PrintOnPosition(playerRow, playerCol, " ", playerColor);
        }
        public void PrintOnPosition(int row, int col, string figure, ConsoleColor color)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.WriteLine(figure);
        }
        //public void ResetDirections()
        //{
        //    throw new NotImplementedException();
        //}
    }
}