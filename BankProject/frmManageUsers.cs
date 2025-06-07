using BankBusinessLayer;
using Guna.UI2.Designer;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace BankProject
{
    public partial class frmManageUsers: Form
    {
        public frmManageUsers(string UserName)
        {
            InitializeComponent();

            lblCurrentUserName.Text = "Welcome : " +  UserName;
        }

        // ------------------- Show All Users (Tab 1) -------------------------

        
        static DataTable UsersDataTable;


        private bool txtFirstNameIsEmpty = true;
        private bool txtLastNameIsEmpty = true;
        private bool txtEmailIsEmpty = true;
        private bool txtPhoneIsEmpty = true;
        private bool txtUserNameIsEmpty = true;
        private bool txtPasswordIsEmpty = true;



        private void ShowCountUsersInLabel()
        {
            // View the number of users present through the number of ListView elements in them.
            lblCountUserInLoginRegister.Text = lvLoginRegister.Items.Count.ToString() + " User(s) Found.";
            lblCountClients.Text = lvShowAllUsers.Items.Count.ToString() + " User(s) Found.";
        }

        private void ShowUsersInListViewFromDataView(DataView dv)
        {
            // Print User from DataView in ListView Control.

            lvShowAllUsers.Items.Clear();
          
            for (int i = 0; i < dv.Count; i++)
            {
                ListViewItem Item = new ListViewItem(dv[i][0].ToString().Trim());

                Item.SubItems.Add(dv[i][1].ToString().Trim());
                Item.SubItems.Add(dv[i][2].ToString().Trim());
                Item.SubItems.Add(dv[i][3].ToString().Trim());
                Item.SubItems.Add(dv[i][4].ToString().Trim());
                Item.SubItems.Add(dv[i][5].ToString().Trim());
                Item.SubItems.Add(dv[i][6].ToString().Trim());

                lvShowAllUsers.Items.Add(Item);
            }

            ShowCountUsersInLabel();
        }
        
        private void ShowAllUsers()
        {
            // Recover all users from the database and store them in DataTable.
            UsersDataTable = clsUser.GetAllUsers();

            // Create DataView from DataTable.
            DataView UsersDataView = UsersDataTable.DefaultView;

            ShowUsersInListViewFromDataView(UsersDataView);
        }
        
        private void SearchByUserName()
        {
            // In the event that the search box is empty, all users should be displayed.
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                ShowAllUsers();
                return;
            }

            // Here i created a new DataView and applied a filter using like statement phrase on what is in the search box,
            // whether in the begining, the middle or the end.

            DataView UsersDataView1 = UsersDataTable.DefaultView;
            UsersDataView1.RowFilter = $"UserName like '{txtSearch.Text}%' or UserName like '%{txtSearch.Text}'" +
                $"or UserName like '%{txtSearch.Text}%'";

            ShowUsersInListViewFromDataView(UsersDataView1);
        }
        
        private void SortingByUserName(string sortBy)
        {
            // Create DataView from DataTable
            DataView UsersDataView = UsersDataTable.DefaultView;

            // Arrange users in DataView via sort function.
            UsersDataView.Sort = $"{sortBy}";
            ShowUsersInListViewFromDataView(UsersDataView);
        }
        
        private void Sort()
        {
            // Check the arrangement, is it asc or desc according to the RadioButton value.
            if (rbSortAsc.Checked)
                SortingByUserName("UserName Asc");

            if(rbSortDesc.Checked)
                SortingByUserName("UserName Desc");
        }
        


        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            // Once the user screen is load, users should be displayed in each of listView(s) and ComboBox. 
            ShowAllUsers();
            FillUsersInComboBox();
            ShowUsersInLoginRegister();
        }
        
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            // Create an event at each click on this Tab. ListView content must be updated.
            ShowAllUsers();
        }
        
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            // Create an event at every change in the content of the search box. 
            SearchByUserName();
        }
        private void rbSortAsc_Click(object sender, EventArgs e)
        {
            // Create an event when pressing the RadioButton.
            Sort();
        }


        // ------------------- Add New User (Tab 2) -------------------------

        private void EnableAllCheckBoxInAddNewUser(bool Enable)
        {
            cbNManageClients.Enabled = Enable;
            cbNManageUsers.Enabled = Enable;
            cbNClientsTransactions.Enabled = Enable;
            cbNCurrencyExchange.Enabled = Enable;
        }

        private void CheckAllCheckBoxInAddNewUser(bool Check)
        {
            cbNManageUsers.Checked = Check;
            cbNManageClients.Checked = Check;
            cbNClientsTransactions.Checked = Check;
            cbNCurrencyExchange.Checked = Check;
        }

        private void GiveAllAccessInAddNew()
        {
            EnableAllCheckBoxInAddNewUser(false);
            CheckAllCheckBoxInAddNewUser(true);
        }
        
      
        
        private void GiveFullAccessYesOrNoInAddNew()
        {
            // Here are some modifications on the screen after clicking on the RadioButton with the help of functions
            // we previously built.

            if (rbNYes.Checked)
                GiveAllAccessInAddNew();

            if (rbNNo.Checked)
            {
                EnableAllCheckBoxInAddNewUser(true);
                CheckAllCheckBoxInAddNewUser(false);
            }
        }

        private int GetTheUserPermission()
        {
            // Returning the user's permissions as a correct number typeof int.

            int Permissions = 0;

            if (rbNYes.Checked || (cbNClientsTransactions.Checked && cbNCurrencyExchange.Checked 
                && cbNManageClients.Checked && cbNManageUsers.Checked))
            {
                Permissions = Convert.ToInt32(clsPublicFunctions.enPermissions.All);
                return Permissions;
            }

            if (cbNManageClients.Checked)
                Permissions += Convert.ToInt32(clsPublicFunctions.enPermissions.ManageClients);

            if (cbNManageUsers.Checked)
                Permissions += Convert.ToInt32(clsPublicFunctions.enPermissions.ManageUsers);
            
            if (cbNClientsTransactions.Checked)
                Permissions += Convert.ToInt32(clsPublicFunctions.enPermissions.ClientsTransactions);
            
            if (cbNCurrencyExchange.Checked)
                Permissions += Convert.ToInt32(clsPublicFunctions.enPermissions.CurrencyExchange);

            return Permissions;
        }

        private void ResetTextBoxInAddNew()
        {
            txtNFirstName.Text = "";
            txtNLastName.Text = "";
            txtNEmail.Text = "";
            txtNPhone.Text = "";
            txtNUserName.Text = "";
            txtNPassword.Text = "";
        }

        private void ResetRadioButtonInAddNew()
        {
            rbNYes.Checked = false;
            rbNNo.Checked = false;
        }

        private void ResetTheProgressPar()
        {
            pbAddNewUser.Value = 0;
            lblProgressPar.Text = "0%";
        }

        private void AfterAddNewUser()
        {
            // Here are some modifications on the screen after clicking on the RadioButton with the help of functions
            // we previously built.
            ResetTextBoxInAddNew();
            ResetRadioButtonInAddNew();
            ResetTheProgressPar();
            EnableAllCheckBoxInAddNewUser(false);
            CheckAllCheckBoxInAddNewUser(false);
        }

        private void SaveAfterAddNew(clsUser user)
        {
            // After adding the user, we have saved the database .
            
            if (user.Save())
            {
                AfterAddNewUser();
                MessageBox.Show("The user was successfully added.", "Add New User :",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The user has not been added.", "Add New User :",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private bool HaveAllTheInformationWereEnteredInAddNew()
        {
            // Check to enter all user data before pressing the add button.

            if (string.IsNullOrEmpty(txtNUserName.Text) || string.IsNullOrEmpty(txtNFirstName.Text) ||
                string.IsNullOrEmpty(txtNLastName.Text) || string.IsNullOrEmpty(txtNEmail.Text) ||
                string.IsNullOrEmpty(txtNPassword.Text) || string.IsNullOrEmpty(txtNPhone.Text))
            {
                MessageBox.Show("Please enter all the information.", "Warning", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }

        private void AddNewUser()
        {
            if (!HaveAllTheInformationWereEnteredInAddNew())
                return;

            // Definition of a new user by defining a new object from clsUser and adding values from the screen.
            
            clsUser user = new clsUser();

            user.FirstName = txtNFirstName.Text;
            user.LastName = txtNLastName.Text;
            user.Email = txtNEmail.Text;
            user.Phone=txtNPhone.Text;
            user.UserName = txtNUserName.Text;
            user.Password = txtNPassword.Text;
            user.Persmissions = GetTheUserPermission();

            SaveAfterAddNew(user);
        }



        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            AddNewUser();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            clsPublicFunctions.CheckForTheEntryOfThisField(e, txtNUserName, errorProvider1);
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            clsPublicFunctions.CheckForTheEntryOfThisField(e, txtNFirstName, errorProvider1);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            clsPublicFunctions.CheckForTheEntryOfThisFieldIsNumber(e, txtNPhone, errorProvider1);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
           clsPublicFunctions.ValidatingEmail(e, txtNEmail, errorProvider1);
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            clsPublicFunctions.CheckForTheEntryOfThisField(e, txtNLastName, errorProvider1);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            clsPublicFunctions.CheckForTheEntryOfThisField(e, txtNPassword, errorProvider1);
        }


      

        private void txtNUserName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNUserName.Text))
            {
                txtUserNameIsEmpty = true;
                clsPublicFunctions.IncreaseAndDecreaseProgressPar(pbAddNewUser, -18, lblProgressPar);
                return;
            }
            if (txtUserNameIsEmpty)
            {
                txtUserNameIsEmpty = false;
                clsPublicFunctions.IncreaseAndDecreaseProgressPar(pbAddNewUser, 18, lblProgressPar);
            }

        }

        private void txtNFirstName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNFirstName.Text))
            {
                txtFirstNameIsEmpty = true;
                clsPublicFunctions.IncreaseAndDecreaseProgressPar(pbAddNewUser, -10, lblProgressPar);
                return;
            }
            if (txtFirstNameIsEmpty)
            {
                txtFirstNameIsEmpty = false;
                clsPublicFunctions.IncreaseAndDecreaseProgressPar(pbAddNewUser, 10, lblProgressPar);
            }
        }

        private void txtNPhone_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNPhone.Text))
            {
                txtPhoneIsEmpty = true;
                clsPublicFunctions.IncreaseAndDecreaseProgressPar(pbAddNewUser, -18, lblProgressPar);
                return;
            }
            if (txtPhoneIsEmpty)
            {
                txtPhoneIsEmpty = false;
                clsPublicFunctions.IncreaseAndDecreaseProgressPar(pbAddNewUser, 18, lblProgressPar);
            }
        }

        private void txtNEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNEmail.Text))
            {
                txtEmailIsEmpty = true;
                clsPublicFunctions.IncreaseAndDecreaseProgressPar(pbAddNewUser, -18, lblProgressPar);
                return;
            }
            if (txtEmailIsEmpty)
            {
                txtEmailIsEmpty = false;
                clsPublicFunctions.IncreaseAndDecreaseProgressPar(pbAddNewUser, 18, lblProgressPar);
            }
        }

        private void txtNLastName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNLastName.Text))
            {
                txtLastNameIsEmpty = true;
                clsPublicFunctions.IncreaseAndDecreaseProgressPar(pbAddNewUser, -18, lblProgressPar);
                return;
            }
            if (txtLastNameIsEmpty)
            {
                txtLastNameIsEmpty = false;
                clsPublicFunctions.IncreaseAndDecreaseProgressPar(pbAddNewUser, 18, lblProgressPar);
            }
        }

        private void txtNPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNPassword.Text))
            {
                txtPasswordIsEmpty = true;
                clsPublicFunctions.IncreaseAndDecreaseProgressPar(pbAddNewUser, -18, lblProgressPar);
                return;
            }
            if (txtPasswordIsEmpty)
            {
                txtPasswordIsEmpty = false;
                clsPublicFunctions.IncreaseAndDecreaseProgressPar(pbAddNewUser, 18, lblProgressPar);
            }
        }

        private void rbNYes_Click(object sender, EventArgs e)
        {
            GiveFullAccessYesOrNoInAddNew();
        }

        // ------------------- Update User (Tab 3) -------------------------


        static clsUser userUpdate;

        private void EnableAllCheckBoxInUpdateUser(bool Enable)
        {
            cbUManageClients.Enabled = Enable;
            cbUManageUsers.Enabled = Enable;
            cbUClientsTransactions.Enabled = Enable;
            cbUCurrencyExchange.Enabled = Enable;
        }

        private void CheckAllCheckBoxInUpdateUser(bool Check)
        {
            cbUManageUsers.Checked = Check;
            cbUManageClients.Checked = Check;
            cbUClientsTransactions.Checked = Check;
            cbUCurrencyExchange.Checked = Check;
        }

        private int GetTheUserPermissionUpdateUser()
        {
            // Returning the user's permissions as a correct number typeof int.

            int permssions = 0;

            if (rbUYes.Checked || (cbUClientsTransactions.Checked && cbUCurrencyExchange.Checked &&
                cbUManageClients.Checked && cbUManageUsers.Checked))
            {
                permssions = Convert.ToInt32(clsPublicFunctions.enPermissions.All);
                return permssions;
            }

            if (cbUManageClients.Checked)
                permssions += Convert.ToInt32(clsPublicFunctions.enPermissions.ManageClients);

            if (cbUManageUsers.Checked)
                permssions += Convert.ToInt32(clsPublicFunctions.enPermissions.ManageUsers);

            if (cbUClientsTransactions.Checked)
                permssions += Convert.ToInt32(clsPublicFunctions.enPermissions.ClientsTransactions);

            if (cbUCurrencyExchange.Checked)
                permssions += Convert.ToInt32(clsPublicFunctions.enPermissions.CurrencyExchange);

            return permssions;
        }

        private void GiveAllAccessInUpdateUser()
        {
            EnableAllCheckBoxInUpdateUser(false);
            CheckAllCheckBoxInUpdateUser(true);
        }

        private void GiveFullAccessYesOrNoInUpdateUser()
        {
            if (rbUYes.Checked)
                GiveAllAccessInUpdateUser();

            if (rbUNo.Checked)
            {
                EnableAllCheckBoxInUpdateUser(true);
                CheckAllCheckBoxInUpdateUser(false);
            }
        }

        private void ResetTextBoxInUpdateUser()
        {
            cbUserName.Text = "";
            txtUFirstName.Text = "";
            txtULastName.Text = "";
            txtUEmail.Text = "";
            txtUPhone.Text = "";
            txtUPassword.Text = "";
        }

        private void ResetRadioButtonInUpdateUser()
        {
            rbUYes.Checked = false;
            rbUNo.Checked = false;
        }

        private void AfterUpdateUserOrDelete()
        {
            btnToRetreat.Visible = false;
            ResetTextBoxInUpdateUser();
            ResetRadioButtonInUpdateUser();
            EnableAllCheckBoxInUpdateUser(false);
            CheckAllCheckBoxInUpdateUser(false);
        }

        private void FillUsersInComboBox()
        {
            UsersDataTable = clsUser.GetAllUsers();

            // Add all users to the ComboBox via the DataView.

            cbUserName.Items.Clear();

            DataView UsersDataView = UsersDataTable.DefaultView;

            for(int i=0; i < UsersDataView.Count; i++)
            {
                cbUserName.Items.Add(UsersDataView[i][0]);
            }
        }

        private void FillPermissoins(int Permissions)
        {
            // Modification on the screen after reading the user's permissions.

            EnableAllCheckBoxInUpdateUser(true);

            if (Permissions == Convert.ToInt32(clsPublicFunctions.enPermissions.All) )
            {
                rbUYes.Checked = true;
                CheckAllCheckBoxInUpdateUser(true);
                return;
            }

            else
            {
                if ((Permissions & Convert.ToInt32(clsPublicFunctions.enPermissions.CurrencyExchange)) ==
                    Convert.ToInt32(clsPublicFunctions.enPermissions.CurrencyExchange))
                {
                    cbUCurrencyExchange.Checked = true;
                }

                if ((Permissions & Convert.ToInt32(clsPublicFunctions.enPermissions.ClientsTransactions)) ==
                    Convert.ToInt32(clsPublicFunctions.enPermissions.ClientsTransactions))
                {
                    cbUClientsTransactions.Checked = true;
                }

                if ((Permissions & Convert.ToInt32(clsPublicFunctions.enPermissions.ManageClients)) ==
                   Convert.ToInt32(clsPublicFunctions.enPermissions.ManageClients))
                {
                    cbUManageClients.Checked = true;
                }

                if ((Permissions & Convert.ToInt32(clsPublicFunctions.enPermissions.ManageUsers)) ==
                    Convert.ToInt32(clsPublicFunctions.enPermissions.ManageUsers))
                {
                    cbUManageUsers.Checked = true;
                }    
            }
        }

        private void ShowUserInformation(string UserName)
        {
            // View all user data after choosing the username from the comboBox.

            userUpdate = clsUser.Find(UserName);

            if (userUpdate != null)
            {
                btnToRetreat.Visible = true;
                txtUFirstName.Text = userUpdate.FirstName;
                txtULastName.Text = userUpdate.LastName;
                txtUPhone.Text = userUpdate.Phone;
                txtUEmail.Text = userUpdate.Email;
                txtUPassword.Text = userUpdate.Password;
                FillPermissoins(userUpdate.Persmissions);
            }
            else
            {
                MessageBox.Show("User is not found!", "Error: ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void SaveAfterUpdate(clsUser user)
        {
            // Save user data after updating it to the database.

            if (user.Save())
            {
                AfterUpdateUserOrDelete();
                FillUsersInComboBox();
                MessageBox.Show("The user was successfully updated.", "Update User :",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The user has not been updated.", "Update User :",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private bool HaveAllTheInformationWereEnteredInUpdateUserOrDelete()
        {
            // Here we verified the display of user data before clicking on the editing button or deletion to avoid errors.

            if (string.IsNullOrEmpty(txtUFirstName.Text))
            {
                MessageBox.Show("Please enter all the information.", "Warning", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }



        private void UpdateUser()
        {
            if (!HaveAllTheInformationWereEnteredInUpdateUserOrDelete())
                return;

            // Read the user data modification from the screen.

            userUpdate.FirstName = txtUFirstName.Text;
            userUpdate.LastName = txtULastName.Text;
            userUpdate.Email = txtUEmail.Text;
            userUpdate.Phone = txtUPhone.Text;
            userUpdate.Password = txtUPassword.Text;
            userUpdate.UserName = cbUserName.Text;
            userUpdate.Persmissions = GetTheUserPermissionUpdateUser();

            SaveAfterUpdate(userUpdate);
        }

        private void DeleteUserByUserID(int UserID)
        {

            if (MessageBox.Show("Are you sure you want to delete user?", "Delete User: ",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsUser.DeleteUser(UserID))
                {
                    AfterUpdateUserOrDelete();
                    FillUsersInComboBox();
                    MessageBox.Show("The user was successfully deleted.", "delete User :",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The delete has not been updated.", "delete User :",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteUser()
        {
            if (!HaveAllTheInformationWereEnteredInUpdateUserOrDelete())
                return;

            DeleteUserByUserID(userUpdate.UserID);
        }




        private void cbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowUserInformation(cbUserName.Text);
        }

        private void rbUYes_Click(object sender, EventArgs e)
        {
            GiveFullAccessYesOrNoInUpdateUser();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            UpdateUser();
        }

        private void tabUpdateUser_Enter(object sender, EventArgs e)
        {
            FillUsersInComboBox();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void btnToRetreat_Click(object sender, EventArgs e)
        {
            AfterUpdateUserOrDelete();
        }

        // ------------------- Login Register (Tab 4) -------------------------

        DataTable UsersInLoginRegister;

        private void ShowUsersInListViewFromDataViewInLoginRegister(DataView dv)
        {
            // Print User from DataView in ListView Control.

            lvLoginRegister.Items.Clear();

            for (int i = 0; i < dv.Count; i++)
            {
                ListViewItem Item = new ListViewItem(dv[i][0].ToString().Trim());

                Item.SubItems.Add(dv[i][1].ToString().Trim());
                Item.SubItems.Add(dv[i][2].ToString().Trim());
                Item.SubItems.Add(dv[i][3].ToString().Trim());
                Item.SubItems.Add(dv[i][4].ToString().Trim());
                Item.SubItems.Add(dv[i][5].ToString().Trim());
                Item.SubItems.Add(dv[i][6].ToString().Trim());
                Item.SubItems.Add(dv[i][7].ToString().Trim());

                lvLoginRegister.Items.Add(Item);
            }

            ShowCountUsersInLabel();
        }

        private void ShowUsersInLoginRegister()
        {
            UsersInLoginRegister = clsUser.GetAllUsersWithLogDate();

            DataView dataView = UsersInLoginRegister.DefaultView;

            ShowUsersInListViewFromDataViewInLoginRegister(dataView);
        }

        private void SearchByUserNameInLoginRegister()
        {
            // In the event that the search box is empty, all users should be displayed.
            if (string.IsNullOrEmpty(txtSearchInLoginRegister.Text))
            {
                ShowUsersInLoginRegister();
                return;
            }

            // Here i created a new DataView and applied a filter using like statement phrase on what is in the search box,
            // whether in the begining, the middle or the end.

            DataView UsersDataView1 = UsersInLoginRegister.DefaultView;
            UsersDataView1.RowFilter = $"UserName like '{txtSearchInLoginRegister.Text}%' or UserName like '%{txtSearchInLoginRegister.Text}'" +
                $"or UserName like '%{txtSearchInLoginRegister.Text}%'";

            ShowUsersInListViewFromDataViewInLoginRegister(UsersDataView1);
        }

        private void SortingByUserNameInLoginRegister(string sortBy)
        {
            // Create DataView from DataTable
            DataView UsersDataView = UsersInLoginRegister.DefaultView;

            // Arrange users in DataView via sort function.
            UsersDataView.Sort = $"{sortBy}";
            ShowUsersInListViewFromDataViewInLoginRegister(UsersDataView);
        }

        private void SortInLoginRegister()
        {
            // Check the arrangement, is it asc or desc according to the RadioButton value.
            if (rbUSortAsc.Checked)
                SortingByUserNameInLoginRegister("UserName Asc");

            if (rbUSortDesc.Checked)
                SortingByUserNameInLoginRegister("UserName Desc");
        }

        private void tabLoginRegister_Enter(object sender, EventArgs e)
        {
            ShowUsersInLoginRegister();
        }

        private void txtSearchInLoginRegister_TextChanged_1(object sender, EventArgs e)
        {
            SearchByUserNameInLoginRegister(); 
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            SortInLoginRegister();
        }

        private void ManageUserTimer_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM yyyy  \nHH:mm:ss tt");
        }


        // add context menue

        private ListViewItem selectedItemForContextMenu;
        
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Point mousePosition = lvShowAllUsers.PointToClient(Control.MousePosition);

            ListViewHitTestInfo hitTestInfo = lvShowAllUsers.HitTest(mousePosition);

            if (hitTestInfo.Item != null)
            {
                selectedItemForContextMenu = hitTestInfo.Item;
            }
            else
                selectedItemForContextMenu = null;
        }

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedItemForContextMenu == null)
                return;

            string UserName = selectedItemForContextMenu.SubItems[0].Text;

            tpManageUsers.SelectedTab = tpUpdateUser;
            cbUserName.Text = UserName;
        }

     
    }
}
