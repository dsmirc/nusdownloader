// Decompiled with JetBrains decompiler
// Type: wyDay.Controls.Windows7Taskbar
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

using System;
using System.Runtime.InteropServices;

namespace wyDay.Controls
{
  public static class Windows7Taskbar
  {
    private static ITaskbarList3 _taskbarList;
    private static readonly OperatingSystem osInfo = Environment.OSVersion;

    internal static ITaskbarList3 TaskbarList
    {
      get
      {
        if (Windows7Taskbar._taskbarList == null)
        {
          lock (typeof (Windows7Taskbar))
          {
            if (Windows7Taskbar._taskbarList == null)
            {
              Windows7Taskbar._taskbarList = (ITaskbarList3) new CTaskbarList();
              Windows7Taskbar._taskbarList.HrInit();
            }
          }
        }
        return Windows7Taskbar._taskbarList;
      }
    }

    internal static bool Windows7OrGreater => Windows7Taskbar.osInfo.Version.Major == 6 && Windows7Taskbar.osInfo.Version.Minor >= 1 || Windows7Taskbar.osInfo.Version.Major > 6;

    public static void SetProgressState(IntPtr hwnd, ThumbnailProgressState state)
    {
      if (!Windows7Taskbar.Windows7OrGreater)
        return;
      Windows7Taskbar.TaskbarList.SetProgressState(hwnd, state);
    }

    public static void SetProgressValue(IntPtr hwnd, ulong current, ulong maximum)
    {
      if (!Windows7Taskbar.Windows7OrGreater)
        return;
      Windows7Taskbar.TaskbarList.SetProgressValue(hwnd, current, maximum);
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    internal static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
  }
}
