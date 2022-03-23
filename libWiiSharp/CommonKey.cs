// Decompiled with JetBrains decompiler
// Type: libWiiSharp.CommonKey
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

using System.IO;

namespace libWiiSharp
{
  public class CommonKey
  {
    private static string standardKey = "ebe42a225e8593e448d9c5457381aaf7";
    private static string koreanKey = "63b82bb4f4614e2e13f2fefbba4c9b7e";
    private static string dsiKey = "af1bf516a807d21aea45984f04742861";
    private static string currentDir = Directory.GetCurrentDirectory();
    private static string standardKeyName = "key.bin";
    private static string koreanKeyName = "kkey.bin";
    private static string dsiKeyName = "dsikey.bin";

    public static byte[] GetStandardKey() => File.Exists(Path.Combine(CommonKey.currentDir, CommonKey.standardKeyName)) ? File.ReadAllBytes(Path.Combine(CommonKey.currentDir, CommonKey.standardKeyName)) : Shared.HexStringToByteArray(CommonKey.standardKey);

    public static byte[] GetKoreanKey() => File.Exists(Path.Combine(CommonKey.currentDir, CommonKey.koreanKeyName)) ? File.ReadAllBytes(Path.Combine(CommonKey.currentDir, CommonKey.koreanKeyName)) : Shared.HexStringToByteArray(CommonKey.koreanKey);

    public static byte[] GetDSiKey() => File.Exists(Path.Combine(CommonKey.currentDir, CommonKey.dsiKeyName)) ? File.ReadAllBytes(Path.Combine(CommonKey.currentDir, CommonKey.dsiKeyName)) : Shared.HexStringToByteArray(CommonKey.dsiKey);
  }
}
