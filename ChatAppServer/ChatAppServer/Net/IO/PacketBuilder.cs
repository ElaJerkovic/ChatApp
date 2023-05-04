using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Net.IO
{
    /* allows us to append data to memory stream which will be able to use in order
     * to get the bytes to send to the server */
    /* sending the data in the form of bytes from the client to the server and vice versa */
    class PacketBuilder
    {
        MemoryStream _ms;
        public PacketBuilder()
        {
            _ms = new MemoryStream(); 
            
        }
        /* function that allows us to write an op code to the packet */
        public void WriteOpCode(byte opcode)
        {
            _ms.WriteByte(opcode);
        }

        /* function that allows us to write string to the packet */
        public void WriteString(string msg)
        {
            var msgLength = msg.Length;
            /* Before writing the string, the method first calculates the length of the string in bytes using the msg.Length property, 
             * and writes this length to the memory stream using the BitConverter.GetBytes */
            _ms.Write(BitConverter.GetBytes(msgLength)); /* we want to get the bytes and append it to the memory stream */
            _ms.Write(Encoding.ASCII.GetBytes(msg));
        }

        /* function to stream the bytes */
        public byte[] GetPacketBytes()
        {
            return _ms.ToArray();
        }
    }
}
