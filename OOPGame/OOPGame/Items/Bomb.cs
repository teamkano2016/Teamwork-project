namespace OOPGame.Items
{
	using System;

	using GameAbstracts;

	public class Bomb : Weapon
	{
		public Bomb(int row, int col, string figure, ConsoleColor color) : base(row, col, figure, color)
		{

		}
	}
}