using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankBusinessLayer;

namespace BankProject
{
    public partial class frmCurrencyExchange: Form
    {
        public frmCurrencyExchange(string UserName)
        {
            InitializeComponent();

            lblCurrentUserName.Text = "Welcome : " +  UserName;

        }

        // --------------------------- Show All Currencies (tap 1) -----------------------------------------

        DataTable CurrenciesDataTable;

        private void GetAllCurrencies()
        {
            // Recover all currency data and store us in Data Table
            CurrenciesDataTable = clsCurrency.GetAllCurrencies();
        }

        private void PrintAllCurrenciesInListView(DataView dv)
        {
            // Currency data print in List View using for loop
            lvShowAllCurremcies.Items.Clear();

            for(int i = 0; i < dv.Count; i++)
            {
                ListViewItem item = new ListViewItem(dv[i][0].ToString().Trim());

                item.SubItems.Add(dv[i][1].ToString().Trim());
                item.SubItems.Add(dv[i][2].ToString().Trim());
                item.SubItems.Add(dv[i][3].ToString().Trim());

                lvShowAllCurremcies.Items.Add(item);
            }

            // Print the number of currencies
            PrintCountCurrencies();
        }

        private void ShowAllCurrencies()
        {
            GetAllCurrencies();

            DataView dataView = CurrenciesDataTable.DefaultView;

            PrintAllCurrenciesInListView(dataView);

        }

        private void SortBy(string sort)
        {
            // To arrange currencies, we know a dataview and use sort method
            DataView dataView = CurrenciesDataTable.DefaultView;

            dataView.Sort = sort;

            PrintAllCurrenciesInListView(dataView);
        }

        private void Sorting()
        {
            if (rbSortAsc.Checked)
                SortBy("Code asc");

            if (rbSortDesc.Checked)
                SortBy("Code desc");
        }

        private void Search()
        {
            // To search in currencies we know DataView and use RowFilter method with like statement.
            DataView dataView = CurrenciesDataTable.DefaultView;

            dataView.RowFilter = $"Country like '%{txtSearchCurrency.Text}' or Country like '{txtSearchCurrency.Text}%' or " +
                $"Country like '%{txtSearchCurrency.Text}%' or Code like '%{txtSearchCurrency.Text}' or Code like '{txtSearchCurrency.Text}%' or " +
                $"Code like '%{txtSearchCurrency.Text}%'";

            // Print after the arrangement
            PrintAllCurrenciesInListView(dataView);
        }

        private void PrintCountCurrencies()
        {
            lblCountCurrency.Text = lvShowAllCurremcies.Items.Count + " Currency(s) Found"; 
        }

        private void frmCurrencyExchange_Load(object sender, EventArgs e)
        {
            ShowAllCurrencies();
        }

        private void rbSortAsc_Click(object sender, EventArgs e)
        {
            Sorting();
        }

        private void txtSearchCurrency_TextChanged_1(object sender, EventArgs e)
        {
            Search();
        }

        private void tpShowAllCurrency_Enter(object sender, EventArgs e)
        {
            ShowAllCurrencies();
        }

        // --------------------------- Update Rate (tap 2) -----------------------------------------

        clsCurrency CurrenctCurrency;

        private void FillCurrenciesInComboBox(DataView dv, ComboBox comboBox)
        {
            // 
            comboBox.Items.Clear();

            for(int i = 0; i < dv.Count; i++)
            {
                comboBox.Items.Add(dv[i][0]);
            }
        }

        private void FillAllCurrenciesInComboBox(ComboBox comboBox)
        {
            // Recover all currency data and store us in Data Table in preparation for putting it in ComboBox
            GetAllCurrencies();

            DataView dataView = CurrenciesDataTable.DefaultView;

            // Printing all currencies in ComboBox
            FillCurrenciesInComboBox(dataView, comboBox);
        }

        private void ShowCurrencyDataInPanel(Label LCode, Label LCountry, Label LName, Label LRate , clsCurrency currency)
        {
            // View currency data on the screen

            LCode.Text = $"Code : {currency.Code}";
            LCountry.Text = $"Country : {currency.Country}";
            LName.Text = $"Name : {currency.Name}";
            LRate.Text = $"Rate : ({currency.Rate}$)";
        }

        private void SearchInComboBox(ComboBox comboBox)
        {
            // Search within the combobox via the first letter
            DataView dataView = CurrenciesDataTable.DefaultView;

            dataView.RowFilter = $"Code like '{comboBox.Text}%' ";

            FillCurrenciesInComboBox(dataView, comboBox);

            if (dataView.Count > 0 && !string.IsNullOrEmpty(comboBox.Text))
                comboBox.DroppedDown = true;
        }

        private void ViewTheSelectedCurrencyData(ComboBox comboBox, Panel PCurrenctCurrency, ref clsCurrency currency, 
            Button buttonToRetreat, Label LCode, Label LCountry, Label LName, Label LRate)
        {
            if (string.IsNullOrEmpty(comboBox.Text))
            {
                FillAllCurrenciesInComboBox(comboBox);
                PCurrenctCurrency.Visible = false;
                comboBox.DroppedDown = false;
                return;
            }

            currency = clsCurrency.Find(comboBox.Text);
          

            if (currency == null)
            {
                SearchInComboBox(comboBox);
                    return;
            }
            PCurrenctCurrency.Visible = true;
            buttonToRetreat.Visible = true;

            ShowCurrencyDataInPanel(LCode, LCountry, LName, LRate, currency);
        }

