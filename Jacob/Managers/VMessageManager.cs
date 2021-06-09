namespace Jacob.Managers
{
    //This class is responsible for sending VMessage
    public class VMessageManager : SmtpMessageManager
    {
        /// <summary>
        /// This method is used to send a message to one person
        /// </summary>
        /// <param name="m"></param>
        /// <param name="isHTML"></param>
        public override void sendMessage(Message m, bool isHTML)
        {
            //her implementeres alt koden til at sende via VMessage
            base.sendMessage(m, isHTML);
        }

        /// <summary>
        /// This method is used to send messages to more than one person
        /// </summary>
        /// <param name="to"></param>
        /// <param name="m"></param>
        /// <param name="isHTML"></param>
        public override void sendMessageToAll(string[] to, Message m, bool isHTML)
        {
            //her implementeres alt koden til at sende via VMessage
            base.sendMessageToAll(to, m, isHTML);
        }
    }
}

