namespace Jacob.Managers
{
    public class SmtpMessageManager
    {
        public virtual void sendMessage(Message m, bool isHTML)
        {
            //herinde sendes der en email ud til modtageren
            if (isHTML)
            {
                m.Body = Converter.ConvertBodyToHTML(m.Body);
                //her implementeres alt koden til at sende via Smtp

            }
        }

        public virtual void sendMessageToAll(string[] to, Message m, bool isHTML)
        {
            if (isHTML)
            {
                m.Body = Converter.ConvertBodyToHTML(m.Body);
                //her implementeres alt koden til at sende via Smtp
            }
        }
    }
}
