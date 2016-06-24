using OOPGame.GameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPGame
{
    public struct Field : IDrawable
    {
        // Fields.
        public const int windowWidth = 110;
        public const int windowHeight = 30;
        public const int screenUpperBorder = 3;
        public const string ExitPoint = "E"; 
        
        // Properties.
        public int WindowWIdth { get { return windowWidth; } }
        public int WindowHeight { get { return windowHeight; } }

        // Methods.
        public void InitialiseSettings()
        {
            Console.WindowWidth = windowWidth;
            Console.WindowHeight = windowHeight;
            Console.BufferWidth = windowWidth;
            Console.BufferHeight = windowHeight;
            PrintOnPosition(screenUpperBorder, windowWidth - 1, ExitPoint, ConsoleColor.Blue);
            Console.CursorVisible = false;
        }
        // Draw exit point of the game.
        public void PrintOnPosition(int row, int col, string text, ConsoleColor color)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }
    }
}