using IP_App.Converters;
using IP_App.Tools;
using IP_App_Tools;
using System;
using System.Net;

namespace IP_App
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            string input = "";
            int number;
          

            while (running == true)
            {
                Console.Clear();
                Console.WriteLine("1 Ping Local\n2 Convert Host name to IP\n3 Convert IP to host name\n4 Trace Route\n5 Get DHCP Addresses");
                int.TryParse(Console.ReadLine(), out number);
                switch (number)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine(LocalCommunication.LocalPing().ToString());
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Type in the host name fx. www.google.com");
                        input = Console.ReadLine();
                        Console.WriteLine(HostAndIpConvertion.GetIpFromHostName(input));
                        Console.ReadKey();
                        break;

                    case 3:

                        Console.Clear();
                        Console.WriteLine("Type in the IP fx. 8.8.8.8");
                        input = Console.ReadLine();
                        Console.WriteLine(HostAndIpConvertion.GetHostNameFromIp(input));
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Type in the IP fx. 8.8.8.8 or host name fx. www.google.com");
                        input = Console.ReadLine();
                        Console.WriteLine(Diagnosis.Traceroute(input));
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Clear();
                        Diagnosis.DisplayDhcpServerAddresses();
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Something went wrong try again");
                        break;
                }
            }

        }
    }
}

