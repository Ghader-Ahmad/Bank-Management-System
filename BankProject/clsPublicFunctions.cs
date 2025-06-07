using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankProject
{
    class clsPublicFunctions
    {
        public enum enPermissions { ManageClients = 1, ManageUsers = 2, ClientsTransactions = 4,
            CurrencyExchange = 8, All = -1 };
        
        public  enPermissions permissions;

        public static string NumberToText(long Number)
        {
            if (Number == 0)
            {
                return "";
            }

            if (Number >= 1 && Number <= 19)
            {
                string[] arr = { "","One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
            "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

                return arr[Number] + " ";
            }

            if (Number >= 20 && Number <= 99)
            {
                string[] arr = { "", "", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                return arr[Number / 10] + "  " + NumberToText(Number % 10);
            }

            if (Number >= 100 && Number <= 199)
            {
                return "One Handred " + NumberToText(Number % 100);
            }

            if (Number >= 200 && Number <= 999)
            {
                return NumberToText(Number / 100) + " Handreds " + NumberToText(Number % 100);
            }

            if (Number >= 1000 && Number <= 1999)
            {
                return "One Thousand " + NumberToText(Number % 1000);
            }

            if (Number >= 2000 && Number <= 999999)
            {
                return NumberToText(Number / 1000) + " Thousands " + NumberToText(Number % 1000);
            }

            if (Number >= 1000000 && Number <= 1999999)
            {
                return "One Million " + NumberToText(Number % 1000000);
            }

            if (Number >= 2000000 && Number <= 999999999)
            {
                return NumberToText(Number / 1000000) + " Millios " + NumberToText(Number % 1000000);
            }

            if (Number >= 1000000000 && Number <= 1999999999)
            {
                return "One Billion " + NumberToText(Number % 1000000000);
            }

            else
            {
                return NumberToText(Number / 1000000000) + " Billios " + NumberToText(Number % 1000000000);
            }
        }

        public static void CheckForTheEntryOfThisField(CancelEventArgs e, TextBox textBox, ErrorProvider errorProvider)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider.SetError(textBox, "Required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox, "");
            }
        }

        public static void CheckForTheEntryOfThisFieldIsNumber(CancelEventArgs e, TextBox textBox, ErrorProvider errorProvider)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider.SetError(textBox, "Required!");
                return;
            }

            if(!int.TryParse(textBox.Text, out int number))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider.SetError(textBox, "Please enter numbers!");
            }

            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox, "");
            }
        }

        public static void ValidatingEmail(CancelEventArgs e, TextBox textBox, ErrorProvider errorProvider)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(textBox.Text, emailPattern))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider.SetError(textBox, "Please enter the email in a correct format!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox, "");
            }
        }

        public static bool ValidateNumber(string Input)
        {
            if (string.IsNullOrEmpty(Input))
                return true;

            int Number = 0;

            if (!int.TryParse(Input, out Number) && Number >= 0)
            {
                MessageBox.Show("Please enter a positive number!", "Info: ", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            else
                return true;
        }

        public static void IncreaseAndDecreaseProgressPar(Guna2CircleProgressBar progress, short value, Label lblProgress)
        {
            progress.Value += value;
            lblProgress.Text = (((float)progress.Value / progress.Maximum) * 100) + "%";
        }
    }
}