        private bool VerifyTheEntryOfDataBeforeUpdateRate()
        {
            if (string.IsNullOrEmpty(cbCode.Text) || nudNewRate.Value == 0)
            {
                MessageBox.Show("Please enter Code and New Rate!", "Info: ", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            else
                return true;
        }

        private void ScreenUpdateAfterUpdaeRate()
        {
            pUpdateCurrency.Visible = false;
            cbCode.Text = "";
            nudNewRate.Value = 0;
            btnToRetreatInUpdateCurrency.Visible = false;
        }

        private void ReferToTheUpdateRate()
        {
            ScreenUpdateAfterUpdaeRate();
        }

        private void UpdateRate()
        {
            if (!VerifyTheEntryOfDataBeforeUpdateRate())
                return;

            if (clsCurrency.UpdateRate(cbCode.Text, Convert.ToDouble(nudNewRate.Value)))
            {
                ScreenUpdateAfterUpdaeRate();
                MessageBox.Show("The Rate modification process was successful.", "Alarm", 
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }


        private void cbCode_TextChanged(object sender, EventArgs e)
        {
            ViewTheSelectedCurrencyData(cbCode, pUpdateCurrency,ref CurrenctCurrency, btnToRetreatInUpdateCurrency, 
                lblCode,lblCountry,lblName, lblRate);
        }

        private void btnUpdateRate_Click(object sender, EventArgs e)
        {
            UpdateRate();
        }

        private void cbCode_Enter(object sender, EventArgs e)
        {
            FillAllCurrenciesInComboBox(cbCode);
        }

        private void btnToRetreat_Click(object sender, EventArgs e)
        {
            ReferToTheUpdateRate();
        }

        // --------------------------- Currency Calaculator (tap 3) -----------------------------------------

        clsCurrency CurrencyFrom;
        clsCurrency CurrencyTo;

        private int GetAmountToExchane()
        {
            return Convert.ToInt32(nudAmountToExchange.Value);
        }

        private void ResetComboBox()
        {
            cbConvertTo.Text = "";
            cbConvretFrom.Text = "";
            nudAmountToExchange.Value = 0;
        }

        private void ResetPanel()
        {
            pConvert.Visible = false;
            pConvertFrom.Visible = false;
            pConvertTo.Visible = false;
        }

        private void ResetAfterConvert()
        {
            ResetComboBox();
            ResetPanel();
        }

        private bool VerifyTheEntryOfDataBeforeConvert()
        {
            if(string.IsNullOrEmpty(cbConvertTo.Text) || string.IsNullOrEmpty(cbConvretFrom.Text) || 
                nudAmountToExchange.Value == 0)
            {
                MessageBox.Show("Please enter convert to and convert from and amount to exchange", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
                return true;
        }

        private void Reset()
        { 
            ResetAfterConvert();
        }

        private void ConvertCurrency()
        {
            if (!VerifyTheEntryOfDataBeforeConvert())
                return;

            pConvert.Visible = true;
            lblConvert.Text = $"{nudAmountToExchange.Value.ToString()} {cbConvretFrom.Text} =" +
                $" {(GetAmountToExchane() * CurrencyTo.Rate)} {CurrencyTo.Code}";

            lblConvertTo.Text = $"{nudAmountToExchange.Value.ToString()} {cbConvretFrom.Text} =" +
                $" {clsPublicFunctions.NumberToText(Convert.ToInt64(GetAmountToExchane() * CurrencyTo.Rate))} {CurrencyTo .Code}";
        }




        private void cbConvretFrom_TextChanged(object sender, EventArgs e)
        {
            ViewTheSelectedCurrencyData(cbConvretFrom, pConvertFrom, ref CurrencyFrom,
             btnToRetreatInUpdateCurrency, lblFCode, lblFCountry, lblFName, lblFRate);
        }

        private void cbConvertTo_TextChanged(object sender, EventArgs e)
        {
            ViewTheSelectedCurrencyData(cbConvertTo, pConvertTo, ref CurrencyTo,
                btnToRetreatInUpdateCurrency, lblTCode, lblTCountry, lblTName, lblTRate);
        }


        private void cbConvretFrom_Enter(object sender, EventArgs e)
        {
            ViewTheSelectedCurrencyData(cbConvretFrom, pConvertFrom, ref CurrencyFrom,
          btnToRetreatInUpdateCurrency, lblFCode, lblFCountry, lblFName, lblFRate);
        }

        private void cbConvertTo_Enter(object sender, EventArgs e)
        {
            ViewTheSelectedCurrencyData(cbConvertTo, pConvertTo, ref CurrencyTo,
               btnToRetreatInUpdateCurrency, lblTCode, lblTCountry, lblTName, lblTRate);
        }


        private void btnConvert_Click(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void CurrencyTimer_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM yyyy  \nHH:mm:ss tt");
        }



        private ListViewItem selectedItemForContextMenu;

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Point mousePosition = lvShowAllCurremcies.PointToClient(Control.MousePosition);

            ListViewHitTestInfo hitTestInfo = lvShowAllCurremcies.HitTest(mousePosition);

            if (hitTestInfo.Item != null)
            {
                selectedItemForContextMenu = hitTestInfo.Item;
            }
            else
                selectedItemForContextMenu = null;

        }

        private void updateCurrencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedItemForContextMenu == null)
                return;

            string Code = selectedItemForContextMenu.SubItems[0].Text;

            tpCurrencyExchange.SelectedTab = tpUpdateRate;

            cbCode.Text = Code;
        }

        private void currencyFromToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (selectedItemForContextMenu == null)
                return;

            string Code = selectedItemForContextMenu.SubItems[0].Text;

            tpCurrencyExchange.SelectedTab = tpCurrencyCalculator;

            cbConvretFrom.Text = Code;
        }
    }
}
