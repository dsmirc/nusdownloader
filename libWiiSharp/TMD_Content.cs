// Decompiled with JetBrains decompiler
// Type: libWiiSharp.TMD_Content
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

namespace libWiiSharp
{
  public class TMD_Content
  {
    private uint contentId;
    private ushort index;
    private ushort type;
    private ulong size;
    private byte[] hash = new byte[20];

    public uint ContentID
    {
      get => this.contentId;
      set => this.contentId = value;
    }

    public ushort Index
    {
      get => this.index;
      set => this.index = value;
    }

    public ContentType Type
    {
      get => (ContentType) this.type;
      set => this.type = (ushort) value;
    }

    public ulong Size
    {
      get => this.size;
      set => this.size = value;
    }

    public byte[] Hash
    {
      get => this.hash;
      set => this.hash = value;
    }
  }
}
