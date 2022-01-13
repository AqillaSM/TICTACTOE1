using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TICTACTOE1
{
    public partial class design_kotak_ip : Form
    {
        
        public design_kotak_ip()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void design_kotak_ip_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newGame = new Form1(false, textBox1.Text);
            Visible = false;
            if (!newGame.IsDisposed)
            {
                newGame.ShowDialog();
            }
            Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 newGame = new Form1(true);
            Visible = false;
            if (!newGame.IsDisposed)
            {
                newGame.ShowDialog(); 
                Visible = true;
            }
        }
        public void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
