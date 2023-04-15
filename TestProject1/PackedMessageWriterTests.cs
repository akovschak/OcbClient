using OcbClient;


namespace TestProject1
{
    [TestClass]
    public class PackedMessageWriterTests
    {
        [TestMethod]
        public void ValidateBytesTest()
        {
            int cmd = 123;
            string str1 = "Test String 1";
            int i1 = 999;

            MemoryStream ms = new MemoryStream(4096);
            PackedMessageWriter w = new PackedMessageWriter(ms);

            w.WriteCommand(cmd);
            w.WriteString(str1);
            w.WriteInt(i1);

            //have to reset the position to read from the front
            ms.Position = 0;

            //quick sanity check that it wrote what we expect at the byte level
            BinaryReader br = new BinaryReader(ms);
            Assert.AreEqual(PackedDataType.Signature, br.ReadUInt32());
            Assert.AreEqual(PackedDataType.Command, br.ReadUInt16());
            Assert.AreEqual(cmd, br.ReadInt32());

            Assert.AreEqual(PackedDataType.String, br.ReadUInt16());
            Assert.AreEqual(str1, br.ReadString());

            Assert.AreEqual(PackedDataType.Int, br.ReadUInt16());
            Assert.AreEqual(i1, br.ReadInt32());
        }

        [TestMethod]
        public void MessageRoundTrip()
        {
            int cmd = 4545456;
            string str1 = "Test string";
            int i1 = 9090;

            MemoryStream ms = new MemoryStream(4096);
            PackedMessageWriter w = new PackedMessageWriter(ms);
            w.WriteCommand(cmd);
            w.WriteString(str1);
            w.WriteInt(i1);

            ms.Position = 0;

            //read it back with the reader
            PackedMessageReader r = new PackedMessageReader(ms);
            Assert.AreEqual(cmd, r.ReadCommand());
            Assert.AreEqual(str1, r.ReadString());
            Assert.AreEqual(i1, r.ReadInt());
        }

        [TestMethod]
        public void BadRead1()
        {
            int cmd = 999;

            MemoryStream ms = new MemoryStream(4096);
            PackedMessageWriter w = new PackedMessageWriter(ms);
            w.WriteCommand(cmd);
            w.WriteString("xxx");

            ms.Position = 0;

            //read it back with the reader
            PackedMessageReader r = new PackedMessageReader(ms);
            Assert.AreEqual(cmd, r.ReadCommand());

            Assert.ThrowsException<Exception>(() => { r.ReadInt(); });
        }

        [TestMethod]
        public void BadRead2()
        {
            int cmd = 999;

            MemoryStream ms = new MemoryStream(4096);
            PackedMessageWriter w = new PackedMessageWriter(ms);
            w.WriteCommand(cmd);
            w.WriteInt(10888);

            ms.Position = 0;

            //read it back with the reader
            PackedMessageReader r = new PackedMessageReader(ms);
            Assert.AreEqual(cmd, r.ReadCommand());

            Assert.ThrowsException<Exception>(() => { r.ReadString(); });
        }

        [TestMethod]
        public void BadSignature()
        {
            MemoryStream ms = new MemoryStream(4096);
            BinaryWriter w = new BinaryWriter(ms);
            w.Write(0xAAAADDDD); //bogus signature
            w.Write(PackedDataType.Command);
            w.Write(90);

            ms.Position = 0;

            PackedMessageReader r = new PackedMessageReader(ms);
            Assert.ThrowsException<Exception>(() => { r.ReadCommand(); });
        }

        [TestMethod]
        public void CorruptCommand()
        {
            MemoryStream ms = new MemoryStream(4096);
            BinaryWriter w = new BinaryWriter(ms);
            w.Write(PackedDataType.Signature);
            w.Write((ushort)4);
            w.Write(90);

            ms.Position = 0;

            PackedMessageReader r = new PackedMessageReader(ms);
            Assert.ThrowsException<Exception>(() => { r.ReadCommand(); });
        }


    }
}