using BankBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankProject
{
    public partial class frmTransactions: Form
    {
        clsUser CurrentUser;
        public frmTransactions(clsUser currentUser)
        {
            CurrentUser = currentUser;
            InitializeComponent();

            lblCurrentUserName.Text = "Welcome : " + CurrentUser.UserName;
        }

       

        // ---------------------------- Deposit (tab 1) ---------------------------------------------

        DataTable ClientsDataTable;
        clsClient CurrentClient;

        private void GetAllClient()
        {
            ClientsDataTable = clsClient.GetAllClients();
        }

        private void FillAccountNumbersInComboBox(ComboBox comboBox)
        {
            GetAllClient();

            comboBox.Items.Clear();

            DataView dv = ClientsDataTable.DefaultView;

            for (int i = 0; i < dv.Count; i++)
            {
                comboBox.Items.Add(dv[i][0].ToString());
            }
        }

        private void ShowCurrentBalanceLabel(bool visible, Label label1 , Label label2)
        {
            label1.Visible = visible;
            label2.Visible = visible;
        }

        public void PrintCurrentBalanceInScreenAfterDeposit()
        {
            ShowCurrentBalanceLabel(true, lblBalance, lblCurrentBalance);

            CurrentClient = clsClient.Find(Convert.ToInt32(cbAccountNumber.Text));
            lblCurrentBalance.Text = $"${CurrentClient.AccountBalance}";
        }

        private void RefreshScreenAfterDeposit()
        {
            cbAccountNumber.Text = "";
            nudDepositAmount.Value = 0;

            ShowCurrentBalanceLabel(false, lblBalance, lblCurrentBalance);
        }

        private bool HaveAllTheInformationWereEntered(ComboBox comboBox, NumericUpDown numericUp)
        {
            if (string.IsNullOrEmpty(comboBox.Text) || numericUp.Value == 0)
            {
                MessageBox.Show("Please enter all the information.", "Warning", MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Warning);
                return false;
            }

            else
                return true;
        }

        private void Deposit()
        {
            if (!HaveAllTheInformationWereEntered(cbAccountNumber, nudDepositAmount))
                return;

            if (MessageBox.Show("Are you sure to perform this transaction?", "Confirm", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsClient.Deposit(Convert.ToInt32(cbAccountNumber.Text), ((double)nudDepositAmount.Value)))
                {
                    PrintCurrentBalanceInScreenAfterDeposit();

                    MessageBox.Show($"Amount has been deposited (${CurrentClient.AccountBalance}) Successfully", "Alarm", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    RefreshScreenAfterDeposit();
                }
                else
                {
                    MessageBox.Show($"Amount has not been deposited (${CurrentClient.AccountBalance}) Successfully", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    RefreshScreenAfterDeposit();
                }
            }
        }

        private void frmTransactions_Load(object sender, EventArgs e)
        {
            FillAccountNumbersInComboBox(cbAccountNumber);
            FillAccountNumbersInComboBox(cbWAccountNumber);
            FillAccountNumbersInComboBox(cbFromAccountNumber);
            FillAccountNumbersInComboBox(cbToAccountNumber);
            ShowTotalBalance();
            PrintTotalBalanceInScreen();
        }

        private void cbAccountNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrintCurrentBalanceInScreenAfterDeposit();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            Deposit();
        }

        // ---------------------------- Withdraw (tap 2) ---------------------------------------------


        private void RefreshScreenAfterWithdraw()
        {
            cbWAccountNumber.Text = "";
            nudWithdrawAmount.Value = 0;

            ShowCurrentBalanceLabel(false, lblWBalance, lblWCurrentBalance);
        }

        public void PrintCurrentBalanceInScreenAfterWithdraw()
        {
            ShowCurrentBalanceLabel(true, lblWBalance, lblWCurrentBalance);

            CurrentClient = clsClient.Find(Convert.ToInt32(cbWAccountNumber.Text));
            lblWCurrentBalance.Text = $"${CurrentClient.AccountBalance}"; 
        }

        private bool EnsureThatTheAccountBalanceIsNotEmpty()
        {
            if (CurrentClient.AccountBalance == 0)
            {
                MessageBox.Show("The Account Balance is empty you can not withdraw !", 
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RefreshScreenAfterWithdraw();

                return false;
            }

            else
                return true;
        }

        private bool EnsureThatTheAccountBalanceIsSufficient(int WithdrawAmount)
        {
            if (CurrentClient.AccountBalance >= WithdrawAmount)
                return true;
            
            else
            {
                MessageBox.Show("Account Balance is not enough to withdraw the required amount!",
                    "Warning : ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RefreshScreenAfterWithdraw();

                return false;
            }
        }

        private void Withdraw()
        {
            if (!HaveAllTheInformationWereEntered(cbWAccountNumber, nudWithdrawAmount))
                return;

            PrintCurrentBalanceInScreenAfterWithdraw();

            if (!EnsureThatTheAccountBalanceIsNotEmpty())
                return;

            if (!EnsureThatTheAccountBalanceIsSufficient(Convert.ToInt32(nudWithdrawAmount.Value)))
                return;


            if (MessageBox.Show("Are you sure to perform this transaction?", "Confirm", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsClient.Withdraw(Convert.ToInt32(cbWAccountNumber.Text), ((Int32)nudWithdrawAmount.Value)))
                {
                    PrintCurrentBalanceInScreenAfterWithdraw();

                    MessageBox.Show($"Amount has been withdraw (${CurrentClient.AccountBalance}) Successfully", 
                        "Alarm", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    RefreshScreenAfterWithdraw();
                }
                else
                {
                    MessageBox.Show("There is an error that the withdrawal process did not take place from the account."
                        , "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    RefreshScreenAfterWithdraw();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Withdraw();
        }

        private void cbWAccountNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrintCurrentBalanceInScreenAfterWithdraw();
        }


        // ---------------------------- Total Balance (tap 3) ---------------------------------------------

        DataTable TotalBalance;

        private void GetAllClientsWithLessDetails()
        {
            TotalBalance = clsClient.GetAllClientsWithLessDetails();
        }

        private void PrintTotalBalanceInListView(DataView dv)
        {
            lvTotalBalance.Items.Clear();

            for (int i = 0; i < dv.Count; i++)
            {
                ListViewItem item = new ListViewItem(dv[i][0].ToString());

                item.SubItems.Add(dv[i][1].ToString());
                item.SubItems.Add(dv[i][2].ToString());

                lvTotalBalance.Items.Add(item);
            }

            PrintCountClients();
        }

        private void ShowTotalBalance()
        {
            GetAllClientsWithLessDetails();

            DataView dataView = TotalBalance.DefaultView;

            PrintTotalBalanceInListView(dataView);
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(txtSearchClients.Text))
            {
                ShowTotalBalance();
                return;
            }

            if (!clsPublicFunctions.ValidateNumber(txtSearchClients.Text))
                return;

            DataView dv = TotalBalance.DefaultView;

            dv.RowFilter = $"AccountNumber = {txtSearchClients.Text}";

            PrintTotalBalanceInListView(dv);
        }

        private void SortBy(string sort)
        {
            DataView dataView = TotalBalance.DefaultView;

            dataView.Sort = sort;

            PrintTotalBalanceInListView(dataView);
        }

        private void Sorting()
        {
            if (rbSortAsc.Checked)
                SortBy("AccountNumber Asc");

            if (rbSortDesc.Checked)
                SortBy("AccountNumber Desc");
        }

        private void PrintTotalBalanceInScreen()
        {
            double TotalBalance = clsClient.GetTotalAccountBalance();

            lblTotalBalance.Text = $"( ${TotalBalance.ToString()} )";
            lblTotalBalanceInWriting.Text = $"( {clsPublicFunctions.NumberToText(Convert.ToInt32(TotalBalance))} ) Dollar (s)."; 
        }

        private void PrintCountClients()
        {
            lblCountClients.Text = lvTotalBalance.Items.Count.ToString() + " Client(s) Found.";
        }

      

        private void rbSortAsc_Click(object sender, EventArgs e)
        {
            Sorting();
        }

       
        private void txtSearchClients_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void tpTotalBalance_Enter(object sender, EventArgs e)
        {
            ShowTotalBalance();
            PrintTotalBalanceInScreen();
        }

        // ---------------------------- Transfer Balance (tap 4) ---------------------------------------------

        clsClient FromClient, ToClient;

        public void PrintFromCurrentBalanceInScreen()
        {
            ShowCurrentBalanceLabel(true, lblFromBalance, lblTFCurrentBalance);

            FromClient = clsClient.Find(Convert.ToInt32(cbFromAccountNumber.Text));
            lblFromBalance.Text = $"${FromClient.AccountBalance}";
        }

        private void PrintToCurrentBalanceInScreen()
        {
            ShowCurrentBalanceLabel(true, lblToBalance, lblTToCurrentBalance);

            ToClient = clsClient.Find(Convert.ToInt32(cbToAccountNumber.Text));
            lblToBalance.Text = $"${ToClient.AccountBalance}";
        }

        private void RefreshAfterTransferProcess()
        {
            cbToAccountNumber.Text = "";
            cbFromAccountNumber.Text = "";
            nudTransferAmount.Value = 0;

            ShowCurrentBalanceLabel(false, lblTFCurrentBalance, lblFromBalance);
            ShowCurrentBalanceLabel(false, lblTToCurrentBalance, lblToBalance);
        }
        
        private bool CheckForAllTheRequiredData()
        {
            if(string.IsNullOrEmpty(cbFromAccountNumber.Text) || string.IsNullOrEmpty(cbToAccountNumber.Text) || 
                nudTransferAmount.Value == 0)
            {
                MessageBox.Show("Please enter the account number you want to withdraw from it, the recipient account " +
                    "number and the amount sent.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private bool VerifyThatTheAmountSentIsValid()
        {
            if (FromClient.AccountBalance >= Convert.ToDouble(nudTransferAmount.Value))
                return true;

            else
            {
                MessageBox.Show("The amount sent is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudTransferAmount.Value = 0;
                nudTransferAmount.Focus();
                return false;
            }
        }

        private bool CheckTheRecipientAccountNumber()
        {
            if (cbFromAccountNumber.Text != cbToAccountNumber.Text)
                return true;

            else
            {
                MessageBox.Show("The recipient account number is not valid", "Waring", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
        }

        private void Transfer()
        {
            if (!CheckForAllTheRequiredData())
                return;

            if (!VerifyThatTheAmountSentIsValid())
                return;

            if (!CheckTheRecipientAccountNumber())
                return;

            if (MessageBox.Show("Are you sure to perform this transaction?", "Confirm",MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsClient.CreateATransferProcess(CurrentUser.UserID, FromClient.AccountNumber, ToClient.AccountNumber,
                  FromClient.AccountBalance, ToClient.AccountBalance, DateTime.Now, Convert.ToDouble(nudTransferAmount.Value)))
                {
                    RefreshAfterTransferProcess();
                    MessageBox.Show("Transfer Done Successfully.", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }


        private void cbToAccountNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrintToCurrentBalanceInScreen();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Transfer();
        }

        private void cbFromAccountNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrintFromCurrentBalanceInScreen();
        }

        // ---------------------------- Transfer Log (tap 5) --------------------------------------------

        DataTable TransferLogDataTable;

        private void GetTransferLog()
        {
            TransferLogDataTable = clsClient.GetTransferLog();
        }

        private void PrintTransferLogInListView(DataView dv)
        {
            lvTransferLog.Items.Clear();
           
            for(int i = 0; i < dv.Count; i++)
            {
                ListViewItem item = new ListViewItem(dv[i][0].ToString().Trim());

                item.SubItems.Add(dv[i][1].ToString().Trim());
                item.SubItems.Add(dv[i][2].ToString().Trim());
                item.SubItems.Add(dv[i][3].ToString().Trim());
                item.SubItems.Add(dv[i][4].ToString().Trim());
                item.SubItems.Add(dv[i][5].ToString().Trim());
                item.SubItems.Add(dv[i][6].ToString().Trim());

                lvTransferLog.Items.Add(item);
            }
            PrintCountTransferLog();
        }

        private void ShowTransferLog()
        {
            GetTransferLog();
            DataView dataView = TransferLogDataTable.DefaultView;

            PrintTransferLogInListView(dataView);
        }

        private void SearchInTransferLog()
        {
            if (string.IsNullOrEmpty(txtSearchInTransferLog.Text))
            {
                ShowTransferLog();
                return;
            }

            if (!clsPublicFunctions.ValidateNumber(txtSearchInTransferLog.Text))
                return;

            DataView dataView = TransferLogDataTable.DefaultView;

            dataView.RowFilter = $"FromAcct = {txtSearchInTransferLog.Text} or ToAcct = {txtSearchInTransferLog.Text}";

            PrintTransferLogInListView(dataView);
        }

        private void SortByInTransferLog(string sort)
        {
            DataView dataView = TransferLogDataTable.DefaultView;

            dataView.Sort = sort;
            PrintTransferLogInListView(dataView);
        }

        private void SortingTransferLog()
        {
            if (rbSortTransferLogAsc.Checked)
                SortByInTransferLog("FromAcct asc");

            if (rbSortTransferLogDesc.Checked)
                SortByInTransferLog("FromAcct Desc");

        }

        private void PrintCountTransferLog()
        {
            lblCountTransferLog.Text = lvTransferLog.Items.Count.ToString() + " Client(s).";
        }

        private void rbSortTransferLogAsc_Click(object sender, EventArgs e)
        {
            SortingTransferLog();
        }

        private void TransactionTimer_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM yyyy  \nHH:mm:ss tt");
        }

        private void txtSearchInTransferLog_TextChanged_1(object sender, EventArgs e)
        {
            SearchInTransferLog();
        }

        private void tpTransferLog_Enter(object sender, EventArgs e)
        {
            ShowTransferLog(); ;
        }

    }
}
