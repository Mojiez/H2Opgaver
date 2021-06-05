using Event_Demo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event_Demo
{
    public class DataSorter
    {
        public enum DataTypes
        {
            User,
            Project
        }

        public T GetService<T>()
        {
            switch (typeof(T).ToString().ToLower())
            {
                case "symetriskkryptering.project":
                    return (T)(object) new Heart();

                case "symetriskkryptering.user":
                    return (T)(object) new User();

                default:
                    return (T)(object) null;
            }
        }

    }
}
