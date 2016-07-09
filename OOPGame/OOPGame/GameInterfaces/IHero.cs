namespace OOPGame.GameInterfaces
{
	public interface IHero
	{
		// Example of methods and properties to implement.
		int AttackPoints { get; }

		//int DefencePoints { get;}

		int Lives { get; }

		int Health { get; }

		bool IsAlive();

		//void ResetDirections();

		void AddLive();

		void RemoveLive();
	}
}