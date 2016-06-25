using OOPGame.GameInterfaces;
using OOPGame.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame.GameStructure
{
    public class Engine : IDrawable
    {

        public void Clear(IGameObject gameobject)
        {
            PrintOnPosition(gameobject.Row, gameobject.Col, new string(' ', gameobject.Figure.Length), gameobject.Color);
        }

        public void Draw(IGameObject gameobject)
        {
            PrintOnPosition(gameobject.Row, gameobject.Col, gameobject.Figure, gameobject.Color);
        }

        public void PrintOnPosition(int row, int col, string figure, ConsoleColor color)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.WriteLine(figure);
        }
    }
}
