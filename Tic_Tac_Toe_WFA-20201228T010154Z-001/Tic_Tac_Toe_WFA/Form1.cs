using System;
using System.Windows.Forms;
using System.Threading;

namespace Tic_Tac_Toe_WFA
{
    public partial class Form1 : Form
    {
        ControlGame objTwo = new ControlGame(2);

        public Form1()
        {
            InitializeComponent();
        }
        private void howToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame();
        }
        private void eXcitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button_click(object sender, EventArgs e)
        {
            objTwo.btn = (Button)sender;
            if (objTwo.turn)
            {
                objTwo.btn.Text = "X";
            }
            else
            {
                objTwo.btn.Text = "O";
            }
            checkForWinner();
            objTwo.turn = !objTwo.turn;
            objTwo.btn.Enabled = false;
            objTwo.turn_count++;
        }
        private void checkForWinner()
        {
            //Thread.Sleep(2000);
            //herizontal checks
            if((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled || !A2.Enabled || !A3.Enabled))
            {
                objTwo.check = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled || !B2.Enabled || !B3.Enabled))
            {
                objTwo.check = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled || !C2.Enabled || !C3.Enabled))
            {
                objTwo.check = true;
            }
            //Vertical checks
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled || !B1.Enabled || !C1.Enabled))
            {
                objTwo.check = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled || !B2.Enabled || !C2.Enabled))
            {
                objTwo.check = true;
            }
            else if ((C3.Text == B3.Text) && (B3.Text == A3.Text) && (!A3.Enabled || !B3.Enabled || !C3.Enabled))
            {
                objTwo.check = true;
            }
            //Diagonal checks
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled || !B2.Enabled || !C3.Enabled))
            {
                objTwo.check = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled || !B2.Enabled || !C1.Enabled))
            {
                objTwo.check = true;
            }
            //Print win Or Draw
            if (objTwo.check)
            {
                disableBtn();
                if (objTwo.turn)
                {
                    MessageBox.Show("X is wins! Wow!");
                }
                else
                {
                    MessageBox.Show("O is wins! Wow!");
                }
                objTwo.result = MessageBox.Show("Do you want New Game?", "Confirmation", MessageBoxButtons.YesNo);
            }
            else
            {
                if(objTwo.turn_count == 9)
                {
                    MessageBox.Show("Draw!");
                    objTwo.result = MessageBox.Show("Do you want New Game?", "Confirmation", MessageBoxButtons.YesNo);
                }
            }
            if (objTwo.result == DialogResult.Yes)
            {
                newGame();
            }
        }
        private void disableBtn()
        {
            foreach(Control c in this.Controls)
            {
                if(c is Button)
                {
                    c.Enabled = false;
                }
            }
        }

        private void btn_enter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Enabled)
            {
                if (objTwo.turn)
                {
                    btn.Text = "X";
                }
                else
                {
                    btn.Text = "O";
                }
            }
        }

        private void btn_leave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Enabled)
            {
                btn.Text = "";
            }
        }
        private void newGame()
        {
            this.Close();
            choose_number_player.newGame();
        }
    }
}
