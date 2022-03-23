// Decompiled with JetBrains decompiler
// Type: wyDay.Controls.ITaskbarList3
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace wyDay.Controls
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
  [ComImport]
  internal interface ITaskbarList3
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    void HrInit();

    [MethodImpl(MethodImplOptions.PreserveSig)]
    void AddTab(IntPtr hwnd);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    void DeleteTab(IntPtr hwnd);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    void ActivateTab(IntPtr hwnd);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    void SetActiveAlt(IntPtr hwnd);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

    void SetProgressValue(IntPtr hwnd, ulong ullCompleted, ulong ullTotal);

    void SetProgressState(IntPtr hwnd, ThumbnailProgressState tbpFlags);
  }
}
