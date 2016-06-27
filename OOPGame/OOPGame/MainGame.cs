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
				mainPlayer.MovePlayer(gameField);

				for (int i = 0; i < mainPlayer.Weapon.Bullets.Count; i++)
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
								mainPlayer.MovePlayer(gameField);
								//Teleport.TeleportPlayer(mainPlayer);//TO DO make teleporter respond to hotkey t -or any other :)
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
			for (int i = 0; i < Constants.potionsFirstLevel; i++)
			{
				var potion = new Potion();
				Engine.Draw(potion);
				GameObjects.Potions.Add(potion);
			}
			for (int i = 0; i < Constants.enemiesFirstLevel; i++)
			{
				var enemy = new Enemy1();
				Engine.Draw(enemy);
				GameObjects.Enemies.Add(enemy);
			}
		}
	}
}
