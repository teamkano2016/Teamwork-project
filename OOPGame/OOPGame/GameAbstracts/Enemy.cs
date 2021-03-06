﻿namespace OOPGame.GameAbstracts
{
	using System;

	using GameInterfaces;
	using OOPGame.GameStructure;
	using OOPGame.Items;

	public abstract class Enemy : IEnemy, IGameObject, IAttackable
	{
		private static Random randomCoordinate = new Random();
		private const int enemyAttackPoints = 10;

		protected Enemy()
		{
			this.Row = randomCoordinate.Next(Constants.ScreenUpperBorder + 1, Constants.WindowHeight - 4);
			this.Col = Constants.WindowWidth - 1;
			this.Figure = Constants.Enemy;
			this.Color = ConsoleColor.Magenta;
			this.Health = Constants.DefaultHealthPoints;
			this.Weapon = new SpecialWeapon(this.Row, this.Col - 1, Constants.EnemyWeapon, Constants.EnemyWeaponColor);
		}

		public int Row { get; set; }

		public int Col { get; set; }

		public ConsoleColor Color { get; set; }

		public string Figure { get; set; }

		public Weapon Weapon { get; private set; }

		public int Health { get; set; }

		public int AttackPoints
		{
			get
			{
				return enemyAttackPoints;
			}
		}

		public void Shoot()
		{
			this.Weapon.Bullets.Add(new SpecialWeaponBullet(this.Row, this.Col - 2, Constants.EnemyBullet, Constants.SpecialWeaponBulletColor));
		}

		public void MoveEnemies()
		{
			throw new NotImplementedException();
		}
	}
}