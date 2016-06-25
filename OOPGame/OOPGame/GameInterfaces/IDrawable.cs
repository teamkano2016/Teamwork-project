namespace OOPGame.GameInterfaces
{
    using System;

    public interface IDrawable
    {
        void PrintOnPosition(int row, int col, string figure, ConsoleColor color);
    }
}
