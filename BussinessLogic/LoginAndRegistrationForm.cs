using Bunifu.Framework.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BussinessLogic
{
    public partial class LoginAndRegistrationForm : Form
    {
        public LoginAndRegistrationForm()
        {
            InitializeComponent();
            RememberMeCheckBox.Location = new Point(89, 310);
            label4.Location = new Point(112, 310);
            label9.Location = new Point(4, 263);
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginRegisterTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (LoginRegisterTabControl.SelectedIndex)
            {
                case 0:
                    PanelLeft.BackColor = Color.FromArgb(2, 170, 245);
                    PictureBoxIRCTC.Image = Properties.Resources.Indian_Railwaylogo;
                    break;

                case 1:
                    PanelLeft.BackColor = Color.FromArgb(238, 26, 74);
                    PictureBoxIRCTC.Image = Properties.Resources.Indian_Railways_Logo_Blue;
                    break;
            }
        }

        private void Password_Enter(object sender, EventArgs e)
        {
            if (!(sender is BunifuMaterialTextbox textbox)) return;
            switch (textbox.Name)
            {
                case "Password":
                case "RegisterPassword":
                case "ConfirmPassword":
                    if (textbox.Text == "Password")
                    {
                        textbox.Text = "";
                        textbox.ForeColor = Color.Black;
                    }

                    break;
            }
        }

        private void Password_Leave(object sender, EventArgs e)
        {
            if (!(sender is BunifuMaterialTextbox textbox)) return;
            switch (textbox.Name)
            {
                case "Password":
                case "RegisterPassword":
                case "ConfirmPassword":
                    if (textbox.Text == "")
                    {
                        textbox.Text = "Password";
                        textbox.ForeColor = Color.Gray;
                    }

                    break;
            }
        }
    }
}

