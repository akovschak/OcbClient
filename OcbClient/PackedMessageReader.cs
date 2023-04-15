using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcbClient
{
    public class PackedMessageReader : IMessageReader
    {
        Stream _stream;
        BinaryReader _br;

        public PackedMessageReader(Stream stream)
        {
            _stream = stream;
            _br = new BinaryReader(_stream);
        }

        public int ReadCommand()
        {
            if (_br.ReadUInt32() != PackedDataType.Signature)
                throw new Exception("Signature does not match");

            if (PackedDataType.Command != _br.ReadUInt16())
                throw new Exception("");
            
            return _br.ReadInt32();
        }

        public string ReadString()
        {
            if (PackedDataType.String != _br.ReadUInt16())
                throw new Exception("");

            return _br.ReadString();
        }

        public int ReadInt()
        {
            if (PackedDataType.Int != _br.ReadUInt16())
                throw new Exception("");

            return _br.ReadInt32();
        }



    }
}
