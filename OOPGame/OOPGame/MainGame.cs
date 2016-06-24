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

            // TO DO optimize score board to be set in Field.
            ScoreBoard scoreBoard = new ScoreBoard();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(scoreBoard.ToString());

            // Create Player.
            Player mainPlayer = new Player();
            while (!isGameOver)
            {
                // Important notes: TO DO
                // Optimize methods draw, clear and move.
                // Important bullets are not moving automatically???
                foreach (var bullet in mainPlayer.Weapon.Bullets)
                {
                    bullet.Clear();
                    bullet.Move();
                    bullet.Draw();
                }
                ConsoleKeyInfo userInput = Console.ReadKey();
                mainPlayer.Clear();
                mainPlayer.Weapon.Clear();
                mainPlayer.Move(userInput);
                mainPlayer.Weapon.Move(userInput);
                mainPlayer.Draw();
                mainPlayer.Weapon.Draw();
                
                Thread.Sleep(100);
            }
        }
    }
}
