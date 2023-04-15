using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcbClient
{
    public interface IMessageWriter
    {
        void WriteCommand(int command);
        void WriteString(string s);
        void WriteInt(int i);
    }
}
