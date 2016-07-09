namespace OOPGame.GameStructure
{
	using System.Collections.Generic;

	using GameAbstracts;
	using Items;

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
