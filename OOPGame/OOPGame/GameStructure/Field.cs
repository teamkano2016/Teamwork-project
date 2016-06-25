using OOPGame.GameInterfaces;
using OOPGame.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPGame
{
    public struct Field //: IDrawable
    {
        // Fields.
        private const int width = Constants.windowWidth;
        private const int height = Constants.windowHeight;
        private const int screenUpperBorder = Constants.screenUpperBorder;
        private const string ExitPoint = Constants.ExitPoint;

        // Methods.
        public void InitialiseSettings()
        {
            Console.WindowWidth = width;
            Console.WindowHeight = height;
            Console.BufferWidth = width;
            Console.BufferHeight = height;
            PrintOnPosition(screenUpperBorder, width - 1, ExitPoint, ConsoleColor.Blue);
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