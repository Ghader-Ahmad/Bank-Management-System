using System;
using System.Data;
using System.Data.SqlClient;

namespace BankDataAccessLayer
{
    public class clsCurrencyData
    {

        public static DataTable GetAllCurrencies()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"select  Code, Country, Name, Rate from Currencies;";
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
                //asd
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static bool FindCurrency(ref int CountryID, string Code, ref string Country, ref string Name
            , ref double Rate)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"select CountryID, Code, Country, Name, Rate from Currencies where Code = @Code;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Code", Code);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    isFound = true;


                    Rate = (double)reader["Rate"];
                    CountryID = (int)reader["CountryID"];
                    Country = (string)reader["Country"];
                    Name = (string)reader["Name"];
                }
            }
            catch (Exception ex)
            {
                //asa
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }


        public static bool UpdateRate(string Code, double NewRate)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.connectionString);

            string query = @"update Currencies 
                             set Rate = @NewRate
                             where Code = @Code;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NewRate", NewRate);
            command.Parameters.AddWithValue("@Code", Code);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //sdsf
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }

    }
}
