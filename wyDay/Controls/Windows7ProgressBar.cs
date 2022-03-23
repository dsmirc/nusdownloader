// Decompiled with JetBrains decompiler
// Type: wyDay.Controls.Windows7ProgressBar
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace wyDay.Controls
{
  [ToolboxBitmap(typeof (ProgressBar))]
  public class Windows7ProgressBar : ProgressBar
  {
    private bool showInTaskbar;
    private ProgressBarState m_State = ProgressBarState.Normal;
    private ContainerControl ownerForm;

    public Windows7ProgressBar()
    {
    }

    public Windows7ProgressBar(ContainerControl parentControl) => this.ContainerControl = parentControl;

    public ContainerControl ContainerControl
    {
      get => this.ownerForm;
      set
      {
        this.ownerForm = value;
        if (this.ownerForm.Visible)
          return;
        ((Form) this.ownerForm).Shown += new EventHandler(this.Windows7ProgressBar_Shown);
      }
    }

    public override ISite Site
    {
      set
      {
        base.Site = value;
        if (value == null || !(value.GetService(typeof (IDesignerHost)) is IDesignerHost service))
          return;
        this.ContainerControl = service.RootComponent as ContainerControl;
      }
    }

    private void Windows7ProgressBar_Shown(object sender, EventArgs e)
    {
      if (this.ShowInTaskbar)
      {
        if (this.Style != ProgressBarStyle.Marquee)
          this.SetValueInTB();
        this.SetStateInTB();
      }
      ((Form) this.ownerForm).Shown -= new EventHandler(this.Windows7ProgressBar_Shown);
    }

    [DefaultValue(false)]
    public bool ShowInTaskbar
    {
      get => this.showInTaskbar;
      set
      {
        if (this.showInTaskbar == value)
          return;
        this.showInTaskbar = value;
        if (this.ownerForm == null)
          return;
        if (this.Style != ProgressBarStyle.Marquee)
          this.SetValueInTB();
        this.SetStateInTB();
      }
    }

    public new int Value
    {
      get => base.Value;
      set
      {
        base.Value = value;
        this.SetValueInTB();
      }
    }

    public new ProgressBarStyle Style
    {
      get => base.Style;
      set
      {
        base.Style = value;
        if (!this.showInTaskbar || this.ownerForm == null)
          return;
        this.SetStateInTB();
      }
    }

    [DefaultValue(ProgressBarState.Normal)]
    public ProgressBarState State
    {
      get => this.m_State;
      set
      {
        this.m_State = value;
        bool flag = this.Style == ProgressBarStyle.Marquee;
        if (flag)
          this.Style = ProgressBarStyle.Blocks;
        Windows7Taskbar.SendMessage(this.Handle, 1040, (int) value, 0);
        if (flag)
          this.SetValueInTB();
        else
          this.SetStateInTB();
      }
    }

    public new void Increment(int value)
    {
      base.Increment(value);
      this.SetValueInTB();
    }

    public new void PerformStep()
    {
      base.PerformStep();
      this.SetValueInTB();
    }

    private void SetValueInTB()
    {
      if (!this.showInTaskbar)
        return;
      Windows7Taskbar.SetProgressValue(this.ownerForm.Handle, (ulong) (this.Value - this.Minimum), (ulong) (this.Maximum - this.Minimum));
    }

    private void SetStateInTB()
    {
      if (this.ownerForm == null)
        return;
      ThumbnailProgressState state = ThumbnailProgressState.Normal;
      if (!this.showInTaskbar)
        state = ThumbnailProgressState.NoProgress;
      else if (this.Style == ProgressBarStyle.Marquee)
        state = ThumbnailProgressState.Indeterminate;
      else if (this.m_State == ProgressBarState.Error)
        state = ThumbnailProgressState.Error;
      else if (this.m_State == ProgressBarState.Pause)
        state = ThumbnailProgressState.Paused;
      Windows7Taskbar.SetProgressState(this.ownerForm.Handle, state);
    }
  }
}
