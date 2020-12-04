using Hotel_LandLyst_WebApp.Interfaces;
using Hotel_LandLyst_WebApp.Logic;
using Hotel_LandLyst_WebApp.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hotel_LandLyst_WebApp.Dal
{
    public static class DBManager
    {
        private static IConfiguration configuration1;
        private static IGetCommands commandBuilder = new CommandBuilder();
        private static void SendToDataBase(SqlCommand sqlCommand)
        {
            SqlConnection sqlConnection = new SqlConnection(configuration1.GetConnectionString("myConnection"));
            sqlConnection.Open();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
   
        private static int ConvertBoolToBit(bool trueOrFalse)
        {
            if (trueOrFalse == true)
                return 1;
            else
                return 0;
        }

        private static bool ConvertToBool(int bit)
        {
            if (bit == 1)
                return true;
            else
                return false;
        }

        //--------------------------------------------------------RoomModel
        #region Room
        public static void SaveRoomToDb(RoomModel roomModel, IConfiguration configuration)
        {
            configuration1 = configuration;
            
            
            SqlCommand command = ((CommandBuilder)commandBuilder).BuildObjectString(roomModel, commandBuilder.InsertInto(roomModel.GetType().Name));
            ((CommandBuilder)commandBuilder).InsertDataValues(command, roomModel);
            SendToDataBase(command);
        }

        public static List<RoomModel> GetRoomsFromDb(IConfiguration configuration)
        {
            List<RoomModel> roomModels = new List<RoomModel>();
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("myConnection"));
            SqlCommand sqlCommand = new SqlCommand(commandBuilder.SelectFromTable("RoomModel"), sqlConnection);
            sqlConnection.Open();
            sqlCommand.Connection = sqlConnection;
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                int number = (int)dataReader["Number"];
                bool clean = (bool)dataReader["Clean"];
                bool rented = (bool)dataReader["Rented"];
                double pricePerNight = (double)dataReader["PricePerNight"];

                roomModels.Add(new RoomModel()
                {
                    Number = number,
                    Clean = clean,
                    Rented = rented,
                    PricePerNight = (float)pricePerNight
                });
            }
            sqlConnection.Close();
            return roomModels;
        }
        #endregion



        //--------------------------------------------------------FurnitureModel

        public static void SaveFurnitureToDb(FurnitureModel furnitureModel, IConfiguration configuration)
        {
            configuration1 = configuration;

            SqlCommand command = ((CommandBuilder)commandBuilder).BuildObjectString(furnitureModel, commandBuilder.InsertInto(furnitureModel.GetType().Name));
            ((CommandBuilder)commandBuilder).InsertDataValues(command, furnitureModel);
            SendToDataBase(command);
        }

        //--------------------------------------------------------Users
        public static List<EmployeeModel> GetEmployeeModels(IConfiguration configuration)
        {
            List<EmployeeModel> empModels = new List<EmployeeModel>();
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("myConnection"));
            SqlCommand sqlCommand = new SqlCommand("SELECT EmployeeModel.FirstName, EmployeeModel.LastName, EmployeeModel.Admin, EmployeeModel.UserName, EmployeeModel.Password, Title.Name FROM EmployeeModel, Title WHERE EmployeeModel.FKTitle_Id = Title.Id", sqlConnection);
            sqlConnection.Open();
            sqlCommand.Connection = sqlConnection;
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                string fName = (string)dataReader["FirstName"];
                string lName = (string)dataReader["LastName"];
                string uName = (string)dataReader["UserName"];
                string password = (string)dataReader["Password"];
                bool admin = (bool)dataReader["Admin"];
                string title = (string)dataReader["Name"];

                empModels.Add(new EmployeeModel(fName, lName, admin, uName, password, title));
            }
            sqlConnection.Close();
            return empModels;
        }
    }
}
