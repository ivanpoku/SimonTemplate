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
            lengthLabel.Text = $"{Form1.pattern.Count}";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            MenuScreen ms = new MenuScreen();
            Form f = this.FindForm();
            Form1.ChangeScreen(this, ms);
        }
    }
}
