/*
 * Description:     A Basic Simon Game
 * Author:      Vaniya Pokusaev           
 * Date:        2024-02-22         
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Drawing.Drawing2D;


namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        int guess;
        int randNum;

        //Sounds
        SoundPlayer greenPlayer = new SoundPlayer(Properties.Resources.green);
        SoundPlayer redPlayer = new SoundPlayer(Properties.Resources.red);
        SoundPlayer bluePlayer = new SoundPlayer(Properties.Resources.blue);
        SoundPlayer yellowPlayer = new SoundPlayer(Properties.Resources.yellow);
        SoundPlayer goPlayer = new SoundPlayer(Properties.Resources.mistake);

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

            //Rounded Buttons
            GraphicsPath circlePath = new GraphicsPath();
            circlePath.AddEllipse(5, 5, 180, 180);

            Region buttonRegion = new Region(circlePath);
            Region buttonRegion90 = new Region(circlePath);
            Region buttonRegion180 = new Region(circlePath);
            Region buttonRegion270 = new Region(circlePath);
            Matrix transformMatrix = new Matrix();

            transformMatrix.RotateAt(90, new PointF(50, 50));

            buttonRegion90.Transform(transformMatrix);
            buttonRegion180.Transform(transformMatrix);
            buttonRegion180.Transform(transformMatrix);
            buttonRegion270.Transform(transformMatrix);
            buttonRegion270.Transform(transformMatrix);
            buttonRegion270.Transform(transformMatrix);

            redButton.Region = buttonRegion90;
            blueButton.Region = buttonRegion180;
            greenButton.Region = buttonRegion;
            yellowButton.Region = buttonRegion270;

            //Clears Pattern and Starts Game
            Refresh();
            Form1.pattern.Clear();
            ComputerTurn();
        }
        private void ComputerTurn()
        {
            //Generates Random Number and Adds to Pattern List
            //Lights up colors appropriate to random number

            randNum = new Random().Next(0, 4);
            Form1.pattern.Add(randNum);

            foreach (int randNum in Form1.pattern)
            {   
                Thread.Sleep(1000);
                switch (randNum)
                {
                    case 0:
                        greenButton.BackColor = Color.LightGreen;
                        Refresh();
                        break;

                    case 1:
                        redButton.BackColor = Color.Red;
                        Refresh();
                        break;

                    case 2:
                        blueButton.BackColor = Color.Blue;
                        Refresh();
                        break;

                    case 3:
                        yellowButton.BackColor = Color.Yellow;
                        Refresh();
                        break;
                }
                Thread.Sleep(500);
                resetToColor();
            }
            guess = 0;
        }
        private void greenButton_Click(object sender, EventArgs e)
        {
            //Checks if the random number is equal to color
            //adds one to guess value, computer.
            //If the pattern length isn't equal to guess value, gameover
            if (Form1.pattern[guess] == 0)
            {
                greenPlayer.Play();
                greenButton.BackColor = Color.LightGreen;
                Refresh();
                Thread.Sleep(500);
                resetToColor();
                guess++;
                if (Form1.pattern.Count() == guess)
                {
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            }
        }
        public void GameOver()
        {
            //Opens gameover screen
            GameOverScreen gos = new GameOverScreen();
            goPlayer.Play();
            Form f = this.FindForm();
            Form1.ChangeScreen(this, gos);

        }
        private void redButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[guess] == 1)
            {
                redPlayer.Play();
                redButton.BackColor = Color.Red;
                Refresh();
                Thread.Sleep(500);
                resetToColor();
                guess++;
                if (Form1.pattern.Count() == guess)
                {
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            }

        }
        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[guess] == 2)
            {
                bluePlayer.Play();
                blueButton.BackColor = Color.Blue;
                Refresh();
                Thread.Sleep(500);
                resetToColor();
                guess++;
                if (Form1.pattern.Count() == guess)
                {
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            }
        }
        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[guess] == 3)
            {
                yellowPlayer.Play();
                yellowButton.BackColor = Color.Yellow;
                Refresh();
                Thread.Sleep(500);
                resetToColor();
                guess++;
                if (Form1.pattern.Count() == guess)
                {
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            }
        }
        public void resetToColor()
        {
            //Resets buttons to original colors
            greenButton.BackColor = Color.ForestGreen;
            redButton.BackColor = Color.DarkRed;
            blueButton.BackColor = Color.DarkBlue;
            yellowButton.BackColor = Color.Goldenrod;
            Refresh();
        }
    }
}
