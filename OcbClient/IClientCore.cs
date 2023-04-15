using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcbClient
{
    internal interface IClientCore
    {
        bool Connect();
        bool Disconnect();
        bool AddLine(string line);
        bool InsertLine(string line, int lineNumber);


    }
}
