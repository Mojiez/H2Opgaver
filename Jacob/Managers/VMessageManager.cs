using System;
using System.Collections.Generic;
using System.Text;

namespace Jacob.Managers
{
    //This class is responsible for sending VMessage
    public class VMessageManager : SmtpMessageManager
    {
        /// <summary>
        /// This method is used to send a message 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="isHTML"></param>
        public override void sendMessage(Message m, bool isHTML)
        {
            //her implementeres alt koden til at sende via VMessage
            base.sendMessage(m, isHTML);
        }

        public override void sendMessageToAll(string[] to, Message m, bool isHTML)
        {
            //her implementeres alt koden til at sende via VMessage
            base.sendMessageToAll(to, m, isHTML);
        }
    }
}

