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
			// Create Player.
			Player mainPlayer = new Player();

			// Create Score Board
			ScoreBoard.InitializeScoreBoard();

			// Create Game field.
			Field.InitialiseSettings();

			// Generate Enemies and Potions
			// Separate in two methods for more clearance. TO DO optimize to one method with custom parameter in it
			// to avoid duplicate code.
			GeneratePotions();
			GenerateEnemies();

			// Draw main player
			mainPlayer.DrawPlayer();

			// Main logic of the game
			MainLogic(mainPlayer);
		}

		// Create random Enemies. Creation is similar to players and items.
		// TO DO - class Enemy must be derived from interface IGameObject????

		// Added checking for randomly generating enemy/potion with row and col that already exist
		// Not sure if condition for potions is correct because a duplicate is very unlikely to be generated

		public static void GeneratePotions()
		{
			for (int i = 0; i < Constants.PotionsFirstLevel; i++)
			{
				var potion = new Potion();
				if ((from p in GameObjects.Potions
					 where p.Row == potion.Row && p.Col == potion.Col
					 select p).ToList().Count > 0)
				{
					i--;
					continue;
				}
				Engine.Draw(potion);
				GameObjects.Potions.Add(potion);
			}

		}
		public static void GenerateEnemies()
		{
			for (int i = 0; i < Constants.EnemiesFirstLevel; i++)
			{
				var enemy = new Enemy1();
				if ((from e in GameObjects.Enemies
					 select e.Row).ToList().Contains(enemy.Row))
				{
					i--;
					continue;
				}
				Engine.Draw(enemy);
				Engine.Draw(enemy.Weapon);
				GameObjects.Enemies.Add(enemy);
			}
		}

		public static void MainLogic(Player mainPlayer)
		{
			// At level 1 an enemy can shoot only one bullet at a time
			for (int i = 0; i < GameObjects.Enemies.Count; i++)
			{
				GameObjects.Enemies[i].Shoot();
			}

			// TODO: Fix player moving after holding arrow key down
			while (mainPlayer.IsAlive())
			{
				// Check for pressed key
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo input = Console.ReadKey(true);

					if (input.Key == ConsoleKey.UpArrow ||
						input.Key == ConsoleKey.DownArrow ||
						input.Key == ConsoleKey.LeftArrow ||
						input.Key == ConsoleKey.RightArrow)
					{
						mainPlayer.MovePlayer(input.Key);
					}
					else if (input.Key == ConsoleKey.Spacebar)
					{
						mainPlayer.Weapon.Bullets.Add(new GunBullet(mainPlayer.Row, mainPlayer.Col + 2, Constants.HeroBullet, Constants.GunBulletColor));
					}
					else if (input.Key == ConsoleKey.T)
					{
						Teleport.TeleportPlayer(mainPlayer);
					}
				}

				// Add automatically shoot from each enemy.
				for (int i = 0; i < GameObjects.Enemies.Count; i++)
				{
					for (int e = 0; e < GameObjects.Enemies[i].Weapon.Bullets.Count; e++)
					{
						GameObjects.Enemies[i].Weapon.Bullets[e].MoveBullet(-1);
						if (GameObjects.Enemies[i].Weapon.Bullets[e].Row == mainPlayer.Row && GameObjects.Enemies[i].Weapon.Bullets[e].Col == mainPlayer.Col + 2)
						{
							Engine.Clear(GameObjects.Enemies[i].Weapon.Bullets[e]);
							GameObjects.Enemies[i].Weapon.Bullets.RemoveAt(e);
							e--;
							mainPlayer.Health -= GameObjects.Enemies[i].AttackPoints;
							if (mainPlayer.Health == 0)
							{
								mainPlayer.RemoveLive();
							}
							GameObjects.Enemies[i].Shoot();
						}
						else if (GameObjects.Enemies[i].Weapon.Bullets[e].Col == 1)
						{
							Engine.Clear(GameObjects.Enemies[i].Weapon.Bullets[e]);
							GameObjects.Enemies[i].Weapon.Bullets.RemoveAt(e);
							e--;
							GameObjects.Enemies[i].Shoot();
						}
					}
				}

				// Make each bullet's move
				for (int i = 0; i < mainPlayer.Weapon.Bullets.Count; i++)
				{
					mainPlayer.Weapon.Bullets[i].MoveBullet(1);
					for (int e = 0; e < GameObjects.Enemies.Count; e++)
					{
						if (GameObjects.Enemies[e].Row == mainPlayer.Weapon.Bullets[i].Row && GameObjects.Enemies[i].Col == mainPlayer.Weapon.Bullets[i].Col + 2)
						{
							mainPlayer.Points += 10;
							// Clear bullets of an enemy if enemy is hit
							for (int j = 0; j < GameObjects.Enemies[e].Weapon.Bullets.Count; j++)
							{
								Engine.Clear(GameObjects.Enemies[e].Weapon.Bullets[j]);
							}
							GameObjects.Enemies.RemoveAt(e);
							e--;
						}
					}
					if (mainPlayer.Weapon.Bullets[i].Col == Constants.WindowWidth - 1) // Remove bullet from list when it reaches the end of the console
					{
						Engine.Clear(mainPlayer.Weapon.Bullets[i]);
						mainPlayer.Weapon.Bullets.RemoveAt(i);
						i--;
						continue;
					}
				}

				ScoreBoard.UpdateScoreBoard(mainPlayer.Lives, mainPlayer.Health, mainPlayer.Points);
				ScoreBoard.InitializeScoreBoard();
				Field.UpdateField();
				Thread.Sleep(15);
			}
		}
	}
}
