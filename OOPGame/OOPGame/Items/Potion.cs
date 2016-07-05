using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OOPGame.GameStructure;

namespace OOPGame
{
    public class Potion : Item
    {
        public Potion() : base()
        {
            this.Figure = Constants.Potion;
        }
    }
}