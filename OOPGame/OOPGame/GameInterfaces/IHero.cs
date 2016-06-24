namespace OOPGame
{
    public interface IHero
    {
        // Example of methods and properties to implement.
        double AttackPoints { get; set; }

        double DefencePoints { get; set; }

        int Lives { get; set; }

        double HealthPoints { get; set; }

        bool IsAlive();

        void ResetDirections();

        void AddLive();

        void RemoveLive();
    }
}