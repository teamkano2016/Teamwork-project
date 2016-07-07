using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPGame
{
    public class Bomb : Weapon
    {
		public Bomb(int row, int col, string figure, ConsoleColor color) : base(row, col, figure, color)
		{

		}
    }
}