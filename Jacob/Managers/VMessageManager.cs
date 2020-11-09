using System;
using System.Collections.Generic;
using System.Text;

namespace Jacob.Managers
{
    public class VMessageManager : SmtpMessageManager
    {
        public override void sendMessage(Message m, bool isHTML)
        {
            base.sendMessage(m, isHTML);
            //her implementeres alt koden til at sende via VMessage
        }

        public override void sendMessageToAll(string[] to, Message m, bool isHTML)
        {
            base.sendMessageToAll(to, m, isHTML);
            //her implementeres alt koden til at sende via VMessage
        }
    }
}

