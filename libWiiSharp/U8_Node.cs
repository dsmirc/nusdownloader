// Decompiled with JetBrains decompiler
// Type: libWiiSharp.U8_Node
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

using System;
using System.IO;

namespace libWiiSharp
{
  public class U8_Node
  {
    private ushort type;
    private ushort offsetToName;
    private uint offsetToData;
    private uint sizeOfData;

    public U8_NodeType Type
    {
      get => (U8_NodeType) this.type;
      set => this.type = (ushort) value;
    }

    public ushort OffsetToName
    {
      get => this.offsetToName;
      set => this.offsetToName = value;
    }

    public uint OffsetToData
    {
      get => this.offsetToData;
      set => this.offsetToData = value;
    }

    public uint SizeOfData
    {
      get => this.sizeOfData;
      set => this.sizeOfData = value;
    }

    public void Write(Stream writeStream)
    {
      writeStream.Write(BitConverter.GetBytes(Shared.Swap(this.type)), 0, 2);
      writeStream.Write(BitConverter.GetBytes(Shared.Swap(this.offsetToName)), 0, 2);
      writeStream.Write(BitConverter.GetBytes(Shared.Swap(this.offsetToData)), 0, 4);
      writeStream.Write(BitConverter.GetBytes(Shared.Swap(this.sizeOfData)), 0, 4);
    }
  }
}
