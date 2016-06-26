namespace OOPGame
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	using OOPGame.GameStructure;

	class MainGame
	{
		static void Main()
		{
			bool isGameOver = false;

			// Create Player.
			Player mainPlayer = new Player();

			ScoreBoard scoreBoard = new ScoreBoard(mainPlayer.Lives, mainPlayer.HealthPoints, 0, 0);

			// Create Game field.
			Field gameField = new Field(scoreBoard);
			gameField.InitialiseSettings();

			GenerateEnemiesPotions();

			while (!isGameOver)
			{
				mainPlayer.MovePlayer();

				for(int i = 0; i < mainPlayer.Weapon.Bullets.Count; i++)
				{
					while (mainPlayer.Weapon.Bullets[i].Col < Constants.windowWidth - 1)
					{
						mainPlayer.Weapon.Bullets[i].MoveBullet();

						DateTime timeoutValue = DateTime.Now.AddMilliseconds(30);

						while (DateTime.Now < timeoutValue)
						{
							// TODO: Fire bullet with spacebar immediately
							if (Console.KeyAvailable)
							{
								mainPlayer.MovePlayer();
							}
							else
							{
								Thread.Sleep(30);
							}
						}
					}
					Engine.Clear(mainPlayer.Weapon.Bullets[i]);
				}
			}
		}

		public static void GenerateEnemiesPotions()
		{
			// Create random Enemies. Creation is similar to players and items.
			// TO DO - class Enemy must be derived from interface IGameObject????

			// Create random potions. TO DO when new level is reached potion must be reduced.
			// TO DO - if player get potion must add new live to player's property.
			for (int i = 0; i < Constants.potionsFirstLevel; i++)
			{
				Engine.Draw(new Potion());
				// TODO: Add this item to GameObjects
			}
			for (int i = 0; i < Constants.enemiesFirstLevel; i++)
			{
				Engine.Draw(new Enemy1());
				// TODO: Add this enemy to GameObjects
			}
		}
	}
}
