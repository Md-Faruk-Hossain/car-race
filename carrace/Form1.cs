using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace carrace
{
    public partial class from1 : Form
    {
        int roadSpeed = 15;
        int trafficSpeed = 15;
        int playeSpeed = 12;
        int score;
        int carImage;

        Random rand = new Random();
        Random carPosition = new Random();
        bool goleft, goright;
        public from1()
        {
            InitializeComponent();
        }     

        private void restartGame(object sender, EventArgs e)
        {
            resetGame();
        }
        private void resetGame()
        {
            btnStart.Enabled = false;
            explosion.Visible = false;
            award.Visible = false;
            goleft = false;
            goright = false;
            score = 0;
            award.Image = Properties.Resources.bronze1;
            roadSpeed = 12;
            trafficSpeed = 15;
            A1.Top = carPosition.Next(200, 500) *  -1;
            A1.Left = carPosition.Next(5, 200);
            A2.Top = carPosition.Next(200, 500) * -1;
            A2.Left = carPosition.Next(245, 422);
            gameTimer.Start();


        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            lblScore.Text = "Score : " + score;
            score++;

            if (goleft == true && player.Left > 10)
            {
                player.Left -= playeSpeed;
            }
            if (goright == true && player.Left < 415)
            {
                player.Left += playeSpeed;
            }

            roadTrack1.Top += roadSpeed;
            roadTrack2.Top += roadSpeed;

            if (roadTrack2.Top > 519)
            {
                roadTrack2.Top = -519;
            }
            if(roadTrack1.Top > 519)
            {
                roadTrack1.Top = -519;
            }
            A1.Top += trafficSpeed;
            A2.Top += trafficSpeed;

            if (A1.Top > 530)
            {
                ChangeACars(A1);
            }
            if (A2.Top > 530)
            {
                ChangeACars(A2);
            }
            if (player.Bounds.IntersectsWith(A1.Bounds) || player.Bounds.IntersectsWith(A2.Bounds))    
            {
                gameOver();
            }
            if (score > 40 && score < 500)
            {
                award.Image = Properties.Resources.game_over_game;
            }
            if (score > 500 && score < 2000)
            {
                award.Image = Properties.Resources.silver1;
            }
            if ( score > 2000)
            {
                award.Image = Properties.Resources.bronze1;
                roadSpeed = 27;
                trafficSpeed = 25;
            }
        }
        private void gameOver()
        {
            gameTimer.Stop();
            explosion.Visible = true;
            player.Controls.Add(explosion);
            explosion.Location = new Point(-5, 8);
            explosion.BackColor = Color.Transparent;
            award.Visible = true;
            award.BringToFront();
            btnStart.Enabled = true;

        }
        private void ChangeACars(PictureBox tempCar)
        {
            carImage = rand.Next(1, 7);
            switch (carImage)
            {
                case 1:
                    tempCar.Image = Properties.Resources.carblue1;
                    break;
                case 2:
                    tempCar.Image = Properties.Resources.policecar1;
                    break;
                case 3:
                    tempCar.Image = Properties.Resources.caryellow1;
                    break;
                case 4:
                    tempCar.Image = Properties.Resources.CarRed1;
                    break;
                case 5:
                    tempCar.Image = Properties.Resources.nabycar1;
                    break;
                case 6:
                    tempCar.Image = Properties.Resources.whitecar1;
                    break; 
                case 7:
                    tempCar.Image= Properties.Resources.cargray1;
                    break;
                case 8:
                    tempCar.Image = Properties.Resources.nabycar1;
                    break;


            }
            tempCar.Top= carPosition.Next(100, 400)* -1;
            if ((string)tempCar.Tag == "carLeft")
            {
                tempCar.Left = carPosition.Next(5, 200);
            }
            if ((string)tempCar.Tag == "carRight")
            {
                tempCar.Left = carPosition.Next(245, 422);
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
        }
    }
}
