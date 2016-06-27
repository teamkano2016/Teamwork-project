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
			int row = rand.Next(Constants.screenUpperBorder, Constants.windowHeight - 2);
			int col = rand.Next(0, Constants.windowWidth - 2);
			Engine.Clear(player);
			Engine.Clear(player.Weapon);
			Engine.PrintOnPosition(row, col, player.Figure, player.Color);
			Engine.PrintOnPosition(row, col + 1, player.Weapon.Figure, player.Weapon.Color);

			Engine.Clear(player);
			Engine.Clear(player.Weapon);
			Engine.Draw(player);
			Engine.Draw(player.Weapon);
			Engine.Clear(player);
			Engine.Clear(player.Weapon);
		}
	}
}