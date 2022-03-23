// Decompiled with JetBrains decompiler
// Type: libWiiSharp.Shared
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace libWiiSharp
{
  public static class Shared
  {
    public static string[] MergeStringArrays(string[] a, string[] b)
    {
      List<string> stringList = new List<string>((IEnumerable<string>) a);
      foreach (string str in b)
      {
        if (!stringList.Contains(str))
          stringList.Add(str);
      }
      stringList.Sort();
      return stringList.ToArray();
    }

    public static bool CompareByteArrays(
      byte[] first,
      int firstIndex,
      byte[] second,
      int secondIndex,
      int length)
    {
      if (first.Length < length || second.Length < length)
        return false;
      for (int index = 0; index < length; ++index)
      {
        if ((int) first[firstIndex + index] != (int) second[secondIndex + index])
          return false;
      }
      return true;
    }

    public static bool CompareByteArrays(byte[] first, byte[] second)
    {
      if (first.Length != second.Length)
        return false;
      for (int index = 0; index < first.Length; ++index)
      {
        if ((int) first[index] != (int) second[index])
          return false;
      }
      return true;
    }

    public static string ByteArrayToString(byte[] byteArray, char separator = ' ')
    {
      string str = string.Empty;
      foreach (byte num in byteArray)
        str = str + num.ToString("x2").ToUpper() + (object) separator;
      return str.Remove(str.Length - 1);
    }

    public static byte[] HexStringToByteArray(string hexString)
    {
      byte[] byteArray = new byte[hexString.Length / 2];
      for (int index = 0; index < hexString.Length / 2; ++index)
        byteArray[index] = byte.Parse(hexString.Substring(index * 2, 2), NumberStyles.HexNumber);
      return byteArray;
    }

    public static int CountCharsInString(string theString, char theChar)
    {
      int num1 = 0;
      foreach (int num2 in theString)
      {
        if (num2 == (int) theChar)
          ++num1;
      }
      return num1;
    }

    public static long AddPadding(long value) => Shared.AddPadding(value, 64);

    public static long AddPadding(long value, int padding)
    {
      if (value % (long) padding != 0L)
        value += (long) padding - value % (long) padding;
      return value;
    }

    public static int AddPadding(int value) => Shared.AddPadding(value, 64);

    public static int AddPadding(int value, int padding)
    {
      if (value % padding != 0)
        value += padding - value % padding;
      return value;
    }

    public static ushort Swap(ushort value) => (ushort) IPAddress.HostToNetworkOrder((short) value);

    public static uint Swap(uint value) => (uint) IPAddress.HostToNetworkOrder((int) value);

    public static ulong Swap(ulong value) => (ulong) IPAddress.HostToNetworkOrder((long) value);

    public static byte[] UShortArrayToByteArray(ushort[] array)
    {
      List<byte> byteList = new List<byte>();
      foreach (ushort num in array)
      {
        byte[] bytes = BitConverter.GetBytes(num);
        byteList.AddRange((IEnumerable<byte>) bytes);
      }
      return byteList.ToArray();
    }

    public static byte[] UIntArrayToByteArray(uint[] array)
    {
      List<byte> byteList = new List<byte>();
      foreach (uint num in array)
      {
        byte[] bytes = BitConverter.GetBytes(num);
        byteList.AddRange((IEnumerable<byte>) bytes);
      }
      return byteList.ToArray();
    }

    public static uint[] ByteArrayToUIntArray(byte[] array)
    {
      uint[] uintArray = new uint[array.Length / 4];
      int num = 0;
      for (int startIndex = 0; startIndex < array.Length; startIndex += 4)
        uintArray[num++] = BitConverter.ToUInt32(array, startIndex);
      return uintArray;
    }

    public static ushort[] ByteArrayToUShortArray(byte[] array)
    {
      ushort[] ushortArray = new ushort[array.Length / 2];
      int num = 0;
      for (int startIndex = 0; startIndex < array.Length; startIndex += 2)
        ushortArray[num++] = BitConverter.ToUInt16(array, startIndex);
      return ushortArray;
    }
  }
}
