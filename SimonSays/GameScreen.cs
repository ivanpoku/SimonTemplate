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
        //TODO: create an int guess variable to track what part of the pattern the user is at
        int guess;
        int randNum;
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

            Refresh();
            Form1.pattern.Clear();
            ComputerTurn();
        }
        private void ComputerTurn()
        {
            //TODO: get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list. Each number represents a button. For example, 0 may be green, 1 may be blue, etc.

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
            //TODO: set guess value back to 0
            guess = 0;
        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            //TODO: is the value in the pattern list at index [guess] equal to a green?
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
            GameOverScreen gos = new GameOverScreen();
            goPlayer.Play();
            Form f = this.FindForm();
            Form1.ChangeScreen(this, gos);
            //TODO: close this screen and open the GameOverScreen

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
            greenButton.BackColor = Color.ForestGreen;
            redButton.BackColor = Color.DarkRed;
            blueButton.BackColor = Color.DarkBlue;
            yellowButton.BackColor = Color.Goldenrod;
            Refresh();
        }

    }
}
