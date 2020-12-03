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
        public SqlCommand BuildObjectString(object obj, string sqlCommand)
        {
            PropertyInfo[] propertyInfo = obj.GetType().GetProperties();
            sqlCommand += "(";
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                if (propertyInfo[i].ToString().Split()[0].Length < 15)
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

        public SqlCommand InsertDataValues(SqlCommand command, object obj)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                if(propertyInfos[i].ToString().Split()[0].Length < 15)
                command.Parameters.Add(new SqlParameter($"@{propertyInfos[i].ToString().Split()[1]}", propertyInfos[i].GetValue(obj)));
            }
            return command;
        }

        public CommandBuilder()
        {

        }
    }
}
