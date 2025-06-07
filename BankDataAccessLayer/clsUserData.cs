using System;
using System.Data;
using System.Data.SqlClient;

namespace BankDataAccessLayer
{
    public class clsUserData
    {
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"
                        SELECT   Users.UserName, Persons.FirstName, Persons.LastName, Persons.Email, Persons.Phone, 
                         Users.Password, Users.Permissions
                         FROM            Persons INNER JOIN
                         Users ON Persons.ID = Users.PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);
            }
            catch (Exception ex)
            {
                ///
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }

        public static DataTable GetAllUsersWithLogDate()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"
                       SELECT Users.UserName, LoginRegister.LogDate, Persons.FirstName, Persons.LastName,
                            Persons.Email, Persons.Phone, Users.Password, Users.Permissions
                            FROM LoginRegister INNER JOIN Users 
                            ON LoginRegister.UserID = Users.UserID INNER JOIN
                            Persons 
                            ON Persons.ID = Users.PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);
            }
            catch (Exception ex)
            {
                ///
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }


        public static int AddNewUser(string FirstName, string LastName, string Email, string Phone, string UserName, 
            string Password, int Persmissions)
        {
            int UserId = -1;
            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"INSERT INTO Persons
                        (FirstName,LastName,Email,Phone)
                        VALUES (@FirstName, @LastName, @Email, @Phone)
                        
                        Declare @personID int;
                        set @personID = Scope_Identity();

                             INSERT INTO Users
                             (PersonID, UserName,Password,Permissions)
                             VALUES (@personID, @UserName, @Password, @Permissions);

                        Declare @userID int;
                        set @userID = Scope_Identity();

                              INSERT INTO LoginRegister
                             (UserID, LogDate)
                             VALUES (@userID, @LogDate);

                              select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Permissions", Persmissions);
            command.Parameters.AddWithValue("@LogDate", DateTime.Now);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    UserId = insertedID;
                }
                else
                    UserId = -1;
            }
            catch(Exception ex)
            {
                UserId = -1;
            }
            finally
            {
                connection.Close();
            }
            return UserId;
        }


        public static bool UpdateUser(int UserID, string FirstName, string LastName, string Email, string Phone,
            string UserName, string Password, int Persmissions)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"
                    declare @personID int;
                    set @personID = (select PersonID from Users where UserID = @UserID);
                    
                    UPDATE Persons
                    SET FirstName = @FirstName
                       ,LastName = @LastName
                       ,Email = @Email
                       ,Phone = @Phone
                    WHERE ID = @personID;

                    UPDATE Users
                      SET UserName = @UserName
                         ,Password = @Password
                         ,Permissions = @Permissions
                    WHERE UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Permissions", Persmissions);


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

        public static bool FindByUserNameAndPassword(ref int UserID, ref string FirstName, ref string LastName,
            ref string Email, ref string Phone,string UserName, string Password, ref int Persmissions)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"SELECT Persons.FirstName, Persons.LastName, Persons.Email, Persons.Phone, 
                                Users.Password, Users.UserName, Users.Permissions, Users.UserID
                                FROM Persons INNER JOIN Users 
                                ON Persons.ID = Users.PersonID
                                where Users.UserName = @UserName and Users.Password = @Password";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    Persmissions = (int)reader["Permissions"];
                    UserID = (int)reader["UserID"];
                }
                else
                    isFound = false;
            }
            catch(Exception ex)
            {
                isFound = false;
            }
            finally
            { connection.Close(); }
            return isFound;
        }

        public static bool FindByUserName(ref int UserID, ref string FirstName, ref string LastName,
            ref string Email, ref string Phone, string UserName,ref string Password, ref int Persmissions)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"SELECT Persons.FirstName, Persons.LastName, Persons.Email, Persons.Phone, 
                                Users.Password, Users.UserName, Users.Permissions, Users.UserID
                                FROM Persons INNER JOIN Users 
                                ON Persons.ID = Users.PersonID
                                where Users.UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    Persmissions = (int)reader["Permissions"];
                    UserID = (int)reader["UserID"];
                }
                else
                    isFound = false;
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            { connection.Close(); }
            return isFound;
        }   

        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"
                            delete from LoginRegister where UserID =@UserID; 
                            delete from Users where UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // 
            }
            finally { connection.Close(); }

            return (rowsAffected > 0);
        }


    }
}
