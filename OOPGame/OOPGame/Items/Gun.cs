namespace OOPGame.Items
{
	using System;

	using GameAbstracts;

	public class Gun : Weapon
	{
		public Gun(int row, int col, string figure, ConsoleColor color) : base(row, col, figure, color)
		{

		}
	}
}