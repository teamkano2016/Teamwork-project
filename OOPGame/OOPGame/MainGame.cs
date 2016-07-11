namespace OOPGame
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;

    using Items;
    using OOPGame.GameStructure;
    using Players;

    class MainGame
    {
        public static event EventHandler<EndGameArguments> EndGame;

        private static bool levelPassed = false;

        static void Main()
        {
            EndGame += EndGameHandler.HandleEvent;
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
                var lst = (from e in GameObjects.Enemies
                           select e.Row).ToList();

                if (lst.Contains(enemy.Row) || lst.Contains(Field.ExitPoint.Row))
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
            foreach (var enemy in GameObjects.Enemies)
            {
                enemy.Shoot();
            }

            bool isSpacePressed;
            // TODO: Fix player moving after holding arrow key down
            while (mainPlayer.IsAlive() && !levelPassed)
            {
                isSpacePressed = false;
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
                        isSpacePressed = true;
                        if (mainPlayer.Col + 2 < Field.ExitPoint.Col)
                        {
                            mainPlayer.Weapon.Bullets.Add(new GunBullet(mainPlayer.Row,
                                                                        mainPlayer.Col + 2,
                                                                        Constants.HeroBullet,
                                                                        Constants.GunBulletColor));
                        }
                    }
                    else if (input.Key == ConsoleKey.T)
                    {
                        mainPlayer.TeleportPlayer();
                    }
                }

                // Add automatically shoot from each enemy.
                foreach (var enemy in GameObjects.Enemies)
                {
                    foreach (var bullet in enemy.Weapon.Bullets)
                    {
                        bullet.MoveBullet(-1);
                        if (bullet.Row == mainPlayer.Row &&
                            bullet.Col == mainPlayer.Col + 2)
                        {
                            Engine.Clear(bullet);
                            enemy.Weapon.Bullets.Remove(bullet);

                            mainPlayer.Health -= enemy.AttackPoints;

                            if (mainPlayer.Health == 0)
                            {
                                mainPlayer.RemoveLive();
                                //Raise event if we are dead.
                                if (mainPlayer.Lives == 0)
                                {
                                    OnRiseEndGameEvent(new EndGameArguments("DEFEATED! GAME OVER!", false));
                                    mainPlayer.IsAlive();
                                }
                            }
                            enemy.Shoot();
                            break;
                        }
                        else if (bullet.Col == 1)
                        {
                            Engine.Clear(bullet);
                            enemy.Weapon.Bullets.Remove(bullet);
                            enemy.Shoot();
                            break;
                        }
                    }
                }

                // Make each bullet's move
                foreach (var playerBullet in mainPlayer.Weapon.Bullets)
                {
                    playerBullet.MoveBullet(1);
                    foreach (var enemy in GameObjects.Enemies)
                    {
                        if (enemy.Row == playerBullet.Row && enemy.Col == playerBullet.Col + 2)
                        {
                            enemy.Health -= mainPlayer.AttackPoints;

                            if (enemy.Health == 0)
                            {
                                mainPlayer.Points += 10;
                                GameObjects.Enemies.Remove(enemy);
                                Engine.Clear(enemy.Weapon);
                                Engine.Clear(enemy);

                                // Clear bullets of an enemy if enemy is hit
                                foreach (var enemyBullet in enemy.Weapon.Bullets)
                                {
                                    Engine.Clear(enemyBullet);
                                }
                            }
                            Engine.Clear(playerBullet);
                            mainPlayer.Weapon.Bullets.Remove(playerBullet);
                            break;

                        }
                    }
                    // Remove bullet from list when it reaches the end of the console
                    if (playerBullet.Col == Constants.WindowWidth - 1 ||
                        GameObjects.Enemies.Any(enemy => enemy.Col - 2 == playerBullet.Col))
                    {
                        Engine.Clear(playerBullet);
                        mainPlayer.Weapon.Bullets.Remove(playerBullet);
                        break;
                    }
                    // Check if all enemies are killed.
                    if (GameObjects.Enemies.Count == 0)
                    {
                        break;
                    }
                }
                // TODO Implement logic after finishing the level???
                //Raising event for exiting the game with pressing the space button when u are infront of...
                //... the exit. If needed the space button can be removed from the checking.
                if (mainPlayer.Row.CompareTo(Field.ExitPoint.Row) == 0 &&
                    mainPlayer.Col.CompareTo(Field.ExitPoint.Col - 2) == 0 &&
                    GameObjects.Enemies.Count == 0 && isSpacePressed)
                {
                    
                    OnRiseEndGameEvent(new EndGameArguments("CONGRATULATIONS VICTORY", true));

                }
                ScoreBoard.UpdateScoreBoard(mainPlayer.Lives, mainPlayer.Health, mainPlayer.Points);
                ScoreBoard.InitializeScoreBoard();
                Field.UpdateField();
                Thread.Sleep(30);
            }
        }

        protected static void OnRiseEndGameEvent(EndGameArguments e)
        {
            EventHandler<EndGameArguments> handler = EndGame;

            if (handler != null)
            {
                handler(null, e);

                if (e.GameState)
                {
                    levelPassed = true;
                }                
            }
        }

    }
}
