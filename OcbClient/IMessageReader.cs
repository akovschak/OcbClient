using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcbClient
{
    public interface IMessageReader
    {
        int ReadCommand();
        string ReadString();
        int ReadInt();
    }
}
