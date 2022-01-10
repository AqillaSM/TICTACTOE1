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

        //Char "X" || "O"
        private char PlayersChar;   
        private char OpponentsChar;
        //Multiplayer
        private Socket sock;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;
        //score
        int counterScorePlayerOne = 0;
        int counterScorePlayerTwo = 0;
        int counterDrawScore = 0;
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
            //baris pertama
            else if (button1.Text == button2.Text && button2.Text == button3.Text && button3.Text == button4.Text && button4.Text
                == button5.Text && button5.Text != "")
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

            else if (button2.Text == button3.Text && button3.Text == button4.Text && button4.Text
                == button5.Text && button5.Text == button6.Text && button6.Text != "")
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

            else if (button3.Text == button4.Text && button4.Text
                == button5.Text && button5.Text == button6.Text && button6.Text == button7.Text && button7.Text != "")
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
            else if (button4.Text == button5.Text && button5.Text == button6.Text && button6.Text == button7.Text && button7.Text == button8.Text
                && button8.Text != "")
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
            else if (button5.Text == button6.Text && button6.Text == button7.Text && button7.Text == button8.Text && button8.Text == button9.Text &&
                button9.Text != "")
            {
                if (button5.Text[0] == PlayersChar)
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
            //baris ke 2
            else if (button10.Text == button11.Text && button11.Text == button12.Text && button12.Text == button13.Text && button13.Text
                == button14.Text && button14.Text != "")
            {
                if (button10.Text[0] == PlayersChar)
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

            else if (button11.Text == button12.Text && button12.Text == button13.Text && button13.Text
                == button14.Text && button14.Text == button15.Text && button15.Text != "")
            {
                if (button11.Text[0] == PlayersChar)
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

            else if (button12.Text == button13.Text && button13.Text == button14.Text &&
                button14.Text == button15.Text && button15.Text == button16.Text && button16.Text != "")
            {
                if (button12.Text[0] == PlayersChar)
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
            else if (button13.Text == button14.Text && button14.Text == button15.Text &&
                button15.Text == button16.Text && button16.Text == button17.Text && button17.Text != "")
            {
                if (button13.Text[0] == PlayersChar)
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
            else if (button14.Text == button15.Text && button15.Text == button16.Text &&
                button16.Text == button17.Text && button17.Text == button18.Text && button18.Text != "")
            {
                if (button14.Text[0] == PlayersChar)
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
            // baris ke 3
            else if (button19.Text == button20.Text && button20.Text == button21.Text && button21.Text == button22.Text && button22.Text
                == button23.Text && button23.Text != "")
            {
                if (button19.Text[0] == PlayersChar)
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

            else if (button20.Text == button21.Text && button21.Text == button22.Text && button22.Text
                == button23.Text && button23.Text == button24.Text && button24.Text != "")
            {
                if (button20.Text[0] == PlayersChar)
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

            else if (button21.Text == button22.Text && button22.Text == button23.Text &&
                button23.Text == button24.Text && button24.Text == button25.Text && button25.Text != "")
            {
                if (button21.Text[0] == PlayersChar)
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
            else if (button22.Text == button23.Text && button23.Text == button24.Text
                && button24.Text == button25.Text && button25.Text == button26.Text && button26.Text != "")
            {
                if (button22.Text[0] == PlayersChar)
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
            else if (button23.Text == button24.Text && button24.Text == button25.Text &&
                button25.Text == button26.Text && button26.Text == button27.Text && button27.Text != "")
            {
                if (button23.Text[0] == PlayersChar)
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
            // baris ke 4
            else if (button28.Text == button29.Text && button29.Text == button30.Text && button30.Text == button31.Text && button31.Text
                == button32.Text && button32.Text != "")
            {
                if (button28.Text[0] == PlayersChar)
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

            else if (button29.Text == button30.Text && button30.Text == button31.Text && button31.Text
                == button32.Text && button32.Text == button33.Text && button33.Text != "")
            {
                if (button29.Text[0] == PlayersChar)
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

            else if (button30.Text == button31.Text && button31.Text == button32.Text &&
                button32.Text == button33.Text && button33.Text == button34.Text && button34.Text != "")
            {
                if (button30.Text[0] == PlayersChar)
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
            else if (button31.Text == button32.Text && button32.Text == button33.Text &&
                button33.Text == button34.Text && button34.Text == button35.Text && button35.Text != "")
            {
                if (button31.Text[0] == PlayersChar)
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
            else if (button32.Text == button33.Text && button33.Text == button34.Text &&
                button34.Text == button35.Text && button35.Text == button36.Text && button36.Text != "")
            {
                if (button32.Text[0] == PlayersChar)
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
            //baris ke 5
            else if (button37.Text == button38.Text && button38.Text == button39.Text && button39.Text == button40.Text && button40.Text
                == button41.Text && button41.Text != "")
            {
                if (button37.Text[0] == PlayersChar)
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

            else if (button38.Text == button39.Text && button39.Text == button40.Text && button40.Text
                == button41.Text && button41.Text == button42.Text && button42.Text != "")
            {
                if (button38.Text[0] == PlayersChar)
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

            else if (button39.Text == button40.Text && button40.Text == button41.Text &&
                button41.Text == button42.Text && button42.Text == button43.Text && button43.Text != "")
            {
                if (button39.Text[0] == PlayersChar)
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
            else if (button40.Text == button41.Text && button41.Text == button42.Text && button42.Text == button43.Text
                && button43.Text == button44.Text && button44.Text != "")
            {
                if (button40.Text[0] == PlayersChar)
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
            else if (button41.Text == button42.Text && button42.Text == button43.Text
                && button43.Text == button44.Text && button44.Text == button45.Text && button45.Text != "")
            {
                if (button41.Text[0] == PlayersChar)
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
            //baris 6
            else if (button46.Text == button47.Text && button47.Text == button48.Text && button48.Text == button49.Text && button49.Text
                == button50.Text && button50.Text != "")
            {
                if (button46.Text[0] == PlayersChar)
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

            else if (button47.Text == button48.Text && button48.Text == button49.Text && button49.Text
                == button50.Text && button50.Text == button51.Text && button51.Text != "")
            {
                if (button47.Text[0] == PlayersChar)
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

            else if (button48.Text == button49.Text && button49.Text == button50.Text && button50.Text ==
                button51.Text && button51.Text == button52.Text && button52.Text != "")
            {
                if (button48.Text[0] == PlayersChar)
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
            else if (button49.Text == button50.Text && button50.Text == button51.Text &&
                button51.Text == button52.Text && button52.Text == button53.Text && button53.Text != "")
            {
                if (button49.Text[0] == PlayersChar)
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
            else if (button50.Text == button51.Text && button51.Text == button52.Text && button52.Text == button53.Text &&
                button53.Text == button54.Text && button54.Text != "")
            {
                if (button50.Text[0] == PlayersChar)
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
            // baris ke 7
            else if (button55.Text == button56.Text && button56.Text == button57.Text && button57.Text == button58.Text && button58.Text
                == button59.Text && button59.Text != "")
            {
                if (button55.Text[0] == PlayersChar)
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

            else if (button56.Text == button57.Text && button57.Text == button58.Text && button58.Text
                == button59.Text && button59.Text == button60.Text && button60.Text != "")
            {
                if (button56.Text[0] == PlayersChar)
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

            else if (button57.Text == button58.Text && button58.Text == button59.Text &&
                button59.Text == button60.Text && button60.Text == button61.Text && button61.Text != "")
            {
                if (button57.Text[0] == PlayersChar)
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
            else if (button58.Text == button59.Text && button59.Text == button60.Text &&
                button60.Text == button61.Text && button61.Text == button62.Text && button62.Text != "")
            {
                if (button58.Text[0] == PlayersChar)
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
            else if (button59.Text == button60.Text && button60.Text == button61.Text && button61.Text == button62.Text &&
                button62.Text == button63.Text && button63.Text != "")
            {
                if (button59.Text[0] == PlayersChar)
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
            // baris ke 8
            else if (button64.Text == button65.Text && button65.Text == button66.Text && button66.Text == button67.Text && button67.Text
                == button68.Text && button68.Text != "")
            {
                if (button64.Text[0] == PlayersChar)
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

            else if (button65.Text == button66.Text && button66.Text == button67.Text && button67.Text
                == button68.Text && button68.Text == button69.Text && button69.Text != "")
            {
                if (button65.Text[0] == PlayersChar)
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

            else if (button66.Text == button67.Text && button67.Text == button68.Text &&
                button68.Text == button69.Text && button69.Text == button70.Text && button70.Text != "")
            {
                if (button66.Text[0] == PlayersChar)
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
            else if (button67.Text == button68.Text && button68.Text == button69.Text && button69.Text == button70.Text &&
                button70.Text == button71.Text && button71.Text != "")
            {
                if (button67.Text[0] == PlayersChar)
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
            else if (button68.Text == button69.Text && button69.Text == button70.Text &&
                button70.Text == button71.Text && button71.Text == button72.Text && button72.Text != "")
            {
                if (button68.Text[0] == PlayersChar)
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
            // baris 9 hore
            else if (button73.Text == button74.Text && button74.Text == button75.Text && button75.Text == button76.Text && button76.Text
                == button77.Text && button77.Text != "")
            {
                if (button73.Text[0] == PlayersChar)
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

            else if (button74.Text == button75.Text && button75.Text == button76.Text && button76.Text
                == button77.Text && button77.Text == button78.Text && button78.Text != "")
            {
                if (button74.Text[0] == PlayersChar)
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

            else if (button75.Text == button76.Text && button76.Text == button77.Text &&
                button77.Text == button78.Text && button78.Text == button79.Text && button79.Text != "")
            {
                if (button75.Text[0] == PlayersChar)
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
            else if (button76.Text == button77.Text && button77.Text == button78.Text && button78.Text == button79.Text
                && button79.Text == button80.Text && button80.Text != "")
            {
                if (button76.Text[0] == PlayersChar)
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
            else if (button77.Text == button78.Text && button78.Text == button79.Text
                && button79.Text == button80.Text && button80.Text == button81.Text && button81.Text != "")
            {
                if (button77.Text[0] == PlayersChar)
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
                counterDrawScore++;
                DrawScore.Text = (counterDrawScore.ToString());
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
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
            button16.Enabled = false;
            button17.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;
            button20.Enabled = false;
            button21.Enabled = false;
            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button25.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;
            button29.Enabled = false;
            button30.Enabled = false;
            button31.Enabled = false;
            button32.Enabled = false;
            button33.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;
            button40.Enabled = false;
            button41.Enabled = false;
            button42.Enabled = false;
            button43.Enabled = false;
            button44.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button47.Enabled = false;
            button48.Enabled = false;
            button49.Enabled = false;
            button50.Enabled = false;
            button51.Enabled = false;
            button52.Enabled = false;
            button53.Enabled = false;
            button54.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;
            button60.Enabled = false;
            button61.Enabled = false;
            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button65.Enabled = false;
            button66.Enabled = false;
            button67.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;
            button70.Enabled = false;
            button71.Enabled = false;
            button72.Enabled = false;
            button73.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;
            button80.Enabled = false;
            button81.Enabled = false;
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
            if (button10.Text == "")
                button10.Enabled = true;
            if (button11.Text == "")
                button11.Enabled = true;
            if (button12.Text == "")
                button12.Enabled = true;
            if (button13.Text == "")
                button13.Enabled = true;
            if (button14.Text == "")
                button14.Enabled = true;
            if (button15.Text == "")
                button15.Enabled = true;
            if (button16.Text == "")
                button16.Enabled = true;
            if (button17.Text == "")
                button17.Enabled = true;
            if (button18.Text == "")
                button18.Enabled = true;
            if (button19.Text == "")
                button19.Enabled = true;
            if (button20.Text == "")
                button20.Enabled = true;
            if (button21.Text == "")
                button21.Enabled = true;
            if (button22.Text == "")
                button22.Enabled = true;
            if (button23.Text == "")
                button23.Enabled = true;
            if (button24.Text == "")
                button24.Enabled = true;
            if (button25.Text == "")
                button25.Enabled = true;
            if (button26.Text == "")
                button26.Enabled = true;
            if (button27.Text == "")
                button27.Enabled = true;
            if (button28.Text == "")
                button28.Enabled = true;
            if (button29.Text == "")
                button29.Enabled = true;
            if (button30.Text == "")
                button30.Enabled = true;
            if (button31.Text == "")
                button31.Enabled = true;
            if (button32.Text == "")
                button32.Enabled = true;
            if (button33.Text == "")
                button33.Enabled = true;
            if (button34.Text == "")
                button34.Enabled = true;
            if (button35.Text == "")
                button35.Enabled = true;
            if (button36.Text == "")
                button36.Enabled = true;
            if (button37.Text == "")
                button37.Enabled = true;
            if (button38.Text == "")
                button38.Enabled = true;
            if (button39.Text == "")
                button39.Enabled = true;
            if (button40.Text == "")
                button40.Enabled = true;
            if (button41.Text == "")
                button41.Enabled = true;
            if (button42.Text == "")
                button42.Enabled = true;
            if (button43.Text == "")
                button43.Enabled = true;
            if (button44.Text == "")
                button44.Enabled = true;
            if (button45.Text == "")
                button45.Enabled = true;
            if (button46.Text == "")
                button46.Enabled = true;
            if (button47.Text == "")
                button47.Enabled = true;
            if (button48.Text == "")
                button48.Enabled = true;
            if (button49.Text == "")
                button49.Enabled = true;
            if (button50.Text == "")
                button50.Enabled = true;
            if (button51.Text == "")
                button51.Enabled = true;
            if (button52.Text == "")
                button52.Enabled = true;
            if (button53.Text == "")
                button53.Enabled = true;
            if (button54.Text == "")
                button54.Enabled = true;
            if (button55.Text == "")
                button55.Enabled = true;
            if (button56.Text == "")
                button56.Enabled = true;
            if (button57.Text == "")
                button57.Enabled = true;
            if (button58.Text == "")
                button58.Enabled = true;
            if (button59.Text == "")
                button59.Enabled = true;
            if (button60.Text == "")
                button60.Enabled = true;
            if (button61.Text == "")
                button61.Enabled = true;
            if (button62.Text == "")
                button62.Enabled = true;
            if (button63.Text == "")
                button63.Enabled = true;
            if (button64.Text == "")
                button64.Enabled = true;
            if (button65.Text == "")
                button65.Enabled = true;
            if (button66.Text == "")
                button66.Enabled = true;
            if (button67.Text == "")
                button67.Enabled = true;
            if (button68.Text == "")
                button68.Enabled = true;
            if (button69.Text == "")
                button69.Enabled = true;
            if (button70.Text == "")
                button70.Enabled = true;
            if (button71.Text == "")
                button71.Enabled = true;
            if (button72.Text == "")
                button72.Enabled = true;
            if (button73.Text == "")
                button73.Enabled = true;
            if (button74.Text == "")
                button74.Enabled = true;
            if (button75.Text == "")
                button75.Enabled = true;
            if (button76.Text == "")
                button76.Enabled = true;
            if (button77.Text == "")
                button77.Enabled = true;
            if (button78.Text == "")
                button78.Enabled = true;
            if (button79.Text == "")
                button79.Enabled = true;
            if (button80.Text == "")
                button80.Enabled = true;
            if (button81.Text == "")
                button81.Enabled = true;
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
            if (buffer[0] == 10)
            {
                button10.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 11)
            {
                button11.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 12)
            {
                button12.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 13)
            {
                button13.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 14)
            {
                button14.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 15)
            {
                button15.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 16)
            {
                button16.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 17)
            {
                button17.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 18)
            {
                button18.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 19)
            {
                button19.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 20)
            {
                button20.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 21)
            {
                button21.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 22)
            {
                button22.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 23)
            {
                button23.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 24)
            {
                button24.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 25)
            {
                button25.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 26)
            {
                button26.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 27)
            {
                button27.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 28)
            {
                button28.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 29)
            {
                button29.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 30)
            {
                button30.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 31)
            {
                button31.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 32)
            {
                button32.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 33)
            {
                button33.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 34)
            {
                button34.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 35)
            {
                button35.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 36)
            {
                button36.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 37)
            {
                button37.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 38)
            {
                button38.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 39)
            {
                button39.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 40)
            {
                button40.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 41)
            {
                button41.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 42)
            {
                button42.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 43)
            {
                button43.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 44)
            {
                button44.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 45)
            {
                button45.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 46)
            {
                button46.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 47)
            {
                button47.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 48)
            {
                button48.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 49)
            {
                button49.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 50)
            {
                button50.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 51)
            {
                button51.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 52)
            {
                button52.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 53)
            {
                button53.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 54)
            {
                button54.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 55)
            {
                button55.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 56)
            {
                button56.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 57)
            {
                button57.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 58)
            {
                button58.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 59)
            {
                button59.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 60)
            {
                button60.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 61)
            {
                button61.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 62)
            {
                button62.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 63)
            {
                button63.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 64)
            {
                button64.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 65)
            {
                button65.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 66)
            {
                button66.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 67)
            {
                button67.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 68)
            {
                button68.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 69)
            {
                button69.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 70)
            {
                button70.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 71)
            {
                button71.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 72)
            {
                button72.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 73)
            {
                button73.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 74)
            {
                button74.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 75)
            {
                button75.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 76)
            {
                button76.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 77)
            {
                button77.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 78)
            {
                button78.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 79)
            {
                button79.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 80)
            {
                button80.Text = OpponentsChar.ToString();
            }
            if (buffer[0] == 81)
            {
                button81.Text = OpponentsChar.ToString();
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
            button10.Text = "";
            button11.Text = "";
            button12.Text = "";
            button13.Text = "";
            button14.Text = "";
            button15.Text = "";
            button16.Text = "";
            button17.Text = "";
            button18.Text = "";
            button19.Text = "";
            button20.Text = "";
            button21.Text = "";
            button22.Text = "";
            button23.Text = "";
            button24.Text = "";
            button25.Text = "";
            button26.Text = "";
            button27.Text = "";
            button28.Text = "";
            button29.Text = "";
            button30.Text = "";
            button31.Text = "";
            button32.Text = "";
            button33.Text = "";
            button34.Text = "";
            button35.Text = "";
            button36.Text = "";
            button37.Text = "";
            button38.Text = "";
            button39.Text = "";
            button40.Text = "";
            button41.Text = "";
            button42.Text = "";
            button43.Text = "";
            button44.Text = "";
            button45.Text = "";
            button46.Text = "";
            button47.Text = "";
            button48.Text = "";
            button49.Text = "";
            button50.Text = "";
            button51.Text = "";
            button52.Text = "";
            button53.Text = "";
            button54.Text = "";
            button55.Text = "";
            button56.Text = "";
            button57.Text = "";
            button58.Text = "";
            button59.Text = "";
            button60.Text = "";
            button61.Text = "";
            button62.Text = "";
            button63.Text = "";
            button64.Text = "";
            button65.Text = "";
            button66.Text = "";
            button67.Text = "";
            button68.Text = "";
            button69.Text = "";
            button70.Text = "";
            button71.Text = "";
            button72.Text = "";
            button73.Text = "";
            button74.Text = "";
            button75.Text = "";
            button76.Text = "";
            button77.Text = "";
            button78.Text = "";
            button79.Text = "";
            button80.Text = "";
            button81.Text = "";
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
            byte[] num = { 10 };
            sock.Send(num);
            button10.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            byte[] num = { 11 };
            sock.Send(num);
            button11.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            byte[] num = { 12 };
            sock.Send(num);
            button12.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            byte[] num = { 13 };
            sock.Send(num);
            button13.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            byte[] num = { 14 };
            sock.Send(num);
            button14.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            byte[] num = { 15 };
            sock.Send(num);
            button15.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            byte[] num = { 16 };
            sock.Send(num);
            button16.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            byte[] num = { 17 };
            sock.Send(num);
            button17.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            byte[] num = { 18 };
            sock.Send(num);
            button18.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            byte[] num = { 19 };
            sock.Send(num);
            button19.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            byte[] num = { 20 };
            sock.Send(num);
            button20.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            byte[] num = { 21 };
            sock.Send(num);
            button21.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            byte[] num = { 22 };
            sock.Send(num);
            button22.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            byte[] num = { 23 };
            sock.Send(num);
            button23.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            byte[] num = { 24 };
            sock.Send(num);
            button24.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            byte[] num = { 25 };
            sock.Send(num);
            button25.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            byte[] num = { 26 };
            sock.Send(num);
            button26.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            byte[] num = { 27 };
            sock.Send(num);
            button27.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            byte[] num = { 28 };
            sock.Send(num);
            button28.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            byte[] num = { 29 };
            sock.Send(num);
            button29.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            byte[] num = { 30 };
            sock.Send(num);
            button30.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            byte[] num = { 31 };
            sock.Send(num);
            button31.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            byte[] num = { 32 };
            sock.Send(num);
            button32.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            byte[] num = { 33 };
            sock.Send(num);
            button33.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            byte[] num = { 34 };
            sock.Send(num);
            button34.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            byte[] num = { 35 };
            sock.Send(num);
            button35.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            byte[] num = { 36 };
            sock.Send(num);
            button36.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            byte[] num = { 37 };
            sock.Send(num);
            button37.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            byte[] num = { 38 };
            sock.Send(num);
            button38.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            byte[] num = { 39 };
            sock.Send(num);
            button39.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            byte[] num = { 40 };
            sock.Send(num);
            button40.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            byte[] num = { 41 };
            sock.Send(num);
            button41.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            byte[] num = { 42 };
            sock.Send(num);
            button42.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            byte[] num = { 43 };
            sock.Send(num);
            button43.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            byte[] num = { 44 };
            sock.Send(num);
            button44.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            byte[] num = { 45 };
            sock.Send(num);
            button45.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            byte[] num = { 46 };
            sock.Send(num);
            button46.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            byte[] num = { 47 };
            sock.Send(num);
            button47.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            byte[] num = { 48 };
            sock.Send(num);
            button48.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            byte[] num = { 49 };
            sock.Send(num);
            button49.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            byte[] num = { 50 };
            sock.Send(num);
            button50.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            byte[] num = { 51 };
            sock.Send(num);
            button51.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            byte[] num = { 52 };
            sock.Send(num);
            button52.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            byte[] num = { 53 };
            sock.Send(num);
            button53.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            byte[] num = { 54 };
            sock.Send(num);
            button54.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            byte[] num = { 55 };
            sock.Send(num);
            button55.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button56_Click(object sender, EventArgs e)
        {
            byte[] num = { 56 };
            sock.Send(num);
            button56.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            byte[] num = { 57 };
            sock.Send(num);
            button57.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button58_Click(object sender, EventArgs e)
        {
            byte[] num = { 58 };
            sock.Send(num);
            button58.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button59_Click(object sender, EventArgs e)
        {
            byte[] num = { 59 };
            sock.Send(num);
            button59.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button60_Click(object sender, EventArgs e)
        {
            byte[] num = { 60 };
            sock.Send(num);
            button60.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button61_Click(object sender, EventArgs e)
        {
            byte[] num = { 61 };
            sock.Send(num);
            button61.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button62_Click(object sender, EventArgs e)
        {
            byte[] num = { 62 };
            sock.Send(num);
            button62.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button63_Click(object sender, EventArgs e)
        {
            byte[] num = { 63 };
            sock.Send(num);
            button63.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button64_Click(object sender, EventArgs e)
        {
            byte[] num = { 64 };
            sock.Send(num);
            button64.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button65_Click(object sender, EventArgs e)
        {
            byte[] num = { 65 };
            sock.Send(num);
            button65.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            byte[] num = { 66 };
            sock.Send(num);
            button66.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button67_Click(object sender, EventArgs e)
        {
            byte[] num = { 67 };
            sock.Send(num);
            button67.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button68_Click(object sender, EventArgs e)
        {
            byte[] num = { 68 };
            sock.Send(num);
            button68.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button69_Click(object sender, EventArgs e)
        {
            byte[] num = { 69 };
            sock.Send(num);
            button69.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button70_Click(object sender, EventArgs e)
        {
            byte[] num = { 70 };
            sock.Send(num);
            button70.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button71_Click(object sender, EventArgs e)
        {
            byte[] num = { 71 };
            sock.Send(num);
            button71.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button72_Click(object sender, EventArgs e)
        {
            byte[] num = { 72 };
            sock.Send(num);
            button72.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button73_Click(object sender, EventArgs e)
        {
            byte[] num = { 73 };
            sock.Send(num);
            button73.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button74_Click(object sender, EventArgs e)
        {
            byte[] num = { 74 };
            sock.Send(num);
            button74.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button75_Click(object sender, EventArgs e)
        {
            byte[] num = { 75 };
            sock.Send(num);
            button75.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button76_Click(object sender, EventArgs e)
        {
            byte[] num = { 76 };
            sock.Send(num);
            button76.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button77_Click(object sender, EventArgs e)
        {
            byte[] num = { 77 };
            sock.Send(num);
            button77.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button78_Click(object sender, EventArgs e)
        {
            byte[] num = { 78 };
            sock.Send(num);
            button78.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button79_Click(object sender, EventArgs e)
        {
            byte[] num = { 79 };
            sock.Send(num);
            button79.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button80_Click(object sender, EventArgs e)
        {
            byte[] num = { 80 };
            sock.Send(num);
            button80.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
        }

        private void button81_Click(object sender, EventArgs e)
        {
            byte[] num = { 81 };
            sock.Send(num);
            button81.Text = PlayersChar.ToString();
            CheckSituation();
            MessageReceiver.RunWorkerAsync();
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
            counterDrawScore = 0;
            YoursScore.Text = counterScorePlayerOne.ToString();
            OpponentsScore.Text = counterScorePlayerTwo.ToString();
            DrawScore.Text = counterDrawScore.ToString();
        }
    }
}
