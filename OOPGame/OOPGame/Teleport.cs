namespace OOPGame
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using OOPGame.GameStructure;

	public static class Teleport
	{
		public static void TeleportPlayer(Player player)
		{
			Random rand = new Random();
			int row = rand.Next(Constants.ScreenUpperBorder + 1, Constants.WindowHeight - 5);
			int col = rand.Next(0, Constants.WindowWidth - 2);
			Engine.Clear(player);
			Engine.Clear(player.Weapon);

			player.Row = row;
			player.Col = col;
			player.Weapon.Row = row;
			player.Weapon.Col = col + 1;

			Engine.Draw(player);
			Engine.Draw(player.Weapon);
		}
	}
}