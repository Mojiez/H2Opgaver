namespace Jacob.Managers
{
    // This class is responsible for sending Smtp messages
    public class SmtpMessageManager
    {
        /// <summary>
        /// This method is used to seng a message to one person
        /// </summary>
        /// <param name="m"></param>
        /// <param name="isHTML"></param>
        public virtual void sendMessage(Message mess, bool isHTML)
        {
            if (isHTML)
            {
                //her implementeres alt koden til at sende via Smtp
                mess.Body = Converter.ConvertBodyToHTML(mess.Body);
            }
        }

        /// <summary>
        /// This method is used to seng a message to more than one person
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="mess"></param>
        /// <param name="isHTML"></param>
        public virtual void sendMessageToAll(string[] receiver, Message mess, bool isHTML)
        {
            if (isHTML)
            {
                mess.Body = Converter.ConvertBodyToHTML(m.Body);
                //her implementeres alt koden til at sende via Smtp
            }
        }
    }
}
