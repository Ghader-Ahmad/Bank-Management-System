using System;
using System.Data;
using System.Runtime.CompilerServices;
using BankDataAccessLayer;

namespace BankBusinessLayer
{
    public class clsUser : clsPersons
    {
        enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.Update;

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.FirstName, this.LastName, this.Email, this.Phone, 
                this.UserName, this.Password, this.Persmissions);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.FirstName, this.LastName, this.Email, this.Phone, this.UserName,
                this.Password, this.Persmissions);
        }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Persmissions { get; set; }

        public clsUser()
        {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.Persmissions = 0;

            _Mode = enMode.AddNew;
        }

        private clsUser(int userID, string userName, string password, int persmissions, string FirstName, string LastName, 
            string Email, string Phone)
            : base(FirstName, LastName, Email,Phone)
        {
            UserName = userName;
            Password = password;
            Persmissions = persmissions;
            UserID = userID;

            _Mode = enMode.Update;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }
        
        public static DataTable GetAllUsersWithLogDate()
        {
            return clsUserData.GetAllUsersWithLogDate();
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    {
                        _Mode = enMode.Update;
                        return _AddNewUser();
                    }

                    case enMode.Update:
                    {
                        return _UpdateUser();
                    }
            }
            return false;
        }

        public static clsUser Find(string UserName)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Password = "";
            int Permissions = 0, UserID = 0;

            if (clsUserData.FindByUserName(ref UserID, ref FirstName, ref LastName,
             ref Email, ref Phone, UserName, ref Password, ref Permissions))
            {
                return new clsUser(UserID, UserName, Password, Permissions, FirstName, LastName, Email, Phone);
            }
            else
                return null;
        }

        public static clsUser Find(string UserName, string Password)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "";
            int Permissions = 0, UserID = 0;

            if (clsUserData.FindByUserNameAndPassword(ref UserID, ref FirstName, ref LastName,
             ref Email, ref Phone, UserName, Password, ref Permissions))
            {
                return new clsUser(UserID, UserName, Password, Permissions, FirstName, LastName, Email, Phone);
            }
            else
                return null;
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

    }
}
