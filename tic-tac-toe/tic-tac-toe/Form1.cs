using System;
using System.Drawing;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {

        private int player = 1;
        private Button[,] buttons = new Button[3, 3];
        
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < buttons.Length / 3; i++)
            {
                for (int j = 0; j < buttons.Length / 3; j++)
                {
                    buttons[i, j] = new Button();
                }
            }
            setButtons();
        }

        private void setButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j <  3; j++)
                {

                    buttons[i,j].Size = new System.Drawing.Size(100, 100);
                    buttons[i,j].Text = "";
                    buttons[i,j].Click += gameButton_Click;
                    buttons[i,j].Location = new Point(9 + 106 * j, 52 + 106 * i);
                    buttons[i,j].Font = new Font(new FontFamily("Microsoft Sans Serif"), 25);
                    this.Controls.Add(buttons[i,j]);
                }
            }
        }

        private void gameButton_Click(object sender, EventArgs e)
        {
            ((Button)sender).Text = player == 1 ? "X" : "O";
            ((Button)sender).Enabled = false;
            if (winCheck())
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        buttons[i, j].Enabled = false;
                    }
                }
                DialogResult res = MessageBox.Show($"Выиграл Игрок {player}", "Конец игры", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                if (res == DialogResult.Retry)
                {
                    restartGame();
                }
            }
            else
            {
                player = player == 1 ? 2 : 1;
                label1.Text = $"Ходит: Игрок {player}";
            }
        }

        private bool winCheck()
        {
            bool win = false;
            if (buttons[0, 0].Text == buttons[0, 1].Text && buttons[0, 1].Text == buttons[0, 2].Text && buttons[0, 0].Text != "")
            {
                win = true;
            }
            else if(buttons[1, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[1, 2].Text && buttons[1, 0].Text != "")
            {
                win = true;
            }
            else if (buttons[2, 0].Text == buttons[2, 1].Text && buttons[2, 1].Text == buttons[2, 2].Text && buttons[2, 0].Text != "")
            {
                win = true;
            }
            else if (buttons[0, 0].Text == buttons[1, 0].Text && buttons[1, 0].Text == buttons[2, 0].Text && buttons[0, 0].Text != "")
            {
                win = true;
            }
            else if (buttons[0, 1].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 1].Text && buttons[0, 1].Text != "")
            {
                win = true;
            }
            else if (buttons[0, 2].Text == buttons[1, 2].Text && buttons[1, 2].Text == buttons[2, 2].Text && buttons[0, 2].Text != "")
            {
                win = true;
            }
            else if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text && buttons[0, 0].Text != "")
            {
                win = true;
            }
            else if (buttons[0, 2].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 0].Text && buttons[0, 2].Text != "")
            {
                win = true;
            }
            return win;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void restart_Click(object sender, EventArgs e)
        {
            restartGame();
        }
        private void restartGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = "";
                    buttons[i, j].Enabled = true;
                }
            }
            player = 1;
            label1.Text = $"Ходит: Игрок {player}";
        }
    }
}
