using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Interfaces
{
    public interface IGetCommands
    {
        public string InsertInto(string table)
        {
            return $"INSERT INTO {table} VALUES";
        }

        public string UpdateTable(string table, string property, string value)
        {
            return $"Update {table} SET {property} = {value}";
        }

        public string UpdateTableWithCondition(string table, string property, string value, string whereStatment, string whereStatementValue)
        {
            return UpdateTable(table, property, value) + $" WHERE {whereStatment} = '{whereStatementValue}'";
        }

        public string DeleteFromTable(string table)
        {
            return $"";
        }

        public string SelectFromTable(string table)
        {
            return $"Select * FROM {table}";
        }
    }
}
