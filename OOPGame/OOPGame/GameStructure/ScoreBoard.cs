namespace OOPGame.GameStructure
{
	using System;

	public static class ScoreBoard
	{
		static ScoreBoard()
		{
			Lives = Constants.InitialNumberOfLives;
			Health = 100;
			Points = 0;
		}

		public static int Lives { get; set; }

		public static int Health { get; set; }

		public static int Points { get; set; }

		public static void InitializeScoreBoard()
		{
			Console.SetCursorPosition(0, 0);
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine(string.Format("Lives: {0} | Health: {1} | Points: {2}"
								  , Lives
								  , Health
								  , Points));
		}

		public static void UpdateScoreBoard(int lives, int health, int points)
		{
			Lives = lives;
			Health = health;
			Points = points;
		}
	}
}