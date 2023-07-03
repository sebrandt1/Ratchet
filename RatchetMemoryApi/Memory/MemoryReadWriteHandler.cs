using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using RatchetMemoryApi.Memory.Addresses;

namespace RatchetMemoryApi.Memory
{
    public class MemoryReadWriteHandler
    {
        private static MemoryReadWriteHandler instance;
        private Process process;
        private VAMemory vaMem;

        private long BaseAddress => Pcsx2.BASE_ADDRESS;


        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        private const string PROCESS_NAME = "pcsx2-qt";

        public static MemoryReadWriteHandler Instance
        {
            get
            {
                if (instance == null || instance.process == null || instance.vaMem == null || instance.process.HasExited)
                {
                    instance = new MemoryReadWriteHandler();
                    instance.process = Process.GetProcessesByName(PROCESS_NAME).FirstOrDefault();

                    if(instance.process == null)
                    {
                        throw new InvalidOperationException($"Process with name {PROCESS_NAME} was not found.");
                    }    

                    instance.vaMem = new VAMemory(instance.process.ProcessName);
                }
                return instance;
            }
        }

        #region WRITE DATA
        public void WriteBool(int offsetAddress, bool value)
        {
            vaMem.WriteBoolean((IntPtr)(BaseAddress + offsetAddress), value);
        }

        public void WriteByte(int offsetAddress, byte value)
        {
            vaMem.WriteByte((IntPtr)(BaseAddress + offsetAddress), value);
        }

        public void WriteByteArray(int offsetAddress, byte[] value)
        {
            vaMem.WriteByteArray((IntPtr)(BaseAddress + offsetAddress), value);
        }

        public void WriteChar(int offsetAddress, char value)
        {
            vaMem.WriteChar((IntPtr)(BaseAddress + offsetAddress), value);
        }

        public void WriteDouble(int offsetAddress, double value)
        {
            vaMem.WriteDouble((IntPtr)(BaseAddress + offsetAddress), value);
        }

        public void WriteFloat(int offsetAddress, float value)
        {
            vaMem.WriteFloat((IntPtr)(BaseAddress + offsetAddress), value);
        }

        public void WriteShort(int offsetAddress, short value)
        {
            vaMem.WriteInt16((IntPtr)(BaseAddress + offsetAddress), value);
        }

        public void WriteInt(int offsetAddress, int value)
        {
            vaMem.WriteInt32((IntPtr)(BaseAddress + offsetAddress), value);
        }

        public void WriteLong(int offsetAddress, long value)
        {
            vaMem.WriteInt64((IntPtr)(BaseAddress + offsetAddress), value);
        }

        public void WriteUShort(int offsetAddress, ushort value)
        {
            vaMem.WriteUInt16((IntPtr)(BaseAddress + offsetAddress), value);
        }

        public void WriteUInt(int offsetAddress, uint value)
        {
            vaMem.WriteUInt32((IntPtr)(BaseAddress + offsetAddress), value);
        }

        public void WriteULong(int offsetAddress, ulong value)
        {
            vaMem.WriteUInt64((IntPtr)(BaseAddress + offsetAddress), value);
        }
        #endregion

        #region READ DATA
        public bool ReadBool(int offsetAddress)
        {
            return vaMem.ReadBoolean((IntPtr)(BaseAddress + offsetAddress));
        }

        public byte ReadByte(int offsetAddress)
        {
            return vaMem.ReadByte((IntPtr)(BaseAddress + offsetAddress));
        }

        public byte[] ReadByteArray(int offsetAddress, uint size)
        {
            return vaMem.ReadByteArray((IntPtr)(BaseAddress + offsetAddress), size);
        }

        public char ReadChar(int offsetAddress)
        {
            return vaMem.ReadChar((IntPtr)(BaseAddress + offsetAddress));
        }

        public double ReadDouble(int offsetAddress)
        {
            return vaMem.ReadDouble((IntPtr)(BaseAddress + offsetAddress));
        }

        public float ReadFloat(int offsetAddress)
        {
            return vaMem.ReadFloat((IntPtr)(BaseAddress + offsetAddress));
        }

        public short ReadShort(int offsetAddress)
        {
           return vaMem.ReadShort((IntPtr)(BaseAddress + offsetAddress));
        }

        public int ReadInt(int offsetAddress)
        {
            return vaMem.ReadInt32((IntPtr)(BaseAddress + offsetAddress));
        }

        public long ReadLong(int offsetAddress)
        {
            return vaMem.ReadInt64((IntPtr)(BaseAddress + offsetAddress));
        }

        public ushort ReadUShort(int offsetAddress)
        {
            return vaMem.ReadUInt16((IntPtr)(BaseAddress + offsetAddress));
        }

        public uint ReadUInt(int offsetAddress)
        {
            return vaMem.ReadUInt16((IntPtr)(BaseAddress + offsetAddress));
        }

        public ulong ReadULong(int offsetAddress)
        {
            return vaMem.ReadUInt64((IntPtr)(BaseAddress + offsetAddress));
        }
        #endregion
    }
}
