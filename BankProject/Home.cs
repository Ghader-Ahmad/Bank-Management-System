using BankBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankProject
{
    public partial class Home: Form
    {
        clsUser user1;
        public Home(clsUser user)
        {
            InitializeComponent();
            user1 = user;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            lblUserName.Text = "Welcome : " + user1.UserName;


            if (!CheckPermissions(user1.Persmissions, Convert.ToInt32(clsPublicFunctions.enPermissions.ManageClients)))
            {
                btnManageClients.Visible = false;
            }

            if (!CheckPermissions(user1.Persmissions, Convert.ToInt32(clsPublicFunctions.enPermissions.ClientsTransactions)))
            {
                btnClientsTransactions.Visible = false;
            }

            if (!CheckPermissions(user1.Persmissions, Convert.ToInt32(clsPublicFunctions.enPermissions.ManageUsers)))
            {
                btnManageUsers.Visible = false;
            }

            if (!CheckPermissions(user1.Persmissions, Convert.ToInt32(clsPublicFunctions.enPermissions.CurrencyExchange)))
            {
                btnCurrencyExchange.Visible = false;
            }
        }

        private bool CheckPermissions(int UserPermissions, int CurrenctPermissions)
        {
            if (UserPermissions == Convert.ToInt32(clsPublicFunctions.enPermissions.All))
                return true;

            if ((UserPermissions & CurrenctPermissions) == CurrenctPermissions)
                return true;

            else
                return false;
        }

        private void ShowManageClientsScreen()
        {   
            frmClients frm = new frmClients(user1);
            this.Hide();

            frm.ShowDialog();
            this.Show();
        }

        private void ShowClientsTransactions()
        {
            frmTransactions frm = new frmTransactions(user1);
            this.Hide();

            frm.ShowDialog();
            this.Show();
        }

        private void ShowManageUsersScreen()
        {
            frmManageUsers frm = new frmManageUsers(user1.UserName);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void ShowCurrencyExchangeScreen()
        {
            frmCurrencyExchange frm = new frmCurrencyExchange(user1.UserName);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }


        private void btnRecordTheExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            ShowManageUsersScreen();
        }

        private void HomeTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM yyyy  \nHH:mm:ss tt");
        }

        private void btnManageClients_Click(object sender, EventArgs e)
        {
            ShowManageClientsScreen();
        }

        private void btnClientsTransactions_Click(object sender, EventArgs e)
        {
            ShowClientsTransactions();
        }

        private void btnCurrencyExchange_Click(object sender, EventArgs e)
        {
            ShowCurrencyExchangeScreen();
        }
    }
}
