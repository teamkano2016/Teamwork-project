namespace OOPGame
{
    using System;
    using System.Collections.Generic;
    using OOPGame.GameObject;
    using OOPGame.GameStructure;

    public abstract class Enemy : IEnemy, IGameObject, IAttackable
    {
        private static Random randomCoordinate = new Random();
        private const int enemyAttackPoints = 10;

        public Enemy()
        {
            this.Row = randomCoordinate.Next(Constants.ScreenUpperBorder + 1, Constants.WindowHeight - 4);
            this.Col = Constants.WindowWidth - 1;
            this.Figure = Constants.Enemy;
            this.Color = ConsoleColor.Magenta;
            this.Health = 100;
            this.BulletsEnemy = new SpecialWeapon(this.Row, this.Col - 1);
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public ConsoleColor Color { get; set; }

        public string Figure { get; set; }

        public SpecialWeapon BulletsEnemy { get; private set; }

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
            this.BulletsEnemy.MoveBullet();

        }

        public void MoveEnemies()
        {
            throw new NotImplementedException();
        }
    }
}