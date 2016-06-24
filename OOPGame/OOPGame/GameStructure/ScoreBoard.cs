using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPGame
{
    public class ScoreBoard
    {
        public ScoreBoard()
        {
            this.Lives = 5;
            this.Points = 0;
            this.Items = 0;
        }
        public int Lives {get;  set; }
        public int Points { get; set; }
        public int Items { get; set; }
        public override string ToString()
        {
            return string.Format("Lives: {0} Points: {1} Items: {2}"
                                  , this.Lives
                                  , this.Points
                                  , this.Items);
        }
    }
}