// Decompiled with JetBrains decompiler
// Type: libWiiSharp.IosPatcher
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

using System;
using System.ComponentModel;
using System.Text;

namespace libWiiSharp
{
  public class IosPatcher
  {
    private WAD wadFile;
    private int esIndex = -1;

    public void LoadIOS(ref WAD iosWad)
    {
      if (iosWad.TitleID >> 32 != 1UL || (iosWad.TitleID & (ulong) uint.MaxValue) < 3UL || (iosWad.TitleID & (ulong) uint.MaxValue) > (ulong) byte.MaxValue)
        throw new Exception("Only IOS WADs can be patched!");
      this.wadFile = iosWad;
      this.getEsIndex();
    }

    public int PatchFakeSigning() => this.esIndex < 0 ? -1 : this.patchFakeSigning(ref this.wadFile.Contents[this.esIndex]);

    public int PatchEsIdentify() => this.esIndex < 0 ? -1 : this.patchEsIdentify(ref this.wadFile.Contents[this.esIndex]);

    public int PatchNandPermissions() => this.esIndex < 0 ? -1 : this.patchNandPermissions(ref this.wadFile.Contents[this.esIndex]);

    public int PatchAll() => this.esIndex < 0 ? -1 : this.patchAll(ref this.wadFile.Contents[this.esIndex]);

    public int PatchFakeSigning(ref byte[] esModule) => this.patchFakeSigning(ref esModule);

    public int PatchEsIdentify(ref byte[] esModule) => this.patchEsIdentify(ref esModule);

    public int PatchNandPermissions(ref byte[] esModule) => this.patchNandPermissions(ref esModule);

    public int PatchAll(ref byte[] esModule) => this.patchAll(ref esModule);

    private int patchFakeSigning(ref byte[] esModule)
    {
      this.fireDebug("Patching Fakesigning...");
      int num = 0;
      byte[] second1 = new byte[4]
      {
        (byte) 32,
        (byte) 7,
        (byte) 35,
        (byte) 162
      };
      byte[] second2 = new byte[4]
      {
        (byte) 32,
        (byte) 7,
        (byte) 75,
        (byte) 11
      };
      for (int firstIndex = 0; firstIndex < esModule.Length - 4; ++firstIndex)
      {
        this.fireProgress((firstIndex + 1) * 100 / esModule.Length);
        if (Shared.CompareByteArrays(esModule, firstIndex, second1, 0, 4) || Shared.CompareByteArrays(esModule, firstIndex, second2, 0, 4))
        {
          this.fireDebug("   Patching at Offset: 0x{0}", (object) firstIndex.ToString("x8").ToUpper());
          esModule[firstIndex + 1] = (byte) 0;
          firstIndex += 4;
          ++num;
        }
      }
      this.fireDebug("Patching Fakesigning Finished... (Patches applied: {0})", (object) num);
      return num;
    }

    private int patchEsIdentify(ref byte[] esModule)
    {
      this.fireDebug("Patching ES_Identify...");
      int num = 0;
      byte[] second = new byte[4]
      {
        (byte) 40,
        (byte) 3,
        (byte) 209,
        (byte) 35
      };
      for (int firstIndex = 0; firstIndex < esModule.Length - 4; ++firstIndex)
      {
        this.fireProgress((firstIndex + 1) * 100 / esModule.Length);
        if (Shared.CompareByteArrays(esModule, firstIndex, second, 0, 4))
        {
          this.fireDebug("   Patching at Offset: 0x{0}", (object) firstIndex.ToString("x8").ToUpper());
          esModule[firstIndex + 2] = (byte) 0;
          esModule[firstIndex + 3] = (byte) 0;
          firstIndex += 4;
          ++num;
        }
      }
      this.fireDebug("Patching ES_Identify Finished... (Patches applied: {0})", (object) num);
      return num;
    }

