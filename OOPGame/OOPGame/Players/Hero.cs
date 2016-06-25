using OOPGame.GameInterfaces;
using OOPGame.GameObject;
using OOPGame.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPGame
{
    public abstract class Hero : IGameObject //IHero, ITransformable, ICollectable, IAttackable
    {
        // Fields.
        private int lives;
        private int playerRow = Constants.screenUpperBorder;
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
            // PrintOnPosition(playerRow, playerCol, playerFigure, playerColor);
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

        public int Row { get { return this.playerRow; } }

        public int Col { get { return this.playerCol; } }

        public string Figure { get { return this.playerFigure; } }

        public ConsoleColor Color { get { return this.playerColor; } }

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
                else if (userInput.Key == ConsoleKey.RightArrow && playerCol < Constants.windowWidth - 3)
                {
                    playerCol++;
                }
                else if (userInput.Key == ConsoleKey.UpArrow && playerRow > Constants.screenUpperBorder)
                {
                    playerRow--;
                }
                else if (userInput.Key == ConsoleKey.DownArrow && playerRow < Constants.windowHeight - 2)
                {
                    playerRow++;
                }
        }

        //public void ResetDirections()
        //{
        //    throw new NotImplementedException();
        //}
    }
}