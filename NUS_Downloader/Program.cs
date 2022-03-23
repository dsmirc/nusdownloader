// Decompiled with JetBrains decompiler
// Type: NUS_Downloader.Program
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NUS_Downloader
{
  internal static class Program
  {
    [DllImport("user32.dll")]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [STAThread]
    private static void Main(string[] args)
    {
      if (args.Length != 0)
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run((Form) new Form1(args));
      }
      else
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run((Form) new Form1());
      }
    }

    public static void setConsoleWindowVisibility(bool visible, string title)
    {
      IntPtr window = Program.FindWindow((string) null, title);
      if (!(window != IntPtr.Zero))
        return;
      if (!visible)
        Program.ShowWindow(window, 0);
      else
        Program.ShowWindow(window, 1);
    }
  }
}
