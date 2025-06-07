using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Security.Permissions;

                       
namespace BankDataAccessLayer
{
    public class clsClientData
    {
        public static DataTable GetAllClients()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"select Clients.AccountNumber, Clients.PinCode, Persons.FirstName, Persons.LastName, 
                            Persons.Email, Persons.Phone, Clients.AccountBalance
                            from Clients inner join Persons
                            on Clients.PersonID = Persons.ID;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);
            }
            catch(Exception ex)
            {
                //sda
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static DataTable GetAllClientsWithLessDetails()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"SELECT Clients.AccountNumber, Persons.FirstName, Clients.AccountBalance
                             FROM Clients INNER JOIN Persons
                             ON Clients.PersonID = Persons.ID;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch(Exception ex)
            {
                //sad
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool Find (int AccountNumber, ref string PinCode, ref string FirstName, ref string LastName, 
            ref string Email, ref string Phone, ref double AccountBalance)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"
                            select Clients.AccountNumber, Clients.PinCode, Persons.FirstName, Persons.LastName, 
                            Persons.Email, Persons.Phone, Clients.AccountBalance
                            from Clients inner join Persons
                            on Clients.PersonID = Persons.ID
                            where Clients.AccountNumber = @AccountNumber;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PinCode = (string)reader["PinCode"];
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    AccountBalance = (double)reader["AccountBalance"];
                }
                else
                    isFound = false;
            }
            catch(Exception ex)
            {
                // dsa
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }


        public static int AddNewClient (int AccountNumber, string PinCode, string FirstName, string LastName,
             string Email, string Phone, double AccountBalance)
        {
            int Id = -1;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"INSERT INTO Persons
                         (FirstName,LastName,Email,Phone)
                    VALUES (@FirstName, @LastName, @Email, @Phone);
                        
                     Declare @personID int;
                     set @personID =  Scope_Identity();

                    INSERT INTO Clients
                    (PersonID,PinCode,AccountBalance, AccountNumber)
                    VALUES (@personID, @PinCode, @AccountBalance, @AccountNumber);
                    
                    select Account = @AccountNumber;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@PinCode", PinCode);
            command.Parameters.AddWithValue("@AccountBalance", AccountBalance);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
               
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    Id = insertedID;
                }
                else
                    Id = -1;
            }
            catch(Exception ex)
            {
                //sas
            }
            finally
            {
                connection.Close();
            }
            return Id;
        }


        public static bool UpdateClient(int AccountNumber, string PinCode, string FirstName, string LastName,
             string Email, string Phone, double AccountBalance)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"Declare @personID int;
                             set @personID = (select PersonID from Clients where AccountNumber = @AccountNumber);

                            UPDATE Clients
                            SET PersonID = @personID
                               ,PinCode = @PinCode
                               ,AccountBalance = @AccountBalance
                            WHERE AccountNumber = @AccountNumber;

                             UPDATE Persons
                             SET FirstName = @FirstName
                                ,LastName = @LastName
                                ,Email = @Email
                                ,Phone = @Phone
                                where ID = @personID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PinCode", PinCode);
            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command.Parameters.AddWithValue("@AccountBalance", AccountBalance);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //asdas
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }


        public static bool  DeleteClient(int AccountNumber)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"Declare @personID int;
                             set @personID = (select PersonID from Clients where AccountNumber = @AccountNumber);
                             delete from Clients where AccountNumber = @AccountNumber;  
                             
                             delete from Persons where ID = @personID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // sd
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);

        }


        public static bool Deposit(int AccountNumber, double DepositAmount) 
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @" update Clients 
                              set AccountBalance += @NewAccountBalance
                              where AccountNumber = @AccountNumber;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NewAccountBalance", DepositAmount);
            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                // 
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }


        public static bool Withdraw(int AccountNumber , double WithdrawAmount)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection (clsBankDataAccessSettings.connectionString);

            string query = @"update Clients 
                             set AccountBalance -= @WithdrawAmount
                             where AccountNumber = @AccountNumber and AccountBalance >= @WithdrawAmount;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command.Parameters.AddWithValue("@WithdrawAmount", WithdrawAmount);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                /// dfsdf
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static double GetTotalAccountBalance()
        {
            double TotalBalance = 0.0;
            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"select Sum(AccountBalance) from Clients;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && double.TryParse(result.ToString(), out double totalBalance))
                {
                    TotalBalance = totalBalance;
                }
            }
            catch (Exception ex)
            {
                // sd
            }
            finally
            {
                connection.Close();
            }

            return TotalBalance;
        }

        public static int CreateATransferProcess(int UserID, int FromAccountNumber, int ToAccountNumber,
            double FromAccountBalance, double ToAccountBalance, DateTime TransferDate, double Amount)
        {
            int TransferID = -1;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"update Clients
                             set AccountBalance -= @Amount
                             where AccountNumber = @FromAccountNumber;

                             update Clients
                             set AccountBalance += @Amount
                             where AccountNumber = @ToAccountNumber;

                            INSERT INTO TransferLog
                            (UserID,Date,FromAcct, ToAcct,FromBalance,ToBalance, Amount)
                            VALUES
                        (@UserID,@Date, @FromAccountNumber, @ToAccountNumber, @FromAccountBalance, @ToAccountBalance, @Amount);

                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Date", TransferDate);
            command.Parameters.AddWithValue("@FromAccountNumber", FromAccountNumber);
            command.Parameters.AddWithValue("@ToAccountNumber", ToAccountNumber);
            command.Parameters.AddWithValue("@FromAccountBalance", FromAccountBalance);
            command.Parameters.AddWithValue("@ToAccountBalance", ToAccountBalance);
            command.Parameters.AddWithValue("@Amount", Amount);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString(), out int transferID))
                {
                    TransferID = transferID;
                }
            }
            catch(Exception ex)
            {
                //ada
            }
            finally
            {
                connection.Close();
            }
            return TransferID;
        }

        public static DataTable GetTransferLog()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"SELECT TransferLog.Date, TransferLog.FromAcct, TransferLog.ToAcct,
                            TransferLog.Amount, TransferLog.FromBalance, TransferLog.ToBalance, Users.UserName
                            FROM TransferLog INNER JOIN Users 
                            ON TransferLog.UserID = Users.UserID;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch(Exception ex)
            {
                //dsd
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }

        public static bool ClientIsExist(int AccountNumber)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"select Found = 1 from Clients where AccountNumber = @AccountNumber;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null)
                    isFound = true;

                else
                    isFound = false;
            }
            catch (Exception ex)
            {
                //sada
            }
            finally
            {
                connection.Close();
            }
            return isFound;

        }

    }
}
