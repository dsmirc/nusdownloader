// Decompiled with JetBrains decompiler
// Type: libWiiSharp.U8
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace libWiiSharp
{
  public class U8 : IDisposable
  {
    private const int dataPadding = 32;
    private Headers.HeaderType headerType;
    private object header;
    private U8_Header u8Header = new U8_Header();
    private U8_Node rootNode = new U8_Node();
    private List<U8_Node> u8Nodes = new List<U8_Node>();
    private List<string> stringTable = new List<string>();
    private List<byte[]> data = new List<byte[]>();
    private int iconSize = -1;
    private int bannerSize = -1;
    private int soundSize = -1;
    private bool lz77;
    private bool isDisposed;

    public Headers.HeaderType HeaderType => this.headerType;

    public object Header => this.header;

    public U8_Node RootNode => this.rootNode;

    public List<U8_Node> Nodes => this.u8Nodes;

    public string[] StringTable => this.stringTable.ToArray();

    public byte[][] Data => this.data.ToArray();

    public int NumOfNodes => (int) this.rootNode.SizeOfData - 1;

    public int IconSize => this.iconSize;

    public int BannerSize => this.bannerSize;

    public int SoundSize => this.soundSize;

    public bool Lz77Compress
    {
      get => this.lz77;
      set => this.lz77 = value;
    }

    public U8() => this.rootNode.Type = U8_NodeType.Directory;

    ~U8() => this.Dispose(false);

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposing && !this.isDisposed)
      {
        this.header = (object) null;
        this.u8Header = (U8_Header) null;
        this.rootNode = (U8_Node) null;
        this.u8Nodes.Clear();
        this.u8Nodes = (List<U8_Node>) null;
        this.stringTable.Clear();
        this.stringTable = (List<string>) null;
        this.data.Clear();
        this.data = (List<byte[]>) null;
      }
      this.isDisposed = true;
    }

    public static bool IsU8(string pathToFile) => U8.IsU8(File.ReadAllBytes(pathToFile));

    public static bool IsU8(byte[] file)
    {
      if (Lz77.IsLz77Compressed(file))
      {
        byte[] file1 = new byte[file.Length > 2000 ? 2000 : file.Length];
        for (int index = 0; index < file1.Length; ++index)
          file1[index] = file[index];
        return U8.IsU8(new Lz77().Decompress(file1));
      }
      Headers.HeaderType startIndex = Headers.DetectHeader(file);
      return Shared.Swap(BitConverter.ToUInt32(file, (int) startIndex)) == 1437218861U;
    }

    public static U8 Load(string pathToU8) => U8.Load(File.ReadAllBytes(pathToU8));

    public static U8 Load(byte[] u8File)
    {
      U8 u8 = new U8();
      MemoryStream u8File1 = new MemoryStream(u8File);
      try
      {
        u8.parseU8((Stream) u8File1);
      }
      catch
      {
        u8File1.Dispose();
        throw;
      }
      u8File1.Dispose();
      return u8;
    }

    public static U8 Load(Stream u8File)
    {
      U8 u8 = new U8();
      u8.parseU8(u8File);
      return u8;
    }

    public static U8 FromDirectory(string pathToDirectory)
    {
      U8 u8 = new U8();
      u8.createFromDir(pathToDirectory);
      return u8;
    }

    public void LoadFile(string pathToU8) => this.LoadFile(File.ReadAllBytes(pathToU8));

    public void LoadFile(byte[] u8File)
    {
      MemoryStream u8File1 = new MemoryStream(u8File);
      try
      {
        this.parseU8((Stream) u8File1);
      }
      catch
      {
        u8File1.Dispose();
        throw;
      }
      u8File1.Dispose();
    }

    public void LoadFile(Stream u8File) => this.parseU8(u8File);

    public void CreateFromDirectory(string pathToDirectory) => this.createFromDir(pathToDirectory);

    public void Save(string savePath)
    {
      if (File.Exists(savePath))
        File.Delete(savePath);
      using (FileStream writeStream = new FileStream(savePath, FileMode.Create))
        this.writeToStream((Stream) writeStream);
    }

    public MemoryStream ToMemoryStream()
    {
      MemoryStream writeStream = new MemoryStream();
      try
      {
        this.writeToStream((Stream) writeStream);
      }
      catch
      {
        writeStream.Dispose();
        throw;
      }
      return writeStream;
    }

    public byte[] ToByteArray() => this.ToMemoryStream().ToArray();

    public void Unpack(string saveDir) => this.unpackToDir(saveDir);

    public void Extract(string saveDir) => this.unpackToDir(saveDir);

    public void AddHeaderImet(bool shortImet, params string[] titles)
    {
      if (this.iconSize == -1)
        throw new Exception("icon.bin wasn't found!");
      if (this.bannerSize == -1)
        throw new Exception("banner.bin wasn't found!");
      if (this.soundSize == -1)
        throw new Exception("sound.bin wasn't found!");
      this.header = (object) Headers.IMET.Create(shortImet, this.iconSize, this.bannerSize, this.soundSize, titles);
      this.headerType = shortImet ? Headers.HeaderType.ShortIMET : Headers.HeaderType.IMET;
    }

    public void AddHeaderImd5() => this.headerType = Headers.HeaderType.IMD5;

    public void ReplaceFile(int fileIndex, string pathToNewFile, bool changeFileName = false)
    {
      if (this.u8Nodes[fileIndex].Type == U8_NodeType.Directory)
        throw new Exception("You can't replace a directory with a file!");
      this.data[fileIndex] = File.ReadAllBytes(pathToNewFile);
      if (changeFileName)
        this.stringTable[fileIndex] = Path.GetFileName(pathToNewFile);
      if (this.stringTable[fileIndex].ToLower() == "icon.bin")
        this.iconSize = this.getRealSize(File.ReadAllBytes(pathToNewFile));
      else if (this.stringTable[fileIndex].ToLower() == "banner.bin")
      {
        this.bannerSize = this.getRealSize(File.ReadAllBytes(pathToNewFile));
      }
      else
      {
        if (!(this.stringTable[fileIndex].ToLower() == "sound.bin"))
          return;
        this.soundSize = this.getRealSize(File.ReadAllBytes(pathToNewFile));
      }
    }

    public void ReplaceFile(int fileIndex, byte[] newData)
    {
      if (this.u8Nodes[fileIndex].Type == U8_NodeType.Directory)
        throw new Exception("You can't replace a directory with a file!");
      this.data[fileIndex] = newData;
      if (this.stringTable[fileIndex].ToLower() == "icon.bin")
        this.iconSize = this.getRealSize(newData);
      else if (this.stringTable[fileIndex].ToLower() == "banner.bin")
      {
        this.bannerSize = this.getRealSize(newData);
      }
      else
      {
        if (!(this.stringTable[fileIndex].ToLower() == "sound.bin"))
          return;
        this.soundSize = this.getRealSize(newData);
      }
    }

    public int GetNodeIndex(string fileOrDirName)
    {
      for (int index = 0; index < this.u8Nodes.Count; ++index)
      {
        if (this.stringTable[index].ToLower() == fileOrDirName.ToLower())
          return index;
      }
      return -1;
    }

    public void RenameNode(int index, string newName) => this.stringTable[index] = newName;

    public void RenameNode(string oldName, string newName) => this.stringTable[this.GetNodeIndex(oldName)] = newName;

    public void AddDirectory(string path) => this.addEntry(path, new byte[0]);

    public void AddFile(string path, byte[] data) => this.addEntry(path, data);

    public void RemoveDirectory(string path) => this.removeEntry(path);

    public void RemoveFile(string path) => this.removeEntry(path);

    private void writeToStream(Stream writeStream)
    {
      this.fireDebug("Writing U8 File...");
      this.fireDebug("   Updating Rootnode...");
      this.rootNode.SizeOfData = (uint) (this.u8Nodes.Count + 1);
      MemoryStream writeStream1 = new MemoryStream();
      writeStream1.Seek((long) this.u8Header.OffsetToRootNode + (long) ((this.u8Nodes.Count + 1) * 12), SeekOrigin.Begin);
      this.fireDebug("   Writing String Table... (Offset: 0x{0})", (object) writeStream1.Position.ToString("x8").ToUpper());
      writeStream1.WriteByte((byte) 0);
      int num = (int) writeStream1.Position - 1;
      for (int index = 0; index < this.u8Nodes.Count; ++index)
      {
        this.fireDebug("    -> Entry #{1} of {2}: \"{3}\"... (Offset: 0x{0})", (object) writeStream1.Position.ToString("x8").ToUpper(), (object) (index + 1), (object) this.u8Nodes.Count, (object) this.stringTable[index]);
        this.u8Nodes[index].OffsetToName = (ushort) ((ulong) writeStream1.Position - (ulong) num);
        byte[] bytes = Encoding.ASCII.GetBytes(this.stringTable[index]);
        writeStream1.Write(bytes, 0, bytes.Length);
        writeStream1.WriteByte((byte) 0);
      }
      this.u8Header.HeaderSize = (uint) ((ulong) writeStream1.Position - (ulong) this.u8Header.OffsetToRootNode);
      this.u8Header.OffsetToData = 0U;
      for (int index = 0; index < this.u8Nodes.Count; ++index)
      {
        this.fireProgress((index + 1) * 100 / this.u8Nodes.Count);
        if (this.u8Nodes[index].Type == U8_NodeType.File)
        {
          writeStream1.Seek((long) Shared.AddPadding((int) writeStream1.Position, 32), SeekOrigin.Begin);
          this.fireDebug("   Writing Data #{1} of {2}... (Offset: 0x{0})", (object) writeStream1.Position.ToString("x8").ToUpper(), (object) (index + 1), (object) this.u8Nodes.Count);
          if (this.u8Header.OffsetToData == 0U)
            this.u8Header.OffsetToData = (uint) writeStream1.Position;
          this.u8Nodes[index].OffsetToData = (uint) writeStream1.Position;
          this.u8Nodes[index].SizeOfData = (uint) this.data[index].Length;
          writeStream1.Write(this.data[index], 0, this.data[index].Length);
        }
        else
          this.fireDebug("   Node #{0} of {1} is a Directory...", (object) (index + 1), (object) this.u8Nodes.Count);
      }
      while (writeStream1.Position % 16L != 0L)
        writeStream1.WriteByte((byte) 0);
      writeStream1.Seek(0L, SeekOrigin.Begin);
      this.fireDebug("   Writing Header... (Offset: 0x{0})", (object) writeStream1.Position.ToString("x8").ToUpper());
      this.u8Header.Write((Stream) writeStream1);
      this.fireDebug("   Writing Rootnode... (Offset: 0x{0})", (object) writeStream1.Position.ToString("x8").ToUpper());
      this.rootNode.Write((Stream) writeStream1);
      for (int index = 0; index < this.u8Nodes.Count; ++index)
      {
        this.fireDebug("   Writing Node Entry #{1} of {2}... (Offset: 0x{0})", (object) writeStream1.Position.ToString("x8").ToUpper(), (object) (index + 1), (object) this.u8Nodes.Count);
        this.u8Nodes[index].Write((Stream) writeStream1);
      }
      byte[] numArray = writeStream1.ToArray();
      writeStream1.Dispose();
      if (this.lz77)
      {
        this.fireDebug("   Lz77 Compressing U8 File...");
        numArray = new Lz77().Compress(numArray);
      }
      if (this.headerType == Headers.HeaderType.IMD5)
      {
        this.fireDebug("   Adding IMD5 Header...");
        writeStream.Seek(0L, SeekOrigin.Begin);
        Headers.IMD5.Create(numArray).Write(writeStream);
      }
      else if (this.headerType == Headers.HeaderType.IMET || this.headerType == Headers.HeaderType.ShortIMET)
      {
        this.fireDebug("   Adding IMET Header...");
        ((Headers.IMET) this.header).IconSize = (uint) this.iconSize;
        ((Headers.IMET) this.header).BannerSize = (uint) this.bannerSize;
        ((Headers.IMET) this.header).SoundSize = (uint) this.soundSize;
        writeStream.Seek(0L, SeekOrigin.Begin);
        ((Headers.IMET) this.header).Write(writeStream);
      }
      writeStream.Write(numArray, 0, numArray.Length);
      this.fireDebug("Writing U8 File Finished...");
    }

    private void unpackToDir(string saveDir)
    {
      this.fireDebug("Unpacking U8 File to: {0}", (object) saveDir);
      if (!Directory.Exists(saveDir))
        Directory.CreateDirectory(saveDir);
      string[] strArray = new string[this.u8Nodes.Count];
      strArray[0] = saveDir;
      int[] numArray = new int[this.u8Nodes.Count];
      int index1 = 0;
      for (int index2 = 0; index2 < this.u8Nodes.Count; ++index2)
      {
        this.fireDebug("   Unpacking Entry #{0} of {1}", (object) (index2 + 1), (object) this.u8Nodes.Count);
        this.fireProgress((index2 + 1) * 100 / this.u8Nodes.Count);
        if (this.u8Nodes[index2].Type == U8_NodeType.Directory)
        {
          this.fireDebug("    -> Directory: \"{0}\"", (object) this.stringTable[index2]);
          if ((int) strArray[index1][strArray[index1].Length - 1] != (int) Path.DirectorySeparatorChar)
            strArray[index1] = strArray[index1] + (object) Path.DirectorySeparatorChar;
          Directory.CreateDirectory(strArray[index1] + this.stringTable[index2]);
          strArray[index1 + 1] = strArray[index1] + this.stringTable[index2];
          ++index1;
          numArray[index1] = (int) this.u8Nodes[index2].SizeOfData;
        }
        else
        {
          this.fireDebug("    -> File: \"{0}\"", (object) this.stringTable[index2]);
          this.fireDebug("    -> Size: {0} bytes", (object) this.data[index2].Length);
          using (FileStream fileStream = new FileStream(strArray[index1] + (object) Path.DirectorySeparatorChar + this.stringTable[index2], FileMode.Create))
            fileStream.Write(this.data[index2], 0, this.data[index2].Length);
        }
        while (index1 > 0 && numArray[index1] == index2 + 2)
          --index1;
      }
      this.fireDebug("Unpacking U8 File Finished");
    }

    private void parseU8(Stream u8File)
    {
      this.fireDebug("Pasing U8 File...");
      this.u8Header = new U8_Header();
      this.rootNode = new U8_Node();
      this.u8Nodes = new List<U8_Node>();
      this.stringTable = new List<string>();
      this.data = new List<byte[]>();
      this.fireDebug("   Detecting Header...");
      this.headerType = Headers.DetectHeader(u8File);
      Headers.HeaderType offset = this.headerType;
      this.fireDebug("    -> {0}", (object) this.headerType.ToString());
      if (this.headerType == Headers.HeaderType.IMD5)
      {
        this.fireDebug("   Reading IMD5 Header...");
        this.header = (object) Headers.IMD5.Load(u8File);
        byte[] buffer = new byte[u8File.Length];
        u8File.Read(buffer, 0, buffer.Length);
        MD5 md5 = MD5.Create();
        byte[] hash = md5.ComputeHash(buffer, (int) this.headerType, (int) ((int) u8File.Length - this.headerType));
        md5.Clear();
        if (!Shared.CompareByteArrays(hash, ((Headers.IMD5) this.header).Hash))
        {
          this.fireDebug("/!\\ /!\\ /!\\ Hashes do not match /!\\ /!\\ /!\\");
          this.fireWarning(string.Format("Hashes of IMD5 header and file do not match! The content might be corrupted!"));
        }
      }
      else if (this.headerType == Headers.HeaderType.IMET || this.headerType == Headers.HeaderType.ShortIMET)
      {
        this.fireDebug("   Reading IMET Header...");
        this.header = (object) Headers.IMET.Load(u8File);
        if (!((Headers.IMET) this.header).HashesMatch)
        {
          this.fireDebug("/!\\ /!\\ /!\\ Hashes do not match /!\\ /!\\ /!\\");
          this.fireWarning(string.Format("The hash stored in the IMET header doesn't match the headers hash! The header and/or file might be corrupted!"));
        }
      }
      this.fireDebug("   Checking for Lz77 Compression...");
      if (Lz77.IsLz77Compressed(u8File))
      {
        this.fireDebug("    -> Lz77 Compression Found...");
        this.fireDebug("   Decompressing U8 Data...");
        Stream file = new Lz77().Decompress(u8File);
        offset = Headers.DetectHeader(file);
        u8File = file;
        this.lz77 = true;
      }
      u8File.Seek((long) offset, SeekOrigin.Begin);
      byte[] buffer1 = new byte[4];
      this.fireDebug("   Reading U8 Header: Magic... (Offset: 0x{0})", (object) u8File.Position.ToString("x8").ToUpper());
      u8File.Read(buffer1, 0, 4);
      if ((int) Shared.Swap(BitConverter.ToUInt32(buffer1, 0)) != (int) this.u8Header.U8Magic)
      {
        this.fireDebug("    -> Invalid Magic!");
        throw new Exception("U8 Header: Invalid Magic!");
      }
      this.fireDebug("   Reading U8 Header: Offset to Rootnode... (Offset: 0x{0})", (object) u8File.Position.ToString("x8").ToUpper());
      u8File.Read(buffer1, 0, 4);
      if ((int) Shared.Swap(BitConverter.ToUInt32(buffer1, 0)) != (int) this.u8Header.OffsetToRootNode)
      {
        this.fireDebug("    -> Invalid Offset to Rootnode");
        throw new Exception("U8 Header: Invalid Offset to Rootnode!");
      }
      this.fireDebug("   Reading U8 Header: Header Size... (Offset: 0x{0})", (object) u8File.Position.ToString("x8").ToUpper());
      u8File.Read(buffer1, 0, 4);
      this.u8Header.HeaderSize = Shared.Swap(BitConverter.ToUInt32(buffer1, 0));
      this.fireDebug("   Reading U8 Header: Offset to Data... (Offset: 0x{0})", (object) u8File.Position.ToString("x8").ToUpper());
      u8File.Read(buffer1, 0, 4);
      this.u8Header.OffsetToData = Shared.Swap(BitConverter.ToUInt32(buffer1, 0));
      u8File.Seek(16L, SeekOrigin.Current);
      this.fireDebug("   Reading Rootnode... (Offset: 0x{0})", (object) u8File.Position.ToString("x8").ToUpper());
      u8File.Read(buffer1, 0, 4);
      this.rootNode.Type = (U8_NodeType) Shared.Swap(BitConverter.ToUInt16(buffer1, 0));
      this.rootNode.OffsetToName = Shared.Swap(BitConverter.ToUInt16(buffer1, 2));
      u8File.Read(buffer1, 0, 4);
      this.rootNode.OffsetToData = Shared.Swap(BitConverter.ToUInt32(buffer1, 0));
      u8File.Read(buffer1, 0, 4);
      this.rootNode.SizeOfData = Shared.Swap(BitConverter.ToUInt32(buffer1, 0));
      int num = (int) ((long) offset + (long) this.u8Header.OffsetToRootNode + (long) (this.rootNode.SizeOfData * 12U));
      int position = (int) u8File.Position;
      for (int index = 0; (long) index < (long) (this.rootNode.SizeOfData - 1U); ++index)
      {
        this.fireDebug("   Reading Node #{1} of {2}... (Offset: 0x{0})", (object) u8File.Position.ToString("x8").ToUpper(), (object) (index + 1), (object) (uint) ((int) this.rootNode.SizeOfData - 1));
        this.fireProgress((int) ((long) ((index + 1) * 100) / (long) (this.rootNode.SizeOfData - 1U)));
        U8_Node u8Node = new U8_Node();
        string empty = string.Empty;
        byte[] numArray = new byte[0];
        u8File.Seek((long) position, SeekOrigin.Begin);
        this.fireDebug("    -> Reading Node Entry... (Offset: 0x{0})", (object) u8File.Position.ToString("x8").ToUpper());
        u8File.Read(buffer1, 0, 4);
        u8Node.Type = (U8_NodeType) Shared.Swap(BitConverter.ToUInt16(buffer1, 0));
        u8Node.OffsetToName = Shared.Swap(BitConverter.ToUInt16(buffer1, 2));
        u8File.Read(buffer1, 0, 4);
        u8Node.OffsetToData = Shared.Swap(BitConverter.ToUInt32(buffer1, 0));
        u8File.Read(buffer1, 0, 4);
        u8Node.SizeOfData = Shared.Swap(BitConverter.ToUInt32(buffer1, 0));
        position = (int) u8File.Position;
        this.fireDebug("        -> {0}", (object) u8Node.Type.ToString());
        u8File.Seek((long) (num + (int) u8Node.OffsetToName), SeekOrigin.Begin);
        this.fireDebug("    -> Reading Node Name... (Offset: 0x{0})", (object) u8File.Position.ToString("x8").ToUpper());
        do
        {
          char ch = (char) u8File.ReadByte();
          if (ch != char.MinValue)
            empty += (string) (object) ch;
          else
            break;
        }
        while (empty.Length <= (int) byte.MaxValue);
        this.fireDebug("        -> {0}", (object) empty);
        if (u8Node.Type == U8_NodeType.File)
        {
          u8File.Seek((long) offset + (long) u8Node.OffsetToData, SeekOrigin.Begin);
          this.fireDebug("    -> Reading Node Data (Offset: 0x{0})", (object) u8File.Position.ToString("x8").ToUpper());
          numArray = new byte[(IntPtr) u8Node.SizeOfData];
          u8File.Read(numArray, 0, numArray.Length);
        }
        if (empty.ToLower() == "icon.bin")
          this.iconSize = this.getRealSize(numArray);
        else if (empty.ToLower() == "banner.bin")
          this.bannerSize = this.getRealSize(numArray);
        else if (empty.ToLower() == "sound.bin")
          this.soundSize = this.getRealSize(numArray);
        this.u8Nodes.Add(u8Node);
        this.stringTable.Add(empty);
        this.data.Add(numArray);
      }
      this.fireDebug("Pasing U8 File Finished...");
    }

    private void createFromDir(string path)
    {
      this.fireDebug("Creating U8 File from: {0}", (object) path);
      if ((int) path[path.Length - 1] != (int) Path.DirectorySeparatorChar)
        path += (string) (object) Path.DirectorySeparatorChar;
      this.fireDebug("   Collecting Content...");
      string[] dirContent = this.getDirContent(path, true);
      int num1 = 1;
      int num2 = 0;
      this.fireDebug("   Creating U8 Header...");
      this.u8Header = new U8_Header();
      this.rootNode = new U8_Node();
      this.u8Nodes = new List<U8_Node>();
      this.stringTable = new List<string>();
      this.data = new List<byte[]>();
      this.fireDebug("   Creating Rootnode...");
      this.rootNode.Type = U8_NodeType.Directory;
      this.rootNode.OffsetToName = (ushort) 0;
      this.rootNode.OffsetToData = 0U;
      this.rootNode.SizeOfData = (uint) (dirContent.Length + 1);
      for (int index1 = 0; index1 < dirContent.Length; ++index1)
      {
        this.fireDebug("   Creating Node #{0} of {1}", (object) (index1 + 1), (object) dirContent.Length);
        this.fireProgress((index1 + 1) * 100 / dirContent.Length);
        U8_Node u8Node = new U8_Node();
        byte[] data = new byte[0];
        string theString = dirContent[index1].Remove(0, path.Length - 1);
        if (Directory.Exists(dirContent[index1]))
        {
          this.fireDebug("    -> Directory");
          u8Node.Type = U8_NodeType.Directory;
          u8Node.OffsetToData = (uint) Shared.CountCharsInString(theString, Path.DirectorySeparatorChar);
          int num3 = this.u8Nodes.Count + 2;
          for (int index2 = 0; index2 < dirContent.Length; ++index2)
          {
            if (dirContent[index2].Contains(dirContent[index1] + Path.DirectorySeparatorChar.ToString()))
              ++num3;
          }
          u8Node.SizeOfData = (uint) num3;
        }
        else
        {
          this.fireDebug("    -> File");
          this.fireDebug("    -> Reading File Data...");
          data = File.ReadAllBytes(dirContent[index1]);
          u8Node.Type = U8_NodeType.File;
          u8Node.OffsetToData = (uint) num2;
          u8Node.SizeOfData = (uint) data.Length;
          num2 += Shared.AddPadding(num2 + data.Length, 32);
        }
        u8Node.OffsetToName = (ushort) num1;
        num1 += Path.GetFileName(dirContent[index1]).Length + 1;
        this.fireDebug("    -> Reading Name...");
        string fileName = Path.GetFileName(dirContent[index1]);
        if (fileName.ToLower() == "icon.bin")
          this.iconSize = this.getRealSize(data);
        else if (fileName.ToLower() == "banner.bin")
          this.bannerSize = this.getRealSize(data);
        else if (fileName.ToLower() == "sound.bin")
          this.soundSize = this.getRealSize(data);
        this.u8Nodes.Add(u8Node);
        this.stringTable.Add(fileName);
        this.data.Add(data);
      }
      this.fireDebug("   Updating U8 Header...");
      this.u8Header.HeaderSize = (uint) ((this.u8Nodes.Count + 1) * 12 + num1);
      this.u8Header.OffsetToData = (uint) Shared.AddPadding((int) this.u8Header.OffsetToRootNode + (int) this.u8Header.HeaderSize, 32);
      this.fireDebug("   Calculating Data Offsets...");
      for (int index = 0; index < this.u8Nodes.Count; ++index)
      {
        this.fireDebug("    -> Node #{0} of {1}...", (object) (index + 1), (object) this.u8Nodes.Count);
        int offsetToData = (int) this.u8Nodes[index].OffsetToData;
        this.u8Nodes[index].OffsetToData = (uint) ((ulong) this.u8Header.OffsetToData + (ulong) offsetToData);
      }
      this.fireDebug("Creating U8 File Finished...");
    }

    private string[] getDirContent(string dir, bool root)
    {
      string[] files = Directory.GetFiles(dir);
      string[] directories = Directory.GetDirectories(dir);
      string str1 = "";
      if (!root)
        str1 = str1 + dir + "\n";
      for (int index = 0; index < files.Length; ++index)
        str1 = str1 + files[index] + "\n";
      foreach (string dir1 in directories)
      {
        foreach (string str2 in this.getDirContent(dir1, false))
          str1 = str1 + str2 + "\n";
      }
      return str1.Split(new char[1]{ '\n' }, StringSplitOptions.RemoveEmptyEntries);
    }

    private int getRealSize(byte[] data)
    {
      if (data[0] != (byte) 73 || data[1] != (byte) 77 || data[2] != (byte) 68 || data[3] != (byte) 53)
        return data.Length;
      return data[32] == (byte) 76 && data[33] == (byte) 90 && data[34] == (byte) 55 && data[35] == (byte) 55 ? BitConverter.ToInt32(data, 36) >> 8 : data.Length - 32;
    }

    private void addEntry(string nodePath, byte[] fileData)
    {
      if (nodePath.StartsWith("/"))
        nodePath = nodePath.Remove(0, 1);
      string[] strArray = nodePath.Split('/');
      int index1 = -1;
      int num1 = this.u8Nodes.Count > 0 ? this.u8Nodes.Count - 1 : 0;
      int num2 = 0;
      List<int> intList = new List<int>();
      for (int index2 = 0; index2 < strArray.Length - 1; ++index2)
      {
        for (int index3 = num2; index3 <= num1; ++index3)
        {
          if (this.stringTable[index3].ToLower() == strArray[index2].ToLower())
          {
            if (index2 == strArray.Length - 2)
              index1 = index3;
            num1 = (int) this.u8Nodes[index3].SizeOfData - 1;
            num2 = index3 + 1;
            intList.Add(index3);
            break;
          }
          if (index3 == num1 - 1)
            throw new Exception("Path wasn't found!");
        }
      }
      int num3 = index1 <= -1 ? (this.rootNode.SizeOfData > 1U ? (int) this.rootNode.SizeOfData - 2 : -1) : (int) this.u8Nodes[index1].SizeOfData - 2;
      U8_Node u8Node = new U8_Node();
      u8Node.Type = fileData.Length == 0 ? U8_NodeType.Directory : U8_NodeType.File;
      u8Node.SizeOfData = fileData.Length == 0 ? (uint) (num3 + 2) : (uint) fileData.Length;
      u8Node.OffsetToData = fileData.Length == 0 ? (uint) Shared.CountCharsInString(nodePath, '/') : 0U;
      this.stringTable.Insert(num3 + 1, strArray[strArray.Length - 1]);
      this.u8Nodes.Insert(num3 + 1, u8Node);
      this.data.Insert(num3 + 1, fileData);
      ++this.rootNode.SizeOfData;
      foreach (int index4 in intList)
      {
        if (this.u8Nodes[index4].Type == U8_NodeType.Directory)
          ++this.u8Nodes[index4].SizeOfData;
      }
      for (int index5 = num3 + 1; index5 < this.u8Nodes.Count; ++index5)
      {
        if (this.u8Nodes[index5].Type == U8_NodeType.Directory)
          ++this.u8Nodes[index5].SizeOfData;
      }
    }

    private void removeEntry(string nodePath)
    {
      if (nodePath.StartsWith("/"))
        nodePath = nodePath.Remove(0, 1);
      string[] strArray = nodePath.Split('/');
      int index1 = -1;
      int num1 = this.u8Nodes.Count - 1;
      int num2 = 0;
      List<int> intList = new List<int>();
      for (int index2 = 0; index2 < strArray.Length; ++index2)
      {
        for (int index3 = num2; index3 < num1; ++index3)
        {
          if (this.stringTable[index3].ToLower() == strArray[index2].ToLower())
          {
            if (index2 == strArray.Length - 1)
              index1 = index3;
            else
              intList.Add(index3);
            num1 = (int) this.u8Nodes[index3].SizeOfData - 1;
            num2 = index3 + 1;
            break;
          }
          if (index3 == num1 - 1)
            throw new Exception("Path wasn't found!");
        }
      }
      int num3 = 0;
      if (this.u8Nodes[index1].Type == U8_NodeType.Directory)
      {
        for (int index4 = (int) this.u8Nodes[index1].SizeOfData - 2; index4 >= index1; --index4)
        {
          this.stringTable.RemoveAt(index4);
          this.u8Nodes.RemoveAt(index4);
          this.data.RemoveAt(index4);
          ++num3;
        }
      }
      else
      {
        this.stringTable.RemoveAt(index1);
        this.u8Nodes.RemoveAt(index1);
        this.data.RemoveAt(index1);
        ++num3;
      }
      this.rootNode.SizeOfData -= (uint) num3;
      foreach (int index5 in intList)
      {
        if (this.u8Nodes[index5].Type == U8_NodeType.Directory)
          this.u8Nodes[index5].SizeOfData -= (uint) num3;
      }
      for (int index6 = index1 + 1; index6 < this.u8Nodes.Count; ++index6)
      {
        if (this.u8Nodes[index6].Type == U8_NodeType.Directory)
          this.u8Nodes[index6].SizeOfData -= (uint) num3;
      }
    }

    public event EventHandler<ProgressChangedEventArgs> Progress;

    public event EventHandler<MessageEventArgs> Warning;

    public event EventHandler<MessageEventArgs> Debug;

    private void fireWarning(string warningMessage)
    {
      EventHandler<MessageEventArgs> warning = this.Warning;
      if (warning == null)
        return;
      warning(new object(), new MessageEventArgs(warningMessage));
    }

    private void fireDebug(string debugMessage, params object[] args)
    {
      EventHandler<MessageEventArgs> debug = this.Debug;
      if (debug == null)
        return;
      debug(new object(), new MessageEventArgs(string.Format(debugMessage, args)));
    }

    private void fireProgress(int progressPercentage)
    {
      EventHandler<ProgressChangedEventArgs> progress = this.Progress;
      if (progress == null)
        return;
      progress(new object(), new ProgressChangedEventArgs(progressPercentage, (object) string.Empty));
    }
  }
}
