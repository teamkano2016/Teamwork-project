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
                GameObjects.Enemies.Add(enemy);
            }
        }

        public static void MainLogic(Player mainPlayer)
        {
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
                        mainPlayer.Weapon.Bullets.Add(new Bullet(mainPlayer.Row, mainPlayer.Col + 2));
                    }
                    else if (input.Key == ConsoleKey.T)
                    {
                        Teleport.TeleportPlayer(mainPlayer);
                    }

                }

                // Check for collision between enemy and player bullet.
                // If enemy dies add points to score board and remove enemy from field.
                foreach (var enemy in GameObjects.Enemies)
                {
                    if (mainPlayer.Weapon.Bullets.Any(x => (x.Col + 1).CompareTo(enemy.Col) == 0
                                                       && x.Row.CompareTo(enemy.Row) == 0))
                    {
                        enemy.Health -= mainPlayer.AttackPoints;
                        if (enemy.Health == 0)
                        {
                            Engine.Clear(enemy);
                            GameObjects.Enemies.Remove(enemy);
                            Engine.Clear(enemy.BulletsEnemy);
                            ScoreBoard.Points++;
                            break;
                        }
                    }
                }

                // Add automatically shoot from each enemy.
                foreach (var enemy in GameObjects.Enemies)
                {
                    enemy.Shoot();
                    if (enemy.BulletsEnemy.Col == 1)
                    {
                        Engine.Clear(enemy.BulletsEnemy);
                        enemy.BulletsEnemy.Col = enemy.Col - 1;
                        break;
                    }
                    else if (enemy.BulletsEnemy.Col == mainPlayer.Col + 2 &&
                             enemy.BulletsEnemy.Row == mainPlayer.Row)
                    {
                        mainPlayer.Health -= enemy.AttackPoints;
                        if (mainPlayer.Health == 0)
                        {
                            mainPlayer.RemoveLive();
                        }
                        Engine.Clear(enemy.BulletsEnemy);

                        enemy.BulletsEnemy.Col = enemy.Col - 1;
                        break;
                    }
                    Thread.Sleep(10);
                }

                

                // Make each bullet's move
                for (int i = 0; i < mainPlayer.Weapon.Bullets.Count; i++)
                {
                    if (mainPlayer.Weapon.Bullets[i].Col == Constants.WindowWidth - 2) // Remove bullet from list when it reaches the end of the console
                    {
                        Engine.Clear(mainPlayer.Weapon.Bullets[i]);
                        mainPlayer.Weapon.Bullets.RemoveAt(i);
                        i--;
                        continue;
                    }
                    
                    mainPlayer.Weapon.Bullets[i].MoveBullet();
                }

                ScoreBoard.UpdateScoreBoard(mainPlayer.Lives, mainPlayer.Health, ScoreBoard.Points);
                ScoreBoard.InitializeScoreBoard();
                Field.UpdateField();
                Thread.Sleep(10);

            }
        }
    }
}
