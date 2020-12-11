using Hotel_LandLyst_WebApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Logic
{
    public class CommandBuilder : IGetCommands
    {
        /// <summary>
        /// Sets the names on the query uses the object to find the property names
        /// </summary
        /// <param name="obj"></param>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public SqlCommand BuildObjectString(object obj, string sqlCommand)
        {
            PropertyInfo[] propertyInfo = obj.GetType().GetProperties();
            sqlCommand += "(";
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                if (propertyInfo[i].ToString().Split()[0].Length < 15 && propertyInfo[i].ToString().Split()[1] != "Id")
                {
                    if (propertyInfo.Length > i + 1 && propertyInfo[i + 1].ToString().Split()[0].Length < 15)
                        sqlCommand += $"@{propertyInfo[i].ToString().Split()[1]}, ";
                    else
                        sqlCommand += $"@{propertyInfo[i].ToString().Split()[1]}";
                }
            }
            sqlCommand += ")";
            return new SqlCommand(sqlCommand);
        }


        /// <summary>
        /// Find the objects property names and values
        /// the it creates a new sql parameter with the value of the object this method will ignore lists
        /// </summary>
        /// <param name="command"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public SqlCommand InsertDataValues(SqlCommand command, object obj)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                if (propertyInfos[i].ToString().Split()[0].Length < 15 && propertyInfos[i].ToString().Split()[1] != "Id")
                    //Gets the value and the property
                    command.Parameters.Add(new SqlParameter($"@{propertyInfos[i].ToString().Split()[1]}", propertyInfos[i].GetValue(obj)));
            }
            return command;
        }

        public CommandBuilder()
        {

        }
    }
}
