using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankBusinessLayer;

namespace BankProject
{
    public partial class Login: Form
    {
        public Login()
        {
            InitializeComponent();
        }

        static short CountLoginFaild = 0;
   
        private void ShowMessage()
        {
            MessageBox.Show("Contact System Administractors to Unlock your Account.", "Blocked User:",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool BlockedUser()
        {
            if (CountLoginFaild == 3)
            {
                lblLoginFaild.Text = "You are locked after 3 Faild Trails!\n" +
                    "Contact System Administractors to Unlock your Account.";
                btnLogin.Enabled = false;
                ShowMessage();
                return true;
            }
            else
                return false;
        }

        private void LoginFaild()
        {
            CountLoginFaild++;
            SystemSounds.Beep.Play();
            lblLoginFaild.Text = $"Invailde UserName or Password!\nYou have {3 - CountLoginFaild} attempts before" +
                $"lock your account.";

            if (BlockedUser())
                this.Close();
        }

        private void _RestartTheMeter()
        {
            CountLoginFaild = 0;
        }

        private void _UpdateLoginScreen()
        {
            txtPassword.Text = "";
            txtUserName.Text = "";
            lblLoginFaild.Text = "";
            _RestartTheMeter();
        }

        private void ShowHomeScreen(clsUser user)
        {
            _UpdateLoginScreen();
            Home frm = new Home(user);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void _Login()
        {
            string UserName = txtUserName.Text;
            string Password = txtPassword.Text;

            clsUser user = clsUser.Find(UserName, Password);

            if (user != null)
            {
                ShowHomeScreen(user);
            }
            else
            {
                LoginFaild();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _Login();
        }

        private void timerLogin_Tick(object sender, EventArgs e)
        {
            lblDateAndTime.Text = DateTime.Now.ToString("dddd, MMMM yyyy  \nHH:mm:ss tt");
        }

        private void Login_Load(object sender, EventArgs e)
        {
            timerLogin.Enabled = true;
        }

        private void txtUserName_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, "Please enter UserName!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void txtPassword_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Please enter Password!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }
    }
}
