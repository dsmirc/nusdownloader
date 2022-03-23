// Decompiled with JetBrains decompiler
// Type: libWiiSharp.CertificateChain
// Assembly: NUS Downloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDAF9FEC-76DE-4BD8-8A6D-D7CAD5827AC6
// Assembly location: C:\dotpeek\NUS Downloader.exe

using System;
using System.IO;
using System.Security.Cryptography;

namespace libWiiSharp
{
  public class CertificateChain : IDisposable
  {
    private const string certCaHash = "5B7D3EE28706AD8DA2CBD5A6B75C15D0F9B6F318";
    private const string certCpHash = "6824D6DA4C25184F0D6DAF6EDB9C0FC57522A41C";
    private const string certXsHash = "09787045037121477824BC6A3E5E076156573F8A";
    private SHA1 sha = SHA1.Create();
    private bool[] certsComplete = new bool[3];
    private byte[] certCa = new byte[1024];
    private byte[] certCp = new byte[768];
    private byte[] certXs = new byte[768];
    private bool isDisposed;

    public bool CertsComplete => this.certsComplete[0] && this.certsComplete[1] && this.certsComplete[2];

    ~CertificateChain() => this.Dispose(false);

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposing && !this.isDisposed)
      {
        this.sha.Clear();
        this.sha = (SHA1) null;
        this.certsComplete = (bool[]) null;
        this.certCa = (byte[]) null;
        this.certCp = (byte[]) null;
        this.certXs = (byte[]) null;
      }
      this.isDisposed = true;
    }

    public static CertificateChain Load(string pathToCert) => CertificateChain.Load(File.ReadAllBytes(pathToCert));

    public static CertificateChain Load(byte[] certFile)
    {
      CertificateChain certificateChain = new CertificateChain();
      MemoryStream certFile1 = new MemoryStream(certFile);
      try
      {
        certificateChain.parseCert((Stream) certFile1);
      }
      catch
      {
        certFile1.Dispose();
        throw;
      }
      certFile1.Dispose();
      return certificateChain;
    }

    public static CertificateChain Load(Stream cert)
    {
      CertificateChain certificateChain = new CertificateChain();
      certificateChain.parseCert(cert);
      return certificateChain;
    }

    public static CertificateChain FromTikTmd(string pathToTik, string pathToTmd) => CertificateChain.FromTikTmd(File.ReadAllBytes(pathToTik), File.ReadAllBytes(pathToTmd));

    public static CertificateChain FromTikTmd(string pathToTik, byte[] tmdFile) => CertificateChain.FromTikTmd(File.ReadAllBytes(pathToTik), tmdFile);

    public static CertificateChain FromTikTmd(byte[] tikFile, byte[] tmdFile)
    {
      CertificateChain certificateChain = new CertificateChain();
      MemoryStream tik = new MemoryStream(tikFile);
      try
      {
        certificateChain.grabFromTik((Stream) tik);
      }
      catch
      {
        tik.Dispose();
        throw;
      }
      MemoryStream tmd = new MemoryStream(tmdFile);
      try
      {
        certificateChain.grabFromTmd((Stream) tmd);
      }
      catch
      {
        tmd.Dispose();
        throw;
      }
      tmd.Dispose();
      return certificateChain.CertsComplete ? certificateChain : throw new Exception("Couldn't locate all certs!");
    }

    public static CertificateChain FromTikTmd(Stream tik, Stream tmd)
    {
      CertificateChain certificateChain = new CertificateChain();
      certificateChain.grabFromTik(tik);
      certificateChain.grabFromTmd(tmd);
      return certificateChain;
    }

    public void LoadFile(string pathToCert) => this.LoadFile(File.ReadAllBytes(pathToCert));

    public void LoadFile(byte[] certFile)
    {
      MemoryStream certFile1 = new MemoryStream(certFile);
      try
      {
        this.parseCert((Stream) certFile1);
      }
      catch
      {
        certFile1.Dispose();
        throw;
      }
      certFile1.Dispose();
    }

    public void LoadFile(Stream cert) => this.parseCert(cert);

    public void LoadFromTikTmd(string pathToTik, string pathToTmd) => this.LoadFromTikTmd(File.ReadAllBytes(pathToTik), File.ReadAllBytes(pathToTmd));

    public void LoadFromTikTmd(string pathToTik, byte[] tmdFile) => this.LoadFromTikTmd(File.ReadAllBytes(pathToTik), tmdFile);

    public void LoadFromTikTmd(byte[] tikFile, byte[] tmdFile)
    {
      MemoryStream tik = new MemoryStream(tikFile);
      try
      {
        this.grabFromTik((Stream) tik);
      }
      catch
      {
        tik.Dispose();
        throw;
      }
      MemoryStream tmd = new MemoryStream(tmdFile);
      try
      {
        this.grabFromTmd((Stream) tmd);
      }
      catch
      {
        tmd.Dispose();
        throw;
      }
      tmd.Dispose();
      if (!this.CertsComplete)
        throw new Exception("Couldn't locate all certs!");
    }

    public void LoadFromTikTmd(Stream tik, Stream tmd)
    {
      this.grabFromTik(tik);
      this.grabFromTmd(tmd);
    }

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

    public byte[] ToByteArray()
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
      byte[] array = writeStream.ToArray();
      writeStream.Dispose();
      return array;
    }

    private void writeToStream(Stream writeStream)
    {
      this.fireDebug("Writing Certificate Chain...");
      if (!this.CertsComplete)
      {
        this.fireDebug("   Certificate Chain incomplete...");
        throw new Exception("At least one certificate is missing!");
      }
      writeStream.Seek(0L, SeekOrigin.Begin);
      this.fireDebug("   Writing Certificate CA... (Offset: 0x{0})", (object) writeStream.Position.ToString("x8"));
      writeStream.Write(this.certCa, 0, this.certCa.Length);
      this.fireDebug("   Writing Certificate CP... (Offset: 0x{0})", (object) writeStream.Position.ToString("x8"));
      writeStream.Write(this.certCp, 0, this.certCp.Length);
      this.fireDebug("   Writing Certificate XS... (Offset: 0x{0})", (object) writeStream.Position.ToString("x8"));
      writeStream.Write(this.certXs, 0, this.certXs.Length);
      this.fireDebug("Writing Certificate Chain Finished...");
    }

    private void parseCert(Stream certFile)
    {
      this.fireDebug("Parsing Certificate Chain...");
      int offset = 0;
      for (int index = 0; index < 3; ++index)
      {
        this.fireDebug("   Scanning at Offset 0x{0}:", (object) offset.ToString("x8"));
        try
        {
          certFile.Seek((long) offset, SeekOrigin.Begin);
          byte[] array = new byte[1024];
          certFile.Read(array, 0, array.Length);
          this.fireDebug("   Checking for Certificate CA...");
          if (this.isCertCa(array) && !this.certsComplete[1])
          {
            this.fireDebug("   Certificate CA detected...");
            this.certCa = array;
            this.certsComplete[1] = true;
            offset += 1024;
            continue;
          }
          this.fireDebug("   Checking for Certificate CP...");
          if (this.isCertCp(array) && !this.certsComplete[2])
          {
            this.fireDebug("   Certificate CP detected...");
            Array.Resize<byte>(ref array, 768);
            this.certCp = array;
            this.certsComplete[2] = true;
            offset += 768;
            continue;
          }
          this.fireDebug("   Checking for Certificate XS...");
          if (this.isCertXs(array))
          {
            if (!this.certsComplete[0])
            {
              this.fireDebug("   Certificate XS detected...");
              Array.Resize<byte>(ref array, 768);
              this.certXs = array;
              this.certsComplete[0] = true;
              offset += 768;
              continue;
            }
          }
        }
        catch (Exception ex)
        {
          this.fireDebug("Error: {0}", (object) ex.Message);
        }
        offset += 768;
      }
      if (!this.CertsComplete)
      {
        this.fireDebug("   Couldn't locate all Certificates...");
        throw new Exception("Couldn't locate all certs!");
      }
      this.fireDebug("Parsing Certificate Chain Finished...");
    }

    private void grabFromTik(Stream tik)
    {
      this.fireDebug("Scanning Ticket for Certificates...");
      int offset = 676;
      for (int index = 0; index < 3; ++index)
      {
        this.fireDebug("   Scanning at Offset 0x{0}:", (object) offset.ToString("x8"));
        try
        {
          tik.Seek((long) offset, SeekOrigin.Begin);
          byte[] array = new byte[1024];
          tik.Read(array, 0, array.Length);
          this.fireDebug("   Checking for Certificate CA...");
          if (this.isCertCa(array) && !this.certsComplete[1])
          {
            this.fireDebug("   Certificate CA detected...");
            this.certCa = array;
            this.certsComplete[1] = true;
            offset += 1024;
            continue;
          }
          this.fireDebug("   Checking for Certificate CP...");
          if (this.isCertCp(array) && !this.certsComplete[2])
          {
            this.fireDebug("   Certificate CP detected...");
            Array.Resize<byte>(ref array, 768);
            this.certCp = array;
            this.certsComplete[2] = true;
            offset += 768;
            continue;
          }
          this.fireDebug("   Checking for Certificate XS...");
          if (this.isCertXs(array))
          {
            if (!this.certsComplete[0])
            {
              this.fireDebug("   Certificate XS detected...");
              Array.Resize<byte>(ref array, 768);
              this.certXs = array;
              this.certsComplete[0] = true;
              offset += 768;
              continue;
            }
          }
        }
        catch
        {
        }
        offset += 768;
      }
      this.fireDebug("Scanning Ticket for Certificates Finished...");
    }

    private void grabFromTmd(Stream tmd)
    {
      this.fireDebug("Scanning TMD for Certificates...");
      byte[] buffer = new byte[2];
      tmd.Seek(478L, SeekOrigin.Begin);
      tmd.Read(buffer, 0, 2);
      int offset = 484 + (int) Shared.Swap(BitConverter.ToUInt16(buffer, 0)) * 36;
      for (int index = 0; index < 3; ++index)
      {
        this.fireDebug("   Scanning at Offset 0x{0}:", (object) offset.ToString("x8"));
        try
        {
          tmd.Seek((long) offset, SeekOrigin.Begin);
          byte[] array = new byte[1024];
          tmd.Read(array, 0, array.Length);
          this.fireDebug("   Checking for Certificate CA...");
          if (this.isCertCa(array) && !this.certsComplete[1])
          {
            this.fireDebug("   Certificate CA detected...");
            this.certCa = array;
            this.certsComplete[1] = true;
            offset += 1024;
            continue;
          }
          this.fireDebug("   Checking for Certificate CP...");
          if (this.isCertCp(array) && !this.certsComplete[2])
          {
            this.fireDebug("   Certificate CP detected...");
            Array.Resize<byte>(ref array, 768);
            this.certCp = array;
            this.certsComplete[2] = true;
            offset += 768;
            continue;
          }
          this.fireDebug("   Checking for Certificate XS...");
          if (this.isCertXs(array))
          {
            if (!this.certsComplete[0])
            {
              this.fireDebug("   Certificate XS detected...");
              Array.Resize<byte>(ref array, 768);
              this.certXs = array;
              this.certsComplete[0] = true;
              offset += 768;
              continue;
            }
          }
        }
        catch
        {
        }
        offset += 768;
      }
      this.fireDebug("Scanning TMD for Certificates Finished...");
    }

    private bool isCertXs(byte[] part)
    {
      if (part.Length < 768)
        return false;
      if (part.Length > 768)
        Array.Resize<byte>(ref part, 768);
      return part[388] == (byte) 88 && part[389] == (byte) 83 && Shared.CompareByteArrays(this.sha.ComputeHash(part), Shared.HexStringToByteArray("09787045037121477824BC6A3E5E076156573F8A"));
    }

    private bool isCertCa(byte[] part)
    {
      if (part.Length < 1024)
        return false;
      if (part.Length > 1024)
        Array.Resize<byte>(ref part, 1024);
      return part[644] == (byte) 67 && part[645] == (byte) 65 && Shared.CompareByteArrays(this.sha.ComputeHash(part), Shared.HexStringToByteArray("5B7D3EE28706AD8DA2CBD5A6B75C15D0F9B6F318"));
    }

    private bool isCertCp(byte[] part)
    {
      if (part.Length < 768)
        return false;
      if (part.Length > 768)
        Array.Resize<byte>(ref part, 768);
      return part[388] == (byte) 67 && part[389] == (byte) 80 && Shared.CompareByteArrays(this.sha.ComputeHash(part), Shared.HexStringToByteArray("6824D6DA4C25184F0D6DAF6EDB9C0FC57522A41C"));
    }

    public event EventHandler<MessageEventArgs> Debug;

    private void fireDebug(string debugMessage, params object[] args)
    {
      EventHandler<MessageEventArgs> debug = this.Debug;
      if (debug == null)
        return;
      debug(new object(), new MessageEventArgs(string.Format(debugMessage, args)));
    }
  }
}
