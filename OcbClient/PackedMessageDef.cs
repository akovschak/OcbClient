using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcbClient
{

    public class PackedDataType
    {
        public const UInt32 Signature = 0xDEADD0B0;

        public const UInt16 Command = 1;
        public const UInt16 String = 2;
        public const UInt16 Int = 3;
    }



}
