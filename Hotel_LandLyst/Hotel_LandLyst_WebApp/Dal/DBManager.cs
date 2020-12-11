using Hotel_LandLyst_WebApp.Interfaces;
using Hotel_LandLyst_WebApp.Logic;
using Hotel_LandLyst_WebApp.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Hotel_LandLyst_WebApp.Dal
{
    public static class DBManager
    {
        private static IConfiguration configuration1;
        private static IGetCommands commandBuilder = new CommandBuilder();

        private static void SendToDb(SqlCommand sqlCommand)
        {
            SqlConnection sqlConnection = new SqlConnection(configuration1.GetConnectionString("myConnection"));
            sqlConnection.Open();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        //--------------------------------------------------------RoomModel
        #region Room
        public static void SaveRoomToDb(RoomModel roomModel, IConfiguration configuration)
        {
            configuration1 = configuration;
            SqlCommand command = ((CommandBuilder)commandBuilder).BuildObjectString(roomModel, commandBuilder.InsertInto(roomModel.GetType().Name));
            ((CommandBuilder)commandBuilder).InsertDataValues(command, roomModel);
            SendToDb(command);
        }

        public static List<RoomModel> CombineRoomAndFurniture(List<RoomModel> rooms, List<FurnitureModel> furnitures, IConfiguration configuration)
        {
            List<RoomFurniture> roomFurnitures = GetRoomFurnitureFromDb(configuration);
            RoomModel room;
            FurnitureModel furniture;
            foreach (var roomFurniture in roomFurnitures)
            {
                room = rooms.Where(x => x.Number == roomFurniture.RoomNumber).FirstOrDefault();
                furniture = furnitures.Where(x => x.Id == roomFurniture.FurnitureId).FirstOrDefault();
                RoomModel roomModel = rooms.Find(x => x.Number == room.Number);
                roomModel.Furnitures = new List<FurnitureModel>();
                roomModel.Furnitures.Add(furniture);
            }
            return rooms;
        }

        public static List<RoomModel> GetRoomsAndFurniture(IConfiguration configuration)
        {
            List<RoomModel> rooms = new List<RoomModel>();
            List<FurnitureModel> furnitures = new List<FurnitureModel>();
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("myConnection"));
            SqlCommand sqlCommand = new SqlCommand("GetRoomsAndFurniture", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                int roomNum = (int)reader["Number"];
                bool clean = (bool)reader["Clean"];
                bool rented = (bool)reader["Rented"];
                double pricePerNight = (double)reader["PricePerNight"];
                RoomModel room = new RoomModel() { Number = roomNum, Clean = clean, Rented = rented, PricePerNight = (float)pricePerNight };
                rooms.Add(room);

                int id = (int)reader["Id"];
                string name = (string)reader["Name"];
                double price = (double)reader["Price"];
                FurnitureModel furniture = new FurnitureModel() { Id = id, Name = name, Price = (float)price };
                furnitures.Add(furniture);
            }
            sqlConnection.Close();
            return CombineRoomAndFurniture(rooms, furnitures, configuration);
        }


        //----------------------------------------------------------RoomFurniture
        public static List<RoomFurniture> GetRoomFurnitureFromDb(IConfiguration configuration)
        {
            List<RoomFurniture> roomFurnitures = new List<RoomFurniture>();
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("myConnection"));
            SqlCommand sqlCommand = new SqlCommand(commandBuilder.SelectFromTable("RoomFurniture"), sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                int number = (int)sqlDataReader["FKRoom_Number"];
                int id = (int)sqlDataReader["FKFurniture_Id"];

                roomFurnitures.Add(new RoomFurniture()
                {
                    FurnitureId = id,
                    RoomNumber = number
                });
            }
            sqlConnection.Close();
            return roomFurnitures;
        }
        #endregion

        //--------------------------------------------------------FurnitureModel
        #region Furniture
        public static List<FurnitureModel> GetFurnitureFromDb(IConfiguration configuration)
        {
            List<FurnitureModel> furnitureModels = new List<FurnitureModel>();
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("myConnection"));
            SqlCommand sqlCommand = new SqlCommand(commandBuilder.SelectFromTable("FurnitureModel"), sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                int id = (int)sqlDataReader["Id"];
                string name = (string)sqlDataReader["Name"];
                double price = (double)sqlDataReader["Price"];

                furnitureModels.Add(new FurnitureModel()
                {
                    Id = id,
                    Name = name,
                    Price = (float)price
                });
            }
            sqlConnection.Close();
            return furnitureModels;
        }

        public static void SaveFurnitureToDb(FurnitureModel furnitureModel, IConfiguration configuration)
        {
            configuration1 = configuration;

            SqlCommand command = ((CommandBuilder)commandBuilder).BuildObjectString(furnitureModel, commandBuilder.InsertInto(furnitureModel.GetType().Name));
            ((CommandBuilder)commandBuilder).InsertDataValues(command, furnitureModel);
            SendToDb(command);
        }

        #endregion
        //--------------------------------------------------------Employees
        #region Employees
        /* 
         * public static List<EmployeeModel> GetEmployeeModels(IConfiguration configuration)
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
                string salt = (string)dataReader["Salt"];

                empModels.Add(new EmployeeModel(fName, lName, admin, uName, password, title, salt));
            }
            sqlConnection.Close();
            return empModels;
        }

        public static void SaveEmployeeToDb(IConfiguration configuration, EmployeeModel employeeModel)
        {
            configuration1 = configuration;
            SqlCommand command = ((CommandBuilder)commandBuilder).BuildObjectString(employeeModel, commandBuilder.InsertInto(employeeModel.GetType().Name));
            ((CommandBuilder)commandBuilder).InsertDataValues(command, employeeModel);
        }
         */
        //Gets all employees from db
    #endregion
        //--------------------------------------------------------Orders
        #region Orders

        //-------GET
        public static List<OrderModel> GetOrderModels(IConfiguration configuration)
        {
            List<OrderModel> orders = new List<OrderModel>();
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("myConnection"));
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM OrderModel;", sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                int orderNum = (int)reader["Number"];
                int roomNum = (int)reader["FKRoom_Number"];
                DateTime checkInDate = (DateTime)reader["CheckInDate"];
                DateTime checkOutDate = (DateTime)reader["CheckOutDate"];
                double totalPrice = (double)reader["TotalPrice"];
                int rentingPeriod = (int)reader["RentingPeriod"];
                OrderModel order = new OrderModel() { Number = orderNum, CheckInDate = checkInDate, CheckOutDate = checkOutDate, TotalPrice = (float)totalPrice, RentingPeriod = rentingPeriod, Rooms = GetRoomNumbersRented(configuration, orderNum) };
            }
            sqlConnection.Close();
            return orders;
        }

        public static List<RoomModel> GetRoomNumbersRented(IConfiguration configuration, int orderNumber)
        {
            List<RoomModel> roomModels = new List<RoomModel>();
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("myConnection"));
            SqlCommand sqlCommand = new SqlCommand("SELECT CostumerOrders.FKCostOrd_OrdNum, CostumerOrders.FKCostOrd_PhoneNum, CostumerOrders.FKRoom_Number FROM CostumerOrders", sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                int orderNum = (int)reader["FKCostOrd_OrdNum"];
                int CostphoneNum = (int)reader["FKCostOrd_PhoneNum"];
                int roomNum = (int)reader["FKRoom_Number"];

                CostumerOrder order = new CostumerOrder() { OrderNum = orderNum, CostPhoneNumber = CostphoneNum, RoomNumber = roomNum };
                if(order.OrderNum == orderNumber)
                {
                    roomModels.Add(new RoomModel() { Number = order.RoomNumber });
                }
            }
            sqlConnection.Close();
            return roomModels;
        }

        //-------------POST
        public static void SaveOrder(OrderModel order, IConfiguration configuration)
        {
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("myConnection"));
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO OrderModel(CheckInDate, CheckOutDate, TotalPrice, RentingPeriod, FKRoom_Number) VALUES(@CheckInDate, @CheckOutDate, @TotalPrice, @RentingPeriod, @FKRoom_Number)", sqlConnection);
            sqlConnection.Open();
            string date = order.CheckInDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
            sqlCommand.Parameters.Add(new SqlParameter("@CheckInDate", date));
            date = order.CheckOutDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
            sqlCommand.Parameters.Add(new SqlParameter("@CheckOutDate", date));
            sqlCommand.Parameters.Add(new SqlParameter("@TotalPrice", (double)order.TotalPrice));
            sqlCommand.Parameters.Add(new SqlParameter("@RentingPeriod", order.RentingPeriod));
            sqlCommand.Parameters.Add(new SqlParameter("@Number", order.Number));
            sqlCommand.Parameters.Add(new SqlParameter("@FKRoom_Number", order.Rooms[0].Number));

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            foreach (var roomNumber in order.BookedRooms)
            {
                SaveCostumerOrder(order.Costumer.PhoneNumber, order.Number, roomNumber, configuration);
            }
        }

        public static void SaveCostumerOrder(int costPhoneNumber, int ordNum, int roomNum, IConfiguration configuration)
        {
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("myConnection"));
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO CostumerOrders (FKCostOrd_OrdNum, FKCostOrd_PhoneNum, FKRoom_Number) VALUES(@FKCostOrd_OrdNum, @FKCostOrd_PhoneNum, @FKRoom_Number)", sqlConnection);
            sqlConnection.Open();

            sqlCommand.Parameters.Add(new SqlParameter("@FKCostOrd_OrdNum", GetNewlyCreatedOrder(configuration) + 1));
            sqlCommand.Parameters.Add(new SqlParameter("@FKCostOrd_PhoneNum", costPhoneNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@FKRoom_Number", roomNum));

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static int GetNewlyCreatedOrder(IConfiguration configuration)
        {
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("myConnection"));
            SqlCommand sqlCommand = new SqlCommand("SELECT MAX(OrderModel.Number)as Number FROM OrderModel;", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            int ordNum = 0;

            while (reader.Read())
            {
                ordNum = (int)reader["Number"];
            }
            sqlConnection.Close();
            return ordNum; 
        }
        #endregion
    }
}
