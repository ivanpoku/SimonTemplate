using System;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            //TODO: remove this screen and start the GameScreen
            GameScreen gs = new GameScreen();
            Form f = this.FindForm();
            Form1.ChangeScreen(this, gs);
        }


        private void exitButton_Click(object sender, EventArgs e)
        {
            //TODO: end the application
            Form f = this.FindForm();
            System.Windows.Forms.Application.Exit();
        }
    }
}
