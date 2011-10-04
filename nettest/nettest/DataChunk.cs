using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace nettest
{
    public class DataChunk
    {
        public Vector2 pos;
        public static int size = 8;
        public byte[] getBytes()
        {
            byte[] array = new byte[8];
            BitConverter.GetBytes(pos.X).CopyTo(array, 0);
            BitConverter.GetBytes(pos.Y).CopyTo(array, 4);
            return array;
        }
        public static DataChunk fromBytes(byte[] array)
        {
            DataChunk chunk = new DataChunk();
            chunk.pos.X = BitConverter.ToSingle(array, 0);
            chunk.pos.X = BitConverter.ToSingle(array, 4);
            return chunk;
        }
    }
}
