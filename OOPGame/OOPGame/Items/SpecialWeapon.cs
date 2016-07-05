using OOPGame.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPGame
{
    public class SpecialWeapon : Bullet
    {

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
                return Constants.EnemySpecialWeapon;
            }
        }
    }
}