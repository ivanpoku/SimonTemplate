using System;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            //Displays pattern length at the end of the game
            lengthLabel.Text = $"{Form1.pattern.Count}";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //goes to menu screen
            MenuScreen ms = new MenuScreen();
            Form f = this.FindForm();
            Form1.ChangeScreen(this, ms);
        }
    }
}
