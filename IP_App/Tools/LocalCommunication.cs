using IP_App.DataClasses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace IP_App_Tools
{
    public class LocalCommunication
    {
        private static LocalCommunication _Communication = null;
        private static object controle = new object();
        public static LocalCommunication Communicate
        {
            get
            {
                lock (controle)
                {
                    if (_Communication == null)
                    {
                        _Communication = new LocalCommunication();
                        return _Communication;
                    }
                    else
                    {
                        return _Communication;
                    }
                }
            }
        }
        //This class is responsible for all local communication 
        //For now its only a local ping
        public static PingStatus LocalPing()
        {
            // Ping's the local machine.
            Ping pingSender = new Ping();
            IPAddress address = IPAddress.Loopback;
            PingReply reply = pingSender.Send(address);
            PingStatus pingStatus = new PingStatus(reply.Address.ToString(), reply.RoundtripTime, reply.Options.Ttl, reply.Options.DontFragment, reply.Buffer.Length, reply.Status);
            return pingStatus;
        }
    }
}
