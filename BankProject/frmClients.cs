using BankBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace BankProject
{
    public partial class frmClients: Form
    {
        public frmClients(clsUser User)
        {
            CurrentUser = User;
            InitializeComponent();

            lblCurrentUserName.Text = "Welcome : " + CurrentUser.UserName;
        }

        clsUser CurrentUser;
        DataTable ClientsDataTable;

        private bool txtFirstNameIsEmpty = true;
        private bool txtLastNameIsEmpty = true;
        private bool txtEmailIsEmpty = true;
        private bool txtPhoneIsEmpty = true;
        private bool txtAccountNumberIsEmpty = true;
        private bool txtPinCodeIsEmpty = true;



        // --------------------------- Show All Clients (tab 1) ------------------------------------

        private void GetAllClient()
        {
            ClientsDataTable = clsClient.GetAllClients();
        }

        private void PrintDataInListView(DataView dv)
        {
            lvShowClients.Items.Clear();
            for (int i = 0; i < dv.Count; i++)
            {
                ListViewItem item = new ListViewItem(dv[i][0].ToString().Trim());
                item.Tag = dv[i][0];
                item.SubItems.Add(dv[i][1].ToString().Trim());
                item.SubItems.Add(dv[i][2].ToString().Trim());
                item.SubItems.Add(dv[i][3].ToString().Trim());
                item.SubItems.Add(dv[i][4].ToString().Trim());
                item.SubItems.Add(dv[i][5].ToString().Trim());
                item.SubItems.Add(dv[i][6].ToString().Trim());

                lvShowClients.Items.Add(item);
            }
        }

        private void ShowAllClientsInListView()
        {
            GetAllClient();
            DataView ClientsdataView = ClientsDataTable.DefaultView;

            PrintDataInListView(ClientsdataView);
        }

        private void SearchClient()
        {
            if (!clsPublicFunctions.ValidateNumber(txtSearchClients.Text))
                return;

            if (string.IsNullOrEmpty(txtSearchClients.Text))
            {
                ShowAllClientsInListView();
                return;
            }

            DataView dv = ClientsDataTable.DefaultView;

            dv.RowFilter = $"AccountNumber = {txtSearchClients.Text}";

            PrintDataInListView(dv);
        }

        private void SortBy(string sort)
        {
            DataView dv = ClientsDataTable.DefaultView;

            dv.Sort = $"{sort}";

            PrintDataInListView(dv);
        }

        private void Sorting()
        {
            if (rbSortAsc.Checked)
                SortBy("AccountNumber Asc");

            if (rbSortDesc.Checked)
                SortBy("AccountNumber Desc");
        }

        private void PrintCountClients()
        {
            lblCountClients.Text = lvShowClients.Items.Count + " Client(s) Found";
        }

        private void txtSearchClients_TextChanged_1(object sender, EventArgs e)
        {
            SearchClient();
        }
        private void rbSortDesc_Click(object sender, EventArgs e)
        {
            Sorting();
        }

        private void frmClients_Load(object sender, EventArgs e)
        {
            ShowAllClientsInListView();
            FillAccountNumbersInComboBox();
            PrintCountClients();
        }

        private void tpShowClients_Enter(object sender, EventArgs e)
        {
            ShowAllClientsInListView();
            PrintCountClients();
        }


        // --------------------------- Add New Client (tab 2) ------------------------------------

        private bool GetDataAndSave()
        {
            clsClient client = new clsClient();

            client.AccountNumber = Convert.ToInt32(txtAccountNumber.Text);
            client.FirstName = txtFirstName.Text;
            client.LastName = txtLastName.Text;
            client.Email = txtEmail.Text;
            client.Phone = txtPhone.Text;
            client.PinCode = txtPinCode.Text;
            client.AccountBalance = ((double)nudBalance.Value);

            return client.Save();
        }

        private bool HaveAllTheInformationWereEnteredInAddNew()
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPhone.Text) ||
                string.IsNullOrEmpty(txtPinCode.Text))
            {
                MessageBox.Show("Please enter all the information.", "Warning", MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Warning);
                return false;
            }

            else
                return true;
        }

        private void ResetTextBox()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtPinCode.Text = "";
            txtAccountNumber.Text = "";
            nudBalance.Value = 0;
        }

        private void ResetAfterAddNewClient()
        {
            ResetTextBox();
        }

        private void AddNewClient()
        {
            if (!HaveAllTheInformationWereEnteredInAddNew())
                return;

             if (GetDataAndSave())
            {
                ResetAfterAddNewClient();
                MessageBox.Show("The client was successfully added.", "Add New Client :",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The client has not been added.", "Add New Client :",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnAddNewClient_Click(object sender, EventArgs e)
        {
            AddNewClient();
        }



        private void CheckForTheEntryOfThisField(CancelEventArgs e, TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, "Required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox, "");
            }
        }


        private void txtAccountNumber_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtAccountNumber.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAccountNumber, "Required!");
                txtAccountNumber.Focus();
                return;
            }
            if (clsClient.ClientIsExist(Convert.ToInt32(txtAccountNumber.Text)))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAccountNumber, $"Account Number ({txtAccountNumber.Text}) is already used," +
                    $"Choose another one.");
                txtAccountNumber.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAccountNumber, "");
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            clsPublicFunctions.CheckForTheEntryOfThisField(e, txtFirstName, errorProvider1);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            clsPublicFunctions.CheckForTheEntryOfThisFieldIsNumber(e, txtPhone, errorProvider1);
        }

        private void txtPinCode_Validating(object sender, CancelEventArgs e)
        {
            clsPublicFunctions.CheckForTheEntryOfThisFieldIsNumber(e, txtPinCode, errorProvider1);
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            clsPublicFunctions.CheckForTheEntryOfThisField(e, txtLastName, errorProvider1);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            clsPublicFunctions.ValidatingEmail(e, txtEmail, errorProvider1);
        }


        // --------------------------- Update Client (tab 3) ------------------------------------

        clsClient UpdateClient;

        private void FillAccountNumbersInComboBox()
        {
            GetAllClient();

            cbAccountNumber.Items.Clear();

            DataView dv = ClientsDataTable.DefaultView;

            for(int i = 0; i < dv.Count; i++)
            {
                cbAccountNumber.Items.Add(dv[i][0].ToString());
            }
        }

        private void ShowUserInformation()
        {
            UpdateClient = clsClient.Find(Convert.ToInt32(cbAccountNumber.Text));

            txtUFirstName.Text = UpdateClient.FirstName;
            txtULastName.Text = UpdateClient.LastName;
            txtUEmail.Text = UpdateClient.Email;
            txtUPhone.Text = UpdateClient.Phone;
            txtUPinCode.Text = UpdateClient.PinCode;
            nudUBalance.Value = ((int)UpdateClient.AccountBalance);

            btnToRetreat.Visible = true;
        }

        private bool HaveAllTheInformationWereEnteredInUpdateOrDeleteClient()
        {
            if (string.IsNullOrEmpty(txtUFirstName.Text))
            {
                MessageBox.Show("Please enter all the information.", "Warning", MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Warning);
                return false;
            }

            else
                return true;
        }

        private void ResetAfterUpdateOrDelete()
        {
            
            cbAccountNumber.Text = "";
            txtUFirstName.Text = "";
            txtULastName.Text = "";
            txtUEmail.Text = "";
            txtUPhone.Text = "";
            txtUPinCode.Text = "";
            nudUBalance.Value = 0;

            btnToRetreat.Visible = false;
        }

        private void SaveAfterUpdate(clsClient client)
        {
            if (client.Save())
            {
                ResetAfterUpdateOrDelete();
                FillAccountNumbersInComboBox();
                MessageBox.Show("The client was successfully updated.", "Client User :",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The client has not been updated.", "Client User :",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void GetDataAndUpdateClient()
        {
            if (!HaveAllTheInformationWereEnteredInUpdateOrDeleteClient())
                return;

            UpdateClient.FirstName = txtUFirstName.Text;
            UpdateClient.LastName = txtULastName.Text;
            UpdateClient.Email = txtUEmail.Text;
            UpdateClient.Phone = txtUPhone.Text;
            UpdateClient.PinCode = txtUPinCode.Text;
            UpdateClient.AccountBalance = ((double)nudUBalance.Value);

            SaveAfterUpdate(UpdateClient);
        }

        private void DeleteClient()
        {
            if (!HaveAllTheInformationWereEnteredInUpdateOrDeleteClient())
                return;

            if (MessageBox.Show("Are you sure you want to delete client?", "Delete Client: ",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsClient.DeleteClient(UpdateClient.AccountNumber))
                {
                    ResetAfterUpdateOrDelete();
                    FillAccountNumbersInComboBox();
                    MessageBox.Show("The client was successfully deleted.", "Delete Client :",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The client has not been deleted.", "Delete Client :",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }


        private void cbAccountNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowUserInformation();
        }

        private void cbAccountNumber_Click(object sender, EventArgs e)
        {
            FillAccountNumbersInComboBox();
        }

        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            GetDataAndUpdateClient();
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            DeleteClient();
        }

        private void btnToRetreat_Click(object sender, EventArgs e)
        {
            ResetAfterUpdateOrDelete();
        }


        private void ClientTimer_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM yyyy  \nHH:mm:ss tt");
        }

        // Add the event TextChanged for ProgressPar

        private void txtAccountNumber_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccountNumber.Text))
            {
                txtAccountNumberIsEmpty = true;
                clsPublicFunctions.IncreaseAndDecreaseProgressPar(pbAddNewUser, -18, lblProgressPar);
                return;
            }
            if (txtAccountNumberIsEmpty)
            {
                txtAccountNumberIsEmpty = false;
                clsPublicFunctions.IncreaseAndDecreaseProgressPar(pbAddNewUser, 18, lblProgressPar);
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
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

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
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

        private void txtPinCode_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPinCode.Text))
            {
                txtPinCodeIsEmpty = true;
                clsPublicFunctions.IncreaseAndDecreaseProgressPar(pbAddNewUser, -18, lblProgressPar);
                return;
            }
            if (txtPinCodeIsEmpty)
            {
                txtPinCodeIsEmpty = false;
                clsPublicFunctions.IncreaseAndDecreaseProgressPar(pbAddNewUser, 18, lblProgressPar);
            }
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
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

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
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
        

        // add context menue 

        private ListViewItem selectedItemForContextMenu;
        
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Point mousePosition = lvShowClients.PointToClient(Control.MousePosition);

            ListViewHitTestInfo hitTestInfo = lvShowClients.HitTest(mousePosition);

            if (hitTestInfo.Item != null)
            {
                selectedItemForContextMenu = hitTestInfo.Item;
            }
            else
                selectedItemForContextMenu = null;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedItemForContextMenu == null)
                return;

            string AccountNumber = selectedItemForContextMenu.SubItems[0].Text;

            if (MessageBox.Show("Are you sure you want to delete client?", "Delete Client: ",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsClient.DeleteClient(Convert.ToInt32(AccountNumber)))
                {
                    ShowAllClientsInListView();
                    ResetAfterUpdateOrDelete();
                    FillAccountNumbersInComboBox();
                    MessageBox.Show("The client was successfully deleted.", "Delete Client :",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The client has not been deleted.", "Delete Client :",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedItemForContextMenu == null)
                return;

            string AccountNumber = selectedItemForContextMenu.SubItems[0].Text;

            tpShowAllClients.SelectedTab = tpUpdateClient;

            cbAccountNumber.Text = AccountNumber;
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedItemForContextMenu == null)
                return;


            string AccountNumber = selectedItemForContextMenu.SubItems[0].Text;


            frmTransactions frm = new frmTransactions(CurrentUser);

            TabPage DepositTabPage = frm.tcTransactions.TabPages[0];

            frm.tcTransactions.SelectedTab = DepositTabPage;

            foreach(Control control in DepositTabPage.Controls)
            {
                if(control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    comboBox.Text = AccountNumber;
                }
            }  
            frm.PrintCurrentBalanceInScreenAfterDeposit();
            frm.ShowDialog();
            this.Show();

            ShowAllClientsInListView();
        }

        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedItemForContextMenu == null)
                return;


            string AccountNumber = selectedItemForContextMenu.SubItems[0].Text;


            frmTransactions frm = new frmTransactions(CurrentUser);

            TabPage DepositTabPage = frm.tcTransactions.TabPages[1];

            frm.tcTransactions.SelectedTab = DepositTabPage;

            frm.cbWAccountNumber.Text = AccountNumber;
            frm.PrintCurrentBalanceInScreenAfterWithdraw();
            
            frm.ShowDialog();
            this.Show();

            ShowAllClientsInListView();
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedItemForContextMenu == null)
                return;


            string AccountNumber = selectedItemForContextMenu.SubItems[0].Text;


            frmTransactions frm = new frmTransactions(CurrentUser);

            TabPage DepositTabPage = frm.tcTransactions.TabPages[3];

            frm.tcTransactions.SelectedTab = DepositTabPage;
            frm.cbFromAccountNumber.Text = AccountNumber;
            frm.PrintFromCurrentBalanceInScreen();
            
            frm.ShowDialog();
            this.Show();

            ShowAllClientsInListView();
        }
    }
}
