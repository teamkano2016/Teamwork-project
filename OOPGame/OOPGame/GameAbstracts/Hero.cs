namespace OOPGame
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using OOPGame.GameInterfaces;
	using OOPGame.GameObject;
	using OOPGame.GameStructure;

	public abstract class Hero : IGameObject, IAttackable //IHero, ITransformable, ICollectable, 
    {
		// Fields.
		private int lives;
		private int health;
        private int attackPoints = 10;
		private int playerRow;
		private int playerCol;
		private string playerFigure;
		private ConsoleColor playerColor;
		private GameKeyBoardKeys playerKeyBoardKeys;
		private Weapon weapon;

		// Constructor.
		public Hero(int lives)
		{
			this.Lives = lives;
			this.Health = 100;
			this.Weapon = new Gun();
			this.Row = Constants.ScreenUpperBorder + 1;
			this.Col = 1;
			this.Figure = "Q";
			this.Color = ConsoleColor.Yellow;
			// PrintOnPosition(playerRow, playerCol, playerFigure, playerColor);
		}

		// Properties.
		public Weapon Weapon
		{
			get
			{
				return this.weapon;
			}
			private set
			{
				this.weapon = value;
			}
		}

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
        }

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

        public int Health
		{
			get
			{
				return this.health;
			}

			set
			{
				this.health = value;
			}
		}

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

		public int Row
		{
			get
			{
				return this.playerRow;
			}
			set
			{
				this.playerRow = value;
			}
		}

		public int Col
		{
			get
			{
				return this.playerCol;
			}
			set
			{
				this.playerCol = value;
			}
		}

		public string Figure
		{
			get
			{
				return this.playerFigure;
			}
			private set
			{
				this.playerFigure = value;
			}
		}

		public ConsoleColor Color
		{
			get
			{
				return this.playerColor;
			}
			private set
			{
				this.playerColor = value;
			}
		}

		// Methods.
		public void AddLive()
		{
			this.Lives++;
		}

		public bool IsAlive()
		{
			if (this.Lives > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void RemoveLive()
		{
			this.Lives--;
            this.Health = 100;
		}

		public void Move(ConsoleKey userInput)
		{
			if (userInput == ConsoleKey.LeftArrow && this.Col > 1)
			{
				this.Col--;
			}
			else if (userInput == ConsoleKey.RightArrow && this.Col < Constants.WindowWidth - 3)
			{
				this.Col++;
			}
			else if (userInput == ConsoleKey.UpArrow && this.Row > Constants.ScreenUpperBorder + 1)
			{
				this.Row--;
			}
			else if (userInput == ConsoleKey.DownArrow && this.Row < Constants.WindowHeight - 5)
			{
				this.Row++;
			}
		}

		public void DrawPlayer()
		{
			Engine.Draw(this);
			Engine.Draw(this.Weapon);
		}

		public void MovePlayer(ConsoleKey userInput)
		{
			Engine.Clear(this);
			Engine.Clear(this.Weapon);

			this.Move(userInput);
			this.Weapon.Move(userInput);

			DrawPlayer();

			// When player hits potion => lives++
			if ((from potion in GameObjects.Potions
				 where potion.Row == this.Row && potion.Col == this.Col
				 select potion).ToList().Count > 0)
			{
				GameObjects.Potions.RemoveAll(potion => potion.Row == this.Row && potion.Col == this.Col);
				this.Lives++;
				ScoreBoard.UpdateScoreBoard(this.Lives, this.Health, ScoreBoard.Points);
				ScoreBoard.InitializeScoreBoard();
			}
		}

		//public void ResetDirections()
		//{
		//    throw new NotImplementedException();
		//}
	}
}