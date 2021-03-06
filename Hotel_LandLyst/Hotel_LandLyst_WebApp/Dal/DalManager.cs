﻿using Hotel_LandLyst_WebApp.Interfaces;
using Hotel_LandLyst_WebApp.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Dal
{
    //This class is responsible for communication with data base 
    public class DalManager
    {
        private static DalManager _manager = null;
        private static object controle = new object();
        //creates singleton with thread lock
        public static DalManager Manager
        {
            get
            {
                lock (controle)
                {
                    if (_manager == null)
                    {
                        _manager = new DalManager();
                        return _manager;
                    }
                    else
                    {
                        return _manager;
                    }
                }
            }
        }
        //-----------------------------------------Room
        public void SaveRoom(RoomModel roomModel, IConfiguration configuration)
        {
            DBManager.SaveRoomToDb(roomModel, configuration);
        }
        
        public List<RoomModel> GetRooms(IConfiguration configuration)
        {
            return DBManager.GetRoomsAndFurniture(configuration);
        }
   
    
        //----------------------------------------Furniture
        //Make this method save Furniture
        public void SaveNewFuniture(FurnitureModel furnitureModel, IConfiguration configuration)
        {
            DBManager.SaveFurnitureToDb(furnitureModel, configuration);
        }

        //---------------------------------------Order
        //Make this method save Order
        public void SaveNewOrder(OrderModel order, IConfiguration configuration)
        {
            DBManager.SaveOrder(order, configuration);
        }
    }
}
