namespace OOPGame
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using OOPGame.GameInterfaces;
	using OOPGame.GameObject;
	using OOPGame.GameStructure;

	public abstract class Hero : IGameObject //IHero, ITransformable, ICollectable, IAttackable
	{
		// Fields.
		private int lives;
		private int health;
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
			this.Weapon = new Gun();
			this.Row = Constants.screenUpperBorder;
			this.Col = 0;
			this.Figure = "Q";
			this.Color = ConsoleColor.DarkYellow;
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

		public int HealthPoints
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
			private set
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
			private set
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
				this.Col--;
			}
			else if (userInput.Key == ConsoleKey.RightArrow && playerCol < Constants.windowWidth - 3)
			{
				this.Col++;
			}
			else if (userInput.Key == ConsoleKey.UpArrow && playerRow > Constants.screenUpperBorder)
			{
				this.Row--;
			}
			else if (userInput.Key == ConsoleKey.DownArrow && playerRow < Constants.windowHeight - 2)
			{
				this.Row++;
			}
		}

		public void MovePlayer(Field field)
		{
			Engine.Draw(this);
			Engine.Draw(this.Weapon);

			ConsoleKeyInfo userInput = Console.ReadKey();

			Engine.Clear(this);
			Engine.Clear(this.Weapon);

			this.Move(userInput);
			this.Weapon.Move(userInput);
			Engine.Draw(this);
			Engine.Draw(this.Weapon);

			// When player hits potion => lives++
			if ((from potion in GameObjects.Potions
				 where potion.Row == this.Row && potion.Col == this.Col
				 select potion).ToList().Count > 0)
			{
				GameObjects.Potions.RemoveAll(potion => potion.Row == this.Row && potion.Col == this.Col);
				this.Lives++;
				field.UpdateScoreBoard(this.Lives, this.HealthPoints, field.Scores.Points, field.Scores.Items);
				field.InitializeScoreBoard();
			}
		}

		//public void ResetDirections()
		//{
		//    throw new NotImplementedException();
		//}
	}
}