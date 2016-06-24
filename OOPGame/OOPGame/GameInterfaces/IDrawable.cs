namespace OOPGame.GameInterfaces
{
    using System;

    interface IDrawable
    {
        void PrintOnPosition(int row, int col, string figure, ConsoleColor color);
    }
}
