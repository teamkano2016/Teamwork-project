using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame.GameStructure
{
    public class EndGameArguments : EventArgs
    {
        private string endGameMsg;
        private bool endGameState;
        public string Message
        {
            get
            {
                return this.endGameMsg;
            }
        }

        public bool GameState
        {
            get
            {
                return this.endGameState;
            }
        }

        public EndGameArguments(string msg, bool state)
        {
            endGameState = state;
            endGameMsg = msg;
        }
    }
}
