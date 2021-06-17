using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 

namespace ArrayList
{
    public class KenTechArray
    {
        private object[] listArray;

        public object[] objectArray { get => listArray; set => listArray = value; }

        /// <summary>
        /// Construktor for this class
        /// Just need a array size
        /// Default is 1
        /// </summary>
        /// <param name="arraySize"></param>
        public KenTechArray(int arraySize = 1)
        {
            objectArray = new object[arraySize];
        }

        /// <summary>
        /// Finds a empty spot in the array and returns the given index
        /// Returns -1 if not empty spot
        /// </summary>
        /// <returns></returns>
        private int FindEmptySpace()
        {
            for (int i = 0; i < objectArray.Length; i++)
            {
                if (objectArray[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }

        #region ConvertInputToArray
        
        /// <summary>
        /// Converts the param input to an object
        /// Then it placeses the object in the array
        /// </summary>
        /// <param name="value"></param>
        private void ConvertInputToArray(int value)
        {
            if (FindEmptySpace() == -1)
            {
                Array.Resize<object>(ref listArray, objectArray.Length + 1);
            }
            objectArray[FindEmptySpace()] = (object)value;
        }

        /// <summary>
        /// Converts the param input to an object
        /// Then it placeses the object in the array
        /// </summary>
        /// <param name="value"></param>
        private void ConvertInputToArray(string value)
        {
            if (FindEmptySpace() == -1)
            {
                Array.Resize<object>(ref listArray, objectArray.Length + 1);
            }
            objectArray[FindEmptySpace()] = (object)value;
        }

        /// <summary>
        /// Converts the param input to an object
        /// Then it placeses the object in the array
        /// </summary>
        /// <param name="value"></param>
        private void ConvertInputToArray(bool value)
        {
            if (FindEmptySpace() == -1)
            {
                Array.Resize<object>(ref listArray, objectArray.Length + 1);
            }
            objectArray[FindEmptySpace()] = (object)value;
        }

        /// <summary>
        /// Converts the param input to an object
        /// Then it placeses the object in the array
        /// </summary>
        /// <param name="value"></param>
        private void ConvertInputToArray(object value)
        {
            if (FindEmptySpace() == -1)
            {
                Array.Resize<object>(ref listArray, objectArray.Length + 1);
            }
            objectArray[FindEmptySpace()] = (object)value;
        }
        #endregion

        #region Inset
        /// <summary>
        /// Used to insert values into the array 
        /// </summary>
        /// <param name="value"></param>
        public void Inset(int value)
        {
            ConvertInputToArray(value);
        }
        /// <summary>
        /// Used to insert values into the array 
        /// </summary>
        /// <param name="value"></param>
        public void Inset(string value)
        {
            ConvertInputToArray(value);
        }
        /// <summary>
        /// Used to insert values into the array 
        /// </summary>
        /// <param name="value"></param>
        public void Inset(bool value)
        {
            ConvertInputToArray(value);
        }
        /// <summary>
        /// Used to insert values into the array 
        /// </summary>
        /// <param name="value"></param>
        public void Inset(object value)
        {
            ConvertInputToArray(value);
        }

        #endregion
        
        #region InsertAt
        /// <summary>
        /// Used to place a value at the given index
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public void InsetAtIndex(object value, int index)
        {
            objectArray[index] = value;
        }

        /// <summary>
        /// Used to place a value at the given index
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public void InsetAtIndex(string value, int index)
        {
            objectArray[index] = value;
        }

        /// <summary>
        /// Used to place a value at the given index
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public void InsetAtIndex(int value, int index)
        {
            objectArray[index] = value;
        }

        /// <summary>
        /// Used to place a value at the given index
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public void InsetAtIndex(bool value, int index)
        {
            objectArray[index] = value;
        }
        #endregion

        #region Find
        /// <summary>
        /// Finds the given object 
        /// And returns the result
        /// returns null if nothing found
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public object Find(object value) 
        {
            foreach (var item in objectArray)
            {
                if (item == value)
                {
                    return item;
                }
            }
            return null;
        }

        #endregion
    }
}
