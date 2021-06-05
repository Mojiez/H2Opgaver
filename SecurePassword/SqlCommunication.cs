using SecurePassword.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SecurePassword
{
    internal class SqlCommunication
    {

        //------------------------------------------------------------------------- User Methods

        
        public void CreateUser(SqlConnection connection, User user)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Users (UserName, Password, Salt) VALUES (@UserName, @Password, @Salt)", connection);

            command.Parameters.AddWithValue("UserName", user.UserName);
            command.Parameters.AddWithValue("Password", user.Password);
            command.Parameters.AddWithValue("Salt", user.Salt);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Make a query to the selected database/sql connection
        /// Gets the Salt from db based on user name
        /// </summary>
        /// <param name="username"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public string GetSalt(string username, SqlConnection connection)
        {
            DataSet data = new DataSet();
            // Makes the query so it takes a parameter
            SqlCommand command = new SqlCommand("SELECT Salt FROM Users WHERE @UserName = Users.UserName", connection);
            //Adds the username parameter value to the command parameter
            command.Parameters.AddWithValue("Username", username);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(data);
            //Secures that the application runs 
            try
            {
                return data.Tables[0].Rows[0].ItemArray[0].ToString(); // returns if successfull
            }
            catch (Exception ex)
            {
                return ex.Message; // returns the error is the method throws an exception
            }
            
        }

        public string GetHash(string username, SqlConnection connection)
        {
            DataSet data = new DataSet();
            SqlCommand command = new SqlCommand("SELECT Password FROM Users WHERE @UserName = Users.UserName", connection);

            command.Parameters.AddWithValue("Username", username);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(data);
            try
            {
                return data.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
