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

        private long BaseAddress => Pcsx2.BASE_ADDRESS;


        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(int hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

        private const string PROCESS_NAME = "pcsx2-qt";
        private const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        private IntPtr processHandle = IntPtr.Zero;

        private static object lockObject = new object();

        public static MemoryReadWriteHandler Instance
        {
            get
            {
                lock(lockObject)
                {
                    if (instance == null || instance.process == null || instance.process.HasExited)
                    {
                        instance = new MemoryReadWriteHandler();
                        instance.process = Process.GetProcessesByName(PROCESS_NAME).FirstOrDefault();

                        if (instance.process != null)
                        {
                            instance.processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, instance.process.Id);
                        }

                        if (instance.process == null)
                        {
                            throw new InvalidOperationException($"Process with name {PROCESS_NAME} was not found.");
                        }
                    }
                }
                return instance;
            }
        }

        #region WRITE DATA
        public void WriteBool(int offsetAddress, bool value)
        {
            var bytesWritten = 0;
            var bytes = BitConverter.GetBytes(value);
            WriteProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), bytes, bytes.Length, ref bytesWritten);
        }

        public void WriteByte(int offsetAddress, byte value)
        {
            var bytesWritten = 0;
            var bytes = new byte[1] { value };
            WriteProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), bytes, bytes.Length, ref bytesWritten);
        }

        public void WriteByteArray(int offsetAddress, byte[] value)
        {
            var bytesWritten = 0;
            var bytes = value;
            WriteProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), bytes, bytes.Length, ref bytesWritten);
        }

        public void WriteChar(int offsetAddress, char value)
        {
            var bytesWritten = 0;
            var bytes = BitConverter.GetBytes(value);
            WriteProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), bytes, bytes.Length, ref bytesWritten);
        }

        public void WriteDouble(int offsetAddress, double value)
        {
            var bytesWritten = 0;
            var bytes = BitConverter.GetBytes(value);
            WriteProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), bytes, bytes.Length, ref bytesWritten);
        }

        public void WriteFloat(int offsetAddress, float value)
        {
            var bytesWritten = 0;
            var bytes = BitConverter.GetBytes(value);
            WriteProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), bytes, bytes.Length, ref bytesWritten);
        }

        public void WriteShort(int offsetAddress, short value)
        {
            var bytesWritten = 0;
            var bytes = BitConverter.GetBytes(value);
            WriteProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), bytes, bytes.Length, ref bytesWritten);
        }

        public void WriteInt(int offsetAddress, int value)
        {
            var bytesWritten = 0;
            var bytes = BitConverter.GetBytes(value);
            WriteProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), bytes, bytes.Length, ref bytesWritten);
        }

        public void WriteLong(int offsetAddress, long value)
        {
            var bytesWritten = 0;
            var bytes = BitConverter.GetBytes(value);
            WriteProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), bytes, bytes.Length, ref bytesWritten);
        }

        public void WriteUShort(int offsetAddress, ushort value)
        {
            var bytesWritten = 0;
            var bytes = BitConverter.GetBytes(value);
            WriteProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), bytes, bytes.Length, ref bytesWritten);
        }

        public void WriteUInt(int offsetAddress, uint value)
        {
            var bytesWritten = 0;
            var bytes = BitConverter.GetBytes(value);
            WriteProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), bytes, bytes.Length, ref bytesWritten);
        }

        public void WriteULong(int offsetAddress, ulong value)
        {
            var bytesWritten = 0;
            var bytes = BitConverter.GetBytes(value);
            WriteProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), bytes, bytes.Length, ref bytesWritten);
        }
        #endregion

        #region READ DATA
        public bool ReadBool(int offsetAddress)
        {
            var bytesWritten = 0;
            var buffer = new byte[sizeof(bool)];
            ReadProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), buffer, buffer.Length, ref bytesWritten);

            return BitConverter.ToBoolean(buffer, 0);
        }

        public byte ReadByte(int offsetAddress)
        {
            var bytesWritten = 0;
            var buffer = new byte[sizeof(byte)];
            ReadProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), buffer, buffer.Length, ref bytesWritten);

            return buffer[0];
        }

        public byte[] ReadByteArray(int offsetAddress, uint size)
        {
            var bytesWritten = 0;
            var buffer = new byte[size];
            ReadProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), buffer, buffer.Length, ref bytesWritten);

            return buffer;
        }

        public char ReadChar(int offsetAddress)
        {
            var bytesWritten = 0;
            var buffer = new byte[sizeof(char)];
            ReadProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), buffer, buffer.Length, ref bytesWritten);

            return BitConverter.ToChar(buffer, 0);
        }

        public double ReadDouble(int offsetAddress)
        {
            var bytesWritten = 0;
            var buffer = new byte[sizeof(double)];
            ReadProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), buffer, buffer.Length, ref bytesWritten);

            return BitConverter.ToDouble(buffer, 0);
        }

        public float ReadFloat(int offsetAddress)
        {
            var bytesWritten = 0;
            var buffer = new byte[sizeof(float)];
            ReadProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), buffer, buffer.Length, ref bytesWritten);

            return BitConverter.ToSingle(buffer, 0);
        }

        public short ReadShort(int offsetAddress)
        {
            var bytesWritten = 0;
            var buffer = new byte[sizeof(short)];
            ReadProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), buffer, buffer.Length, ref bytesWritten);

            return BitConverter.ToInt16(buffer, 0);
        }

        public int ReadInt(int offsetAddress)
        {
            var bytesWritten = 0;
            var buffer = new byte[sizeof(int)];
            ReadProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), buffer, buffer.Length, ref bytesWritten);

            return BitConverter.ToInt32(buffer, 0);
        }

        public long ReadLong(int offsetAddress)
        {
            var bytesWritten = 0;
            var buffer = new byte[sizeof(long)];
            ReadProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), buffer, buffer.Length, ref bytesWritten);

            return BitConverter.ToInt64(buffer, 0);
        }

        public ushort ReadUShort(int offsetAddress)
        {
            var bytesWritten = 0;
            var buffer = new byte[sizeof(ushort)];
            ReadProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), buffer, buffer.Length, ref bytesWritten);

            return BitConverter.ToUInt16(buffer, 0);
        }

        public uint ReadUInt(int offsetAddress)
        {
            var bytesWritten = 0;
            var buffer = new byte[sizeof(uint)];
            ReadProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), buffer, buffer.Length, ref bytesWritten);

            return BitConverter.ToUInt32(buffer, 0);
        }

        public ulong ReadULong(int offsetAddress)
        {
            var bytesWritten = 0;
            var buffer = new byte[sizeof(ulong)];
            ReadProcessMemory((int)processHandle, (IntPtr)(BaseAddress + offsetAddress), buffer, buffer.Length, ref bytesWritten);

            return BitConverter.ToUInt64(buffer, 0);
        }
        #endregion
    }
}
