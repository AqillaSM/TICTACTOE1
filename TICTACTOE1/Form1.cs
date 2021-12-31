using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace TICTACTOE1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private char PlayersChar;
        private char OpponentsChar;
        private Socket sock;
        private bool CheckSituation()
        {
            //Verticals Win
            if (button1.Text == button4.Text && button4.Text == button7.Text && button7.Text != "")
            {
                if (button1.Text[0] == PlayersChar)
                {
                    label7.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label7.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button2.Text == button5.Text && button5.Text == button8.Text && button8.Text != "")
            {
                if (button2.Text[0] == PlayersChar)
                {
                    label7.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label7.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button3.Text == button6.Text && button6.Text == button9.Text && button9.Text != "")
            {
                if (button3.Text[0] == PlayersChar)
                {
                    label7.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label7.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button1.Text == button5.Text && button5.Text == button9.Text && button9.Text != "")
            {
                if (button1.Text[0] == PlayersChar)
                {
                    label7.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label7.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button3.Text == button5.Text && button5.Text == button7.Text && button7.Text != "")
            {
                if (button3.Text[0] == PlayersChar)
                {
                    label7.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label7.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            //Horizontals Win
            else if (button1.Text == button2.Text && button2.Text == button3.Text && button3.Text != "")
            {
                if (button1.Text[0] == PlayersChar)
                {
                    label7.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label7.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button4.Text == button5.Text && button5.Text == button6.Text && button6.Text != "")
            {
                if (button4.Text[0] == PlayersChar)
                {
                    label7.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label7.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button7.Text == button8.Text && button8.Text == button9.Text && button9.Text != "")
            {
                if (button7.Text[0] == PlayersChar)
                {
                    label7.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label7.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            //Draw
            else if (button1.Text != "" && button2.Text != "" && button3.Text != "" && button4.Text != "" && button5.Text != "" && button6.Text != "" && button7.Text != "" && button8.Text != "" && button9.Text != "")
            {
                label7.Text = "It's a draw!";
                MessageBox.Show("It's a draw!");
                return true;
            }
            return false;
        }
        private void FreezeBoard()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }
        private void UnfreezeBoard()
        {
            if (button1.Text == "")
                button1.Enabled = true;
            if (button2.Text == "")
                button2.Enabled = true;
            if (button3.Text == "")
                button3.Enabled = true;
            if (button4.Text == "")
                button4.Enabled = true;
            if (button5.Text == "")
                button5.Enabled = true;
            if (button6.Text == "")
                button6.Enabled = true;
            if (button7.Text == "")
                button7.Enabled = true;
            if (button8.Text == "")
                button8.Enabled = true;
            if (button9.Text == "")
                button9.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click_1(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void button6_Click(object sender, EventArgs e)
        {

        }
        private void button7_Click(object sender, EventArgs e)
        {

        }
        private void button8_Click(object sender, EventArgs e)
        {

        }
        private void button9_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
       
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}
