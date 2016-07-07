using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame.GameStructure
{
	public static class Constants
	{
		public const int WindowWidth = 110;
		public const int WindowHeight = 33;
		public const int ScreenUpperBorder = 1;
		public const int PotionsFirstLevel = 5;
		public const int EnemiesFirstLevel = 6;
		public const string UpBorder = "_";
		public const string DownBorder = "-";
		public const string LeftBorder = "|";
		public const ConsoleColor BorderColor = ConsoleColor.DarkGreen;
		public const ConsoleColor HeroWeaponColor = ConsoleColor.Yellow;
		public const ConsoleColor EnemyWeaponColor = ConsoleColor.Magenta;
		public const ConsoleColor GunBulletColor = ConsoleColor.Blue;
		public const ConsoleColor SpecialWeaponBulletColor = ConsoleColor.Blue;
		public const int InitialNumberOfLives = 5;
        public const string Potion = "u";
        public const string Hero = "Q";
        public const string Enemy = "@";
        public const string HeroWeapon = ">";
        public const string EnemyWeapon = "<";
		public const string HeroBullet = ".";
        public const string EnemyBullet = "=";

    }
}
