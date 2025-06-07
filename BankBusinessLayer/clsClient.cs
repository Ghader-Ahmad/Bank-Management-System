using System;
using System.Data;
using System.Net.Http.Headers;
using System.Security;
using BankDataAccessLayer;

namespace BankBusinessLayer
{
    public class clsClient : clsPersons
    {
        enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode;

        private bool _AddNewClient()
        {
            this.AccountNumber = clsClientData.AddNewClient(this.AccountNumber, this.PinCode, this.FirstName, this.LastName,
                this.Email, this.Phone, this.AccountBalance);

            return (this.AccountNumber != -1);
        }

        private bool _UpdateClient()
        {
            return clsClientData.UpdateClient(this.AccountNumber, this.PinCode, this.FirstName, this.LastName, this.Email,
                this.Phone, this.AccountBalance);
        }

        public int AccountNumber { get; set; }
        public string PinCode { get; set; }
        public double AccountBalance { get; set; }
        
        public clsClient()
        {
            AccountNumber = 0;
            PinCode = "";
            AccountBalance = 0.0;

            _Mode = enMode.AddNew;
        }

        private clsClient(int AccountNumber, string PinCode, double AccountBalance, string FirstName, 
            string LastName, string Email, string Phone)
            : base(FirstName, LastName, Email, Phone)
        { 
            this.AccountNumber = AccountNumber;
            this.PinCode = PinCode;
            this.AccountBalance = AccountBalance;

            _Mode = enMode.Update;
        }

    
        public static DataTable GetAllClients()
        {
            return clsClientData.GetAllClients();
        }

        public static DataTable GetAllClientsWithLessDetails()
        {
            return clsClientData.GetAllClientsWithLessDetails();
        }

        public static clsClient Find(int AccountNumber)
        {
            string PinCode = "", FirstName = "", LastName = "", Emial = "", Phone = "";
            double AccountBalance = 0.0;

            if (clsClientData.Find(AccountNumber, ref PinCode, ref FirstName, ref LastName, ref Emial, ref Phone, ref AccountBalance))
            {
                return new clsClient(AccountNumber, PinCode, AccountBalance, FirstName, LastName, Emial, Phone);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    {
                        _Mode = enMode.Update;
                        return _AddNewClient();
                    }

                case enMode.Update:
                    {
                        return _UpdateClient();
                    }
            }
            return false;
        }

        public static bool DeleteClient(int AccountNumber)
        {
            return clsClientData.DeleteClient(AccountNumber);
        }

        public static bool Deposit(int AccountNumber, double DepositAmount)
        {
            return clsClientData.Deposit(AccountNumber, DepositAmount);
        }

        public static bool Withdraw(int AccountNumber, double WithdrawAmount)
        {
            return clsClientData.Withdraw(AccountNumber, WithdrawAmount);
        }

        public static double GetTotalAccountBalance()
        {
            return clsClientData.GetTotalAccountBalance();
        }

        public static bool CreateATransferProcess(int UserID, int FromAccountNumber, int ToAccountNumber,
            double FromAccountBalance, double ToAccountBalance, DateTime TransferDate, double TransferAmount)
        {
            int insertedID = clsClientData.CreateATransferProcess(UserID, FromAccountNumber, ToAccountNumber,
                FromAccountBalance, ToAccountBalance, TransferDate, TransferAmount);

            return (insertedID != -1);
        }

        public static DataTable GetTransferLog()
        {
            return clsClientData.GetTransferLog();
        }

        public static bool ClientIsExist(int AccountNumber)
        {
            return clsClientData.ClientIsExist(AccountNumber);
        }
    }
}
