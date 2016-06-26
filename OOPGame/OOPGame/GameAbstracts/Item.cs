using OOPGame.GameObject;
using OOPGame.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPGame
{
    public abstract class Item : IGameObject //ICollectable, ITransformable
    {
        // Fields 
        private static Random randomCoordinate = new Random();
        private int itemRow = randomCoordinate.Next(Constants.screenUpperBorder, Constants.windowHeight - 2);
        private int itemCol = randomCoordinate.Next(0, Constants.windowWidth - 2);
        private string itemFigure = "t";
        private ConsoleColor itemColor = ConsoleColor.Red;
        public Item()
        {
            //this.Row = itemRow;
            //this.Col = itemCol;
            //this.Figure = itemFigure;
            //this.Color = itemColor;
        }
        public int Col
        {
            get
            {
                return this.itemCol;
            }
        }

        public ConsoleColor Color
        {
            get
            {
                return this.itemColor;
            }
        }

        public string Figure
        {
            get
            {
                return this.itemFigure;
            }
            set
            {
                this.itemFigure = value;
            }
        }

        public int Row
        {
            get
            {
                return this.itemRow;
            }
        }

    }
}