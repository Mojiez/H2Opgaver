using System;
using System.Collections.Generic;
using System.Text;

namespace Jacob
{
    // This class represents a message
    public class Message
    {
        //Make private fields for properties
        private string to, from, body, subject, cc;

        public string To { get => to; set => to = value; }
        public string From { get => from; set => from = value; }
        public string Body { get => body; set => body = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Cc { get => cc; set => cc = value; }

        //Construktor for the message class
        public Message(string to, string from, string body, string subject, string cc)
        {
            this.to = to;
            this.from = from;
            this.body = body;
            this.subject = subject;
            this.cc = cc;
        }
    }
}
