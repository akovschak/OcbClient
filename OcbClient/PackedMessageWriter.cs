using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OcbClient
{
    
    //implement a relatively simple protocol for the messages to be sent
    //similar to msgpack in style
    //[signature][command][data chunks][end]


    public class PackedMessageWriter : IMessageWriter
    {
        Stream _stream;
        BinaryWriter _bw;

        public PackedMessageWriter(Stream stream)
        {
            _stream = stream;
            _bw = new BinaryWriter(_stream);
        }

        //command is always the first part of a message
        //calling this will start a new message
        public void WriteCommand(int command)
        {
            _bw.Write(PackedDataType.Signature);
            _bw.Write(PackedDataType.Command);
            _bw.Write(command);
        }

        public void WriteString(string s)
        {
            _bw.Write(PackedDataType.String);
            _bw.Write(s);
        }

        public void WriteInt(int i)
        {
            _bw.Write(PackedDataType.Int);
            _bw.Write(i);
        }

        //there needs to be an end of message as well
      



    }
}
