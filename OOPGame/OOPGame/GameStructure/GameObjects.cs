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

		public static ICollection<Enemy> Enemies { get; private set; }

		public static ICollection<Potion> Potions { get; private set; }
	}
}
