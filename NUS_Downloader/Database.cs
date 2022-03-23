// Decompiled with JetBrains decompiler
// Type: NUS_Downloader.Database
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

using NUS_Downloader.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace NUS_Downloader
{
  internal class Database
  {
    private string SystemTag = "SYS";
    private string IosTag = "IOS";
    private string VcTag = "VC";
    private string WwTag = "WW";
    private string UpdateTag = "UPD";
    private string DSiSystemTag = "DSISYSTEM";
    private string DSiWareTag = "DSIWARE";
    private string[] VcConsoles = new string[11]
    {
      "C64",
      "GEN",
      "MSX",
      "N64",
      "NEO",
      "NES",
      "SMS",
      "SNES",
      "TG16",
      "TGCD",
      "ARC"
    };
    private string databaseString;
    public static Image green = (Image) Resources.bullet_green;
    public static Image orange = (Image) Resources.bullet_orange;
    public static Image redgreen = (Image) Resources.bullet_redgreen;
    public static Image redorange = (Image) Resources.bullet_redorange;
    public static Image green_blue = (Image) Resources.bullet_green_blue;
    public static Image orange_blue = (Image) Resources.bullet_orange_blue;
    public static Image redgreen_blue = (Image) Resources.bullet_redgreen_blue;
    public static Image redorange_blue = (Image) Resources.bullet_redorange_blue;

    public void LoadDatabaseToStream(string databaseFile) => this.databaseString = File.Exists(databaseFile) ? File.ReadAllText(databaseFile) : throw new FileNotFoundException("I couldn't find the database file!", "database.xml");

    public string GetDatabaseVersion()
    {
      if (this.databaseString.Length < 1)
        throw new Exception("Load the database into a memory stream first!");
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(this.databaseString);
      return xmlDocument.GetElementsByTagName("database")[0].Attributes[0].Value;
    }

    public static string GetDatabaseVersion(string databaseString)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(databaseString);
      return xmlDocument.GetElementsByTagName("database")[0].Attributes[0].Value;
    }

    public ToolStripMenuItem[] LoadSystemTitles()
    {
      if (this.databaseString.Length < 1)
        throw new Exception("Load the database into a memory stream first!");
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(this.databaseString);
      XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(this.SystemTag);
      ToolStripMenuItem[] toolStripMenuItemArray = new ToolStripMenuItem[elementsByTagName.Count];
      for (int i1 = 0; i1 < elementsByTagName.Count; ++i1)
      {
        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
        XmlAttributeCollection attributes = elementsByTagName[i1].Attributes;
        string str1 = "";
        string str2 = "";
        bool danger = false;
        bool ticket = true;
        XmlNodeList childNodes = elementsByTagName[i1].ChildNodes;
        for (int i2 = 0; i2 < childNodes.Count; ++i2)
        {
          switch (childNodes[i2].Name)
          {
            case "name":
              str2 = childNodes[i2].InnerText;
              break;
            case "titleID":
              str1 = childNodes[i2].InnerText;
              break;
            case "version":
              string[] strArray1 = childNodes[i2].InnerText.Split(',');
              if (toolStripMenuItem.DropDownItems.Count > 0)
              {
                for (int index1 = 0; index1 < toolStripMenuItem.DropDownItems.Count; ++index1)
                {
                  if (childNodes[i2].InnerText != "")
                  {
                    ToolStripMenuItem dropDownItem = (ToolStripMenuItem) toolStripMenuItem.DropDownItems[index1];
                    dropDownItem.DropDownItems.Add("Latest Version");
                    for (int index2 = 0; index2 < strArray1.Length; ++index2)
                      dropDownItem.DropDownItems.Add("v" + strArray1[index2]);
                  }
                }
                break;
              }
              toolStripMenuItem.DropDownItems.Add("Latest Version");
              if (childNodes[i2].InnerText != "")
              {
                for (int index = 0; index < strArray1.Length; ++index)
                  toolStripMenuItem.DropDownItems.Add("v" + strArray1[index]);
                break;
              }
              break;
            case "region":
              string[] strArray2 = childNodes[i2].InnerText.Split(',');
              if (childNodes[i2].InnerText != "")
              {
                for (int index = 0; index < strArray2.Length; ++index)
                  toolStripMenuItem.DropDownItems.Add(this.RegionFromIndex(Convert.ToInt32(strArray2[index])));
                break;
              }
              break;
            case "ticket":
              ticket = Convert.ToBoolean(childNodes[i2].InnerText);
              break;
            case "danger":
              danger = true;
              toolStripMenuItem.ToolTipText = childNodes[i2].InnerText;
              break;
          }
          toolStripMenuItem.Image = this.SelectItemImage(ticket, danger);
          if (str1 != "")
            toolStripMenuItem.Text = string.Format("{0} - {1}", (object) str1, (object) str2);
          else
            toolStripMenuItem.Text = str2;
        }
        toolStripMenuItemArray[i1] = toolStripMenuItem;
      }
      return toolStripMenuItemArray;
    }

    public ToolStripMenuItem[] LoadIosTitles()
    {
      if (this.databaseString.Length < 1)
        throw new Exception("Load the database into a memory stream first!");
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(this.databaseString);
      XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(this.IosTag);
      ToolStripMenuItem[] toolStripMenuItemArray = new ToolStripMenuItem[elementsByTagName.Count];
      for (int i1 = 0; i1 < elementsByTagName.Count; ++i1)
      {
        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
        XmlAttributeCollection attributes = elementsByTagName[i1].Attributes;
        string str1 = "";
        string str2 = "";
        bool danger = false;
        bool ticket = true;
        XmlNodeList childNodes = elementsByTagName[i1].ChildNodes;
        for (int i2 = 0; i2 < childNodes.Count; ++i2)
        {
          switch (childNodes[i2].Name)
          {
            case "name":
              str2 = childNodes[i2].InnerText;
              break;
            case "titleID":
              str1 = childNodes[i2].InnerText;
              break;
            case "version":
              string[] strArray = childNodes[i2].InnerText.Split(',');
              toolStripMenuItem.DropDownItems.Add("Latest Version");
              if (childNodes[i2].InnerText != "")
              {
                for (int index = 0; index < strArray.Length; ++index)
                  toolStripMenuItem.DropDownItems.Add("v" + strArray[index]);
                break;
              }
              break;
            case "ticket":
              ticket = Convert.ToBoolean(childNodes[i2].InnerText);
              break;
            case "danger":
              danger = true;
              toolStripMenuItem.ToolTipText = childNodes[i2].InnerText;
              break;
          }
          toolStripMenuItem.Image = this.SelectItemImage(ticket, danger);
          if (str1 != "")
            toolStripMenuItem.Text = string.Format("{0} - {1}", (object) str1, (object) str2);
          else
            toolStripMenuItem.Text = str2;
        }
        toolStripMenuItemArray[i1] = toolStripMenuItem;
      }
      return toolStripMenuItemArray;
    }

    public ToolStripMenuItem[][] LoadVirtualConsoleTitles()
    {
      if (this.databaseString.Length < 1)
        throw new Exception("Load the database into a memory stream first!");
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(this.databaseString);
      XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(this.VcTag);
      ToolStripMenuItem[][] toolStripMenuItemArray = new ToolStripMenuItem[this.VcConsoles.Length][];
      for (int index = 0; index < toolStripMenuItemArray.Length; ++index)
        toolStripMenuItemArray[index] = new ToolStripMenuItem[0];
      for (int i1 = 0; i1 < elementsByTagName.Count; ++i1)
      {
        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
        XmlAttributeCollection attributes = elementsByTagName[i1].Attributes;
        string str1 = "";
        string str2 = "";
        bool danger = false;
        bool ticket = true;
        XmlNodeList childNodes = elementsByTagName[i1].ChildNodes;
        for (int i2 = 0; i2 < childNodes.Count; ++i2)
        {
          switch (childNodes[i2].Name)
          {
            case "name":
              str2 = childNodes[i2].InnerText;
              break;
            case "titleID":
              str1 = childNodes[i2].InnerText;
              break;
            case "version":
              string[] strArray1 = childNodes[i2].InnerText.Split(',');
              if (toolStripMenuItem.DropDownItems.Count > 0)
              {
                for (int index1 = 0; index1 < toolStripMenuItem.DropDownItems.Count; ++index1)
                {
                  if (childNodes[i2].InnerText != "")
                  {
                    ToolStripMenuItem dropDownItem = (ToolStripMenuItem) toolStripMenuItem.DropDownItems[index1];
                    dropDownItem.DropDownItems.Add("Latest Version");
                    for (int index2 = 0; index2 < strArray1.Length; ++index2)
                      dropDownItem.DropDownItems.Add("v" + strArray1[index2]);
                  }
                }
                break;
              }
              toolStripMenuItem.DropDownItems.Add("Latest Version");
              if (childNodes[i2].InnerText != "")
              {
                for (int index = 0; index < strArray1.Length; ++index)
                  toolStripMenuItem.DropDownItems.Add("v" + strArray1[index]);
                break;
              }
              break;
            case "region":
              string[] strArray2 = childNodes[i2].InnerText.Split(',');
              if (childNodes[i2].InnerText != "")
              {
                for (int index = 0; index < strArray2.Length; ++index)
                  toolStripMenuItem.DropDownItems.Add(this.RegionFromIndex(Convert.ToInt32(strArray2[index])));
                break;
              }
              break;
            case "ticket":
              ticket = Convert.ToBoolean(childNodes[i2].InnerText);
              break;
            case "danger":
              danger = true;
              toolStripMenuItem.ToolTipText = childNodes[i2].InnerText;
              break;
          }
          toolStripMenuItem.Image = this.SelectItemImage(ticket, danger);
          if (str1 != "")
            toolStripMenuItem.Text = string.Format("{0} - {1}", (object) str1, (object) str2);
          else
            toolStripMenuItem.Text = str2;
        }
        for (int index = 0; index < this.VcConsoles.Length; ++index)
        {
          if (attributes[0].Value == this.VcConsoles[index])
          {
            Array.Resize<ToolStripMenuItem>(ref toolStripMenuItemArray[index], toolStripMenuItemArray[index].Length + 1);
            toolStripMenuItemArray[index][toolStripMenuItemArray[index].Length - 1] = toolStripMenuItem;
          }
        }
      }
      return toolStripMenuItemArray;
    }

    public ToolStripMenuItem[] LoadWiiWareTitles()
    {
      if (this.databaseString.Length < 1)
        throw new Exception("Load the database into a memory stream first!");
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(this.databaseString);
      XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(this.WwTag);
      ToolStripMenuItem[] toolStripMenuItemArray = new ToolStripMenuItem[elementsByTagName.Count];
      for (int i1 = 0; i1 < elementsByTagName.Count; ++i1)
      {
        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
        XmlAttributeCollection attributes = elementsByTagName[i1].Attributes;
        string str1 = "";
        string str2 = "";
        bool danger = false;
        bool ticket = true;
        XmlNodeList childNodes = elementsByTagName[i1].ChildNodes;
        for (int i2 = 0; i2 < childNodes.Count; ++i2)
        {
          switch (childNodes[i2].Name)
          {
            case "name":
              str2 = childNodes[i2].InnerText;
              break;
            case "titleID":
              str1 = childNodes[i2].InnerText;
              break;
            case "version":
              string[] strArray1 = childNodes[i2].InnerText.Split(',');
              if (toolStripMenuItem.DropDownItems.Count > 0)
              {
                for (int index1 = 0; index1 < toolStripMenuItem.DropDownItems.Count; ++index1)
                {
                  if (childNodes[i2].InnerText != "")
                  {
                    ToolStripMenuItem dropDownItem = (ToolStripMenuItem) toolStripMenuItem.DropDownItems[index1];
                    dropDownItem.DropDownItems.Add("Latest Version");
                    for (int index2 = 0; index2 < strArray1.Length; ++index2)
                      dropDownItem.DropDownItems.Add("v" + strArray1[index2]);
                  }
                }
                break;
              }
              toolStripMenuItem.DropDownItems.Add("Latest Version");
              if (childNodes[i2].InnerText != "")
              {
                for (int index = 0; index < strArray1.Length; ++index)
                  toolStripMenuItem.DropDownItems.Add("v" + strArray1[index]);
                break;
              }
              break;
            case "region":
              string[] strArray2 = childNodes[i2].InnerText.Split(',');
              if (childNodes[i2].InnerText != "")
              {
                for (int index = 0; index < strArray2.Length; ++index)
                  toolStripMenuItem.DropDownItems.Add(this.RegionFromIndex(Convert.ToInt32(strArray2[index])));
                break;
              }
              break;
            case "ticket":
              ticket = Convert.ToBoolean(childNodes[i2].InnerText);
              break;
            case "danger":
              danger = true;
              toolStripMenuItem.ToolTipText = childNodes[i2].InnerText;
              break;
          }
          toolStripMenuItem.Image = this.SelectItemImage(ticket, danger);
          if (str1 != "")
            toolStripMenuItem.Text = string.Format("{0} - {1}", (object) str1, (object) str2);
          else
            toolStripMenuItem.Text = str2;
        }
        toolStripMenuItemArray[i1] = toolStripMenuItem;
      }
      return toolStripMenuItemArray;
    }

    private string RegionFromIndex(int index)
    {
      if (this.databaseString.Length < 1)
        throw new Exception("Load the database into a memory stream first!");
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(this.databaseString);
      XmlNodeList childNodes = xmlDocument.GetElementsByTagName("REGIONS")[0].ChildNodes;
      for (int i = 0; i < childNodes.Count; ++i)
      {
        if (Convert.ToInt32(childNodes[i].Attributes[0].Value) == index)
          return childNodes[i].InnerText;
      }
      return "XX (Error)";
    }

    private Image SelectItemImage(bool ticket, bool danger)
    {
      if (ticket && !danger)
        return Database.green;
      if (!ticket && !danger)
        return Database.orange;
      if (ticket && danger)
        return Database.redgreen;
      return !ticket && danger ? Database.redorange : (Image) null;
    }

    public ToolStripMenuItem[] LoadRegionCodes()
    {
      if (this.databaseString.Length < 1)
        throw new Exception("Load the database into a memory stream first!");
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(this.databaseString);
      XmlNodeList childNodes = xmlDocument.GetElementsByTagName("REGIONS")[0].ChildNodes;
      ToolStripMenuItem[] toolStripMenuItemArray = new ToolStripMenuItem[childNodes.Count];
      for (int i = 0; i < childNodes.Count; ++i)
      {
        toolStripMenuItemArray[i] = new ToolStripMenuItem();
        toolStripMenuItemArray[i].Text = childNodes[i].InnerText;
      }
      return toolStripMenuItemArray;
    }

    public ToolStripMenuItem[] LoadScripts()
    {
      if (this.databaseString.Length < 1)
        throw new Exception("Load the database into a memory stream first!");
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(this.databaseString);
      XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(this.UpdateTag);
      ToolStripMenuItem[] toolStripMenuItemArray = new ToolStripMenuItem[elementsByTagName.Count];
      for (int i1 = 0; i1 < elementsByTagName.Count; ++i1)
      {
        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
        XmlAttributeCollection attributes = elementsByTagName[i1].Attributes;
        XmlNodeList childNodes = elementsByTagName[i1].ChildNodes;
        for (int i2 = 0; i2 < childNodes.Count; ++i2)
        {
          switch (childNodes[i2].Name)
          {
            case "name":
              toolStripMenuItem.Text = childNodes[i2].InnerText;
              break;
            case "script":
              toolStripMenuItem.ToolTipText = childNodes[i2].InnerText;
              break;
          }
          toolStripMenuItem.Image = (Image) Resources.script_start;
        }
        toolStripMenuItemArray[i1] = toolStripMenuItem;
      }
      return toolStripMenuItemArray;
    }

    public ToolStripMenuItem[] LoadDSiSystemTitles()
    {
      if (this.databaseString.Length < 1)
        throw new Exception("Load the database into a memory stream first!");
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(this.databaseString);
      XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(this.DSiSystemTag);
      ToolStripMenuItem[] toolStripMenuItemArray = new ToolStripMenuItem[elementsByTagName.Count];
      for (int i1 = 0; i1 < elementsByTagName.Count; ++i1)
      {
        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
        XmlAttributeCollection attributes = elementsByTagName[i1].Attributes;
        string str1 = "";
        string str2 = "";
        bool danger = false;
        bool ticket = true;
        XmlNodeList childNodes = elementsByTagName[i1].ChildNodes;
        for (int i2 = 0; i2 < childNodes.Count; ++i2)
        {
          switch (childNodes[i2].Name)
          {
            case "name":
              str2 = childNodes[i2].InnerText;
              break;
            case "titleID":
              str1 = childNodes[i2].InnerText;
              break;
            case "version":
              string[] strArray1 = childNodes[i2].InnerText.Split(',');
              if (toolStripMenuItem.DropDownItems.Count > 0)
              {
                for (int index1 = 0; index1 < toolStripMenuItem.DropDownItems.Count; ++index1)
                {
                  if (childNodes[i2].InnerText != "")
                  {
                    ToolStripMenuItem dropDownItem = (ToolStripMenuItem) toolStripMenuItem.DropDownItems[index1];
                    dropDownItem.DropDownItems.Add("Latest Version");
                    for (int index2 = 0; index2 < strArray1.Length; ++index2)
                      dropDownItem.DropDownItems.Add("v" + strArray1[index2]);
                  }
                }
                break;
              }
              toolStripMenuItem.DropDownItems.Add("Latest Version");
              if (childNodes[i2].InnerText != "")
              {
                for (int index = 0; index < strArray1.Length; ++index)
                  toolStripMenuItem.DropDownItems.Add("v" + strArray1[index]);
                break;
              }
              break;
            case "region":
              string[] strArray2 = childNodes[i2].InnerText.Split(',');
              if (childNodes[i2].InnerText != "")
              {
                for (int index = 0; index < strArray2.Length; ++index)
                  toolStripMenuItem.DropDownItems.Add(this.RegionFromIndex(Convert.ToInt32(strArray2[index])));
                break;
              }
              break;
            case "ticket":
              ticket = Convert.ToBoolean(childNodes[i2].InnerText);
              break;
            case "danger":
              danger = true;
              toolStripMenuItem.ToolTipText = childNodes[i2].InnerText;
              break;
          }
          toolStripMenuItem.Image = this.SelectItemImage(ticket, danger);
          if (str1 != "")
            toolStripMenuItem.Text = string.Format("{0} - {1}", (object) str1, (object) str2);
          else
            toolStripMenuItem.Text = str2;
        }
        toolStripMenuItemArray[i1] = toolStripMenuItem;
      }
      return toolStripMenuItemArray;
    }

    public ToolStripMenuItem[] LoadDsiWareTitles()
    {
      if (this.databaseString.Length < 1)
        throw new Exception("Load the database into a memory stream first!");
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(this.databaseString);
      XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(this.DSiWareTag);
      ToolStripMenuItem[] toolStripMenuItemArray = new ToolStripMenuItem[elementsByTagName.Count];
      for (int i1 = 0; i1 < elementsByTagName.Count; ++i1)
      {
        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
        XmlAttributeCollection attributes = elementsByTagName[i1].Attributes;
        string str1 = "";
        string str2 = "";
        bool danger = false;
        bool ticket = true;
        XmlNodeList childNodes = elementsByTagName[i1].ChildNodes;
        for (int i2 = 0; i2 < childNodes.Count; ++i2)
        {
          switch (childNodes[i2].Name)
          {
            case "name":
              str2 = childNodes[i2].InnerText;
              break;
            case "titleID":
              str1 = childNodes[i2].InnerText;
              break;
            case "version":
              string[] strArray1 = childNodes[i2].InnerText.Split(',');
              if (toolStripMenuItem.DropDownItems.Count > 0)
              {
                for (int index1 = 0; index1 < toolStripMenuItem.DropDownItems.Count; ++index1)
                {
                  if (childNodes[i2].InnerText != "")
                  {
                    ToolStripMenuItem dropDownItem = (ToolStripMenuItem) toolStripMenuItem.DropDownItems[index1];
                    dropDownItem.DropDownItems.Add("Latest Version");
                    for (int index2 = 0; index2 < strArray1.Length; ++index2)
                      dropDownItem.DropDownItems.Add("v" + strArray1[index2]);
                  }
                }
                break;
              }
              toolStripMenuItem.DropDownItems.Add("Latest Version");
              if (childNodes[i2].InnerText != "")
              {
                for (int index = 0; index < strArray1.Length; ++index)
                  toolStripMenuItem.DropDownItems.Add("v" + strArray1[index]);
                break;
              }
              break;
            case "region":
              string[] strArray2 = childNodes[i2].InnerText.Split(',');
              if (childNodes[i2].InnerText != "")
              {
                for (int index = 0; index < strArray2.Length; ++index)
                  toolStripMenuItem.DropDownItems.Add(this.RegionFromIndex(Convert.ToInt32(strArray2[index])));
                break;
              }
              break;
            case "ticket":
              ticket = Convert.ToBoolean(childNodes[i2].InnerText);
              break;
            case "danger":
              danger = true;
              toolStripMenuItem.ToolTipText = childNodes[i2].InnerText;
              break;
          }
          toolStripMenuItem.Image = this.SelectItemImage(ticket, danger);
          if (str1 != "")
            toolStripMenuItem.Text = string.Format("{0} - {1}", (object) str1, (object) str2);
          else
            toolStripMenuItem.Text = str2;
        }
        toolStripMenuItemArray[i1] = toolStripMenuItem;
      }
      return toolStripMenuItemArray;
    }
  }
}
