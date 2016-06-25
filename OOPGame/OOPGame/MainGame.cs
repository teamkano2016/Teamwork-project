using OOPGame.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPGame
{
    class MainGame
    {
        static void Main()
        {
            bool isGameOver = false;
            // Create Game field.
            Field gameField = new Field();
            gameField.InitialiseSettings();

            // Create Game Engine - use for drawing and clearing objects from game field.
            Engine gameEngine = new Engine();

            // TO DO optimize score board to be set in Field.
            ScoreBoard scoreBoard = new ScoreBoard();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(scoreBoard.ToString());

            
            // Create Player.
            Player mainPlayer = new Player();
            // Create random Enemies. Creation is similar to players and items.
            // TO DO - class Enemy must be derived from interface IGameObject????

            // Create random potions. TO DO when new level is reached potion must be reduced.
            // TO DO - if player get potion must add new live to player's property.
            for (int i = 0; i < 5; i++)
            {
                gameEngine.Draw(new Potion());
            }
            while (!isGameOver)
            {
                gameEngine.Draw(mainPlayer);
                gameEngine.Draw(mainPlayer.Weapon);

                ConsoleKeyInfo userInput = Console.ReadKey();

                gameEngine.Clear(mainPlayer);
                gameEngine.Clear(mainPlayer.Weapon);

                mainPlayer.Move(userInput);
                mainPlayer.Weapon.Move(userInput);
                gameEngine.Draw(mainPlayer);
                gameEngine.Draw(mainPlayer.Weapon);
                //// Important bullets are not moving automatically???
                foreach (var bullet in mainPlayer.Weapon.Bullets)
                {
                    gameEngine.Clear(bullet);
                    bullet.Move();
                    gameEngine.Draw(bullet);
                }
                Thread.Sleep(100);
            }
        }
    }
}
