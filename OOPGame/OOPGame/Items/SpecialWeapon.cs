using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPGame
{
    public class SpecialWeapon : Bullet
    {
        private const string bulletEnemyFigure = "=";

        public SpecialWeapon(int row, int col) : base(row, col)
        {

        }
        public override void Move()
        {
            this.Col--;
        }
        public override string Figure
        {
            get
            {
                return bulletEnemyFigure;
            }
        }
    }
}