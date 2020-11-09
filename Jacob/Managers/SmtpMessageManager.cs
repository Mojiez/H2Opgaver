﻿using Jacob.MessageTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jacob.Managers
{
    class SmtpMessageManager
    {
        public virtual void sendMessage(Message m, bool isHTML)
        {
            //herinde sendes der en email ud til modtageren
            if (isHTML)
            {
                m.Body = Converter.ConvertBodyToHTML(m.Body);
            }
        }

        public virtual void sendMessageToAll(string[] to, Message m, bool isHTML)
        {
            if (isHTML)
            {
                m.Body = Converter.ConvertBodyToHTML(m.Body);
            }
        }
    }
}