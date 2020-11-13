using System;
using System.Net;
using System.Net.Sockets;
using System.Security;

namespace IP_App.Converters
{
    public class HostAndIpConvertion
    {
       
        private static HostAndIpConvertion _Communication = null;
        private static object controle = new object();
        //Used for the static methods
        public static HostAndIpConvertion Communicate
        {
            get
            {
                lock (controle)
                {
                    if (_Communication == null)
                    {
                        _Communication = new HostAndIpConvertion();
                        return _Communication;
                    }
                    else
                    {
                        return _Communication;
                    }
                }
            }
        }
        /// <summary>
        /// This method takes a ip then converts it to the host name Via DNS
        /// </summary>
        /// <param name="Ip"></param>
        /// <returns></returns>
        public static string GetHostNameFromIp(string Ip)
        {
            string hostname = "";
            try
            {
                IPHostEntry ipHostEntry = Dns.GetHostEntry(Ip);
                hostname = ipHostEntry.HostName;
            }
            catch (FormatException)
            {
                hostname = "Please specify a valid IP address.";
                return hostname;
            }
            catch (SocketException)
            {
                hostname = "Unable to perform lookup - a socket error occured.";
                return hostname;
            }
            catch (SecurityException)
            {
                hostname = "Unable to perform lookup - permission denied.";
                return hostname;
            }
            catch (Exception)
            {
                hostname = "An unspecified error occured.";
                return hostname;
            }

            return hostname;
        }
        /// <summary>
        /// This method takes the host name fx. www.google.com and returns the Host IP via DNS 
        /// </summary>
        /// <param name="Hostname"></param>
        /// <returns></returns>
        public static string GetIpFromHostName(string Hostname)
        {
            string ip = "";
            try
            {
                IPHostEntry ipHostEntry = Dns.GetHostEntry(Hostname);
                if (ipHostEntry.AddressList.Length > 0)
                {
                    //ip = ipHostEntry.AddressList[0].Address.ToString();
                    ip = ipHostEntry.AddressList[0].ToString();
                }
                else
                {
                    ip = "No information found.";
                }
            }
            catch (SocketException)
            {
                ip = "Unable to perform lookup - a socket error occured.";
                return ip;
            }
            catch (SecurityException)
            {
                ip = "Unable to perform lookup - permission denied.";
                return ip;
            }
            catch (Exception)
            {
                ip = "An unspecified error occured.";
                return ip;
            }
            return ip;
        }
    }
}