    private int patchNandPermissions(ref byte[] esModule)
    {
      this.fireDebug("Patching NAND Permissions...");
      int num = 0;
      byte[] second = new byte[6]
      {
        (byte) 66,
        (byte) 139,
        (byte) 208,
        (byte) 1,
        (byte) 37,
        (byte) 102
      };
      for (int firstIndex = 0; firstIndex < esModule.Length - 6; ++firstIndex)
      {
        this.fireProgress((firstIndex + 1) * 100 / esModule.Length);
        if (Shared.CompareByteArrays(esModule, firstIndex, second, 0, 6))
        {
          this.fireDebug("   Patching at Offset: 0x{0}", (object) firstIndex.ToString("x8").ToUpper());
          esModule[firstIndex + 2] = (byte) 224;
          firstIndex += 6;
          ++num;
        }
      }
      this.fireDebug("Patching NAND Permissions Finished... (Patches applied: {0})", (object) num);
      return num;
    }

    private int patchAll(ref byte[] esModule)
    {
      this.fireDebug("Patching Fakesigning, ES_Identify and NAND Permissions...");
      int num = 0;
      byte[] second1 = new byte[4]
      {
        (byte) 32,
        (byte) 7,
        (byte) 35,
        (byte) 162
      };
      byte[] second2 = new byte[4]
      {
        (byte) 32,
        (byte) 7,
        (byte) 75,
        (byte) 11
      };
      byte[] second3 = new byte[4]
      {
        (byte) 40,
        (byte) 3,
        (byte) 209,
        (byte) 35
      };
      byte[] second4 = new byte[6]
      {
        (byte) 66,
        (byte) 139,
        (byte) 208,
        (byte) 1,
        (byte) 37,
        (byte) 102
      };
      for (int firstIndex = 0; firstIndex < esModule.Length - 6; ++firstIndex)
      {
        this.fireProgress((firstIndex + 1) * 100 / esModule.Length);
        if (Shared.CompareByteArrays(esModule, firstIndex, second1, 0, 4) || Shared.CompareByteArrays(esModule, firstIndex, second2, 0, 4))
        {
          this.fireDebug("   Patching Fakesigning at Offset: 0x{0}", (object) firstIndex.ToString("x8").ToUpper());
          esModule[firstIndex + 1] = (byte) 0;
          firstIndex += 4;
          ++num;
        }
        else if (Shared.CompareByteArrays(esModule, firstIndex, second3, 0, 4))
        {
          this.fireDebug("   Patching ES_Identify at Offset: 0x{0}", (object) firstIndex.ToString("x8").ToUpper());
          esModule[firstIndex + 2] = (byte) 0;
          esModule[firstIndex + 3] = (byte) 0;
          firstIndex += 4;
          ++num;
        }
        else if (Shared.CompareByteArrays(esModule, firstIndex, second4, 0, 6))
        {
          this.fireDebug("   Patching NAND Permissions at Offset: 0x{0}", (object) firstIndex.ToString("x8").ToUpper());
          esModule[firstIndex + 2] = (byte) 224;
          firstIndex += 6;
          ++num;
        }
      }
      this.fireDebug("Patching Fakesigning, ES_Identify and NAND Permissions Finished... (Patches applied: {0})", (object) num);
      return num;
    }

    private void getEsIndex()
    {
      this.fireDebug("Scanning for ES Module...");
      string str = "$IOSVersion:";
      for (int index1 = this.wadFile.NumOfContents - 1; index1 >= 0; --index1)
      {
        this.fireDebug("   Scanning Content #{0} of {1}...", (object) (index1 + 1), (object) this.wadFile.NumOfContents);
        this.fireProgress((index1 + 1) * 100 / this.wadFile.NumOfContents);
        for (int index2 = 0; index2 < this.wadFile.Contents[index1].Length - 64; ++index2)
        {
          if (Encoding.ASCII.GetString(this.wadFile.Contents[index1], index2, 12) == str)
          {
            int index3 = index2 + 12;
            while (this.wadFile.Contents[index1][index3] == (byte) 32)
              ++index3;
            if (Encoding.ASCII.GetString(this.wadFile.Contents[index1], index3, 3) == "ES:")
            {
              this.fireDebug("    -> ES Module found!");
              this.fireDebug("Scanning for ES Module Finished...");
              this.esIndex = index1;
              this.fireProgress(100);
              return;
            }
          }
        }
      }
      this.fireDebug("/!\\/!\\/!\\ ES Module wasn't found! /!\\/!\\/!\\");
      throw new Exception("ES module wasn't found!");
    }

    public event EventHandler<ProgressChangedEventArgs> Progress;

    public event EventHandler<MessageEventArgs> Debug;

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
