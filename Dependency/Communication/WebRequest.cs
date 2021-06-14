using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dependency.Communication
{
    public class WebRequestNow : ICommunicate
    {
        public void SendRequest(string url)
        {
            // Initialize the WebRequest.
            WebRequest myRequest = WebRequest.Create("http://www.contoso.com");

            myRequest.Method = "GET";


            Console.WriteLine();
        }
    }
}
