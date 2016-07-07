﻿namespace OOPGame.GameObject
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public interface IGameObject
	{
		int Row { get; }

		int Col { get; }

		string Figure { get; }

		ConsoleColor Color { get; }
	}
}
