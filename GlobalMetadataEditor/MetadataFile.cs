using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GlobalMetadataEditor
{
    public class StringLiteral
    {
        public uint Offset;
        public uint Length;
    }

    class MetadataFile : IDisposable
    {
        public BinaryReader reader;
        private uint offset;
        private uint length;
        private long dataMsgPositon;
        private uint dataOffset;
        private uint dataLength;
        private List<StringLiteral> stringLiterals = new List<StringLiteral>();
        //public List<byte[]> strBytes = new List<byte[]>();
        public List<string> stringList = new List<string>();
        public MetadataFile(string filePath)
        {
            reader = new BinaryReader(File.OpenRead(filePath));
            ReadMessage();
            ReadLiteral();
            ReadStrByte();
        }

        private void ReadMessage()
        {
            reader.ReadUInt32();//标志位
            reader.ReadInt32();//版本位
            offset = reader.ReadUInt32();//指针区偏移
            length = reader.ReadUInt32();//指针区长度
            dataMsgPositon = reader.BaseStream.Position;//记录数据区信息位数
            dataOffset = reader.ReadUInt32();//数据区偏移
            dataLength = reader.ReadUInt32();//数据区长度
        }

        private void ReadLiteral()
        {

            reader.BaseStream.Position = offset;
            for (int i = 0; i < length / 8; i++)
            {
                stringLiterals.Add(new StringLiteral
                {
                    Length = reader.ReadUInt32(),
                    Offset = reader.ReadUInt32()
                });
            }
        }

        private void ReadStrByte()
        {
            for (int i = 0; i < stringLiterals.Count; i++)
            {
                reader.BaseStream.Position = dataOffset + stringLiterals[i].Offset;
                byte[] temp = reader.ReadBytes((int)stringLiterals[i].Length);
                //strBytes.Add(temp);
                stringList.Add(Encoding.UTF8.GetString(temp));
            }
        }

        public void WriteToNewFile(string fileName, List<byte[]> list)
        {
            BinaryWriter writer = new BinaryWriter(File.Create(fileName));

            reader.BaseStream.Position = 0;
            reader.BaseStream.CopyTo(writer.BaseStream);

            writer.BaseStream.Position = offset;
            uint count = 0;
            for (int i = 0; i < stringLiterals.Count; i++)
            {

                stringLiterals[i].Offset = count;
                stringLiterals[i].Length = (uint)list[i].Length;

                writer.Write(stringLiterals[i].Length);
                writer.Write(stringLiterals[i].Offset);
                count += stringLiterals[i].Length;
            }

            //对齐
            var tmp = (dataOffset + count) % 4;
            if (tmp != 0) count += 4 - tmp;

            // 判断字符串替换方式
            if (count > dataLength)
            {
                if (dataOffset + dataLength < writer.BaseStream.Length)
                {
                    dataOffset = (uint)writer.BaseStream.Length;
                }
            }
            dataLength = count;

            // 写入字符串
            writer.BaseStream.Position = dataOffset;
            for (int i = 0; i < list.Count; i++)
            {
                writer.Write(list[i]);
            }
            // 更新文件信息
            writer.BaseStream.Position = dataMsgPositon;
            writer.Write(dataOffset);
            writer.Write(dataLength);
            writer.Close();
        }

        public void Dispose()
        {
            reader?.Dispose();
        }

    }
}
