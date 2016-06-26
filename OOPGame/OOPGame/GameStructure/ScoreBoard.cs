using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPGame
{
    public class ScoreBoard
    {
        public ScoreBoard(int lives, int health, int points, int items)
        {
            this.Lives = lives;
			this.Health = health;
            this.Points = points;
            this.Items = items;
        }

        public int Lives {get;  set; }

		public int Health { get; set; }

		public int Points { get; set; }

        public int Items { get; set; }

        public override string ToString()
        {
            return string.Format("Lives: {0} Health: {1} Points: {2} Items: {3}"
                                  , this.Lives
								  , this.Health
                                  , this.Points
                                  , this.Items);
        }
    }
}