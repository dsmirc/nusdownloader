// Decompiled with JetBrains decompiler
// Type: NUS_Downloader.Form1
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

using libWiiSharp;
using NUS_Downloader.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using System.Xml;
using wmgCMS;
using wyDay.Controls;

namespace NUS_Downloader
{
  internal class Form1 : Form
  {
    private const string _chars = "abcdefghijklmnopqrstuvwxyz";
    private IContainer components;
    private Button Extrasbtn;
    private Button downloadstartbtn;
    private RichTextBox statusbox;
    private CheckBox packbox;
    private CheckBox localuse;
    private BackgroundWorker NUSDownloader;
    private Label label1;
    private TextBox wadnamebox;
    private CheckBox decryptbox;
    private Button databaseButton;
    private ContextMenuStrip databaseStrip;
    private ToolStripMenuItem SystemMenuList;
    private ToolStripMenuItem IOSMenuList;
    private ToolStripMenuItem VCMenuList;
    private ToolStripMenuItem WiiWareMenuList;
    private ToolStripMenuItem C64MenuList;
    private ToolStripMenuItem NeoGeoMenuList;
    private ToolStripMenuItem NESMenuList;
    private ToolStripMenuItem SNESMenuList;
    private ToolStripMenuItem N64MenuList;
    private ToolStripMenuItem MSXMenuList;
    private ToolStripMenuItem TurboGrafx16MenuList;
    private ToolStripMenuItem SegaMSMenuList;
    private ToolStripMenuItem GenesisMenuList;
    private ToolStripMenuItem VCArcadeMenuList;
    private ToolStripMenuItem TurboGrafxCDMenuList;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem RegionCodesList;
    private Button clearButton;
    private ContextMenuStrip extrasStrip;
    private ToolStripMenuItem loadInfoFromTMDToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripMenuItem proxySettingsToolStripMenuItem;
    private GroupBox proxyBox;
    private TextBox ProxyUser;
    private Button SaveProxyBtn;
    private Button ProxyAssistBtn;
    private TextBox ProxyURL;
    private Label label13;
    private Label label12;
    private GroupBox ProxyVerifyBox;
    private Button SaveProxyPwdBtn;
    private Label label14;
    private TextBox ProxyPwdBox;
    private Windows7ProgressBar dlprogress;
    private ToolStripSeparator toolStripSeparator6;
    private WaterMarkTextBox titleidbox;
    private WaterMarkTextBox titleversion;
    private Button scriptsbutton;
    private ContextMenuStrip scriptsStrip;
    private ToolStripMenuItem loadNUSScriptToolStripMenuItem;
    private ToolStripMenuItem emulateUpdate;
    private ToolStripMenuItem uSANTSCToolStripMenuItem;
    private ToolStripMenuItem europePALToolStripMenuItem;
    private ToolStripMenuItem japanNTSCJToolStripMenuItem;
    private ToolStripMenuItem koreaToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripMenuItem updateDatabaseToolStripMenuItem;
    private ToolStripMenuItem scriptsLocalMenuEntry;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem scriptsDatabaseToolStripMenuItem;
    private ToolStripMenuItem aboutNUSDToolStripMenuItem;
    private CheckBox checkBox1;
    private Button SaveProxyPwdPermanentBtn;
    private CheckBox keepenccontents;
    private Button saveaswadbtn;
    private CheckBox iosPatchCheckbox;
    private GroupBox iosPatchGroupBox;
    private CheckedListBox iosPatchesListBox;
    private Button iosPatchGroupBoxOKbtn;
    private Label label2;
    private Panel richPanel;
    private ToolStripMenuItem systemFakeMenuItem;
    private ToolStripMenuItem iosFakeMenuItem;
    private ToolStripMenuItem vcFakeMenuItem;
    private ToolStripMenuItem wwFakeMenuItem;
    private ToolStripMenuItem openNUSDDirectoryToolStripMenuItem;
    private ToolStripMenuItem moreExtrasToolStripMenuItem;
    private ToolStripMenuItem runFolderFixToolStripMenuItem;
    private ToolStripMenuItem wiiBrewToolStripMenuItem;
    private ToolStripMenuItem mainPageToolStripMenuItem;
    private ToolStripMenuItem databasePageToolStripMenuItem;
    private ToolStripMenuItem removeNUSDFilesFoldersToolStripMenuItem;
    private ToolStripMenuItem databaseToolStripMenuItem;
    private ToolStripMenuItem localTicketInventoryToolStripMenuItem;
    private ToolStripMenuItem donateToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripMenuItem dsiSystemToolStripMenu;
    private ToolStripMenuItem dsiFakeSystemToolStripMenu;
    private ToolStripMenuItem dSiWareToolStripMenu;
    private ToolStripMenuItem dSiWareFakeToolStripMenu;
    private ToolStripMenuItem wiiRegionCodesMenu;
    private ToolStripMenuItem dsiRegionCodesMenu;
    private Label serverLbl;
    private ToolStripSeparator toolStripSeparator7;
    private CheckBox pathbox;
    private readonly string CURRENT_DIR = Directory.GetCurrentDirectory();
    private string version = "v1.9 mod";
    private string WAD_Saveas_Filename;
    private string proxy_url;
    private string proxy_usr;
    private string proxy_pwd;
    private BackgroundWorker databaseWorker;
    private BackgroundWorker dsiDatabaseWorker;
    private BackgroundWorker scriptsWorker;
    private Color normalcolor = Color.FromName("Black");
    private Color warningcolor = Color.FromName("DarkGoldenrod");
    private Color errorcolor = Color.FromName("Crimson");
    private Color infocolor = Color.FromName("RoyalBlue");
    private bool[] disabledStorage = new bool[14];
    private readonly Random _rng = new Random();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.Extrasbtn = new Button();
      this.downloadstartbtn = new Button();
      this.statusbox = new RichTextBox();
      this.NUSDownloader = new BackgroundWorker();
      this.label1 = new Label();
      this.wadnamebox = new TextBox();
      this.databaseStrip = new ContextMenuStrip(this.components);
      this.SystemMenuList = new ToolStripMenuItem();
      this.systemFakeMenuItem = new ToolStripMenuItem();
      this.IOSMenuList = new ToolStripMenuItem();
      this.iosFakeMenuItem = new ToolStripMenuItem();
      this.VCMenuList = new ToolStripMenuItem();
      this.C64MenuList = new ToolStripMenuItem();
      this.GenesisMenuList = new ToolStripMenuItem();
      this.MSXMenuList = new ToolStripMenuItem();
      this.N64MenuList = new ToolStripMenuItem();
      this.NeoGeoMenuList = new ToolStripMenuItem();
      this.NESMenuList = new ToolStripMenuItem();
      this.SegaMSMenuList = new ToolStripMenuItem();
      this.SNESMenuList = new ToolStripMenuItem();
      this.TurboGrafx16MenuList = new ToolStripMenuItem();
      this.TurboGrafxCDMenuList = new ToolStripMenuItem();
      this.VCArcadeMenuList = new ToolStripMenuItem();
      this.vcFakeMenuItem = new ToolStripMenuItem();
      this.WiiWareMenuList = new ToolStripMenuItem();
      this.wwFakeMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator5 = new ToolStripSeparator();
      this.dsiSystemToolStripMenu = new ToolStripMenuItem();
      this.dsiFakeSystemToolStripMenu = new ToolStripMenuItem();
      this.dSiWareToolStripMenu = new ToolStripMenuItem();
      this.dSiWareFakeToolStripMenu = new ToolStripMenuItem();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.RegionCodesList = new ToolStripMenuItem();
      this.wiiRegionCodesMenu = new ToolStripMenuItem();
      this.dsiRegionCodesMenu = new ToolStripMenuItem();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.updateDatabaseToolStripMenuItem = new ToolStripMenuItem();
      this.extrasStrip = new ContextMenuStrip(this.components);
      this.loadInfoFromTMDToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.proxySettingsToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator6 = new ToolStripSeparator();
      this.openNUSDDirectoryToolStripMenuItem = new ToolStripMenuItem();
      this.moreExtrasToolStripMenuItem = new ToolStripMenuItem();
      this.runFolderFixToolStripMenuItem = new ToolStripMenuItem();
      this.wiiBrewToolStripMenuItem = new ToolStripMenuItem();
      this.mainPageToolStripMenuItem = new ToolStripMenuItem();
      this.databasePageToolStripMenuItem = new ToolStripMenuItem();
      this.removeNUSDFilesFoldersToolStripMenuItem = new ToolStripMenuItem();
      this.databaseToolStripMenuItem = new ToolStripMenuItem();
      this.localTicketInventoryToolStripMenuItem = new ToolStripMenuItem();
      this.donateToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator7 = new ToolStripSeparator();
      this.aboutNUSDToolStripMenuItem = new ToolStripMenuItem();
      this.proxyBox = new GroupBox();
      this.label13 = new Label();
      this.label12 = new Label();
      this.ProxyUser = new TextBox();
      this.SaveProxyBtn = new Button();
      this.ProxyAssistBtn = new Button();
      this.ProxyURL = new TextBox();
      this.ProxyVerifyBox = new GroupBox();
      this.SaveProxyPwdPermanentBtn = new Button();
      this.checkBox1 = new CheckBox();
      this.SaveProxyPwdBtn = new Button();
      this.label14 = new Label();
      this.ProxyPwdBox = new TextBox();
      this.scriptsbutton = new Button();
      this.scriptsStrip = new ContextMenuStrip(this.components);
      this.scriptsLocalMenuEntry = new ToolStripMenuItem();
      this.scriptsDatabaseToolStripMenuItem = new ToolStripMenuItem();
      this.loadNUSScriptToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.emulateUpdate = new ToolStripMenuItem();
      this.uSANTSCToolStripMenuItem = new ToolStripMenuItem();
      this.europePALToolStripMenuItem = new ToolStripMenuItem();
      this.japanNTSCJToolStripMenuItem = new ToolStripMenuItem();
      this.koreaToolStripMenuItem = new ToolStripMenuItem();
      this.iosPatchGroupBox = new GroupBox();
      this.label2 = new Label();
      this.iosPatchesListBox = new CheckedListBox();
      this.iosPatchGroupBoxOKbtn = new Button();
      this.richPanel = new Panel();
      this.databaseButton = new Button();
      this.saveaswadbtn = new Button();
      this.iosPatchCheckbox = new CheckBox();
      this.keepenccontents = new CheckBox();
      this.clearButton = new Button();
      this.packbox = new CheckBox();
      this.decryptbox = new CheckBox();
      this.localuse = new CheckBox();
      this.serverLbl = new Label();
      this.titleidbox = new WaterMarkTextBox();
      this.dlprogress = new Windows7ProgressBar();
      this.titleversion = new WaterMarkTextBox();
      this.pathbox = new CheckBox();
      this.databaseStrip.SuspendLayout();
      this.extrasStrip.SuspendLayout();
      this.proxyBox.SuspendLayout();
      this.ProxyVerifyBox.SuspendLayout();
      this.scriptsStrip.SuspendLayout();
      this.iosPatchGroupBox.SuspendLayout();
      this.richPanel.SuspendLayout();
      this.SuspendLayout();
      this.Extrasbtn.FlatStyle = FlatStyle.Popup;
      this.Extrasbtn.Location = new Point(194, 5);
      this.Extrasbtn.Name = "Extrasbtn";
      this.Extrasbtn.Size = new Size(68, 27);
      this.Extrasbtn.TabIndex = 2;
      this.Extrasbtn.Text = "Extras...";
      this.Extrasbtn.UseVisualStyleBackColor = true;
      this.Extrasbtn.Click += new EventHandler(this.extrasMenuButton_Click);
      this.downloadstartbtn.FlatStyle = FlatStyle.Popup;
      this.downloadstartbtn.Location = new Point(12, 64);
      this.downloadstartbtn.Name = "downloadstartbtn";
      this.downloadstartbtn.Size = new Size(250, 25);
      this.downloadstartbtn.TabIndex = 5;
      this.downloadstartbtn.Text = "Start NUS Download!";
      this.downloadstartbtn.UseVisualStyleBackColor = true;
      this.downloadstartbtn.Click += new EventHandler(this.DownloadBtn_Click);
      this.statusbox.BackColor = SystemColors.ControlLightLight;
      this.statusbox.BorderStyle = BorderStyle.FixedSingle;
      this.statusbox.Location = new Point(-2, -2);
      this.statusbox.Name = "statusbox";
      this.statusbox.ReadOnly = true;
      this.statusbox.ScrollBars = RichTextBoxScrollBars.None;
      this.statusbox.Size = new Size(252, 269);
      this.statusbox.TabIndex = 0;
      this.statusbox.Text = "";
      this.NUSDownloader.DoWork += new DoWorkEventHandler(this.NUSDownloader_DoWork);
      this.NUSDownloader.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.NUSDownloader_RunWorkerCompleted);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Location = new Point(159, 45);
      this.label1.Name = "label1";
      this.label1.Size = new Size(13, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "v";
      this.wadnamebox.BorderStyle = BorderStyle.FixedSingle;
      this.wadnamebox.Enabled = false;
      this.wadnamebox.Location = new Point(102, 390);
      this.wadnamebox.MaxLength = 99999;
      this.wadnamebox.Name = "wadnamebox";
      this.wadnamebox.Size = new Size(161, 20);
      this.wadnamebox.TabIndex = 17;
      this.databaseStrip.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.databaseStrip.Items.AddRange(new ToolStripItem[17]
      {
        (ToolStripItem) this.SystemMenuList,
        (ToolStripItem) this.systemFakeMenuItem,
        (ToolStripItem) this.IOSMenuList,
        (ToolStripItem) this.iosFakeMenuItem,
        (ToolStripItem) this.VCMenuList,
        (ToolStripItem) this.vcFakeMenuItem,
        (ToolStripItem) this.WiiWareMenuList,
        (ToolStripItem) this.wwFakeMenuItem,
        (ToolStripItem) this.toolStripSeparator5,
        (ToolStripItem) this.dsiSystemToolStripMenu,
        (ToolStripItem) this.dsiFakeSystemToolStripMenu,
        (ToolStripItem) this.dSiWareToolStripMenu,
        (ToolStripItem) this.dSiWareFakeToolStripMenu,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.RegionCodesList,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.updateDatabaseToolStripMenuItem
      });
      this.databaseStrip.Name = "databaseStrip";
      this.databaseStrip.ShowItemToolTips = false;
      this.databaseStrip.Size = new Size(164, 330);
      this.databaseStrip.Text = "Hidden";
      this.databaseStrip.Closed += new ToolStripDropDownClosedEventHandler(this.anyStrip_Closed);
      this.SystemMenuList.AutoSize = false;
      this.SystemMenuList.Image = (Image) componentResourceManager.GetObject("SystemMenuList.Image");
      this.SystemMenuList.Name = "SystemMenuList";
      this.SystemMenuList.Size = new Size(158, 22);
      this.SystemMenuList.Text = "System";
      this.systemFakeMenuItem.Image = (Image) Resources.arrow_ticker;
      this.systemFakeMenuItem.Name = "systemFakeMenuItem";
      this.systemFakeMenuItem.Size = new Size(163, 22);
      this.systemFakeMenuItem.Text = "System";
      this.systemFakeMenuItem.Visible = false;
      this.IOSMenuList.Image = (Image) componentResourceManager.GetObject("IOSMenuList.Image");
      this.IOSMenuList.Name = "IOSMenuList";
      this.IOSMenuList.Size = new Size(163, 22);
      this.IOSMenuList.Text = "IOS";
      this.iosFakeMenuItem.Image = (Image) Resources.arrow_ticker;
      this.iosFakeMenuItem.Name = "iosFakeMenuItem";
      this.iosFakeMenuItem.Size = new Size(163, 22);
      this.iosFakeMenuItem.Text = "IOS";
      this.iosFakeMenuItem.Visible = false;
      this.VCMenuList.DropDownItems.AddRange(new ToolStripItem[11]
      {
        (ToolStripItem) this.C64MenuList,
        (ToolStripItem) this.GenesisMenuList,
        (ToolStripItem) this.MSXMenuList,
        (ToolStripItem) this.N64MenuList,
        (ToolStripItem) this.NeoGeoMenuList,
        (ToolStripItem) this.NESMenuList,
        (ToolStripItem) this.SegaMSMenuList,
        (ToolStripItem) this.SNESMenuList,
        (ToolStripItem) this.TurboGrafx16MenuList,
        (ToolStripItem) this.TurboGrafxCDMenuList,
        (ToolStripItem) this.VCArcadeMenuList
      });
      this.VCMenuList.Image = (Image) componentResourceManager.GetObject("VCMenuList.Image");
      this.VCMenuList.Name = "VCMenuList";
      this.VCMenuList.Size = new Size(163, 22);
      this.VCMenuList.Text = "Virtual Console";
      this.C64MenuList.Name = "C64MenuList";
      this.C64MenuList.Size = new Size(182, 22);
      this.C64MenuList.Text = "Commodore 64";
      this.GenesisMenuList.Name = "GenesisMenuList";
      this.GenesisMenuList.Size = new Size(182, 22);
      this.GenesisMenuList.Text = "Mega Drive/Genesis";
      this.MSXMenuList.Name = "MSXMenuList";
      this.MSXMenuList.Size = new Size(182, 22);
      this.MSXMenuList.Text = "MSX";
      this.N64MenuList.Name = "N64MenuList";
      this.N64MenuList.Size = new Size(182, 22);
      this.N64MenuList.Text = "Nintendo 64";
      this.NeoGeoMenuList.Name = "NeoGeoMenuList";
      this.NeoGeoMenuList.Size = new Size(182, 22);
      this.NeoGeoMenuList.Text = "NeoGeo";
      this.NESMenuList.Name = "NESMenuList";
      this.NESMenuList.Size = new Size(182, 22);
      this.NESMenuList.Text = "NES";
      this.SegaMSMenuList.Name = "SegaMSMenuList";
      this.SegaMSMenuList.Size = new Size(182, 22);
      this.SegaMSMenuList.Text = "Sega Master System";
      this.SNESMenuList.Name = "SNESMenuList";
      this.SNESMenuList.Size = new Size(182, 22);
      this.SNESMenuList.Text = "SNES";
      this.TurboGrafx16MenuList.Name = "TurboGrafx16MenuList";
      this.TurboGrafx16MenuList.Size = new Size(182, 22);
      this.TurboGrafx16MenuList.Text = "TruboGrafx-16";
      this.TurboGrafxCDMenuList.Name = "TurboGrafxCDMenuList";
      this.TurboGrafxCDMenuList.Size = new Size(182, 22);
      this.TurboGrafxCDMenuList.Text = "TurboGrafx-CD";
      this.VCArcadeMenuList.Name = "VCArcadeMenuList";
      this.VCArcadeMenuList.Size = new Size(182, 22);
      this.VCArcadeMenuList.Text = "Virtual Console Arcade";
      this.vcFakeMenuItem.Image = (Image) Resources.arrow_ticker;
      this.vcFakeMenuItem.Name = "vcFakeMenuItem";
      this.vcFakeMenuItem.Size = new Size(163, 22);
      this.vcFakeMenuItem.Text = "Virtual Console";
      this.vcFakeMenuItem.Visible = false;
      this.WiiWareMenuList.Image = (Image) componentResourceManager.GetObject("WiiWareMenuList.Image");
      this.WiiWareMenuList.Name = "WiiWareMenuList";
      this.WiiWareMenuList.Size = new Size(163, 22);
      this.WiiWareMenuList.Text = "WiiWare";
      this.wwFakeMenuItem.Image = (Image) Resources.arrow_ticker;
      this.wwFakeMenuItem.Name = "wwFakeMenuItem";
      this.wwFakeMenuItem.Size = new Size(163, 22);
      this.wwFakeMenuItem.Text = "WiiWare";
      this.wwFakeMenuItem.Visible = false;
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new Size(160, 6);
      this.dsiSystemToolStripMenu.Image = (Image) Resources.dsi16x16;
      this.dsiSystemToolStripMenu.Name = "dsiSystemToolStripMenu";
      this.dsiSystemToolStripMenu.Size = new Size(163, 22);
      this.dsiSystemToolStripMenu.Text = "System";
      this.dsiFakeSystemToolStripMenu.Image = (Image) Resources.arrow_ticker;
      this.dsiFakeSystemToolStripMenu.Name = "dsiFakeSystemToolStripMenu";
      this.dsiFakeSystemToolStripMenu.Size = new Size(163, 22);
      this.dsiFakeSystemToolStripMenu.Text = "System";
      this.dsiFakeSystemToolStripMenu.Visible = false;
      this.dSiWareToolStripMenu.Image = (Image) Resources.dsi16x16;
      this.dSiWareToolStripMenu.Name = "dSiWareToolStripMenu";
      this.dSiWareToolStripMenu.Size = new Size(163, 22);
      this.dSiWareToolStripMenu.Text = "DSiWare";
      this.dSiWareFakeToolStripMenu.Image = (Image) Resources.arrow_ticker;
      this.dSiWareFakeToolStripMenu.Name = "dSiWareFakeToolStripMenu";
      this.dSiWareFakeToolStripMenu.Size = new Size(163, 22);
      this.dSiWareFakeToolStripMenu.Text = "DSiWare";
      this.dSiWareFakeToolStripMenu.Visible = false;
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(160, 6);
      this.RegionCodesList.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.wiiRegionCodesMenu,
        (ToolStripItem) this.dsiRegionCodesMenu
      });
      this.RegionCodesList.Name = "RegionCodesList";
      this.RegionCodesList.Size = new Size(163, 22);
      this.RegionCodesList.Text = "Region Codes";
      this.wiiRegionCodesMenu.Name = "wiiRegionCodesMenu";
      this.wiiRegionCodesMenu.Size = new Size(89, 22);
      this.wiiRegionCodesMenu.Text = "Wii";
      this.wiiRegionCodesMenu.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.wiiRegionCodesMenu_DropDownItemClicked);
      this.dsiRegionCodesMenu.Name = "dsiRegionCodesMenu";
      this.dsiRegionCodesMenu.Size = new Size(89, 22);
      this.dsiRegionCodesMenu.Text = "DSi";
      this.dsiRegionCodesMenu.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.dsiRegionCodesMenu_DropDownItemClicked);
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new Size(160, 6);
      this.updateDatabaseToolStripMenuItem.Image = (Image) Resources.database_save;
      this.updateDatabaseToolStripMenuItem.Name = "updateDatabaseToolStripMenuItem";
      this.updateDatabaseToolStripMenuItem.Size = new Size(163, 22);
      this.updateDatabaseToolStripMenuItem.Text = "Update Databases";
      this.updateDatabaseToolStripMenuItem.Click += new EventHandler(this.updateDatabaseToolStripMenuItem_Click);
      this.extrasStrip.AllowMerge = false;
      this.extrasStrip.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.extrasStrip.Items.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.loadInfoFromTMDToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.proxySettingsToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator6,
        (ToolStripItem) this.openNUSDDirectoryToolStripMenuItem,
        (ToolStripItem) this.moreExtrasToolStripMenuItem,
        (ToolStripItem) this.donateToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator7,
        (ToolStripItem) this.aboutNUSDToolStripMenuItem
      });
      this.extrasStrip.Name = "extrasStrip";
      this.extrasStrip.Size = new Size(178, 154);
      this.extrasStrip.Text = "Hidden";
      this.extrasStrip.Closed += new ToolStripDropDownClosedEventHandler(this.anyStrip_Closed);
      this.extrasStrip.Opening += new CancelEventHandler(this.extrasStrip_Opening);
      this.loadInfoFromTMDToolStripMenuItem.Image = (Image) Resources.page_white_magnify;
      this.loadInfoFromTMDToolStripMenuItem.Name = "loadInfoFromTMDToolStripMenuItem";
      this.loadInfoFromTMDToolStripMenuItem.Size = new Size(177, 22);
      this.loadInfoFromTMDToolStripMenuItem.Text = "Load Info from TMD";
      this.loadInfoFromTMDToolStripMenuItem.Click += new EventHandler(this.loadInfoFromTMDToolStripMenuItem_Click);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(174, 6);
      this.proxySettingsToolStripMenuItem.Image = (Image) Resources.server_link;
      this.proxySettingsToolStripMenuItem.Name = "proxySettingsToolStripMenuItem";
      this.proxySettingsToolStripMenuItem.Size = new Size(177, 22);
      this.proxySettingsToolStripMenuItem.Text = "Proxy Settings";
      this.proxySettingsToolStripMenuItem.Click += new EventHandler(this.proxySettingsToolStripMenuItem_Click);
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new Size(174, 6);
      this.openNUSDDirectoryToolStripMenuItem.Image = (Image) Resources.folder;
      this.openNUSDDirectoryToolStripMenuItem.Name = "openNUSDDirectoryToolStripMenuItem";
      this.openNUSDDirectoryToolStripMenuItem.Size = new Size(177, 22);
      this.openNUSDDirectoryToolStripMenuItem.Text = "Open NUSD Directory";
      this.openNUSDDirectoryToolStripMenuItem.Click += new EventHandler(this.openNUSDDirectoryToolStripMenuItem_Click);
      this.moreExtrasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.runFolderFixToolStripMenuItem,
        (ToolStripItem) this.wiiBrewToolStripMenuItem,
        (ToolStripItem) this.removeNUSDFilesFoldersToolStripMenuItem,
        (ToolStripItem) this.databaseToolStripMenuItem
      });
      this.moreExtrasToolStripMenuItem.Image = (Image) Resources.wrench;
      this.moreExtrasToolStripMenuItem.Name = "moreExtrasToolStripMenuItem";
      this.moreExtrasToolStripMenuItem.Size = new Size(177, 22);
      this.moreExtrasToolStripMenuItem.Text = "More Extras...";
      this.moreExtrasToolStripMenuItem.Visible = false;
      this.runFolderFixToolStripMenuItem.Name = "runFolderFixToolStripMenuItem";
      this.runFolderFixToolStripMenuItem.Size = new Size(206, 22);
      this.runFolderFixToolStripMenuItem.Text = "Run 'FolderFix'";
      this.runFolderFixToolStripMenuItem.Click += new EventHandler(this.runFolderFixToolStripMenuItem_Click);
      this.wiiBrewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.mainPageToolStripMenuItem,
        (ToolStripItem) this.databasePageToolStripMenuItem
      });
      this.wiiBrewToolStripMenuItem.Name = "wiiBrewToolStripMenuItem";
      this.wiiBrewToolStripMenuItem.Size = new Size(206, 22);
      this.wiiBrewToolStripMenuItem.Text = "WiiBrew";
      this.mainPageToolStripMenuItem.Name = "mainPageToolStripMenuItem";
      this.mainPageToolStripMenuItem.Size = new Size(147, 22);
      this.mainPageToolStripMenuItem.Text = "Main Page";
      this.mainPageToolStripMenuItem.Click += new EventHandler(this.mainPageToolStripMenuItem_Click);
      this.databasePageToolStripMenuItem.Name = "databasePageToolStripMenuItem";
      this.databasePageToolStripMenuItem.Size = new Size(147, 22);
      this.databasePageToolStripMenuItem.Text = "Database Page";
      this.databasePageToolStripMenuItem.Click += new EventHandler(this.databasePageToolStripMenuItem_Click);
      this.removeNUSDFilesFoldersToolStripMenuItem.Name = "removeNUSDFilesFoldersToolStripMenuItem";
      this.removeNUSDFilesFoldersToolStripMenuItem.Size = new Size(206, 22);
      this.removeNUSDFilesFoldersToolStripMenuItem.Text = "Remove NUSD Files\\Folders";
      this.removeNUSDFilesFoldersToolStripMenuItem.Click += new EventHandler(this.removeNUSDFilesFoldersToolStripMenuItem_Click);
      this.databaseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.localTicketInventoryToolStripMenuItem
      });
      this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
      this.databaseToolStripMenuItem.Size = new Size(206, 22);
      this.databaseToolStripMenuItem.Text = "Database";
      this.localTicketInventoryToolStripMenuItem.Name = "localTicketInventoryToolStripMenuItem";
      this.localTicketInventoryToolStripMenuItem.Size = new Size(180, 22);
      this.localTicketInventoryToolStripMenuItem.Text = "Local Ticket Inventory";
      this.localTicketInventoryToolStripMenuItem.Click += new EventHandler(this.localTicketInventoryToolStripMenuItem_Click);
      this.donateToolStripMenuItem.Image = (Image) Resources.money;
      this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
      this.donateToolStripMenuItem.Size = new Size(177, 22);
      this.donateToolStripMenuItem.Text = "Donate!";
      this.donateToolStripMenuItem.Visible = false;
      this.donateToolStripMenuItem.Click += new EventHandler(this.donateToolStripMenuItem_Click);
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new Size(174, 6);
      this.aboutNUSDToolStripMenuItem.Image = (Image) Resources.information;
      this.aboutNUSDToolStripMenuItem.Name = "aboutNUSDToolStripMenuItem";
      this.aboutNUSDToolStripMenuItem.Size = new Size(177, 22);
      this.aboutNUSDToolStripMenuItem.Text = "About NUSD";
      this.aboutNUSDToolStripMenuItem.Click += new EventHandler(this.aboutNUSDToolStripMenuItem_Click);
      this.proxyBox.BackColor = Color.White;
      this.proxyBox.Controls.Add((Control) this.label13);
      this.proxyBox.Controls.Add((Control) this.label12);
      this.proxyBox.Controls.Add((Control) this.ProxyUser);
      this.proxyBox.Controls.Add((Control) this.SaveProxyBtn);
      this.proxyBox.Controls.Add((Control) this.ProxyAssistBtn);
      this.proxyBox.Controls.Add((Control) this.ProxyURL);
      this.proxyBox.Location = new Point(31, 250);
      this.proxyBox.Name = "proxyBox";
      this.proxyBox.Size = new Size(212, 114);
      this.proxyBox.TabIndex = 45;
      this.proxyBox.TabStop = false;
      this.proxyBox.Text = "Proxy Settings";
      this.proxyBox.Visible = false;
      this.label13.AutoSize = true;
      this.label13.Location = new Point(6, 55);
      this.label13.Name = "label13";
      this.label13.Size = new Size(32, 13);
      this.label13.TabIndex = 32;
      this.label13.Text = "User:";
      this.label12.AutoSize = true;
      this.label12.Location = new Point(6, 29);
      this.label12.Name = "label12";
      this.label12.Size = new Size(36, 13);
      this.label12.TabIndex = 31;
      this.label12.Text = "Proxy:";
      this.ProxyUser.BorderStyle = BorderStyle.FixedSingle;
      this.ProxyUser.Location = new Point(55, 53);
      this.ProxyUser.Name = "ProxyUser";
      this.ProxyUser.Size = new Size(151, 20);
      this.ProxyUser.TabIndex = 30;
      this.SaveProxyBtn.FlatStyle = FlatStyle.Popup;
      this.SaveProxyBtn.Location = new Point(6, 79);
      this.SaveProxyBtn.Name = "SaveProxyBtn";
      this.SaveProxyBtn.Size = new Size(161, 26);
      this.SaveProxyBtn.TabIndex = 29;
      this.SaveProxyBtn.Text = "Save Proxy Settings";
      this.SaveProxyBtn.UseVisualStyleBackColor = true;
      this.SaveProxyBtn.Click += new EventHandler(this.SaveProxyBtn_Click);
      this.ProxyAssistBtn.FlatStyle = FlatStyle.Popup;
      this.ProxyAssistBtn.Image = (Image) Resources.help;
      this.ProxyAssistBtn.Location = new Point(177, 79);
      this.ProxyAssistBtn.Name = "ProxyAssistBtn";
      this.ProxyAssistBtn.Size = new Size(29, 26);
      this.ProxyAssistBtn.TabIndex = 28;
      this.ProxyAssistBtn.UseVisualStyleBackColor = true;
      this.ProxyAssistBtn.Click += new EventHandler(this.ProxyAssistBtn_Click);
      this.ProxyURL.BorderStyle = BorderStyle.FixedSingle;
      this.ProxyURL.Location = new Point(55, 27);
      this.ProxyURL.Name = "ProxyURL";
      this.ProxyURL.Size = new Size(151, 20);
      this.ProxyURL.TabIndex = 0;
      this.ProxyVerifyBox.BackColor = SystemColors.Control;
      this.ProxyVerifyBox.Controls.Add((Control) this.SaveProxyPwdPermanentBtn);
      this.ProxyVerifyBox.Controls.Add((Control) this.checkBox1);
      this.ProxyVerifyBox.Controls.Add((Control) this.SaveProxyPwdBtn);
      this.ProxyVerifyBox.Controls.Add((Control) this.label14);
      this.ProxyVerifyBox.Controls.Add((Control) this.ProxyPwdBox);
      this.ProxyVerifyBox.Location = new Point(31, 222);
      this.ProxyVerifyBox.Name = "ProxyVerifyBox";
      this.ProxyVerifyBox.Size = new Size(212, 133);
      this.ProxyVerifyBox.TabIndex = 46;
      this.ProxyVerifyBox.TabStop = false;
      this.ProxyVerifyBox.Text = "Verify Credentials";
      this.ProxyVerifyBox.Visible = false;
      this.SaveProxyPwdPermanentBtn.Enabled = false;
      this.SaveProxyPwdPermanentBtn.FlatStyle = FlatStyle.Popup;
      this.SaveProxyPwdPermanentBtn.Location = new Point(9, 104);
      this.SaveProxyPwdPermanentBtn.Name = "SaveProxyPwdPermanentBtn";
      this.SaveProxyPwdPermanentBtn.Size = new Size(197, 23);
      this.SaveProxyPwdPermanentBtn.TabIndex = 36;
      this.SaveProxyPwdPermanentBtn.Text = "Save (To File)";
      this.SaveProxyPwdPermanentBtn.UseVisualStyleBackColor = true;
      this.SaveProxyPwdPermanentBtn.Click += new EventHandler(this.SaveProxyPwdPermanentBtn_Click);
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(9, 72);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(199, 30);
      this.checkBox1.TabIndex = 35;
      this.checkBox1.Text = "I understand that NUSD stores proxy\r\npasswords in plain text.";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
      this.SaveProxyPwdBtn.FlatStyle = FlatStyle.Popup;
      this.SaveProxyPwdBtn.Location = new Point(9, 43);
      this.SaveProxyPwdBtn.Name = "SaveProxyPwdBtn";
      this.SaveProxyPwdBtn.Size = new Size(197, 23);
      this.SaveProxyPwdBtn.TabIndex = 34;
      this.SaveProxyPwdBtn.Text = "Save (This Session Only)";
      this.SaveProxyPwdBtn.UseVisualStyleBackColor = true;
      this.SaveProxyPwdBtn.Click += new EventHandler(this.SaveProxyPwdButton_Click);
      this.label14.AutoSize = true;
      this.label14.Location = new Point(6, 21);
      this.label14.Name = "label14";
      this.label14.Size = new Size(62, 13);
      this.label14.TabIndex = 33;
      this.label14.Text = "Proxy Pass:";
      this.ProxyPwdBox.BorderStyle = BorderStyle.FixedSingle;
      this.ProxyPwdBox.Location = new Point(71, 19);
      this.ProxyPwdBox.Name = "ProxyPwdBox";
      this.ProxyPwdBox.Size = new Size(135, 20);
      this.ProxyPwdBox.TabIndex = 32;
      this.ProxyPwdBox.UseSystemPasswordChar = true;
      this.ProxyPwdBox.KeyPress += new KeyPressEventHandler(this.ProxyPwdBox_KeyPress);
      this.scriptsbutton.FlatStyle = FlatStyle.Popup;
      this.scriptsbutton.Location = new Point(103, 5);
      this.scriptsbutton.Name = "scriptsbutton";
      this.scriptsbutton.Size = new Size(85, 27);
      this.scriptsbutton.TabIndex = 1;
      this.scriptsbutton.Text = "Scripts...";
      this.scriptsbutton.UseVisualStyleBackColor = true;
      this.scriptsbutton.Click += new EventHandler(this.scriptsbutton_Click);
      this.scriptsStrip.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.scriptsStrip.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.scriptsLocalMenuEntry,
        (ToolStripItem) this.scriptsDatabaseToolStripMenuItem,
        (ToolStripItem) this.loadNUSScriptToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.emulateUpdate
      });
      this.scriptsStrip.Name = "scriptsStrip";
      this.scriptsStrip.ShowItemToolTips = false;
      this.scriptsStrip.Size = new Size(206, 98);
      this.scriptsStrip.Text = "Hidden";
      this.scriptsStrip.Closed += new ToolStripDropDownClosedEventHandler(this.anyStrip_Closed);
      this.scriptsLocalMenuEntry.Enabled = false;
      this.scriptsLocalMenuEntry.Image = (Image) Resources.script_code;
      this.scriptsLocalMenuEntry.Name = "scriptsLocalMenuEntry";
      this.scriptsLocalMenuEntry.Overflow = ToolStripItemOverflow.AsNeeded;
      this.scriptsLocalMenuEntry.Size = new Size(205, 22);
      this.scriptsLocalMenuEntry.Text = "Scripts (Local)";
      this.scriptsDatabaseToolStripMenuItem.Enabled = false;
      this.scriptsDatabaseToolStripMenuItem.Image = (Image) Resources.script_code_red;
      this.scriptsDatabaseToolStripMenuItem.Name = "scriptsDatabaseToolStripMenuItem";
      this.scriptsDatabaseToolStripMenuItem.Size = new Size(205, 22);
      this.scriptsDatabaseToolStripMenuItem.Text = "Scripts (Database)";
      this.loadNUSScriptToolStripMenuItem.Image = (Image) Resources.script_go;
      this.loadNUSScriptToolStripMenuItem.Name = "loadNUSScriptToolStripMenuItem";
      this.loadNUSScriptToolStripMenuItem.Size = new Size(205, 22);
      this.loadNUSScriptToolStripMenuItem.Text = "Load NUS Script";
      this.loadNUSScriptToolStripMenuItem.Click += new EventHandler(this.loadNUSScriptToolStripMenuItem_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(202, 6);
      this.emulateUpdate.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.uSANTSCToolStripMenuItem,
        (ToolStripItem) this.europePALToolStripMenuItem,
        (ToolStripItem) this.japanNTSCJToolStripMenuItem,
        (ToolStripItem) this.koreaToolStripMenuItem
      });
      this.emulateUpdate.Image = (Image) Resources.server_connect;
      this.emulateUpdate.Name = "emulateUpdate";
      this.emulateUpdate.Size = new Size(205, 22);
      this.emulateUpdate.Text = "Emulate Wii System Update";
      this.emulateUpdate.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.emulateUpdate_DropDownItemClicked);
      this.uSANTSCToolStripMenuItem.Name = "uSANTSCToolStripMenuItem";
      this.uSANTSCToolStripMenuItem.Size = new Size(114, 22);
      this.uSANTSCToolStripMenuItem.Text = "USA";
      this.europePALToolStripMenuItem.Name = "europePALToolStripMenuItem";
      this.europePALToolStripMenuItem.Size = new Size(114, 22);
      this.europePALToolStripMenuItem.Text = "EUROPE";
      this.japanNTSCJToolStripMenuItem.Name = "japanNTSCJToolStripMenuItem";
      this.japanNTSCJToolStripMenuItem.Size = new Size(114, 22);
      this.japanNTSCJToolStripMenuItem.Text = "JAPAN";
      this.koreaToolStripMenuItem.Name = "koreaToolStripMenuItem";
      this.koreaToolStripMenuItem.Size = new Size(114, 22);
      this.koreaToolStripMenuItem.Text = "KOREA";
      this.iosPatchGroupBox.Controls.Add((Control) this.label2);
      this.iosPatchGroupBox.Controls.Add((Control) this.iosPatchesListBox);
      this.iosPatchGroupBox.Controls.Add((Control) this.iosPatchGroupBoxOKbtn);
      this.iosPatchGroupBox.Location = new Point(31, 187);
      this.iosPatchGroupBox.Name = "iosPatchGroupBox";
      this.iosPatchGroupBox.Size = new Size(212, 115);
      this.iosPatchGroupBox.TabIndex = 55;
      this.iosPatchGroupBox.TabStop = false;
      this.iosPatchGroupBox.Text = "IOS Patches";
      this.iosPatchGroupBox.Visible = false;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(9, 16);
      this.label2.Name = "label2";
      this.label2.Size = new Size(184, 26);
      this.label2.TabIndex = 2;
      this.label2.Text = "Patch the following bugs into any IOS\r\nI download:";
      this.iosPatchesListBox.BackColor = SystemColors.Menu;
      this.iosPatchesListBox.BorderStyle = BorderStyle.None;
      this.iosPatchesListBox.CheckOnClick = true;
      this.iosPatchesListBox.FormattingEnabled = true;
      this.iosPatchesListBox.Items.AddRange(new object[3]
      {
        (object) "Trucha bug",
        (object) "ES_Identify",
        (object) "NAND permissions"
      });
      this.iosPatchesListBox.Location = new Point(6, 62);
      this.iosPatchesListBox.Name = "iosPatchesListBox";
      this.iosPatchesListBox.Size = new Size(115, 45);
      this.iosPatchesListBox.TabIndex = 1;
      this.iosPatchGroupBoxOKbtn.FlatStyle = FlatStyle.Popup;
      this.iosPatchGroupBoxOKbtn.Location = new Point((int) sbyte.MaxValue, 84);
      this.iosPatchGroupBoxOKbtn.Name = "iosPatchGroupBoxOKbtn";
      this.iosPatchGroupBoxOKbtn.Size = new Size(75, 23);
      this.iosPatchGroupBoxOKbtn.TabIndex = 0;
      this.iosPatchGroupBoxOKbtn.Text = "OK";
      this.iosPatchGroupBoxOKbtn.UseVisualStyleBackColor = true;
      this.iosPatchGroupBoxOKbtn.Click += new EventHandler(this.iosPatchGroupBoxOKbtn_Click);
      this.richPanel.BorderStyle = BorderStyle.FixedSingle;
      this.richPanel.Controls.Add((Control) this.statusbox);
      this.richPanel.Location = new Point(12, 116);
      this.richPanel.Name = "richPanel";
      this.richPanel.Size = new Size(250, 268);
      this.richPanel.TabIndex = 56;
      this.databaseButton.FlatStyle = FlatStyle.Popup;
      this.databaseButton.Location = new Point(12, 5);
      this.databaseButton.Name = "databaseButton";
      this.databaseButton.Size = new Size(85, 27);
      this.databaseButton.TabIndex = 0;
      this.databaseButton.Text = "Database...";
      this.databaseButton.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.databaseButton.UseVisualStyleBackColor = true;
      this.databaseButton.Click += new EventHandler(this.DatabaseButton_Click);
      this.saveaswadbtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.saveaswadbtn.AutoSize = true;
      this.saveaswadbtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.saveaswadbtn.BackColor = Color.Transparent;
      this.saveaswadbtn.Enabled = false;
      this.saveaswadbtn.FlatStyle = FlatStyle.Flat;
      this.saveaswadbtn.Image = (Image) Resources.disk;
      this.saveaswadbtn.Location = new Point(239, 409);
      this.saveaswadbtn.MaximumSize = new Size(0, 24);
      this.saveaswadbtn.MinimumSize = new Size(0, 24);
      this.saveaswadbtn.Name = "saveaswadbtn";
      this.saveaswadbtn.Size = new Size(24, 24);
      this.saveaswadbtn.TabIndex = 11;
      this.saveaswadbtn.TextAlign = ContentAlignment.MiddleLeft;
      this.saveaswadbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.saveaswadbtn.UseVisualStyleBackColor = false;
      this.saveaswadbtn.Click += new EventHandler(this.saveaswadbtn_Click);
      this.saveaswadbtn.MouseEnter += new EventHandler(this.saveaswadbtn_MouseEnter);
      this.saveaswadbtn.MouseLeave += new EventHandler(this.saveaswadbtn_MouseLeave);
      this.iosPatchCheckbox.Enabled = false;
      this.iosPatchCheckbox.Image = (Image) Resources.bug_add;
      this.iosPatchCheckbox.ImageAlign = ContentAlignment.MiddleLeft;
      this.iosPatchCheckbox.Location = new Point(11, 480);
      this.iosPatchCheckbox.Name = "iosPatchCheckbox";
      this.iosPatchCheckbox.Size = new Size(104, 22);
      this.iosPatchCheckbox.TabIndex = 10;
      this.iosPatchCheckbox.Text = "Patch IOS...";
      this.iosPatchCheckbox.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.iosPatchCheckbox.UseVisualStyleBackColor = true;
      this.iosPatchCheckbox.CheckedChanged += new EventHandler(this.iosPatchCheckbox_CheckedChanged);
      this.keepenccontents.Checked = true;
      this.keepenccontents.CheckState = CheckState.Checked;
      this.keepenccontents.Image = (Image) Resources.package;
      this.keepenccontents.ImageAlign = ContentAlignment.MiddleLeft;
      this.keepenccontents.Location = new Point(10, 414);
      this.keepenccontents.Name = "keepenccontents";
      this.keepenccontents.Size = new Size(177, 22);
      this.keepenccontents.TabIndex = 8;
      this.keepenccontents.Text = "Keep Encrypted Contents";
      this.keepenccontents.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.keepenccontents.UseVisualStyleBackColor = true;
      this.clearButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.clearButton.AutoSize = true;
      this.clearButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.clearButton.BackColor = Color.Transparent;
      this.clearButton.FlatStyle = FlatStyle.Flat;
      this.clearButton.Image = (Image) Resources.bin_closed;
      this.clearButton.ImageAlign = ContentAlignment.MiddleRight;
      this.clearButton.Location = new Point(238, 360);
      this.clearButton.MaximumSize = new Size(0, 24);
      this.clearButton.MinimumSize = new Size(0, 24);
      this.clearButton.Name = "clearButton";
      this.clearButton.Size = new Size(24, 24);
      this.clearButton.TabIndex = 12;
      this.clearButton.TextAlign = ContentAlignment.MiddleRight;
      this.clearButton.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.clearButton.UseVisualStyleBackColor = false;
      this.clearButton.Click += new EventHandler(this.ClearStatusbox);
      this.clearButton.MouseEnter += new EventHandler(this.clearButton_MouseEnter);
      this.clearButton.MouseLeave += new EventHandler(this.clearButton_MouseLeave);
      this.packbox.Image = (Image) Resources.box;
      this.packbox.ImageAlign = ContentAlignment.MiddleLeft;
      this.packbox.Location = new Point(10, 392);
      this.packbox.Name = "packbox";
      this.packbox.Size = new Size(98, 22);
      this.packbox.TabIndex = 7;
      this.packbox.Text = "Pack WAD";
      this.packbox.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.packbox.UseVisualStyleBackColor = true;
      this.packbox.CheckedChanged += new EventHandler(this.packbox_CheckedChanged);
      this.packbox.EnabledChanged += new EventHandler(this.packbox_EnabledChanged);
      this.decryptbox.Image = (Image) Resources.package_green;
      this.decryptbox.ImageAlign = ContentAlignment.MiddleLeft;
      this.decryptbox.Location = new Point(11, 436);
      this.decryptbox.Name = "decryptbox";
      this.decryptbox.Size = new Size(231, 22);
      this.decryptbox.TabIndex = 9;
      this.decryptbox.Text = "Create Decrypted Contents (*.app)";
      this.decryptbox.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.decryptbox.UseVisualStyleBackColor = true;
      this.localuse.Checked = true;
      this.localuse.CheckState = CheckState.Checked;
      this.localuse.Image = (Image) Resources.drive_disk;
      this.localuse.ImageAlign = ContentAlignment.MiddleLeft;
      this.localuse.Location = new Point(11, 458);
      this.localuse.MinimumSize = new Size(0, 22);
      this.localuse.Name = "localuse";
      this.localuse.Size = new Size(162, 22);
      this.localuse.TabIndex = 12;
      this.localuse.Text = "Use Local Files If Present";
      this.localuse.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.localuse.UseVisualStyleBackColor = true;
      this.serverLbl.BorderStyle = BorderStyle.FixedSingle;
      this.serverLbl.Location = new Point(233, 38);
      this.serverLbl.Name = "serverLbl";
      this.serverLbl.Size = new Size(29, 20);
      this.serverLbl.TabIndex = 57;
      this.serverLbl.Text = "Wii";
      this.serverLbl.TextAlign = ContentAlignment.MiddleCenter;
      this.serverLbl.TextChanged += new EventHandler(this.serverLbl_TextChanged);
      this.serverLbl.Click += new EventHandler(this.serverLbl_Click);
      this.serverLbl.MouseEnter += new EventHandler(this.serverLbl_MouseEnter);
      this.serverLbl.MouseLeave += new EventHandler(this.serverLbl_MouseLeave);
      this.titleidbox.Font = new Font("Tahoma", 8.25f);
      this.titleidbox.Location = new Point(12, 38);
      this.titleidbox.MaxLength = 16;
      this.titleidbox.Name = "titleidbox";
      this.titleidbox.Size = new Size(141, 21);
      this.titleidbox.TabIndex = 3;
      this.titleidbox.TextAlign = HorizontalAlignment.Center;
      this.titleidbox.WaterMarkColor = Color.Silver;
      this.titleidbox.WaterMarkText = "Title ID";
      this.titleidbox.TextChanged += new EventHandler(this.titleidbox_TextChanged);
      this.dlprogress.ContainerControl = (ContainerControl) this;
      this.dlprogress.Location = new Point(12, 95);
      this.dlprogress.Name = "dlprogress";
      this.dlprogress.Size = new Size(250, 15);
      this.dlprogress.TabIndex = 47;
      this.titleversion.Font = new Font("Tahoma", 8.25f);
      this.titleversion.Location = new Point(169, 38);
      this.titleversion.MaxLength = 8;
      this.titleversion.Name = "titleversion";
      this.titleversion.Size = new Size(58, 21);
      this.titleversion.TabIndex = 4;
      this.titleversion.TextAlign = HorizontalAlignment.Center;
      this.titleversion.WaterMarkColor = Color.Silver;
      this.titleversion.WaterMarkText = "Version";
      this.titleversion.TextChanged += new EventHandler(this.titleversion_TextChanged);
      this.pathbox.Location = new Point(11, 502);
      this.pathbox.Name = "pathbox";
      this.pathbox.Size = new Size(161, 22);
      this.pathbox.TabIndex = 58;
      this.pathbox.Text = "Directory of NUSD v1.5";
      this.pathbox.UseVisualStyleBackColor = true;
      this.AutoScaleMode = AutoScaleMode.None;
      this.ClientSize = new Size(274, 527);
      this.Controls.Add((Control) this.pathbox);
      this.Controls.Add((Control) this.serverLbl);
      this.Controls.Add((Control) this.iosPatchGroupBox);
      this.Controls.Add((Control) this.ProxyVerifyBox);
      this.Controls.Add((Control) this.proxyBox);
      this.Controls.Add((Control) this.scriptsbutton);
      this.Controls.Add((Control) this.titleidbox);
      this.Controls.Add((Control) this.dlprogress);
      this.Controls.Add((Control) this.titleversion);
      this.Controls.Add((Control) this.databaseButton);
      this.Controls.Add((Control) this.iosPatchCheckbox);
      this.Controls.Add((Control) this.downloadstartbtn);
      this.Controls.Add((Control) this.clearButton);
      this.Controls.Add((Control) this.keepenccontents);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.Extrasbtn);
      this.Controls.Add((Control) this.wadnamebox);
      this.Controls.Add((Control) this.richPanel);
      this.Controls.Add((Control) this.decryptbox);
      this.Controls.Add((Control) this.packbox);
      this.Controls.Add((Control) this.saveaswadbtn);
      this.Controls.Add((Control) this.localuse);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (Form1);
      this.Text = " ";
      this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new EventHandler(this.Form1_Load);
      this.MouseWheel += new MouseEventHandler(this.Form1_MouseWheel);
      this.databaseStrip.ResumeLayout(false);
      this.extrasStrip.ResumeLayout(false);
      this.proxyBox.ResumeLayout(false);
      this.proxyBox.PerformLayout();
      this.ProxyVerifyBox.ResumeLayout(false);
      this.ProxyVerifyBox.PerformLayout();
      this.scriptsStrip.ResumeLayout(false);
      this.iosPatchGroupBox.ResumeLayout(false);
      this.iosPatchGroupBox.PerformLayout();
      this.richPanel.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public Form1()
    {
      this.InitializeComponent();
      this.GUISetup();
      this.BootChecks();
    }

    public Form1(string[] args)
    {
      this.InitializeComponent();
      this.GUISetup();
      if (args.Length == 1 && System.IO.File.Exists(args[0]))
      {
        this.BootChecks();
        string str1 = System.IO.File.ReadAllText(args[0]);
        FileInfo fileInfo = new FileInfo(args[0]);
        string str2 = str1 + string.Format(";{0}", (object) fileInfo.Name.Replace("." + fileInfo.Extension, ""));
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        backgroundWorker.DoWork += new DoWorkEventHandler(this.RunScriptBg);
        backgroundWorker.RunWorkerAsync((object) str2);
      }
      else if (args.Length >= 2)
      {
        this.RunCommandMode(args);
        Environment.Exit(0);
      }
      else
        this.BootChecks();
    }

    private void RunCommandMode(string[] args)
    {
      this.packbox.Checked = false;
      this.localuse.Checked = true;
      this.decryptbox.Checked = false;
      this.keepenccontents.Checked = false;
      this.iosPatchCheckbox.Checked = false;
      this.iosPatchesListBox.SetItemChecked(0, false);
      this.iosPatchesListBox.SetItemChecked(1, false);
      this.iosPatchesListBox.SetItemChecked(2, false);
      Console.WriteLine("NUS Downloader - v{0}", (object) this.version);
      if (args.Length < 2)
      {
        Console.WriteLine("Usage:");
        Console.WriteLine("    nusd <titleID> <titleVersion | *> [optionalArgs]");
        Console.WriteLine("\nWhere:");
        Console.WriteLine("    titleID = The ID of the title to be downloaded");
        Console.WriteLine("    titleVersion = The version of the title to be downloaded");
        Console.WriteLine("              Use \"*\" (no quotes) to get the latest version");
        Console.WriteLine("    OptionalArgs:");
        Console.WriteLine("        packwad = A wad file will be generated");
        Console.WriteLine("        localuse = Use local contents if available");
        Console.WriteLine("        decrypt = Create decrypted contents");
        Console.WriteLine("        keepencrypt = Keep encrypted contents");
      }
      else
      {
        for (int index = 0; index < args.Length; ++index)
        {
          Console.WriteLine("{0}", (object) args[index]);
          switch (index)
          {
            case 0:
              this.titleidbox.Text = args[index];
              break;
            case 1:
              if (args[index] == "*")
              {
                this.titleversion.Text = "";
                break;
              }
              this.titleversion.Text = args[index];
              break;
            default:
              if (args[index] == "packwad")
              {
                this.packbox.Checked = true;
                break;
              }
              if (args[index] == "localuse")
              {
                this.localuse.Checked = true;
                break;
              }
              if (args[index] == "decrypt")
              {
                this.decryptbox.Checked = true;
                break;
              }
              if (args[index] == "keepencrypt")
              {
                this.keepenccontents.Checked = true;
                break;
              }
              Console.WriteLine("\n>>>> Warning: Unrecognized command line argument: {0}. This option is ignored...", (object) args[index]);
              break;
          }
        }
        this.UpdatePackedName();
        this.NUSDownloader_DoWork((object) null, (DoWorkEventArgs) null);
        Console.WriteLine("\nSuccessfully downloaded the title {0} version {1}", (object) args[0], (object) args[1]);
      }
    }

    private void GUISetup()
    {
      this.Font = new Font("Tahoma", 8f);
      this.MaximumSize = this.MinimumSize = this.Size;
      if (System.Type.GetType("Mono.Runtime") != null)
      {
        this.saveaswadbtn.Text = "Save As";
        this.clearButton.Text = "Clear";
        this.keepenccontents.Text = "Keep Enc. Contents";
        this.clearButton.Left -= 41;
      }
      else
        this.statusbox.Font = new Font("Microsoft Sans Serif", 7f);
      this.statusbox.SelectionColor = this.statusbox.ForeColor = this.normalcolor;
      if (this.version.StartsWith("SVN"))
      {
        this.WriteStatus("!!!!! THIS IS A DEBUG BUILD FROM SVN !!!!!");
        this.WriteStatus("Features CAN and WILL be broken in this build!");
        this.WriteStatus("Devs: REMEMBER TO CHANGE TO THE RELEASE CONFIGURATION AND CHANGE VERSION NUMBER BEFORE BUILDING!");
        this.WriteStatus("\r\n");
      }
      this.databaseWorker = new BackgroundWorker();
      this.databaseWorker.DoWork += new DoWorkEventHandler(this.DoAllDatabaseyStuff);
      this.databaseWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.DoAllDatabaseyStuff_Completed);
      this.databaseWorker.ProgressChanged += new ProgressChangedEventHandler(this.DoAllDatabaseyStuff_ProgressChanged);
      this.databaseWorker.WorkerReportsProgress = true;
      this.dsiDatabaseWorker = new BackgroundWorker();
      this.dsiDatabaseWorker.DoWork += new DoWorkEventHandler(this.DSiDatabaseWork);
      this.dsiDatabaseWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.DSiDatabaseWork_Completed);
      this.dsiDatabaseWorker.ProgressChanged += new ProgressChangedEventHandler(this.DSiDatabaseWork_ProgressChanged);
      this.dsiDatabaseWorker.WorkerReportsProgress = true;
      this.scriptsWorker = new BackgroundWorker();
      this.scriptsWorker.DoWork += new DoWorkEventHandler(this.OrganizeScripts);
      this.scriptsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.scriptsWorker_RunWorkerCompleted);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.Text = string.Format("NUSD - {0}", (object) this.version);
      this.Size = this.MinimumSize;
      this.serverLbl.Text = "Wii";
    }

    private bool NUSDFileExists(string filename) => System.IO.File.Exists(Path.Combine(this.CURRENT_DIR, filename));

    private void BootChecks()
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new Form1.BootChecksCallback(this.BootChecks));
      }
      else
      {
        if (this.NUSDFileExists("database.xml"))
        {
          Database database = new Database();
          database.LoadDatabaseToStream(Path.Combine(this.CURRENT_DIR, "database.xml"));
          string databaseVersion = database.GetDatabaseVersion();
          this.WriteStatus("Database.xml detected.");
          this.WriteStatus(" - Version: " + databaseVersion);
          this.updateDatabaseToolStripMenuItem.Text = "Update Database";
          this.databaseButton.Text = "  [    ]";
          this.databaseButton.Image = (Image) Resources.arrow_ticker;
          this.databaseWorker.RunWorkerAsync();
        }
        if (this.NUSDFileExists("dsidatabase.xml"))
        {
          Database database = new Database();
          database.LoadDatabaseToStream(Path.Combine(this.CURRENT_DIR, "dsidatabase.xml"));
          string databaseVersion = database.GetDatabaseVersion();
          this.WriteStatus("DSiDatabase.xml detected.");
          this.WriteStatus(" - Version: " + databaseVersion);
          this.updateDatabaseToolStripMenuItem.Text = "Update Database";
          this.databaseButton.Text = "    [  ]";
          this.databaseButton.Image = (Image) Resources.arrow_ticker;
          this.dsiDatabaseWorker.RunWorkerAsync();
        }
        this.RunScriptOrganizer();
        if (!this.NUSDFileExists("proxy.txt"))
          return;
        this.WriteStatus("Proxy settings detected.");
        string[] strArray = System.IO.File.ReadAllLines(Path.Combine(this.CURRENT_DIR, "proxy.txt"));
        this.proxy_url = strArray[0];
        if (strArray.Length > 2)
        {
          this.proxy_usr = strArray[1];
          this.proxy_pwd = strArray[2];
        }
        else
        {
          if (strArray.Length <= 1)
            return;
          this.proxy_usr = strArray[1];
          this.SetAllEnabled(false);
          this.ProxyVerifyBox.Visible = true;
          this.ProxyVerifyBox.Enabled = true;
          this.ProxyPwdBox.Enabled = true;
          this.SaveProxyBtn.Enabled = true;
          this.ProxyVerifyBox.Select();
        }
      }
    }

    private void DoAllDatabaseyStuff(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker worker = sender as BackgroundWorker;
      this.ClearDatabaseStrip();
      this.FillDatabaseStrip(worker);
      this.LoadRegionCodes();
      this.FillDatabaseScripts();
      this.ShowInnerToolTips(false);
    }

    private void DoAllDatabaseyStuff_Completed(object sender, RunWorkerCompletedEventArgs e)
    {
      this.databaseButton.Text = "Database...";
      this.databaseButton.Image = (Image) null;
    }

    private void DoAllDatabaseyStuff_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      if (e.ProgressPercentage == 25)
        this.databaseButton.Text = "  [.   ]";
      else if (e.ProgressPercentage == 50)
        this.databaseButton.Text = "  [..  ]";
      else if (e.ProgressPercentage == 75)
      {
        this.databaseButton.Text = "  [... ]";
      }
      else
      {
        if (e.ProgressPercentage != 100)
          return;
        this.databaseButton.Text = "  [....]";
      }
    }

    private void RunScriptOrganizer() => this.scriptsWorker.RunWorkerAsync();

    private void SetAllEnabled(bool enabled)
    {
      for (int index = 0; index < this.Controls.Count; ++index)
      {
        try
        {
          this.Controls[index].Enabled = enabled;
        }
        catch
        {
        }
      }
    }

    private void extrasMenuButton_Click(object sender, EventArgs e)
    {
      this.extrasStrip.Text = "Showing";
      this.extrasStrip.Show((Control) this.Extrasbtn, 2, 2 + this.Extrasbtn.Height);
      System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
      timer.Interval = 52;
      timer.Tick += new EventHandler(this.contextmenusTimer_Tick);
      timer.Start();
    }

    private void LoadTitleFromTMD()
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "TMD Files|*tmd*";
      openFileDialog.Title = "Open TMD";
      if (openFileDialog.ShowDialog() == DialogResult.Cancel)
        return;
      TMD tmd = new TMD();
      tmd.LoadFile(openFileDialog.FileName);
      this.WriteStatus(string.Format("TMD Loaded ({0} blocks)", (object) tmd.GetNandBlocks()));
      this.titleidbox.Text = tmd.TitleID.ToString("X16");
      this.WriteStatus("Title ID: " + tmd.TitleID.ToString("X16"));
      this.titleversion.Text = tmd.TitleVersion.ToString();
      this.WriteStatus("Version: " + (object) tmd.TitleVersion);
      if (tmd.StartupIOS.ToString("X") != "0")
        this.WriteStatus("Requires: IOS" + (object) int.Parse(tmd.StartupIOS.ToString("X").Substring(7, 2).ToString(), NumberStyles.HexNumber));
      this.WriteStatus("Content Count: " + (object) tmd.NumOfContents);
      for (int index = 0; index < tmd.Contents.Length; ++index)
      {
        this.WriteStatus(string.Format("   Content {0}: {1} ({2} bytes)", (object) index, (object) tmd.Contents[index].ContentID.ToString("X8"), (object) tmd.Contents[index].Size.ToString()));
        this.WriteStatus(string.Format("    - Index: {0}", (object) tmd.Contents[index].Index.ToString()));
        this.WriteStatus(string.Format("    - Type: {0}", (object) tmd.Contents[index].Type.ToString()));
        this.WriteStatus(string.Format("    - Hash: {0}...", (object) this.DisplayBytes(tmd.Contents[index].Hash, string.Empty).Substring(0, 8)));
      }
      this.WriteStatus("TMD information parsed!");
    }

    public void WriteStatus(string Update, Color writecolor)
    {
      if (this.statusbox.InvokeRequired)
      {
        this.Invoke((Delegate) new Form1.WriteStatusCallback(this.WriteStatus), (object) Update, (object) writecolor);
      }
      else
      {
        int textLength1 = this.statusbox.TextLength;
        if (this.statusbox.Text == "")
          this.statusbox.Text = Update;
        else
          this.statusbox.AppendText("\r\n" + Update);
        int textLength2 = this.statusbox.TextLength;
        this.statusbox.Select(textLength1, textLength2 - textLength1);
        this.statusbox.SelectionColor = writecolor;
        this.statusbox.SelectionStart = this.statusbox.TextLength;
        this.statusbox.SelectionLength = 0;
        this.statusbox.ScrollToCaret();
        Console.WriteLine(Update);
      }
    }

    public void WriteStatus(string Update) => this.WriteStatus(Update, this.normalcolor);

    private void ReadIDType(string ttlid)
    {
      if (ttlid.Substring(0, 8) == "00000001")
        this.WriteStatus("ID Type: System Title. BE CAREFUL!", this.warningcolor);
      else if (ttlid.Substring(0, 8) == "00010000" || ttlid.Substring(0, 8) == "00010004")
        this.WriteStatus("ID Type: Disc-Based Game. Unlikely NUS Content!");
      else if (ttlid.Substring(0, 8) == "00010001")
        this.WriteStatus("ID Type: Downloaded Channel. Possible NUS Content.");
      else if (ttlid.Substring(0, 8) == "00010002")
        this.WriteStatus("ID Type: System Channel. BE CAREFUL!", this.warningcolor);
      else if (ttlid.Substring(0, 8) == "00010004")
        this.WriteStatus("ID Type: Game Channel. Unlikely NUS Content!");
      else if (ttlid.Substring(0, 8) == "00010005")
        this.WriteStatus("ID Type: Downloaded Game Content. Unlikely NUS Content!");
      else if (ttlid.Substring(0, 8) == "00010008")
        this.WriteStatus("ID Type: 'Hidden' Channel. Unlikely NUS Content!");
      else
        this.WriteStatus("ID Type: Unknown. Unlikely NUS Content!");
    }

    private void DownloadBtn_Click(object sender, EventArgs e)
    {
      if (this.titleidbox.Text == string.Empty)
        this.WriteStatus("Please enter a Title ID!", this.errorcolor);
      else if (!this.packbox.Checked && !this.decryptbox.Checked && !this.keepenccontents.Checked)
      {
        this.WriteStatus("Running with your current settings will produce no output!", this.errorcolor);
        this.WriteStatus(" - To amend this, look below and check an output type.", this.errorcolor);
      }
      else
        this.NUSDownloader.RunWorkerAsync();
    }

    private void SetTextThreadSafe(Control what, string setto) => this.SetPropertyThreadSafe((Component) what, (object) "Name", setto);

    private void SetPropertyThreadSafe(Component what, object setto, string property)
    {
      if (this.InvokeRequired)
      {
        Form1.SetPropertyThreadSafeCallback method = new Form1.SetPropertyThreadSafeCallback(this.SetPropertyThreadSafe);
        try
        {
          this.Invoke((Delegate) method, (object) what, setto, (object) property);
        }
        catch (Exception ex)
        {
        }
      }
      else
        what.GetType().GetProperty(property).SetValue((object) what, setto, (object[]) null);
    }

    private void NUSDownloader_DoWork(object sender, DoWorkEventArgs e)
    {
      Control.CheckForIllegalCrossThreadCalls = false;
      this.WriteStatus("Starting NUS Download. Please be patient!", this.infocolor);
      this.SetEnableforDownload(false);
      this.downloadstartbtn.Text = "Starting NUS Download!";
      WebClient wcReady = this.ConfigureWithProxy(new WebClient());
      NusClient nusClient = new NusClient();
      nusClient.ConfigureNusClient(wcReady);
      nusClient.UseLocalFiles = this.localuse.Checked;
      nusClient.ContinueWithoutTicket = true;
      if (this.serverLbl.Text == "Wii")
        nusClient.SetToWiiServer();
      else if (this.serverLbl.Text == "DSi")
        nusClient.SetToDSiServer();
      nusClient.Debug += new EventHandler<MessageEventArgs>(this.nusClient_Debug);
      nusClient.Progress += new EventHandler<ProgressChangedEventArgs>(this.nusClient_Progress);
      StoreType[] storeTypeArray = new StoreType[3]
      {
        !this.packbox.Checked ? StoreType.Empty : StoreType.WAD,
        !this.decryptbox.Checked ? StoreType.Empty : StoreType.DecryptedContent,
        !this.keepenccontents.Checked ? StoreType.Empty : StoreType.EncryptedContent
      };
      string wadName = !string.IsNullOrEmpty(this.WAD_Saveas_Filename) ? this.WAD_Saveas_Filename : this.wadnamebox.Text;
      try
      {
        Console.Write(this.packbox.Checked);
        nusClient.DownloadTitle(this.titleidbox.Text, this.titleversion.Text, Path.Combine(this.CURRENT_DIR, "titles"), this.pathbox.Checked, wadName, storeTypeArray);
      }
      catch (Exception ex)
      {
        this.WriteStatus("Download failed: \"" + ex.Message + " ):\"", this.errorcolor);
      }
      if (this.iosPatchCheckbox.Checked)
      {
        bool flag = false;
        IosPatcher iosPatcher = new IosPatcher();
        WAD iosWad = new WAD();
        string str1 = wadName.Replace("[v]", nusClient.TitleVersion.ToString());
        if (str1.Contains(Path.DirectorySeparatorChar.ToString()) || str1.Contains(Path.AltDirectorySeparatorChar.ToString()))
          iosWad.LoadFile(str1);
        else
          iosWad.LoadFile(Path.Combine(Path.Combine(Path.Combine(Path.Combine(this.CURRENT_DIR, "titles"), this.titleidbox.Text), nusClient.TitleVersion.ToString()), str1));
        try
        {
          iosPatcher.LoadIOS(ref iosWad);
        }
        catch (Exception ex)
        {
          this.WriteStatus("NUS Download Finished.", this.infocolor);
          return;
        }
        foreach (object checkedItem in this.iosPatchesListBox.CheckedItems)
        {
          if (this.iosPatchesListBox.GetItemCheckState(this.iosPatchesListBox.Items.IndexOf(checkedItem)).ToString() == "Checked")
          {
            switch (checkedItem.ToString())
            {
              case "Trucha bug":
                int num1 = iosPatcher.PatchFakeSigning();
                if (num1 > 0)
                {
                  this.WriteStatus(" - Patched in fake-signing:", this.infocolor);
                  string str2 = num1 <= 1 ? "" : "es";
                  this.WriteStatus(string.Format("     {0} patch{1} applied.", (object) num1, (object) str2));
                  flag = true;
                  continue;
                }
                this.WriteStatus(" - Could not patch fake-signing", this.errorcolor);
                continue;
              case "ES_Identify":
                int num2 = iosPatcher.PatchEsIdentify();
                if (num2 > 0)
                {
                  this.WriteStatus(" - Patched in ES_Identify:", this.infocolor);
                  string str3 = num2 <= 1 ? "" : "es";
                  this.WriteStatus(string.Format("     {0} patch{1} applied.", (object) num2, (object) str3));
                  flag = true;
                  continue;
                }
                this.WriteStatus(" - Could not patch ES_Identify", this.errorcolor);
                continue;
              case "NAND permissions":
                int num3 = iosPatcher.PatchNandPermissions();
                if (num3 > 0)
                {
                  this.WriteStatus(" - Patched in NAND permissions:", this.infocolor);
                  string str4 = num3 <= 1 ? "" : "es";
                  this.WriteStatus(string.Format("     {0} patch{1} applied.", (object) num3, (object) str4));
                  flag = true;
                  continue;
                }
                this.WriteStatus(" - Could not patch NAND permissions", this.errorcolor);
                continue;
              default:
                continue;
            }
          }
        }
        if (flag)
        {
          string str5 = str1.Replace(".wad", ".patched.wad");
          try
          {
            if (str5.Contains(Path.DirectorySeparatorChar.ToString()) || str5.Contains(Path.AltDirectorySeparatorChar.ToString()))
              iosWad.Save(str5);
            else
              iosWad.Save(Path.Combine(Path.Combine(Path.Combine(Path.Combine(this.CURRENT_DIR, "titles"), this.titleidbox.Text), nusClient.TitleVersion.ToString()), str5));
            this.WriteStatus(string.Format("Patched WAD saved as: {0}", (object) Path.GetFileName(str5)), this.infocolor);
          }
          catch (Exception ex)
          {
            this.WriteStatus(string.Format("Couldn't save patched WAD: \"{0}\" :(", (object) ex.Message), this.errorcolor);
          }
        }
      }
      this.WriteStatus("NUS Download Finished.");
    }

    private void nusClient_Progress(object sender, ProgressChangedEventArgs e) => this.dlprogress.Value = e.ProgressPercentage;

    private void nusClient_Debug(object sender, MessageEventArgs e) => this.WriteStatus(e.Message);

    private void NUSDownloader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.WAD_Saveas_Filename = string.Empty;
      this.SetEnableforDownload(true);
      this.downloadstartbtn.Text = "Start NUS Download!";
      this.dlprogress.Value = 0;
      if (!Form1.IsWin7())
        return;
      this.dlprogress.ShowInTaskbar = false;
    }

    private void packbox_CheckedChanged(object sender, EventArgs e)
    {
      if (this.packbox.Checked)
      {
        this.wadnamebox.Enabled = true;
        this.saveaswadbtn.Enabled = true;
        this.UpdatePackedName();
      }
      else
      {
        this.wadnamebox.Enabled = false;
        this.saveaswadbtn.Enabled = false;
        this.wadnamebox.Text = string.Empty;
        if (!this.iosPatchCheckbox.Checked)
          return;
        this.iosPatchCheckbox.Checked = false;
      }
    }

    private void titleidbox_TextChanged(object sender, EventArgs e)
    {
      this.UpdatePackedName();
      this.EnablePatchIOSBox();
    }

    private void titleversion_TextChanged(object sender, EventArgs e) => this.UpdatePackedName();

    private void EnablePatchIOSBox()
    {
      this.iosPatchCheckbox.Enabled = this.TitleIsIOS(this.titleidbox.Text);
      if (this.iosPatchCheckbox.Enabled)
        return;
      this.iosPatchCheckbox.Checked = false;
    }

    private bool TitleIsIOS(string titleid) => titleid.Length == 16 && !(titleid == "0000000100000001") && !(titleid == "0000000100000002") && titleid.Substring(0, 14) == "00000001000000";

    public string DisplayBytes(byte[] bytes, string spacer)
    {
      string str = "";
      for (int index = 0; index < bytes.Length; ++index)
        str = str + bytes[index].ToString("X2") + spacer;
      return str;
    }

    private void DatabaseButton_Click(object sender, EventArgs e)
    {
      this.databaseStrip.Text = "Showing";
      this.databaseStrip.Show((Control) this.databaseButton, 2, 2 + this.databaseButton.Height);
      System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
      timer.Interval = 50;
      timer.Tick += new EventHandler(this.contextmenusTimer_Tick);
      timer.Start();
    }

    private void contextmenusTimer_Tick(object sender, EventArgs e)
    {
      if (this.SystemMenuList.Pressed || this.IOSMenuList.Pressed || this.VCMenuList.Pressed || this.WiiWareMenuList.Pressed || this.RegionCodesList.Pressed || this.scriptsLocalMenuEntry.Pressed || this.scriptsDatabaseToolStripMenuItem.Pressed || this.emulateUpdate.Pressed)
        return;
      if (this.databaseButton.ClientRectangle.Contains(this.databaseButton.PointToClient(Control.MousePosition)) && ((System.Windows.Forms.Timer) sender).Interval != 50)
      {
        this.databaseStrip.Close();
        this.scriptsStrip.Close();
        this.extrasStrip.Close();
        this.DatabaseButton_Click(sender, EventArgs.Empty);
        ((System.Windows.Forms.Timer) sender).Stop();
      }
      if (this.scriptsbutton.ClientRectangle.Contains(this.scriptsbutton.PointToClient(Control.MousePosition)) && ((System.Windows.Forms.Timer) sender).Interval != 51)
      {
        this.databaseStrip.Close();
        this.scriptsStrip.Close();
        this.extrasStrip.Close();
        this.scriptsbutton_Click(sender, EventArgs.Empty);
        ((System.Windows.Forms.Timer) sender).Stop();
      }
      if (this.Extrasbtn.ClientRectangle.Contains(this.Extrasbtn.PointToClient(Control.MousePosition)) && ((System.Windows.Forms.Timer) sender).Interval != 52)
      {
        this.databaseStrip.Close();
        this.scriptsStrip.Close();
        this.extrasStrip.Close();
        this.extrasMenuButton_Click(sender, EventArgs.Empty);
        ((System.Windows.Forms.Timer) sender).Stop();
      }
      if (this.databaseStrip.Visible || this.extrasStrip.Visible || this.scriptsStrip.Visible)
        return;
      ((System.Windows.Forms.Timer) sender).Stop();
    }

    private void ClearDatabaseStrip()
    {
      Control.CheckForIllegalCrossThreadCalls = false;
      object[] objArray = new object[17]
      {
        (object) this.SystemMenuList,
        (object) this.IOSMenuList,
        (object) this.WiiWareMenuList,
        (object) this.VCMenuList,
        (object) this.C64MenuList,
        (object) this.NeoGeoMenuList,
        (object) this.NESMenuList,
        (object) this.SNESMenuList,
        (object) this.N64MenuList,
        (object) this.TurboGrafx16MenuList,
        (object) this.TurboGrafxCDMenuList,
        (object) this.MSXMenuList,
        (object) this.SegaMSMenuList,
        (object) this.GenesisMenuList,
        (object) this.VCArcadeMenuList,
        (object) this.dsiSystemToolStripMenu,
        (object) this.dSiWareToolStripMenu
      };
      foreach (ToolStripMenuItem toolStripMenuItem in objArray)
      {
        if (toolStripMenuItem.Name != "VCMenuList")
          toolStripMenuItem.DropDownItems.Clear();
      }
    }

    private void FillDatabaseStrip(BackgroundWorker worker)
    {
      this.SetPropertyThreadSafe((Component) this.SystemMenuList, (object) false, "Visible");
      this.SetPropertyThreadSafe((Component) this.IOSMenuList, (object) false, "Visible");
      this.SetPropertyThreadSafe((Component) this.VCMenuList, (object) false, "Visible");
      this.SetPropertyThreadSafe((Component) this.WiiWareMenuList, (object) false, "Visible");
      this.SetPropertyThreadSafe((Component) this.systemFakeMenuItem, (object) true, "Visible");
      this.SetPropertyThreadSafe((Component) this.iosFakeMenuItem, (object) true, "Visible");
      this.SetPropertyThreadSafe((Component) this.vcFakeMenuItem, (object) true, "Visible");
      this.SetPropertyThreadSafe((Component) this.wwFakeMenuItem, (object) true, "Visible");
      Database database = new Database();
      database.LoadDatabaseToStream(Path.Combine(this.CURRENT_DIR, "database.xml"));
      ToolStripMenuItem[] toolStripMenuItemArray1 = database.LoadSystemTitles();
      for (int index1 = 0; index1 < toolStripMenuItemArray1.Length; ++index1)
      {
        toolStripMenuItemArray1[index1].DropDownItemClicked += new ToolStripItemClickedEventHandler(this.DatabaseItem_Clicked);
        for (int index2 = 0; index2 < toolStripMenuItemArray1[index1].DropDownItems.Count; ++index2)
        {
          ToolStripMenuItem dropDownItem = (ToolStripMenuItem) toolStripMenuItemArray1[index1].DropDownItems[index2];
          if (dropDownItem.DropDownItems.Count > 0)
            dropDownItem.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.DatabaseItem_Clicked);
        }
      }
      Array.Sort<ToolStripMenuItem>(toolStripMenuItemArray1, (Comparison<ToolStripMenuItem>) ((tsmi1, tsmi2) => tsmi1.Text.Substring(18, tsmi1.Text.Length - 19).CompareTo(tsmi2.Text.Substring(18, tsmi2.Text.Length - 19))));
      this.AddToolStripItemToStrip(this.SystemMenuList, toolStripMenuItemArray1);
      this.SetPropertyThreadSafe((Component) this.systemFakeMenuItem, (object) false, "Visible");
      this.SetPropertyThreadSafe((Component) this.SystemMenuList, (object) true, "Visible");
      worker.ReportProgress(25);
      ToolStripMenuItem[] additionitems = database.LoadIosTitles();
      for (int index = 0; index < additionitems.Length; ++index)
        additionitems[index].DropDownItemClicked += new ToolStripItemClickedEventHandler(this.DatabaseItem_Clicked);
      this.AddToolStripItemToStrip(this.IOSMenuList, additionitems);
      this.SetPropertyThreadSafe((Component) this.iosFakeMenuItem, (object) false, "Visible");
      this.SetPropertyThreadSafe((Component) this.IOSMenuList, (object) true, "Visible");
      worker.ReportProgress(50);
      ToolStripMenuItem[][] toolStripMenuItemArray2 = database.LoadVirtualConsoleTitles();
      for (int index3 = 0; index3 < toolStripMenuItemArray2.Length; ++index3)
      {
        for (int index4 = 0; index4 < toolStripMenuItemArray2[index3].Length; ++index4)
        {
          toolStripMenuItemArray2[index3][index4].DropDownItemClicked += new ToolStripItemClickedEventHandler(this.DatabaseItem_Clicked);
          for (int index5 = 0; index5 < toolStripMenuItemArray2[index3][index4].DropDownItems.Count; ++index5)
            ((ToolStripDropDownItem) toolStripMenuItemArray2[index3][index4].DropDownItems[index5]).DropDownItemClicked += new ToolStripItemClickedEventHandler(this.DatabaseItem_Clicked);
        }
        Array.Sort<ToolStripMenuItem>(toolStripMenuItemArray2[index3], (Comparison<ToolStripMenuItem>) ((tsmi1, tsmi2) => tsmi1.Text.Substring(18, tsmi1.Text.Length - 19).CompareTo(tsmi2.Text.Substring(18, tsmi2.Text.Length - 19))));
        this.AddToolStripItemToStrip((ToolStripMenuItem) this.VCMenuList.DropDownItems[index3], toolStripMenuItemArray2[index3]);
      }
      this.SetPropertyThreadSafe((Component) this.vcFakeMenuItem, (object) false, "Visible");
      this.SetPropertyThreadSafe((Component) this.VCMenuList, (object) true, "Visible");
      worker.ReportProgress(75);
      ToolStripMenuItem[] toolStripMenuItemArray3 = database.LoadWiiWareTitles();
      for (int index6 = 0; index6 < toolStripMenuItemArray3.Length; ++index6)
      {
        toolStripMenuItemArray3[index6].DropDownItemClicked += new ToolStripItemClickedEventHandler(this.DatabaseItem_Clicked);
        for (int index7 = 0; index7 < toolStripMenuItemArray3[index6].DropDownItems.Count; ++index7)
        {
          ToolStripMenuItem dropDownItem = (ToolStripMenuItem) toolStripMenuItemArray3[index6].DropDownItems[index7];
          if (dropDownItem.DropDownItems.Count > 0)
            dropDownItem.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.DatabaseItem_Clicked);
        }
      }
      Array.Sort<ToolStripMenuItem>(toolStripMenuItemArray3, (Comparison<ToolStripMenuItem>) ((tsmi1, tsmi2) => tsmi1.Text.Substring(18, tsmi1.Text.Length - 19).CompareTo(tsmi2.Text.Substring(18, tsmi2.Text.Length - 19))));
      this.AddToolStripItemToStrip(this.WiiWareMenuList, toolStripMenuItemArray3);
      this.SetPropertyThreadSafe((Component) this.wwFakeMenuItem, (object) false, "Visible");
      this.SetPropertyThreadSafe((Component) this.WiiWareMenuList, (object) true, "Visible");
      worker.ReportProgress(100);
    }

    private void FillDSiDatabaseStrip(BackgroundWorker worker)
    {
      this.SetPropertyThreadSafe((Component) this.dsiSystemToolStripMenu, (object) false, "Visible");
      this.SetPropertyThreadSafe((Component) this.dSiWareToolStripMenu, (object) false, "Visible");
      this.SetPropertyThreadSafe((Component) this.dsiFakeSystemToolStripMenu, (object) true, "Visible");
      this.SetPropertyThreadSafe((Component) this.dSiWareFakeToolStripMenu, (object) true, "Visible");
      Database database = new Database();
      database.LoadDatabaseToStream(Path.Combine(this.CURRENT_DIR, "dsidatabase.xml"));
      ToolStripMenuItem[] toolStripMenuItemArray1 = database.LoadDSiSystemTitles();
      for (int index1 = 0; index1 < toolStripMenuItemArray1.Length; ++index1)
      {
        toolStripMenuItemArray1[index1].DropDownItemClicked += new ToolStripItemClickedEventHandler(this.DatabaseItem_Clicked);
        for (int index2 = 0; index2 < toolStripMenuItemArray1[index1].DropDownItems.Count; ++index2)
        {
          ToolStripMenuItem dropDownItem = (ToolStripMenuItem) toolStripMenuItemArray1[index1].DropDownItems[index2];
          if (dropDownItem.DropDownItems.Count > 0)
            dropDownItem.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.DatabaseItem_Clicked);
        }
      }
      Array.Sort<ToolStripMenuItem>(toolStripMenuItemArray1, (Comparison<ToolStripMenuItem>) ((tsmi1, tsmi2) => tsmi1.Text.Substring(18, tsmi1.Text.Length - 19).CompareTo(tsmi2.Text.Substring(18, tsmi2.Text.Length - 19))));
      this.AddToolStripItemToStrip(this.dsiSystemToolStripMenu, toolStripMenuItemArray1);
      this.SetPropertyThreadSafe((Component) this.dsiFakeSystemToolStripMenu, (object) false, "Visible");
      this.SetPropertyThreadSafe((Component) this.dsiSystemToolStripMenu, (object) true, "Visible");
      worker.ReportProgress(50);
      ToolStripMenuItem[] toolStripMenuItemArray2 = database.LoadDsiWareTitles();
      for (int index3 = 0; index3 < toolStripMenuItemArray2.Length; ++index3)
      {
        toolStripMenuItemArray2[index3].DropDownItemClicked += new ToolStripItemClickedEventHandler(this.DatabaseItem_Clicked);
        for (int index4 = 0; index4 < toolStripMenuItemArray2[index3].DropDownItems.Count; ++index4)
        {
          ToolStripMenuItem dropDownItem = (ToolStripMenuItem) toolStripMenuItemArray2[index3].DropDownItems[index4];
          if (dropDownItem.DropDownItems.Count > 0)
            dropDownItem.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.DatabaseItem_Clicked);
        }
      }
      Array.Sort<ToolStripMenuItem>(toolStripMenuItemArray2, (Comparison<ToolStripMenuItem>) ((tsmi1, tsmi2) => tsmi1.Text.Substring(18, tsmi1.Text.Length - 19).CompareTo(tsmi2.Text.Substring(18, tsmi2.Text.Length - 19))));
      this.AddToolStripItemToStrip(this.dSiWareToolStripMenu, toolStripMenuItemArray2);
      this.SetPropertyThreadSafe((Component) this.dSiWareFakeToolStripMenu, (object) false, "Visible");
      this.SetPropertyThreadSafe((Component) this.dSiWareToolStripMenu, (object) true, "Visible");
      worker.ReportProgress(100);
    }

    private void AddToolStripItemToStrip(
      ToolStripMenuItem menulist,
      ToolStripMenuItem[] additionitems)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new Form1.AddToolStripItemToStripCallback(this.AddToolStripItemToStrip), (object) menulist, (object) additionitems);
      else
        menulist.DropDownItems.AddRange((ToolStripItem[]) additionitems);
    }

    public string OfficialWADNaming(string titlename)
    {
      titlename = !(titlename == "MIOS") ? (!titlename.Contains("IOS") ? (!titlename.Contains("System Menu") ? (!titlename.Contains("System Menu") ? (!(titlename == "BC") ? (!titlename.Contains("Mii Channel") ? (!titlename.Contains("Shopping Channel") ? (!titlename.Contains("Weather Channel") ? titlename + "-NUS-[v].wad" : "RVL-Weather-[v].wad") : "RVL-Shopping-[v].wad") : "RVL-NigaoeNR-[v].wad") : "RVL-bc-[v].wad") : "RVL-WiiSystemmenu-[v].wad") : "RVL-WiiSystemmenu-[v].wad") : titlename + "-64-[v].wad") : "RVL-mios-[v].wad";
      if (this.wadnamebox.InvokeRequired)
      {
        this.wadnamebox.Invoke((Delegate) new Form1.OfficialWADNamingCallback(this.OfficialWADNaming), (object) titlename);
        return titlename;
      }
      this.wadnamebox.Text = titlename;
      if (this.titleversion.Text != "")
        this.wadnamebox.Text = this.wadnamebox.Text.Replace("[v]", "v" + this.titleversion.Text);
      return titlename;
    }

    public void DatabaseItem_Clicked(object sender, ToolStripItemClickedEventArgs e)
    {
      Regex regex1 = new Regex("[0-9A-Z]*\\s-\\s.*");
      Regex regex2 = new Regex("[0-9A-Z][0-9A-Z] \\(.*\\)");
      Regex regex3 = new Regex("v[0-9]*.*");
      object[] objArray1 = new object[4]
      {
        (object) this.SystemMenuList,
        (object) this.IOSMenuList,
        (object) this.WiiWareMenuList,
        (object) this.VCMenuList
      };
      object[] objArray2 = new object[2]
      {
        (object) this.dsiSystemToolStripMenu,
        (object) this.dSiWareToolStripMenu
      };
      if (regex1.IsMatch(e.ClickedItem.Text))
      {
        string[] strArray = e.ClickedItem.Text.Replace(" - ", "~").Split('~');
        this.titleidbox.Text = strArray[0];
        this.statusbox.Text = string.Format(" --- {0} ---", (object) strArray[1]);
        this.titleversion.Text = string.Empty;
        if (e.ClickedItem.Image == Database.orange || e.ClickedItem.Image == Database.redorange)
        {
          this.WriteStatus("Note: This title has no ticket and cannot be packed/decrypted!");
          this.packbox.Checked = false;
          this.decryptbox.Checked = false;
        }
        if (e.ClickedItem.Image == Database.redgreen || e.ClickedItem.Image == Database.redorange)
          this.WriteStatus("\n" + e.ClickedItem.ToolTipText);
        foreach (ToolStripItem toolStripItem in objArray1)
        {
          if (toolStripItem.Name == e.ClickedItem.OwnerItem.Name)
            this.serverLbl.Text = "Wii";
        }
        foreach (ToolStripItem toolStripItem in objArray2)
        {
          if (toolStripItem.Name == e.ClickedItem.OwnerItem.Name)
            this.serverLbl.Text = "DSi";
        }
      }
      if (regex2.IsMatch(e.ClickedItem.Text))
      {
        string[] strArray = e.ClickedItem.OwnerItem.Text.Replace(" - ", "~").Split('~');
        this.titleidbox.Text = strArray[0];
        this.statusbox.Text = string.Format(" --- {0} ---", (object) strArray[1]);
        this.titleversion.Text = string.Empty;
        this.titleidbox.Text = this.titleidbox.Text.Replace("XX", e.ClickedItem.Text.Substring(0, 2));
        if (e.ClickedItem.OwnerItem.Image == Database.orange || e.ClickedItem.OwnerItem.Image == Database.redorange)
        {
          this.WriteStatus("Note: This title has no ticket and cannot be packed/decrypted!");
          this.packbox.Checked = false;
          this.decryptbox.Checked = false;
        }
        if (e.ClickedItem.OwnerItem.Image == Database.redgreen || e.ClickedItem.OwnerItem.Image == Database.redorange)
          this.WriteStatus("\n" + e.ClickedItem.OwnerItem.ToolTipText);
        foreach (ToolStripItem toolStripItem in objArray1)
        {
          if (toolStripItem.Name == e.ClickedItem.OwnerItem.OwnerItem.Name)
            this.serverLbl.Text = "Wii";
        }
        foreach (ToolStripItem toolStripItem in objArray2)
        {
          if (toolStripItem.Name == e.ClickedItem.OwnerItem.OwnerItem.Name)
            this.serverLbl.Text = "DSi";
        }
      }
      if (!regex3.IsMatch(e.ClickedItem.Text) && !(e.ClickedItem.Text == "Latest Version"))
        return;
      if (regex2.IsMatch(e.ClickedItem.OwnerItem.Text))
      {
        string[] strArray = e.ClickedItem.OwnerItem.OwnerItem.Text.Replace(" - ", "~").Split('~');
        this.titleidbox.Text = strArray[0];
        this.statusbox.Text = string.Format(" --- {0} ---", (object) strArray[1]);
        this.titleidbox.Text = this.titleidbox.Text.Replace("XX", e.ClickedItem.OwnerItem.Text.Substring(0, 2));
      }
      else
      {
        string[] strArray = e.ClickedItem.OwnerItem.Text.Replace(" - ", "~").Split('~');
        this.titleidbox.Text = strArray[0];
        this.statusbox.Text = string.Format(" --- {0} ---", (object) strArray[1]);
      }
      if (e.ClickedItem.Text == "Latest Version")
        this.titleversion.Text = string.Empty;
      else
        this.titleversion.Text = e.ClickedItem.Text.Replace("v", "").Split(' ')[0];
      if (regex2.IsMatch(e.ClickedItem.OwnerItem.Text))
      {
        if (e.ClickedItem.OwnerItem.OwnerItem.Image == Database.orange || e.ClickedItem.OwnerItem.OwnerItem.Image == Database.redorange)
        {
          this.WriteStatus("Note: This title has no ticket and cannot be packed/decrypted!");
          this.packbox.Checked = false;
          this.decryptbox.Checked = false;
        }
        if (e.ClickedItem.OwnerItem.OwnerItem.Image == Database.redgreen || e.ClickedItem.OwnerItem.OwnerItem.Image == Database.redorange)
          this.WriteStatus("\n" + e.ClickedItem.OwnerItem.OwnerItem.ToolTipText);
        foreach (ToolStripItem toolStripItem in objArray1)
        {
          if (toolStripItem.Name == e.ClickedItem.OwnerItem.OwnerItem.OwnerItem.Name)
            this.serverLbl.Text = "Wii";
        }
        foreach (ToolStripItem toolStripItem in objArray2)
        {
          if (toolStripItem.Name == e.ClickedItem.OwnerItem.OwnerItem.OwnerItem.Name)
            this.serverLbl.Text = "DSi";
        }
      }
      else
      {
        if (e.ClickedItem.OwnerItem.Image == Database.orange || e.ClickedItem.OwnerItem.Image == Database.redorange)
        {
          this.WriteStatus("Note: This title has no ticket and cannot be packed/decrypted!");
          this.packbox.Checked = false;
          this.decryptbox.Checked = false;
        }
        if (e.ClickedItem.OwnerItem.Image == Database.redgreen || e.ClickedItem.OwnerItem.Image == Database.redorange)
          this.WriteStatus("\n" + e.ClickedItem.OwnerItem.ToolTipText);
        foreach (ToolStripItem toolStripItem in objArray1)
        {
          if (toolStripItem.Name == e.ClickedItem.OwnerItem.OwnerItem.Name)
            this.serverLbl.Text = "Wii";
        }
        foreach (ToolStripItem toolStripItem in objArray2)
        {
          if (toolStripItem.Name == e.ClickedItem.OwnerItem.OwnerItem.Name)
            this.serverLbl.Text = "DSi";
        }
      }
    }

    private string RegionFromIndex(int index, XmlDocument databasexml)
    {
      XmlNodeList childNodes = databasexml.GetElementsByTagName("REGIONS")[0].ChildNodes;
      for (int i = 0; i < childNodes.Count; ++i)
      {
        if (Convert.ToInt32(childNodes[i].Attributes[0].Value) == index)
          return childNodes[i].InnerText;
      }
      return "XX (Error)";
    }

    private void LoadRegionCodes()
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new Form1.BootChecksCallback(this.LoadRegionCodes));
      }
      else
      {
        this.wiiRegionCodesMenu.DropDownItems.Clear();
        this.dsiRegionCodesMenu.DropDownItems.Clear();
        Database database1 = new Database();
        database1.LoadDatabaseToStream(Path.Combine(this.CURRENT_DIR, "database.xml"));
        foreach (ToolStripItem loadRegionCode in database1.LoadRegionCodes())
          this.wiiRegionCodesMenu.DropDownItems.Add(loadRegionCode.Text);
        Database database2 = new Database();
        database2.LoadDatabaseToStream(Path.Combine(this.CURRENT_DIR, "dsidatabase.xml"));
        foreach (ToolStripItem loadRegionCode in database2.LoadRegionCodes())
          this.dsiRegionCodesMenu.DropDownItems.Add(loadRegionCode.Text);
      }
    }

    private static string RemoveIllegalCharacters(string databasestr)
    {
      foreach (char invalidFileNameChar in Path.GetInvalidFileNameChars())
      {
        if (databasestr.Contains(invalidFileNameChar.ToString()))
          databasestr = databasestr.Replace(invalidFileNameChar, '-');
      }
      return databasestr;
    }

    private void ClearStatusbox(object sender, EventArgs e) => this.statusbox.Text = "";

    private void SetEnableforDownload(bool enabled)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new Form1.SetEnableForDownloadCallback(this.SetEnableforDownload), (object) enabled);
      else if (enabled)
      {
        this.downloadstartbtn.Enabled = this.disabledStorage[0];
        this.titleidbox.Enabled = this.disabledStorage[1];
        this.titleversion.Enabled = this.disabledStorage[2];
        this.Extrasbtn.Enabled = this.disabledStorage[3];
        this.databaseButton.Enabled = this.disabledStorage[4];
        this.packbox.Enabled = this.disabledStorage[5];
        this.localuse.Enabled = this.disabledStorage[6];
        this.saveaswadbtn.Enabled = this.disabledStorage[7];
        this.decryptbox.Enabled = this.disabledStorage[8];
        this.keepenccontents.Enabled = this.disabledStorage[9];
        this.scriptsbutton.Enabled = this.disabledStorage[10];
        this.serverLbl.Enabled = this.disabledStorage[11];
        this.iosPatchCheckbox.Enabled = this.disabledStorage[12];
        this.pathbox.Enabled = this.disabledStorage[13];
      }
      else
      {
        this.disabledStorage[0] = this.downloadstartbtn.Enabled;
        this.disabledStorage[1] = this.titleidbox.Enabled;
        this.disabledStorage[2] = this.titleversion.Enabled;
        this.disabledStorage[3] = this.Extrasbtn.Enabled;
        this.disabledStorage[4] = this.databaseButton.Enabled;
        this.disabledStorage[5] = this.packbox.Enabled;
        this.disabledStorage[6] = this.localuse.Enabled;
        this.disabledStorage[7] = this.saveaswadbtn.Enabled;
        this.disabledStorage[8] = this.decryptbox.Enabled;
        this.disabledStorage[9] = this.keepenccontents.Enabled;
        this.disabledStorage[10] = this.scriptsbutton.Enabled;
        this.disabledStorage[11] = this.serverLbl.Enabled;
        this.disabledStorage[12] = this.iosPatchCheckbox.Enabled;
        this.disabledStorage[13] = this.pathbox.Enabled;
        this.downloadstartbtn.Enabled = enabled;
        this.titleidbox.Enabled = enabled;
        this.titleversion.Enabled = enabled;
        this.Extrasbtn.Enabled = enabled;
        this.databaseButton.Enabled = enabled;
        this.packbox.Enabled = enabled;
        this.localuse.Enabled = enabled;
        this.saveaswadbtn.Enabled = enabled;
        this.decryptbox.Enabled = enabled;
        this.keepenccontents.Enabled = enabled;
        this.scriptsbutton.Enabled = enabled;
        this.serverLbl.Enabled = enabled;
        this.iosPatchCheckbox.Enabled = enabled;
        this.pathbox.Enabled = enabled;
      }
    }

    private void ShowInnerToolTips(bool enabled)
    {
      foreach (ToolStripItem toolStripItem in (ArrangedElementCollection) this.databaseStrip.Items)
      {
        try
        {
          ((ToolStripDropDownItem) toolStripItem).DropDown.ShowItemToolTips = false;
        }
        catch (Exception ex)
        {
        }
      }
      foreach (ToolStripItem toolStripItem in (ArrangedElementCollection) this.scriptsStrip.Items)
      {
        try
        {
          ((ToolStripDropDownItem) toolStripItem).DropDown.ShowItemToolTips = false;
        }
        catch (Exception ex)
        {
        }
      }
    }

    private void UpdatePackedName()
    {
      string str = (string) null;
      if (this.titleidbox.Enabled && this.packbox.Checked)
      {
        if (this.titleversion.Text != "")
          this.wadnamebox.Text = this.titleidbox.Text + "-NUS-v" + this.titleversion.Text + ".wad";
        else
          this.wadnamebox.Text = this.titleidbox.Text + "-NUS-[v]" + this.titleversion.Text + ".wad";
        if (System.IO.File.Exists("database.xml") && this.titleidbox.Text.Length == 16)
          str = this.NameFromDatabase(this.titleidbox.Text);
        if (str != null)
        {
          this.wadnamebox.Text = this.wadnamebox.Text.Replace(this.titleidbox.Text, str);
          this.OfficialWADNaming(str);
        }
      }
      this.wadnamebox.Text = Form1.RemoveIllegalCharacters(this.wadnamebox.Text);
    }

    private static bool IsWin7() => Environment.OSVersion.VersionString.Contains("6.1");

    private byte[] NewIntegertoByteArray(int theInt, int arrayLen)
    {
      byte[] numArray = new byte[arrayLen];
      for (int index = arrayLen - 1; index >= 0; --index)
        numArray[index] = (byte) (theInt >> 8 * index & (int) byte.MaxValue);
      Array.Reverse((Array) numArray);
      if (arrayLen > 4)
      {
        for (int index = 0; index < arrayLen - 4; ++index)
          numArray[index] = (byte) 0;
      }
      return numArray;
    }

    private WebClient ConfigureWithProxy(WebClient client)
    {
      if (!string.IsNullOrEmpty(this.proxy_url))
      {
        WebProxy webProxy = new WebProxy();
        webProxy.Address = new Uri(this.proxy_url);
        if (string.IsNullOrEmpty(this.proxy_usr))
        {
          webProxy.UseDefaultCredentials = true;
        }
        else
        {
          NetworkCredential networkCredential = new NetworkCredential();
          networkCredential.UserName = this.proxy_usr;
          if (!string.IsNullOrEmpty(this.proxy_pwd))
            networkCredential.Password = this.proxy_pwd;
          webProxy.Credentials = (ICredentials) networkCredential;
        }
        client.Proxy = (IWebProxy) webProxy;
        this.WriteStatus("  - Custom proxy settings applied!");
      }
      else
      {
        try
        {
          client.Proxy = WebRequest.GetSystemWebProxy();
          client.UseDefaultCredentials = true;
        }
        catch (NotImplementedException ex)
        {
          this.WriteStatus("This operating system does not support automatic system proxy usage. Operating without a proxy...");
        }
      }
      return client;
    }

    private void RetrieveNewDatabase(object sender, DoWorkEventArgs e)
    {
      string str1 = Regex.Replace(new WebClient().DownloadString(e.Argument.ToString() + "?cachesmash=" + DateTime.Now.ToString()), "<(.|\\n)*?>", "");
      string str2 = "&lt;database v";
      string str3 = "&lt;/database&gt;";
      string str4 = str1.Substring(str1.IndexOf(str2), str1.Length - str1.IndexOf(str2));
      string str5 = str4.Substring(0, str4.IndexOf(str3) + str3.Length).Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", '"'.ToString()).Replace("&nbsp;", " ");
      e.Result = (object) str5;
    }

    private void RetrieveNewDatabase_Completed(object sender, RunWorkerCompletedEventArgs e)
    {
      string str1 = e.Result.ToString();
      string str2 = "";
      if (str1.Contains("DSISYSTEM"))
        str2 = "dsidatabase.xml";
      else if (str1.Contains("0000000100000002"))
        str2 = "database.xml";
      try
      {
        Database database = new Database();
        database.LoadDatabaseToStream(Path.Combine(this.CURRENT_DIR, str2));
        string databaseVersion1 = database.GetDatabaseVersion();
        string databaseVersion2 = Database.GetDatabaseVersion(str1);
        this.WriteStatus(string.Format(" - Database successfully parsed! ({0})", (object) str2));
        this.WriteStatus("   - Current Database Version: " + databaseVersion1);
        this.WriteStatus("   - Online Database Version: " + databaseVersion2);
        if (databaseVersion1 == databaseVersion2)
        {
          this.WriteStatus(" - You have the latest database version!");
          return;
        }
      }
      catch (FileNotFoundException ex)
      {
        this.WriteStatus(" - Database does not yet exist.");
        this.WriteStatus("   - Online Database Version: " + Database.GetDatabaseVersion(str1));
      }
      bool flag = false;
      if (System.IO.File.Exists(str2))
      {
        this.WriteStatus(" - Overwriting your current database...");
        this.WriteStatus(string.Format(" - The old database will become 'old{0}' in case the new one is faulty.", (object) str2));
        string contents = System.IO.File.ReadAllText(str2);
        System.IO.File.WriteAllText("old" + str2, contents);
        System.IO.File.Delete(str2);
        System.IO.File.WriteAllText(str2, str1);
      }
      else
      {
        this.WriteStatus(string.Format(" - {0} has been created.", (object) str2));
        System.IO.File.WriteAllText(str2, str1);
        flag = true;
      }
      this.databaseWorker.RunWorkerAsync();
      if (flag)
      {
        this.WriteStatus("Database successfully created!");
        this.databaseButton.Visible = true;
        this.updateDatabaseToolStripMenuItem.Text = "Download Database";
      }
      else
        this.WriteStatus("Database successfully updated!");
    }

    private void updateDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.statusbox.Text = "";
      this.WriteStatus("Updating your databases from Wiibrew/DSibrew");
      string[] strArray = new string[2]
      {
        "http://www.wiibrew.org/wiki/NUS_Downloader/database",
        "http://www.dsibrew.org/wiki/NUS_Downloader/database"
      };
      BackgroundWorker backgroundWorker1 = new BackgroundWorker();
      backgroundWorker1.DoWork += new DoWorkEventHandler(this.RetrieveNewDatabase);
      backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RetrieveNewDatabase_Completed);
      backgroundWorker1.RunWorkerAsync((object) strArray[0]);
      BackgroundWorker backgroundWorker2 = new BackgroundWorker();
      backgroundWorker2.DoWork += new DoWorkEventHandler(this.RetrieveNewDatabase);
      backgroundWorker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RetrieveNewDatabase_Completed);
      backgroundWorker2.RunWorkerAsync((object) strArray[1]);
    }

    private void loadInfoFromTMDToolStripMenuItem_Click(object sender, EventArgs e) => this.LoadTitleFromTMD();

    public string SendSOAPRequest(string soap_xml)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create("http://nus.shop.wii.com/nus/services/NetUpdateSOAP");
      httpWebRequest.Method = "POST";
      httpWebRequest.UserAgent = "wii libnup/1.0";
      httpWebRequest.Headers.Add("SOAPAction", '"'.ToString() + "urn:nus.wsapi.broadon.com/GetSystemUpdate" + (object) '"');
      if (!string.IsNullOrEmpty(this.proxy_url))
      {
        WebProxy webProxy = new WebProxy();
        webProxy.Address = new Uri(this.proxy_url);
        if (string.IsNullOrEmpty(this.proxy_usr))
        {
          webProxy.UseDefaultCredentials = true;
        }
        else
        {
          NetworkCredential networkCredential = new NetworkCredential();
          networkCredential.UserName = this.proxy_usr;
          if (!string.IsNullOrEmpty(this.proxy_pwd))
            networkCredential.Password = this.proxy_pwd;
          webProxy.Credentials = (ICredentials) networkCredential;
        }
        httpWebRequest.Proxy = (IWebProxy) webProxy;
        this.WriteStatus("  - Custom proxy settings applied!");
      }
      else
      {
        httpWebRequest.Proxy = WebRequest.GetSystemWebProxy();
        httpWebRequest.UseDefaultCredentials = true;
      }
      byte[] bytes = new UTF8Encoding().GetBytes(soap_xml);
      httpWebRequest.ContentType = "text/xml; charset=utf-8";
      httpWebRequest.ContentLength = (long) bytes.Length;
      Stream requestStream = httpWebRequest.GetRequestStream();
      requestStream.Write(bytes, 0, bytes.Length);
      requestStream.Close();
      Application.DoEvents();
      try
      {
        string end;
        using (Stream responseStream = httpWebRequest.GetResponse().GetResponseStream())
        {
          using (StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8))
            end = streamReader.ReadToEnd();
        }
        httpWebRequest.Abort();
        Application.DoEvents();
        return end;
      }
      catch (Exception ex)
      {
        httpWebRequest.Abort();
        this.WriteStatus(" --- An Error Occurred: " + ex.Message.ToString());
        return (string) null;
      }
    }

    private void emulateUpdate_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
      this.statusbox.Text = "";
      this.WriteStatus("Starting Wii System Update...");
      this.scriptsStrip.Close();
      string str1 = "4362227770";
      string str2 = "13198105123219038";
      string str3 = "1";
      string str4 = e.ClickedItem.Text.Substring(0, 3);
      if (str4 == "JAP")
        str4 = "JPN";
      string str5 = str4.Substring(0, 2);
      string soap_xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\n<soapenv:Body>\n<GetSystemUpdateRequest xmlns=\"urn:nus.wsapi.broadon.com\">\n<Version>1.0</Version>\n<MessageId>" + str2 + "</MessageId>\n<DeviceId>" + str1 + "</DeviceId>\n<RegionId>" + str4 + "</RegionId>\n<CountryCode>" + str5 + "</CountryCode>\n<TitleVersion>\n<TitleId>0000000100000001</TitleId>\n<Version>2</Version>\n</TitleVersion>\n<TitleVersion>\n<TitleId>0000000100000002</TitleId>\n<Version>33</Version>\n</TitleVersion>\n<TitleVersion>\n<TitleId>0000000100000009</TitleId>\n<Version>516</Version>\n</TitleVersion>\n<Attribute>" + str3 + "</Attribute>\n<AuditData></AuditData>\n</GetSystemUpdateRequest>\n</soapenv:Body>\n</soapenv:Envelope>";
      this.WriteStatus(" - Sending SOAP Request to NUS...");
      this.WriteStatus("   - Region: " + str4);
      string xml = this.SendSOAPRequest(soap_xml);
      if (xml != null)
      {
        this.WriteStatus("   - Recieved Update Info!");
        this.WriteStatus("   - Title information:");
        string contents = "";
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xml);
        XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("TitleVersion");
        for (int i1 = 0; i1 < elementsByTagName.Count; ++i1)
        {
          XmlNodeList childNodes = elementsByTagName[i1].ChildNodes;
          string titleid = "";
          string str6 = "";
          for (int i2 = 0; i2 < childNodes.Count; ++i2)
          {
            switch (childNodes[i2].Name)
            {
              case "TitleId":
                titleid = childNodes[i2].InnerText;
                break;
              case "Version":
                str6 = childNodes[i2].InnerText;
                break;
            }
          }
          this.WriteStatus(string.Format("    - {0} [v{1}]", (object) titleid, (object) str6));
          if (this.NUSDFileExists("database.xml") && !string.IsNullOrEmpty(this.NameFromDatabase(titleid)))
            this.WriteStatus(string.Format(" [{0}]", (object) this.NameFromDatabase(titleid)));
          contents += string.Format("{0} {1}\n", (object) titleid, (object) this.DisplayBytes(this.NewIntegertoByteArray(Convert.ToInt32(str6), 2), ""));
        }
        this.WriteStatus(" - Outputting results to NUS script...");
        if (!Directory.Exists(Path.Combine(this.CURRENT_DIR, "scripts")))
        {
          Directory.CreateDirectory(Path.Combine(this.CURRENT_DIR, "scripts"));
          this.WriteStatus("  - Created 'scripts' directory.");
        }
        string str7 = Form1.RemoveIllegalCharacters(DateTime.Now.ToShortTimeString());
        System.IO.File.WriteAllText(string.Format(Path.Combine(this.CURRENT_DIR, Path.Combine("scripts", "{0}_Update_{1}_{2}_{3} at {4}.nus")), (object) str4, (object) DateTime.Now.Month, (object) DateTime.Now.Day, (object) DateTime.Now.Year, (object) str7), contents);
        this.WriteStatus(" - Script written!");
        this.scriptsLocalMenuEntry.Enabled = false;
        this.scriptsWorker.RunWorkerAsync();
        this.WriteStatus(" - Run this script if you feel like downloading the update!");
      }
      else
        this.WriteStatus("   - Fail.");
    }

    private string NameFromDatabase(string titleid)
    {
      if (titleid == "0000000100000101")
        return "MIOS";
      if (titleid == "0000000100000100")
        return "BC";
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load("database.xml");
      string[] strArray = new string[4]
      {
        "SYS",
        "IOS",
        "VC",
        "WW"
      };
      foreach (string name in strArray)
      {
        XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(name);
        for (int i1 = 0; i1 < elementsByTagName.Count; ++i1)
        {
          bool flag = false;
          XmlNodeList childNodes = elementsByTagName[i1].ChildNodes;
          for (int i2 = 0; i2 < childNodes.Count; ++i2)
          {
            switch (childNodes[i2].Name)
            {
              case "titleID":
                flag = childNodes[i2].InnerText == titleid || childNodes[i2].InnerText.Substring(0, 14) + "XX" == titleid.Substring(0, 14) + "XX" && titleid.Substring(0, 14) != "00000001000000";
                break;
            }
          }
          if (flag)
          {
            for (int i3 = 0; i3 < childNodes.Count; ++i3)
            {
              switch (childNodes[i3].Name)
              {
                case "name":
                  return childNodes[i3].InnerText;
                default:
                  continue;
              }
            }
          }
        }
      }
      return (string) null;
    }

    private void packbox_EnabledChanged(object sender, EventArgs e) => this.saveaswadbtn.Enabled = this.packbox.Enabled;

    private void SaveProxyBtn_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.ProxyURL.Text) && string.IsNullOrEmpty(this.ProxyUser.Text) && System.IO.File.Exists(Path.Combine(this.CURRENT_DIR, "proxy.txt")))
      {
        System.IO.File.Delete(Path.Combine(this.CURRENT_DIR, "proxy.txt"));
        this.proxyBox.Visible = false;
        this.proxy_usr = "";
        this.proxy_url = "";
        this.proxy_pwd = "";
        this.WriteStatus("Proxy settings deleted!");
      }
      else if (string.IsNullOrEmpty(this.ProxyURL.Text) && string.IsNullOrEmpty(this.ProxyUser.Text) && !System.IO.File.Exists(Path.Combine(this.CURRENT_DIR, "proxy.txt")))
      {
        this.proxyBox.Visible = false;
        this.WriteStatus("No proxy settings saved!");
      }
      else
      {
        string contents = "";
        if (!string.IsNullOrEmpty(this.ProxyURL.Text))
        {
          contents = contents + this.ProxyURL.Text + "\n";
          this.proxy_url = this.ProxyURL.Text;
        }
        if (!string.IsNullOrEmpty(this.ProxyUser.Text))
        {
          contents += this.ProxyUser.Text;
          this.proxy_usr = this.ProxyUser.Text;
        }
        if (!string.IsNullOrEmpty(contents))
        {
          System.IO.File.WriteAllText(Path.Combine(this.CURRENT_DIR, "proxy.txt"), contents);
          this.WriteStatus("Proxy settings saved!");
        }
        this.proxyBox.Visible = false;
        this.SetAllEnabled(false);
        this.ProxyVerifyBox.Visible = true;
        this.ProxyVerifyBox.Enabled = true;
        this.ProxyPwdBox.Enabled = true;
        this.SaveProxyBtn.Enabled = true;
        this.ProxyVerifyBox.Select();
      }
    }

    private void proxySettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (System.IO.File.Exists(Path.Combine(this.CURRENT_DIR, "proxy.txt")))
      {
        string[] strArray = System.IO.File.ReadAllLines(Path.Combine(this.CURRENT_DIR, "proxy.txt"));
        this.ProxyURL.Text = strArray[0];
        if (strArray.Length > 1)
          this.ProxyUser.Text = strArray[1];
      }
      this.proxyBox.Visible = true;
    }

    private void SaveProxyPwdButton_Click(object sender, EventArgs e)
    {
      this.proxy_pwd = this.ProxyPwdBox.Text;
      this.ProxyVerifyBox.Visible = false;
      this.SetAllEnabled(true);
    }

    private void ProxyPwdBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ((int) e.KeyChar != (int) Convert.ToChar((object) Keys.Return))
        return;
      this.SaveProxyPwdButton_Click((object) "LOLWUT", EventArgs.Empty);
    }

    private void ProxyAssistBtn_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("If you are behind a proxy, set these settings to get through to NUS. If you have an alternate port for accessing your proxy, add ':' followed by the port.");
    }

    private void loadNUSScriptToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Multiselect = false;
      openFileDialog.Filter = "NUS Scripts|*.nus|All Files|*.*";
      if (Directory.Exists(Path.Combine(this.CURRENT_DIR, "scripts")))
        openFileDialog.InitialDirectory = Path.Combine(this.CURRENT_DIR, "scripts");
      openFileDialog.Title = "Load a NUS/Wiimpersonator script.";
      if (openFileDialog.ShowDialog() == DialogResult.Cancel)
        return;
      string str1 = System.IO.File.ReadAllText(openFileDialog.FileName);
      FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
      string str2 = str1 + string.Format(";{0}", (object) fileInfo.Name.Replace("." + fileInfo.Extension, ""));
      BackgroundWorker backgroundWorker = new BackgroundWorker();
      backgroundWorker.DoWork += new DoWorkEventHandler(this.RunScriptBg);
      backgroundWorker.RunWorkerAsync((object) str2);
    }

    private void RunScriptBg(object sender, DoWorkEventArgs e)
    {
      char ch = ';';
      string[] strArray = e.Argument.ToString().Split(ch);
      if (strArray.Length < 2)
        this.RunScript(strArray[0], "random");
      else
        this.RunScript(strArray[0], Form1.RemoveIllegalCharacters(strArray[1]));
    }

    private void scriptsbutton_Click(object sender, EventArgs e)
    {
      this.scriptsStrip.Text = "Showing";
      this.scriptsStrip.Show((Control) this.scriptsbutton, 2, 2 + this.scriptsbutton.Height);
      System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
      timer.Interval = 51;
      timer.Tick += new EventHandler(this.contextmenusTimer_Tick);
      timer.Start();
    }

    private void DatabaseEnabled(bool enabled)
    {
      for (int index = 0; index < this.databaseStrip.Items.Count; ++index)
      {
        this.databaseStrip.Items[index].Enabled = enabled;
        this.databaseStrip.Items[index].Visible = enabled;
      }
      for (int index = 0; index < this.VCMenuList.DropDownItems.Count; ++index)
      {
        this.VCMenuList.DropDownItems[index].Enabled = true;
        this.VCMenuList.DropDownItems[index].Visible = true;
      }
    }

    private void scriptsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) => this.scriptsLocalMenuEntry.Enabled = true;

    private void OrganizeScripts(object sender, DoWorkEventArgs e)
    {
      if (!Directory.Exists(Path.Combine(this.CURRENT_DIR, "scripts")))
      {
        this.WriteStatus("Scripts directory not found...");
        this.WriteStatus("- Creating it.");
        Directory.CreateDirectory(Path.Combine(this.CURRENT_DIR, "scripts"));
      }
      if (this.scriptsLocalMenuEntry.DropDownItems.Count > 0)
      {
        Control.CheckForIllegalCrossThreadCalls = false;
        this.scriptsLocalMenuEntry.DropDownItems.Clear();
      }
      foreach (string directory in Directory.GetDirectories(Path.Combine(this.CURRENT_DIR, "scripts"), "*", SearchOption.TopDirectoryOnly))
      {
        if (Directory.GetFiles(directory, "*.nus", SearchOption.TopDirectoryOnly).Length > 0)
        {
          DirectoryInfo directoryInfo = new DirectoryInfo(directory);
          ToolStripMenuItem toolStripMenuItem1 = new ToolStripMenuItem();
          toolStripMenuItem1.Text = directoryInfo.Name + (object) Path.DirectorySeparatorChar;
          toolStripMenuItem1.Image = (Image) Resources.folder_table;
          foreach (string file in Directory.GetFiles(directory, "*.nus", SearchOption.TopDirectoryOnly))
          {
            FileInfo fileInfo = new FileInfo(file);
            ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem2.Text = fileInfo.Name;
            toolStripMenuItem2.Image = (Image) Resources.script_start;
            toolStripMenuItem1.DropDownItems.Add((ToolStripItem) toolStripMenuItem2);
            toolStripMenuItem2.Click += new EventHandler(this.nus_script_item_Click);
          }
          this.scriptsLocalMenuEntry.DropDownItems.Add((ToolStripItem) toolStripMenuItem1);
        }
      }
      foreach (string file in Directory.GetFiles(Path.Combine(this.CURRENT_DIR, "scripts"), "*.nus", SearchOption.TopDirectoryOnly))
      {
        FileInfo fileInfo = new FileInfo(file);
        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
        toolStripMenuItem.Text = fileInfo.Name;
        toolStripMenuItem.Image = (Image) Resources.script_start;
        this.scriptsLocalMenuEntry.DropDownItems.Add((ToolStripItem) toolStripMenuItem);
        toolStripMenuItem.Click += new EventHandler(this.nus_script_item_Click);
      }
    }

    private void aboutNUSDToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.statusbox.Text = "";
      this.WriteStatus("NUS Downloader (NUSD)");
      this.WriteStatus("You are running version: " + this.version);
      if (this.version.StartsWith("SVN"))
        this.WriteStatus("SVN BUILD: DO NOT REPORT BROKEN FEATURES!");
      this.WriteStatus("This application created by WB3000");
      this.WriteStatus("Various contributions by lukegb");
      this.WriteStatus(string.Empty);
      if (this.NUSDFileExists("key.bin"))
        this.WriteStatus("Wii Decryption: Local (key.bin)");
      if (this.NUSDFileExists("kkey.bin"))
        this.WriteStatus("Wii Korea Decryption: Local (kkey.bin)");
      if (this.NUSDFileExists("dsikey.bin"))
        this.WriteStatus("DSi Decryption: Local (dsikey.bin)");
      if (!this.NUSDFileExists("database.xml"))
        this.WriteStatus("Database (Wii): Need (database.xml)");
      else
        this.WriteStatus("Database (Wii): OK");
      if (!this.NUSDFileExists("dsidatabase.xml"))
        this.WriteStatus("Database (DSi): Need (dsidatabase.xml)");
      else
        this.WriteStatus("Database (DSi): OK");
      if (Form1.IsWin7())
        this.WriteStatus("Windows 7 Features: Enabled");
      this.WriteStatus("");
      this.WriteStatus("Special thanks to:");
      this.WriteStatus(" * Crediar for his wadmaker tool + source, and for the advice!");
      this.WriteStatus(" * Leathl for libWiiSharp.");
      this.WriteStatus(" * SquidMan/Galaxy/comex/Xuzz/#WiiDev for advice.");
      this.WriteStatus(" * Pasta for impressive database contributions.");
      this.WriteStatus(" * Napo7 for testing proxy settings.");
      this.WriteStatus(" * Wyatt O'Day for the Windows7ProgressBar Control.");
      this.WriteStatus(" * Famfamfam for the Silk Icon Set.");
      this.WriteStatus(" * Anyone who has helped beta test!");
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e) => this.SaveProxyPwdPermanentBtn.Enabled = this.checkBox1.Checked;

    private void SaveProxyPwdPermanentBtn_Click(object sender, EventArgs e)
    {
      this.proxy_pwd = this.ProxyPwdBox.Text;
      string contents = System.IO.File.ReadAllText(Path.Combine(this.CURRENT_DIR, "proxy.txt")) + string.Format("\n{0}", (object) this.proxy_pwd);
      System.IO.File.WriteAllText(Path.Combine(this.CURRENT_DIR, "proxy.txt"), contents);
      this.ProxyVerifyBox.Visible = false;
      this.SetAllEnabled(true);
      this.WriteStatus("To delete all traces of proxy settings, delete the proxy.txt file!");
    }

    private void clearButton_MouseEnter(object sender, EventArgs e) => this.clearButton.Text = "Clear";

    private void clearButton_MouseLeave(object sender, EventArgs e)
    {
      if (System.Type.GetType("Mono.Runtime") != null)
        return;
      this.clearButton.Text = string.Empty;
    }

    private void saveaswadbtn_MouseEnter(object sender, EventArgs e) => this.saveaswadbtn.Text = "Save As";

    private void saveaswadbtn_MouseLeave(object sender, EventArgs e)
    {
      if (System.Type.GetType("Mono.Runtime") != null)
        return;
      this.saveaswadbtn.Text = string.Empty;
    }

    private void nus_script_item_Click(object sender, EventArgs e)
    {
      ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem) sender;
      string str1 = "";
      if (!toolStripMenuItem.OwnerItem.Equals((object) this.scriptsLocalMenuEntry))
        str1 = Path.Combine(toolStripMenuItem.OwnerItem.Text, str1);
      string str2 = System.IO.File.ReadAllText(Path.Combine(this.CURRENT_DIR, Path.Combine("scripts", Path.Combine(str1, toolStripMenuItem.Text)))) + string.Format(";{0}", (object) toolStripMenuItem.Text.Replace(".nus", ""));
      BackgroundWorker backgroundWorker = new BackgroundWorker();
      backgroundWorker.DoWork += new DoWorkEventHandler(this.RunScriptBg);
      backgroundWorker.RunWorkerAsync((object) str2);
    }

    private void saveaswadbtn_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Title = "Save WAD File...";
      saveFileDialog.Filter = "WAD Files|*.wad|All Files|*.*";
      saveFileDialog.AddExtension = true;
      if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
        return;
      this.WAD_Saveas_Filename = saveFileDialog.FileName;
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e) => Environment.Exit(0);

    private void iosPatchCheckbox_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.iosPatchCheckbox.Checked)
        return;
      this.packbox.Checked = true;
      this.SetAllEnabled(false);
      this.iosPatchGroupBox.Visible = true;
      this.iosPatchGroupBox.Enabled = true;
      this.iosPatchesListBox.Enabled = true;
      this.iosPatchGroupBoxOKbtn.Enabled = true;
    }

    private void iosPatchGroupBoxOKbtn_Click(object sender, EventArgs e)
    {
      this.SetAllEnabled(true);
      this.iosPatchGroupBox.Visible = false;
      if (this.iosPatchesListBox.CheckedIndices.Count != 0)
        return;
      this.iosPatchCheckbox.Checked = false;
    }

    private void FillDatabaseScripts()
    {
      this.SetPropertyThreadSafe((Component) this.scriptsDatabaseToolStripMenuItem, (object) false, "Visible");
      Database database = new Database();
      database.LoadDatabaseToStream(Path.Combine(this.CURRENT_DIR, "database.xml"));
      ToolStripMenuItem[] additionitems = database.LoadScripts();
      for (int index = 0; index < additionitems.Length; ++index)
        additionitems[index].Click += new EventHandler(this.ScriptItem_Clicked);
      this.AddToolStripItemToStrip(this.scriptsDatabaseToolStripMenuItem, additionitems);
      this.SetPropertyThreadSafe((Component) this.scriptsDatabaseToolStripMenuItem, (object) true, "Enabled");
      this.SetPropertyThreadSafe((Component) this.scriptsDatabaseToolStripMenuItem, (object) true, "Visible");
    }

    public void ScriptItem_Clicked(object sender, EventArgs e)
    {
      ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem) sender;
      string str = toolStripMenuItem.ToolTipText + string.Format(";{0}", (object) toolStripMenuItem.Text);
      BackgroundWorker backgroundWorker = new BackgroundWorker();
      backgroundWorker.DoWork += new DoWorkEventHandler(this.RunScriptBg);
      backgroundWorker.RunWorkerAsync((object) str);
    }

    private void ReorganizePreviousFolderStructure(object sender, DoWorkEventArgs e)
    {
      Regex regex = new Regex("[a-zA-Z0-9]{16}v?([0-9]*)?");
      if (!Directory.Exists(Path.Combine(this.CURRENT_DIR, "titles")))
        Directory.CreateDirectory(Path.Combine(this.CURRENT_DIR, "titles"));
      foreach (string directory in Directory.GetDirectories(this.CURRENT_DIR, "*", SearchOption.TopDirectoryOnly))
      {
        DirectoryInfo directoryInfo = new DirectoryInfo(directory);
        if (regex.IsMatch(directoryInfo.Name.ToString()) && directoryInfo.Name.Contains("v"))
        {
          string[] strArray = directoryInfo.Name.Split('v');
          this.WriteStatus("Bitte einen Text eingeben: ");
          string str1 = Path.Combine(Path.Combine(this.CURRENT_DIR, "titles"), strArray[0]);
          string str2 = Path.Combine(str1, string.Format("{0}", (object) strArray[1]));
          if (!Directory.Exists(str1))
            Directory.CreateDirectory(str1);
          if (!Directory.Exists(str2))
            Directory.CreateDirectory(str2);
          foreach (string file in Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly))
          {
            FileInfo fileInfo = new FileInfo(file);
            if (!System.IO.File.Exists(Path.Combine(str2, fileInfo.Name)))
              fileInfo.MoveTo(Path.Combine(str2, fileInfo.Name));
          }
          if (directoryInfo.GetFiles().Length <= 0 && directoryInfo.GetDirectories().Length <= 0)
            Directory.Delete(directory);
        }
        else if (regex.IsMatch(directoryInfo.Name.ToString()))
        {
          string str3 = Path.Combine(Path.Combine(this.CURRENT_DIR, "titles"), directoryInfo.Name.ToString());
          TMD tmd = new TMD();
          int num = 0;
          string[] files = Directory.GetFiles(directory, "*tmd*", SearchOption.TopDirectoryOnly);
          if (files.Length <= 1)
          {
            foreach (string pathToTmd in files)
            {
              if (pathToTmd.Contains("tmd"))
              {
                tmd.LoadFile(pathToTmd);
                ++num;
              }
            }
            if (num != 0)
            {
              string str4 = tmd.TitleVersion.ToString();
              string str5 = Path.Combine(str3, string.Format("{0}", (object) str4));
              if (!Directory.Exists(str3))
                Directory.CreateDirectory(str3);
              if (!Directory.Exists(str5))
                Directory.CreateDirectory(str5);
              foreach (string file in Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly))
              {
                FileInfo fileInfo = new FileInfo(file);
                if (!System.IO.File.Exists(Path.Combine(str5, fileInfo.Name)))
                  fileInfo.MoveTo(Path.Combine(str5, fileInfo.Name));
              }
              if (directoryInfo.GetFiles().Length <= 0 && directoryInfo.GetDirectories().Length <= 0)
                Directory.Delete(directory);
            }
          }
        }
      }
    }

    private void ReorganizePreviousFolderStructure_Completed(
      object sender,
      RunWorkerCompletedEventArgs e)
    {
      this.WriteStatus(" - Operation complete!");
    }

    private void RunScript(string scriptstr, string scriptname)
    {
      this.SetTextThreadSafe((Control) this.statusbox, "");
      this.WriteStatus("Starting script download. Please be patient!");
      string str = !(scriptname == "random") ? Path.Combine(Path.Combine(this.CURRENT_DIR, "scripts"), scriptname + "_output") : Path.Combine(Path.Combine(this.CURRENT_DIR, "scripts"), this.RandomString(7) + "_output");
      if (!System.IO.File.Exists(str))
        Directory.CreateDirectory(str);
      string[] strArray1 = scriptstr.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
      this.WriteStatus(string.Format(" - Script loaded ({0} Titles)", (object) strArray1.Length));
      this.WriteStatus(" - Output: " + str.Replace(this.CURRENT_DIR, ""));
      for (int index = 0; index < strArray1.Length; ++index)
      {
        this.WriteStatus(string.Format("===== Running Download ({0}/{1}) =====", (object) (index + 1), (object) strArray1.Length));
        string[] strArray2 = strArray1[index].Split(' ');
        if (!string.IsNullOrEmpty(strArray2[0]))
        {
          WebClient wcReady = this.ConfigureWithProxy(new WebClient());
          wcReady.Headers.Add("User-Agent", "wii libnup/1.0");
          NusClient nusClient = new NusClient();
          nusClient.ConfigureNusClient(wcReady);
          nusClient.UseLocalFiles = this.localuse.Checked;
          nusClient.ContinueWithoutTicket = true;
          nusClient.Debug += new EventHandler<MessageEventArgs>(this.nusClient_Debug);
          StoreType[] storeTypeArray = new StoreType[1]
          {
            StoreType.All
          };
          int num = int.Parse(strArray2[1], NumberStyles.HexNumber);
          string titlename = this.NameFromDatabase(strArray2[0]);
          string wadName;
          if (titlename != null)
            wadName = this.OfficialWADNaming(titlename);
          else
            wadName = strArray2[0] + "-NUS-v" + (object) num + ".wad";
          nusClient.DownloadTitle(strArray2[0], num.ToString(), str, this.pathbox.Checked, wadName, storeTypeArray);
        }
      }
      this.WriteStatus("Script completed!");
    }

    private string RandomString(int size)
    {
      char[] chArray = new char[size];
      for (int index = 0; index < size; ++index)
        chArray[index] = "abcdefghijklmnopqrstuvwxyz"[this._rng.Next("abcdefghijklmnopqrstuvwxyz".Length)];
      return new string(chArray);
    }

    private void Form1_MouseWheel(object sender, MouseEventArgs e)
    {
      if (!this.SystemMenuList.DropDown.DisplayRectangle.Contains(e.Location) && !this.SystemMenuList.DropDown.Bounds.Contains(e.Location) && !this.WiiWareMenuList.DropDown.DisplayRectangle.Contains(e.Location) && !this.WiiWareMenuList.DropDown.Bounds.Contains(e.Location) && !this.VCMenuList.DropDown.DisplayRectangle.Contains(e.Location) && !this.VCMenuList.DropDown.Bounds.Contains(e.Location) && !this.IOSMenuList.DropDown.DisplayRectangle.Contains(e.Location) && !this.IOSMenuList.DropDown.Bounds.Contains(e.Location))
        return;
      if (e.Delta > 0)
      {
        SendKeys.Send("{UP}");
        SendKeys.Send("{UP}");
        SendKeys.Send("{UP}");
        SendKeys.Send("{UP}");
        SendKeys.Send("{UP}");
      }
      else
      {
        SendKeys.Send("{DOWN}");
        SendKeys.Send("{DOWN}");
        SendKeys.Send("{DOWN}");
        SendKeys.Send("{DOWN}");
        SendKeys.Send("{DOWN}");
      }
    }

    private void openNUSDDirectoryToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(this.CURRENT_DIR);

    private void mainPageToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("http://www.wiibrew.org/wiki/NUS_Downloader");

    private void databasePageToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("http://www.wiibrew.org/wiki/NUS_Downloader/database");

    private void extrasStrip_Opening(object sender, CancelEventArgs e) => this.moreExtrasToolStripMenuItem.Visible = Control.ModifierKeys == Keys.Control;

    private void runFolderFixToolStripMenuItem_Click(object sender, EventArgs e)
    {
      BackgroundWorker backgroundWorker = new BackgroundWorker();
      backgroundWorker.DoWork += new DoWorkEventHandler(this.ReorganizePreviousFolderStructure);
      backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.ReorganizePreviousFolderStructure_Completed);
      this.WriteStatus("Organizing your old folder structure...");
      backgroundWorker.RunWorkerAsync();
    }

    private void removeNUSDFilesFoldersToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("This will delete all the files\folders you have downloaded from NUS! Are you sure you want to do this?", "Wait a second!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
        return;
      if (Directory.Exists(Path.Combine(this.CURRENT_DIR, "titles")))
        Directory.Delete(Path.Combine(this.CURRENT_DIR, "titles"), true);
      if (Directory.Exists(Path.Combine(this.CURRENT_DIR, "scripts")))
        Directory.Delete(Path.Combine(this.CURRENT_DIR, "scripts"), true);
      if (System.IO.File.Exists(Path.Combine(this.CURRENT_DIR, "database.xml")))
        System.IO.File.Delete(Path.Combine(this.CURRENT_DIR, "database.xml"));
      if (System.IO.File.Exists(Path.Combine(this.CURRENT_DIR, "dsidatabase.xml")))
        System.IO.File.Delete(Path.Combine(this.CURRENT_DIR, "dsidatabase.xml"));
      if (System.IO.File.Exists(Path.Combine(this.CURRENT_DIR, "olddatabase.xml")))
        System.IO.File.Delete(Path.Combine(this.CURRENT_DIR, "olddatabase.xml"));
      if (System.IO.File.Exists(Path.Combine(this.CURRENT_DIR, "proxy.txt")))
        System.IO.File.Delete(Path.Combine(this.CURRENT_DIR, "proxy.txt"));
      if (System.IO.File.Exists(Path.Combine(this.CURRENT_DIR, "key.bin")))
        System.IO.File.Delete(Path.Combine(this.CURRENT_DIR, "key.bin"));
      if (System.IO.File.Exists(Path.Combine(this.CURRENT_DIR, "kkey.bin")))
        System.IO.File.Delete(Path.Combine(this.CURRENT_DIR, "kkey.bin"));
      if (!System.IO.File.Exists(Path.Combine(this.CURRENT_DIR, "dsikey.bin")))
        return;
      System.IO.File.Delete(Path.Combine(this.CURRENT_DIR, "dsikey.bin"));
    }

    private void anyStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e) => ((Control) sender).Text = "Hidden";

    private void localTicketInventoryToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.WriteStatus("Adding ticket information to database entries...");
      ToolStripMenuItem[] toolStripMenuItemArray = new ToolStripMenuItem[6]
      {
        this.SystemMenuList,
        this.IOSMenuList,
        this.VCMenuList,
        this.WiiWareMenuList,
        this.dsiSystemToolStripMenu,
        this.dSiWareToolStripMenu
      };
      for (int index1 = 0; index1 < toolStripMenuItemArray.Length; ++index1)
      {
        for (int index2 = 0; index2 < toolStripMenuItemArray[index1].DropDownItems.Count; ++index2)
        {
          if (toolStripMenuItemArray[index1].DropDownItems[index2].Text.Length >= 16)
          {
            string path2 = toolStripMenuItemArray[index1].DropDownItems[index2].Text.Substring(0, 16);
            string path = Path.Combine(Path.Combine(this.CURRENT_DIR, "titles"), path2);
            if (Directory.Exists(path) && Directory.GetFiles(path, "cetk", SearchOption.AllDirectories).Length > 0)
            {
              if (toolStripMenuItemArray[index1].DropDownItems[index2].Image == Database.green)
                toolStripMenuItemArray[index1].DropDownItems[index2].Image = Database.green_blue;
              if (toolStripMenuItemArray[index1].DropDownItems[index2].Image == Database.orange)
                toolStripMenuItemArray[index1].DropDownItems[index2].Image = Database.orange_blue;
              if (toolStripMenuItemArray[index1].DropDownItems[index2].Image == Database.redorange)
                toolStripMenuItemArray[index1].DropDownItems[index2].Image = Database.redorange_blue;
              if (toolStripMenuItemArray[index1].DropDownItems[index2].Image == Database.redgreen)
                toolStripMenuItemArray[index1].DropDownItems[index2].Image = Database.redgreen_blue;
            }
          }
        }
      }
      this.WriteStatus(" - Operation completed!");
    }

    private void donateToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("http://wb3000.atspace.name/donations.html");

    private void DSiDatabaseWork(object sender, DoWorkEventArgs e)
    {
      while (this.databaseWorker.IsBusy)
        Thread.Sleep(1000);
      this.FillDSiDatabaseStrip(sender as BackgroundWorker);
      this.LoadRegionCodes();
      this.ShowInnerToolTips(false);
    }

    private void DSiDatabaseWork_Completed(object sender, RunWorkerCompletedEventArgs e)
    {
      this.databaseButton.Text = "Database...";
      this.databaseButton.Image = (Image) null;
    }

    private void DSiDatabaseWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      if (e.ProgressPercentage == 50)
      {
        this.databaseButton.Text = "    [. ]";
      }
      else
      {
        if (e.ProgressPercentage != 100)
          return;
        this.databaseButton.Text = "    [..]";
      }
    }

    private void wiiRegionCodesMenu_DropDownItemClicked(
      object sender,
      ToolStripItemClickedEventArgs e)
    {
      if (this.titleidbox.Text.Length != 16)
        return;
      this.titleidbox.Text = this.titleidbox.Text.Substring(0, 14) + e.ClickedItem.Text.Substring(0, 2);
    }

    private void dsiRegionCodesMenu_DropDownItemClicked(
      object sender,
      ToolStripItemClickedEventArgs e)
    {
      if (this.titleidbox.Text.Length != 16)
        return;
      this.titleidbox.Text = this.titleidbox.Text.Substring(0, 14) + e.ClickedItem.Text.Substring(0, 2);
    }

    private void serverLbl_MouseEnter(object sender, EventArgs e) => this.serverLbl.Font = new Font(this.serverLbl.Font, FontStyle.Underline);

    private void serverLbl_MouseLeave(object sender, EventArgs e) => this.serverLbl.Font = new Font(this.serverLbl.Font, FontStyle.Regular);

    private void serverLbl_TextChanged(object sender, EventArgs e)
    {
      if (this.serverLbl.Text == "Wii")
        this.packbox.Enabled = true;
      if (!(this.serverLbl.Text == "DSi"))
        return;
      this.packbox.Checked = false;
      this.packbox.Enabled = false;
      this.wadnamebox.Enabled = false;
      this.wadnamebox.Text = "";
    }

    private void serverLbl_Click(object sender, EventArgs e)
    {
      string[] strArray = new string[2]{ "Wii", "DSi" };
      for (int index = 0; index < strArray.Length; ++index)
      {
        if (this.serverLbl.Text == strArray[index])
        {
          if (strArray.Length == index + 1)
          {
            this.serverLbl.Text = strArray[0];
            break;
          }
          this.serverLbl.Text = strArray[index + 1];
          break;
        }
      }
    }

    private delegate void AddToolStripItemToStripCallback(
      ToolStripMenuItem menulist,
      ToolStripMenuItem[] additionitems);

    private delegate void WriteStatusCallback(string Update, Color writecolor);

    private delegate void BootChecksCallback();

    private delegate void SetEnableForDownloadCallback(bool enabled);

    private delegate void SetPropertyThreadSafeCallback(
      Component what,
      object setto,
      string property);

    private delegate string OfficialWADNamingCallback(string whut);
  }
}
