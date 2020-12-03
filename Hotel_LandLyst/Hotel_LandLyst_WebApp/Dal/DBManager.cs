using Hotel_LandLyst_WebApp.Interfaces;
using Hotel_LandLyst_WebApp.Logic;
using Hotel_LandLyst_WebApp.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Hotel_LandLyst_WebApp.Dal
{
    public static class DBManager
    {
        private static IConfiguration configuration1;
        private static void SendToDataBase(SqlCommand sqlCommand)
        {
            SqlConnection sqlConnection = new SqlConnection(configuration1.GetConnectionString("myConnection"));
            sqlConnection.Open();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static int ConvertBoolToBit(bool trueOrFalse)
        {
            if (trueOrFalse == true)
                return 1;
            else
                return 0;
        }

        public static bool ConvertToBool(int bit)
        {
            if (bit == 1)
                return true;
            else
                return false;
        }
        //Save
        //--------------------------------------------------------RoomModel

        public static void SaveRoomToDb(RoomModel roomModel, IConfiguration configuration)
        {
            configuration1 = configuration;
            IGetCommands commandBuilder = new CommandBuilder();
            
            SqlCommand command = ((CommandBuilder)commandBuilder).BuildObjectString(roomModel, commandBuilder.InsertInto(roomModel.GetType().Name));
            ((CommandBuilder)commandBuilder).InsertDataValues(command, roomModel);
            SendToDataBase(command);
        }

        //--------------------------------------------------------FurnitureModel

        public static void SaveFurnitureToDb(FurnitureModel furnitureModel, IConfiguration configuration)
        {
            configuration1 = configuration;
            IGetCommands commandBuilder = new CommandBuilder();

            SqlCommand command = ((CommandBuilder)commandBuilder).BuildObjectString(furnitureModel, commandBuilder.InsertInto(furnitureModel.GetType().Name));
            ((CommandBuilder)commandBuilder).InsertDataValues(command, furnitureModel);
            SendToDataBase(command);
        }
    }
}
