// Decompiled with JetBrains decompiler
// Type: libWiiSharp.MessageEventArgs
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

using System;

namespace libWiiSharp
{
  public class MessageEventArgs : EventArgs
  {
    private string message;

    public string Message => this.message;

    public MessageEventArgs(string message) => this.message = message;
  }
}
