using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets; //untuk send ke app lain

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
                YoursLabel.Text = Name;

            }
            else
            {
                PlayersChar = 'O';
                OpponentsChar = 'X';
                //design_kotak_ip Namaku = new design_kotak_ip();
                //label1.Text = Namaku.Name;
                try
                {
                    client = new TcpClient(ip, 5732);
                    sock = client.Client;
                    MessageReceiver.RunWorkerAsync();
                    OpponentsLabel.Text = Name;

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
            TurnLabel.Text = $"Opponents's Turn";
            ReceiveMove();
            TurnLabel.Text = $"Your Turn!";
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
                    TurnLabel.Text = "You Won!";
                    counterScorePlayerOne++;
                    YoursScore.Text = counterScorePlayerOne.ToString();
                    MessageBox.Show($"{Name} Won!");
                    ClearBoard();
                    
                }
                else
                {
                    TurnLabel.Text = "You Lost!";
                    counterScorePlayerTwo++;
                    OpponentsScore.Text = counterScorePlayerTwo.ToString();
                    MessageBox.Show($"{Name} Lost!");
                    ClearBoard();
                }
                return true;
            }

            else if (button2.Text == button5.Text && button5.Text == button8.Text && button8.Text != "")
            {
                if (button2.Text[0] == PlayersChar)
                {
                    TurnLabel.Text = "You Won!";
                    counterScorePlayerOne++;
                    YoursScore.Text = counterScorePlayerOne.ToString();
                    MessageBox.Show($"{Name} Won!");
                    ClearBoard();
                }
                else
                {
                    TurnLabel.Text = "You Lost!";
                    counterScorePlayerTwo++;
                    OpponentsScore.Text = counterScorePlayerTwo.ToString();
                    MessageBox.Show($"{Name} Lost!");
                    ClearBoard();
                }
                return true;
            }

            else if (button3.Text == button6.Text && button6.Text == button9.Text && button9.Text != "")
            {
                if (button3.Text[0] == PlayersChar)
                {
                    TurnLabel.Text = "You Won!";
                    counterScorePlayerOne++;
                    YoursScore.Text = counterScorePlayerOne.ToString();
                    MessageBox.Show($"{Name} Won!");
                    ClearBoard();
                }
                else
                {
                    TurnLabel.Text = "You Lost!";
                    counterScorePlayerTwo++;
                    OpponentsScore.Text = counterScorePlayerTwo.ToString();
                    MessageBox.Show($"{Name} Lost!");
                    ClearBoard();
                }
                return true;
            }

            //Diagonal Win
            else if (button1.Text == button5.Text && button5.Text == button9.Text && button9.Text != "")
            {
                if (button1.Text[0] == PlayersChar)
                {
                    TurnLabel.Text = "You Won!";
                    counterScorePlayerOne++;
                    YoursScore.Text = counterScorePlayerOne.ToString();
                    MessageBox.Show($"{Name} Won!");
                    ClearBoard();
                }
                else
                {
                    TurnLabel.Text = "You Lost!";
                    counterScorePlayerTwo++;
                    OpponentsScore.Text = counterScorePlayerTwo.ToString();
                    MessageBox.Show($"{Name} Lost!");
                    ClearBoard();
                }
                return true;
            }

            else if (button3.Text == button5.Text && button5.Text == button7.Text && button7.Text != "")
            {
                if (button3.Text[0] == PlayersChar)
                {
                    TurnLabel.Text = "You Won!";
                    counterScorePlayerOne++;
                    YoursScore.Text = counterScorePlayerOne.ToString();
                    MessageBox.Show($"{Name} Won!");
                    ClearBoard();
                }
                else
                {
                    TurnLabel.Text = "You Lost!";
                    counterScorePlayerTwo++;
                    OpponentsScore.Text = counterScorePlayerTwo.ToString();
                    MessageBox.Show($"{Name} Lost!");
                    ClearBoard();
                }
                return true;
            }

            //Horizontals Win
            else if (button1.Text == button2.Text && button2.Text == button3.Text && button3.Text != "")
            {
                if (button1.Text[0] == PlayersChar)
                {
                    TurnLabel.Text = "You Won!";
                    counterScorePlayerOne++;
                    YoursScore.Text = counterScorePlayerOne.ToString();
                    MessageBox.Show($"{Name} Won!");
                    ClearBoard();
                }
                else
                {
                    TurnLabel.Text = "You Lost!";
                    counterScorePlayerTwo++;
                    OpponentsScore.Text = counterScorePlayerTwo.ToString();
                    MessageBox.Show($"{Name} Lost!");
                    ClearBoard();
                }
                return true;
            }

            else if (button4.Text == button5.Text && button5.Text == button6.Text && button6.Text != "")
            {
                if (button4.Text[0] == PlayersChar)
                {
                    TurnLabel.Text = "You Won!";
                    counterScorePlayerOne++;
                    YoursScore.Text = counterScorePlayerOne.ToString();
                    MessageBox.Show($"{Name} Won!");
                    ClearBoard();
                }
                else
                {
                    TurnLabel.Text = "You Lost!";
                    counterScorePlayerTwo++;
                    OpponentsScore.Text = counterScorePlayerTwo.ToString();
                    MessageBox.Show($"{Name} Lost!");
                    ClearBoard();
                }
                return true;
            }

            else if (button7.Text == button8.Text && button8.Text == button9.Text && button9.Text != "")
            {
                if (button7.Text[0] == PlayersChar)
                {
                    TurnLabel.Text = "You Won!";
                    counterScorePlayerOne++;
                    YoursScore.Text = counterScorePlayerOne.ToString();
                    MessageBox.Show($"{Name} Won!");
                    ClearBoard();
                }
                else
                {
                    TurnLabel.Text = "You Lost!";
                    counterScorePlayerTwo++;
                    OpponentsScore.Text = counterScorePlayerTwo.ToString();
                    MessageBox.Show($"{Name} Lost!");
                    ClearBoard();
                }
                return true;
            }

            //Draw
            else if (button1.Text != "" && button2.Text != "" && button3.Text != "" && button4.Text != "" && button5.Text != "" && button6.Text != "" && button7.Text != "" && button8.Text != "" && button9.Text != "")
            {
                TurnLabel.Text = "It's a draw!";
                MessageBox.Show("It's a draw!");
                ClearBoard();
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
            CheckSituation();
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
            UnfreezeBoard();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] num = { 1 };
            sock.Send(num);
            button1.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            byte[] num = { 2 };
            sock.Send(num);
            button2.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            byte[] num = { 3 };
            sock.Send(num);
            button3.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            byte[] num = { 4 };
            sock.Send(num);
            button4.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            byte[] num = { 5 };
            sock.Send(num);
            button5.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            byte[] num = { 6 };
            sock.Send(num);
            button6.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            byte[] num = { 7 };
            sock.Send(num);
            button7.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            byte[] num = { 8 };
            sock.Send(num);
            button8.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            byte[] num = { 9 };
            sock.Send(num);
            button9.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {

        }

        private void button32_Click(object sender, EventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {

        }

        private void button34_Click(object sender, EventArgs e)
        {

        }

        private void button35_Click(object sender, EventArgs e)
        {

        }

        private void button36_Click(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {

        }

        private void button38_Click(object sender, EventArgs e)
        {

        }

        private void button39_Click(object sender, EventArgs e)
        {

        }

        private void button40_Click(object sender, EventArgs e)
        {

        }

        private void button41_Click(object sender, EventArgs e)
        {

        }

        private void button42_Click(object sender, EventArgs e)
        {

        }

        private void button43_Click(object sender, EventArgs e)
        {

        }

        private void button44_Click(object sender, EventArgs e)
        {

        }

        private void button45_Click(object sender, EventArgs e)
        {

        }

        private void button46_Click(object sender, EventArgs e)
        {

        }

        private void button47_Click(object sender, EventArgs e)
        {

        }

        private void button48_Click(object sender, EventArgs e)
        {

        }

        private void button49_Click(object sender, EventArgs e)
        {

        }

        private void button50_Click(object sender, EventArgs e)
        {

        }

        private void button51_Click(object sender, EventArgs e)
        {

        }

        private void button52_Click(object sender, EventArgs e)
        {

        }

        private void button53_Click(object sender, EventArgs e)
        {

        }

        private void button54_Click(object sender, EventArgs e)
        {

        }

        private void button55_Click(object sender, EventArgs e)
        {

        }

        private void button56_Click(object sender, EventArgs e)
        {

        }

        private void button57_Click(object sender, EventArgs e)
        {

        }

        private void button58_Click(object sender, EventArgs e)
        {

        }

        private void button59_Click(object sender, EventArgs e)
        {

        }

        private void button60_Click(object sender, EventArgs e)
        {

        }

        private void button61_Click(object sender, EventArgs e)
        {

        }

        private void button62_Click(object sender, EventArgs e)
        {

        }

        private void button63_Click(object sender, EventArgs e)
        {

        }

        private void button64_Click(object sender, EventArgs e)
        {

        }

        private void button65_Click(object sender, EventArgs e)
        {

        }

        private void button66_Click(object sender, EventArgs e)
        {

        }

        private void button67_Click(object sender, EventArgs e)
        {

        }

        private void button68_Click(object sender, EventArgs e)
        {

        }

        private void button69_Click(object sender, EventArgs e)
        {

        }

        private void button70_Click(object sender, EventArgs e)
        {

        }

        private void button71_Click(object sender, EventArgs e)
        {

        }

        private void button72_Click(object sender, EventArgs e)
        {

        }

        private void button73_Click(object sender, EventArgs e)
        {

        }

        private void button74_Click(object sender, EventArgs e)
        {

        }

        private void button75_Click(object sender, EventArgs e)
        {

        }

        private void button76_Click(object sender, EventArgs e)
        {

        }

        private void button77_Click(object sender, EventArgs e)
        {

        }

        private void button78_Click(object sender, EventArgs e)
        {

        }

        private void button79_Click(object sender, EventArgs e)
        {

        }

        private void button80_Click(object sender, EventArgs e)
        {

        }

        private void button81_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
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

        private void ExitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ResetScore_Click_1(object sender, EventArgs e)
        {
            counterScorePlayerOne = 0;
            counterScorePlayerTwo = 0;
            YoursScore.Text = counterScorePlayerOne.ToString();
            OpponentsScore.Text = counterScorePlayerTwo.ToString();
        }
    }
}
