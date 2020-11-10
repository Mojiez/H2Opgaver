using System;
using System.Collections.Generic;
using System.Text;

namespace KaffeMaskinen.DataClasses
{
    public abstract class Container
    {
        private int size;
        private string contentType;
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public string ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }

        public Container(int size, string contentType)
        {
            Size = size;
            ContentType = contentType;    
        }

        public void FillUp(int quantity, string contentType)
        {
            Quantity = quantity;
            ContentType = contentType;
        }

        public void EmptyOut()
        {
            Quantity = 0;
            ContentType = "";
        }
    }
}
