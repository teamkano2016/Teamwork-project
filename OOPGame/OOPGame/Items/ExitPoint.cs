

namespace OOPGame.Items
{
    using System;
    using GameAbstracts;
    using GameStructure;

    public class ExitPointItem : Item
    {
        public ExitPointItem()
        {
            this.Figure = Constants.ExitPoint;
            this.Color = ConsoleColor.Blue;
            this.Col = Constants.ExitPointCol;
            this.Row = Constants.ExitPointRow;
        }
    }
}
