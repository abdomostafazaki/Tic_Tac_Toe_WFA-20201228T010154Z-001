using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_WFA
{
    class ControlGame
    {
        public bool turn;
        public int turn_count = 1;
        public DialogResult result;
        public bool check = false;
        public Button btn;
        public ControlGame(int x)
        {
            if(x == 1)
            {
                turn = false;
            }
            else
            {
                turn = true;
            }
        }
        
    }
}
