namespace OOPGame.GameStructure
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	using OOPGame.GameStructure;

	public static class GameObjects
	{
		static GameObjects()
		{
			Enemies = new List<Enemy>();
			Potions = new List<Potion>();
		}

		public static List<Enemy> Enemies { get; set; }

		public static List<Potion> Potions { get; set; }
	}
}
