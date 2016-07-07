namespace OOPGame
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Gun : Weapon
    {
		public Gun(int row, int col, string figure, ConsoleColor color) : base(row, col, figure, color)
		{
			
		}
    }
}