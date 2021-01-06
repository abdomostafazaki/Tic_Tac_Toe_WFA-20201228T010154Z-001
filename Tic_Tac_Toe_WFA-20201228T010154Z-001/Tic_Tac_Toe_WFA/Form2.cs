using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_WFA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        ControlGame obj = new ControlGame(1);

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
            obj.btn = (Button)sender;
            if (obj.turn)
            {
                obj.btn.Text = "X";
            }
            else
            {
                obj.btn.Text = "O";
            }
            checkForWinner();
            obj.turn = !obj.turn;
            obj.btn.Enabled = false;
            obj.turn_count++;
            if (obj.turn)
            {
                computer_make_move();
            }
        }
        private void checkForWinner()
        {
            //Thread.Sleep(2000);
            //herizontal checks
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled || !A2.Enabled || !A3.Enabled))
            {
                obj.check = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled || !B2.Enabled || !B3.Enabled))
            {
                obj.check = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled || !C2.Enabled || !C3.Enabled))
            {
                obj.check = true;
            }
            //Vertical checks
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled || !B1.Enabled || !C1.Enabled))
            {
                obj.check = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled || !B2.Enabled || !C2.Enabled))
            {
                obj.check = true;
            }
            else if ((C3.Text == B3.Text) && (B3.Text == A3.Text) && (!A3.Enabled || !B3.Enabled || !C3.Enabled))
            {
                obj.check = true;
            }
            //Diagonal checks
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled || !B2.Enabled || !C3.Enabled))
            {
                obj.check = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled || !B2.Enabled || !C1.Enabled))
            {
                obj.check = true;
            }
            //Print win Or Draw
            if (obj.check)
            {
                if (obj.turn)
                {
                    MessageBox.Show("Computer is wins! Game Over!");
                }
                else
                {
                    MessageBox.Show("You is wins! Wow!");
                }
                obj.result = MessageBox.Show("Do you want New Game?", "Confirmation", MessageBoxButtons.YesNo);
                disableBtn();
            }
            else
            {
                if (obj.turn_count == 9)
                {
                    MessageBox.Show("Draw!");
                    obj.result = MessageBox.Show("Do you want New Game?", "Confirmation", MessageBoxButtons.YesNo);
                }
            }
            if (obj.result == DialogResult.Yes)
            {
                newGame();
            }
        }
        private void disableBtn()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button)
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
                if (!obj.turn)
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
            choose_number_player.newGameComputer();
        }
        private void computer_make_move()
        {
            //priority 1:  get tick tac toe
            //priority 2:  block x tic tac toe
            //priority 3:  go for corner space
            //priority 4:  pick open space

            Button move = null;

            //look for tic tac toe opportunities
            move = look_for_win_or_block("O"); //look for win
            if (move == null)
            {
                move = look_for_win_or_block("X"); //look for block
                if (move == null)
                {
                    move = look_for_corner();
                    if (move == null)
                    {
                        move = look_for_open_space();
                    }//end if
                }//end if
            }//end if
            if(move == null)
            {
                move = look_for_open_space();
                move.PerformClick();
            }
            else
            {
                move.PerformClick();
            }
        }

        private Button look_for_open_space()
        {
            Console.WriteLine("Looking for open space");
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b != null)
                {
                    if (b.Text == "")
                        return b;
                }//end if
            }//end if

            return null;
        }

        private Button look_for_corner()
        {
            Console.WriteLine("Looking for corner");
            if (A1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (A3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (C3.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
            }

            if (C1.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
            }

            if (A1.Text == "")
                return A1;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
            if (C3.Text == "")
                return C3;

            return null;
        }

        private Button look_for_win_or_block(string mark)
        {

            //HORIZONTAL TESTS
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (A3.Text == mark) && (A2.Text == ""))
                return A2;

            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
                return B3;
            if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B1.Text == mark) && (B3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
                return C1;
            if ((C1.Text == mark) && (C3.Text == mark) && (C2.Text == ""))
                return C2;

            //VERTICAL TESTS
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
                return B1;

            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
                return C2;
            if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
                return A2;
            if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
                return B3;

            //DIAGONAL TESTS
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
                return B2;

            return null;
        }
    }
}
