using System;
using System.Collections.Generic;
using System.Text;

namespace Jacob.Managers
{
    class VMessage : SmtpMessageManager
    {
        public override void sendMessage(Message m, bool isHTML)
        {
            base.sendMessage(m, isHTML);
        }

        public override void sendMessageToAll(string[] to, Message m, bool isHTML)
        {
            base.sendMessageToAll(to, m, isHTML);
        }
    }
}

