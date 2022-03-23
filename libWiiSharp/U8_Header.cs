// Decompiled with JetBrains decompiler
// Type: libWiiSharp.U8_Header
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

using System;
using System.IO;

namespace libWiiSharp
{
  public class U8_Header
  {
    private uint u8Magic = 1437218861;
    private uint offsetToRootNode = 32;
    private uint headerSize;
    private uint offsetToData;
    private byte[] padding = new byte[16];

    public uint U8Magic => this.u8Magic;

    public uint OffsetToRootNode => this.offsetToRootNode;

    public uint HeaderSize
    {
      get => this.headerSize;
      set => this.headerSize = value;
    }

    public uint OffsetToData
    {
      get => this.offsetToData;
      set => this.offsetToData = value;
    }

    public byte[] Padding => this.padding;

    public void Write(Stream writeStream)
    {
      writeStream.Write(BitConverter.GetBytes(Shared.Swap(this.u8Magic)), 0, 4);
      writeStream.Write(BitConverter.GetBytes(Shared.Swap(this.offsetToRootNode)), 0, 4);
      writeStream.Write(BitConverter.GetBytes(Shared.Swap(this.headerSize)), 0, 4);
      writeStream.Write(BitConverter.GetBytes(Shared.Swap(this.offsetToData)), 0, 4);
      writeStream.Write(this.padding, 0, 16);
    }
  }
}
