namespace OOPGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public struct Field
    {
        private const int windowWidth = 110;
        private const int windowHeight = 30;
        private const char ExitPoint = 'E'; 

        public void InitialiseSettings()
        {
            Console.WindowWidth = windowWidth;
            Console.WindowHeight = windowHeight;
            Console.BufferWidth = windowWidth;
            Console.BufferHeight = windowHeight;
            PrintOnPosition(0, windowWidth - 1, ExitPoint, ConsoleColor.Blue);
            Console.CursorVisible = false;
        }
        // Draw exit point of the game.
        static void PrintOnPosition(int row, int col, char text, ConsoleColor color)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.WriteLine(ExitPoint);
        }
    }
}