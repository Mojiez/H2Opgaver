using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency.Communication
{
    public interface ICommunicate
    {
        public void SendRequest(string url);
    }
}
