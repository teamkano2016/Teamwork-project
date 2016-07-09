namespace OOPGame.GameStructure
{
	using System;

	using OOPGame.GameInterfaces;

	public static class Engine
	{
		public static void Clear(IGameObject gameobject)
		{
			PrintOnPosition(gameobject.Row, gameobject.Col, new string(' ', gameobject.Figure.Length), gameobject.Color);
		}

		public static void Draw(IGameObject gameobject)
		{
			PrintOnPosition(gameobject.Row, gameobject.Col, gameobject.Figure, gameobject.Color);
		}

		public static void PrintOnPosition(int row, int col, string figure, ConsoleColor color)
		{
			Console.SetCursorPosition(col, row);
			Console.ForegroundColor = color;
			Console.WriteLine(figure);
		}
	}
}
