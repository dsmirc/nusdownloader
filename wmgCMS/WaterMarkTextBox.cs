// Decompiled with JetBrains decompiler
// Type: wmgCMS.WaterMarkTextBox
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

using System;
using System.Drawing;
using System.Windows.Forms;

namespace wmgCMS
{
  internal class WaterMarkTextBox : TextBox
  {
    private Font oldFont;
    private bool waterMarkTextEnabled;
    private Color _waterMarkColor = Color.Gray;
    private string _waterMarkText = "Water Mark";

    public Color WaterMarkColor
    {
      get => this._waterMarkColor;
      set
      {
        this._waterMarkColor = value;
        this.Invalidate();
      }
    }

    public string WaterMarkText
    {
      get => this._waterMarkText;
      set
      {
        this._waterMarkText = value;
        this.Invalidate();
      }
    }

    public WaterMarkTextBox() => this.JoinEvents(true);

    protected override void OnCreateControl()
    {
      base.OnCreateControl();
      this.EnableWaterMark();
    }

    protected override void OnPaint(PaintEventArgs args)
    {
      Font font = new Font(this.Font.FontFamily, this.Font.Size, this.Font.Style, this.Font.Unit);
      SolidBrush solidBrush = new SolidBrush(this.WaterMarkColor);
      PointF point = new PointF((float) ((double) args.ClipRectangle.Width / 2.0 - (double) TextRenderer.MeasureText(this.WaterMarkText, this.Font).Width / 2.0), 0.0f);
      args.Graphics.DrawString(this.waterMarkTextEnabled ? this.WaterMarkText : this.Text, font, (Brush) solidBrush, point);
      base.OnPaint(args);
    }

    private void JoinEvents(bool join)
    {
      if (!join)
        return;
      this.TextChanged += new EventHandler(this.WaterMark_Toggel);
      this.LostFocus += new EventHandler(this.WaterMark_Toggel);
      this.GotFocus += new EventHandler(this.WaterMark_Toggel);
      this.MouseCaptureChanged += new EventHandler(this.WaterMark_Toggel);
      this.FontChanged += new EventHandler(this.WaterMark_FontChanged);
    }

    private void WaterMark_Toggel(object sender, EventArgs args) => this.DisbaleWaterMark();

    private void EnableWaterMark()
    {
      this.oldFont = new Font(this.Font.FontFamily, this.Font.Size, this.Font.Style, this.Font.Unit);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.waterMarkTextEnabled = true;
      this.Refresh();
    }

    private void DisbaleWaterMark()
    {
      this.waterMarkTextEnabled = false;
      this.SetStyle(ControlStyles.UserPaint, false);
      if (this.oldFont == null)
        return;
      this.Font = new Font(this.oldFont.FontFamily, this.oldFont.Size, this.oldFont.Style, this.oldFont.Unit);
    }

    private void WaterMark_FontChanged(object sender, EventArgs args)
    {
      if (!this.waterMarkTextEnabled)
        return;
      this.oldFont = new Font(this.Font.FontFamily, this.Font.Size, this.Font.Style, this.Font.Unit);
      this.Refresh();
    }
  }
}
