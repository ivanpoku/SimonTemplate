using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class Form1 : Form
    {
        //TODO: create a List to store the pattern. Must be accessable on other screens
        public static List<int> pattern = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MenuScreen ms = new MenuScreen();
            Form f = this.FindForm();
            ChangeScreen(this, ms);
        }
        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f;

            if (sender is Form)
            {
                f = (Form)sender;
            }
            else
            {
                UserControl current = (UserControl)sender;

                f = current.FindForm();

                f.Controls.Remove(current);
            }

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,

                (f.ClientSize.Height - next.Height) / 2);

            f.Controls.Add(next);

            next.Focus();

        }
    }
}
