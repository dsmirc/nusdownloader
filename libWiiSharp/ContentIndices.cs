// Decompiled with JetBrains decompiler
// Type: libWiiSharp.ContentIndices
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

using System;

namespace libWiiSharp
{
  internal struct ContentIndices : IComparable
  {
    private int index;
    private int contentIndex;

    public int Index => this.index;

    public int ContentIndex => this.contentIndex;

    public ContentIndices(int index, int contentIndex)
    {
      this.index = index;
      this.contentIndex = contentIndex;
    }

    public int CompareTo(object obj)
    {
      if (obj is ContentIndices contentIndices)
        return this.contentIndex.CompareTo(contentIndices.contentIndex);
      throw new ArgumentException();
    }
  }
}
