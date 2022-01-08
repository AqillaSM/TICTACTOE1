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
        public Form1(bool isHost, string ip = null)
        {
            
            InitializeComponent();
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            CheckForIllegalCrossThreadCalls = false;
            

            if (isHost)
            {
                PlayersChar = 'X';
                OpponentsChar = 'O';
                server = new TcpListener(System.Net.IPAddress.Any, 5732);
                server.Start();
                sock = server.AcceptSocket(); 
                nama.Text = Name;

            }
            else
            {
                PlayersChar = 'O';
                OpponentsChar = 'X';
                try
                {
                    client = new TcpClient(ip, 5732);
                    sock = client.Client;
                    MessageReceiver.RunWorkerAsync();
                    nama2.Text = Name;

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    Close();
                }
                
            }

        }

        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            if (CheckSituation())
            {
                return;
            }
            FreezeBoard();
            label7.Text = $"Opponents's Turn";
            ReceiveMove();
            label7.Text = $"Your Turn!";
            if (!CheckSituation())
            {
                UnfreezeBoard();
            }
        }

        private char PlayersChar;   
        private char OpponentsChar;
        private Socket sock;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;
        int counterScorePlayerOne = 0;
        int counterScorePlayerTwo = 0;
        private bool CheckSituation()
        {
            //Verticals Win
            if (button1.Text == button4.Text && button4.Text == button7.Text && button7.Text != "")
            {
                if (button1.Text[0] == PlayersChar)
                {
                    label7.Text = "You Won!";
                    counterScorePlayerOne++;
                    label4.Text = counterScorePlayerOne.ToString();
                    MessageBox.Show($"{Name} Won!");
                }
                else
                {
                    label7.Text = "You Lost!";
                    counterScorePlayerTwo++;
                    label6.Text = counterScorePlayerTwo.ToString();
                    MessageBox.Show($"{Name} Lost!");
                }
                return true;
            }

            else if (button2.Text == button5.Text && button5.Text == button8.Text && button8.Text != "")
            {
                if (button2.Text[0] == PlayersChar)
                {
                    label7.Text = "You Won!";
                    counterScorePlayerOne++;
                    label4.Text = counterScorePlayerOne.ToString();
                    MessageBox.Show($"{Name} Won!");
                }
                else
                {
                    label7.Text = "You Lost!";
                    counterScorePlayerTwo++;
                    label6.Text = counterScorePlayerTwo.ToString();
                    MessageBox.Show($"{Name} Lost!");
                }
                return true;
            }

            else if (button3.Text == button6.Text && button6.Text == button9.Text && button9.Text != "")
            {
                if (button3.Text[0] == PlayersChar)
                {
                    label7.Text = "You Won!";
                    counterScorePlayerOne++;
                    label4.Text = counterScorePlayerOne.ToString();
                    MessageBox.Show($"{Name} Won!");
                }
                else
                {
                    label7.Text = "You Lost!";
                    counterScorePlayerTwo++;
                    label6.Text = counterScorePlayerTwo.ToString();
                    MessageBox.Show($"{Name} Lost!");
                }
                return true;
            }

            else if (button1.Text == button5.Text && button5.Text == button9.Text && button9.Text != "")
            {
                if (button1.Text[0] == PlayersChar)
                {
                    label7.Text = "You Won!";
                    counterScorePlayerOne++;
                    label4.Text = counterScorePlayerOne.ToString();
                    MessageBox.Show($"{Name} Won!");
                }
                else
                {
                    label7.Text = "You Lost!";
                    counterScorePlayerTwo++;
                    label6.Text = counterScorePlayerTwo.ToString();
                    MessageBox.Show($"{Name} Lost!");
                }
                return true;
            }

            else if (button3.Text == button5.Text && button5.Text == button7.Text && button7.Text != "")
            {
                if (button3.Text[0] == PlayersChar)
                {
                    label7.Text = "You Won!";
                    counterScorePlayerOne++;
                    label4.Text = counterScorePlayerOne.ToString();
                    MessageBox.Show($"{Name} Won!");
                }
                else
                {
                    label7.Text = "You Lost!";
                    counterScorePlayerTwo++;
                    label6.Text = counterScorePlayerTwo.ToString();
                    MessageBox.Show($"{Name} Lost!");
                }
                return true;
            }

            //Horizontals Win
            else if (button1.Text == button2.Text && button2.Text == button3.Text && button3.Text != "")
            {
                if (button1.Text[0] == PlayersChar)
                {
                    label7.Text = "You Won!";
                    counterScorePlayerOne++;
                    label4.Text = counterScorePlayerOne.ToString();
                    MessageBox.Show($"{Name} Won!");
                }
                else
                {
                    label7.Text = "You Lost!";
                    counterScorePlayerTwo++;
                    label6.Text = counterScorePlayerTwo.ToString();
                    MessageBox.Show($"{Name} Lost!");
                }
                return true;
            }

            else if (button4.Text == button5.Text && button5.Text == button6.Text && button6.Text != "")
            {
                if (button4.Text[0] == PlayersChar)
                {
                    label7.Text = "You Won!";
                    counterScorePlayerOne++;
                    label4.Text = counterScorePlayerOne.ToString();
                    MessageBox.Show($"{Name} Won!");
                }
                else
                {
                    label7.Text = "You Lost!";
                    counterScorePlayerTwo++;
                    label6.Text = counterScorePlayerTwo.ToString();
                    MessageBox.Show($"{Name} Lost!");
                }
                return true;
            }

            else if (button7.Text == button8.Text && button8.Text == button9.Text && button9.Text != "")
            {
                if (button7.Text[0] == PlayersChar)
                {
                    label7.Text = "You Won!";
                    counterScorePlayerOne++;
                    label4.Text = counterScorePlayerOne.ToString();
                    MessageBox.Show($"{Name} Won!");
                }
                else
                {
                    label7.Text = "You Lost!";
                    counterScorePlayerTwo++;
                    label6.Text = counterScorePlayerTwo.ToString();
                    MessageBox.Show($"{Name} Lost!");
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

        private void ReceiveMove()
        {
            byte[] buffer = new byte[1];
            sock.Receive(buffer);
            if (buffer[0] == 1)
            {
                button1.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 2)
            {
                button2.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 3)
            {
                button3.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 4)
            {
                button4.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 5)
            {
                button5.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 6)
            {
                button6.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 7)
            {
                button7.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 8)
            {
                button8.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 9)
            {
                button9.Text = OpponentsChar.ToString();
            }

        }
        private void ClearBoard()
        {
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
        }

            private void button1_Click(object sender, EventArgs e)
        {
            byte[] num = { 1 };
            sock.Send(num);
            button1.Text = PlayersChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            byte[] num = { 2 };
            sock.Send(num);
            button2.Text = PlayersChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            byte[] num = { 3 };
            sock.Send(num);
            button3.Text = PlayersChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            byte[] num = { 4 };
            sock.Send(num);
            button4.Text = PlayersChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            byte[] num = { 5 };
            sock.Send(num);
            button5.Text = PlayersChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            byte[] num = { 6 };
            sock.Send(num);
            button6.Text = PlayersChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            byte[] num = { 7 };
            sock.Send(num);
            button7.Text = PlayersChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            byte[] num = { 8 };
            sock.Send(num);
            button8.Text = PlayersChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            byte[] num = { 9 };
            sock.Send(num);
            button9.Text = PlayersChar.ToString();
            MessageReceiver.RunWorkerAsync();
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
            //ClearBoard();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            counterScorePlayerOne = 0;
            counterScorePlayerTwo = 0;
            label4.Text = counterScorePlayerOne.ToString();
            label6.Text = counterScorePlayerTwo.ToString();
        }

        private void nama_Click(object sender, EventArgs e)
        {
            
        }

        private void nama2_Click(object sender, EventArgs e)
        {

        }
    }
}
