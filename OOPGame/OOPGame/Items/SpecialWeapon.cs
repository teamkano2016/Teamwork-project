namespace OOPGame
{
	using OOPGame.GameInterfaces;
	using OOPGame.GameStructure;
	using System;

	public class SpecialWeapon : Weapon
    {
		public SpecialWeapon(int row, int col, string figure, ConsoleColor color) : base(row, col, figure, color)
		{

		}
	}
}