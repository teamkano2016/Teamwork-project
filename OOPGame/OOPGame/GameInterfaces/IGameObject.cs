namespace OOPGame.GameInterfaces
{
	using System;

	public interface IGameObject
	{
		int Row { get; }

		int Col { get; }

		string Figure { get; }

		ConsoleColor Color { get; }
	}
}
