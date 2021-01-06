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
    public partial class choose_number_player : Form
    {
        public choose_number_player()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
        }
        public static void newGame()
        {
            Form1 obj = new Form1();
            obj.Show();
        }
        public static void newGameComputer()
        {
            Form2 obj = new Form2();
            obj.Show();
        }
    }
}
