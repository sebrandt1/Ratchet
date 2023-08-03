using RatchetMemoryApi.Memory;
using RatchetMemoryApi.Memory.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatchetMemoryApi
{
    public class Destructible
    {
		private static int ObjectOffset = 0x1c50000;
		private static int PositionOffset = 0x50;
		private static int XOffset = 0x0;
		private static int YOffset = 0x4;
		private static int ZOffset = 0x8;
		private static int StopAddress = 0x1d35000;

		private static int VisibilityOffset = 0x78;
		private static int ColorOffset = 0x7C;//; C=R, D=G, E=B, F=?
		private static int StateOffset = 0x60; //1 byte, sbyte
		private static int OpacityOffset = 0x63; //1 byte, sbyte
		private static int ScaleOffset = 0x6C; //Float
		private static int ModelOffset = 0x64; //2 bytes
		private static int TextureOffset = 0x62; //1 byte

		private int myOffset;
		public int MyAddress => ObjectOffset + myOffset;

		public Destructible(int offset)
        {
			myOffset = offset;
        }

		public ushort GetModelId()
        {
			var targetAddress = ObjectOffset + myOffset + ModelOffset;
			return MemoryReadWriteHandler.Instance.ReadUShort(targetAddress);
        }

		public void SetModelId(ushort id)
        {
			var targetAddress = ObjectOffset + myOffset + ModelOffset;
			MemoryReadWriteHandler.Instance.WriteUShort(targetAddress, id);
		}

		public byte GetOpacity()
        {
			var targetAddress = ObjectOffset + myOffset + OpacityOffset;
			return MemoryReadWriteHandler.Instance.ReadByte(targetAddress);
        }

		public void SetOpacity(byte value)
        {
				var targetAddress = ObjectOffset + myOffset + OpacityOffset;
				MemoryReadWriteHandler.Instance.WriteByte(targetAddress, value);
		}

		public void MoveTo(float x, float y, float z)
        {
			var targetAddress = ObjectOffset + myOffset;
			if (targetAddress > StopAddress)
            {
				return;
            }
			var positionAddress = targetAddress + PositionOffset;

			var a = positionAddress.ToString("X");

			MemoryReadWriteHandler.Instance.WriteFloat(positionAddress + XOffset, x);
			MemoryReadWriteHandler.Instance.WriteFloat(positionAddress + YOffset, y);
			MemoryReadWriteHandler.Instance.WriteFloat(positionAddress + ZOffset, z);
        }

		public void SetVisible(bool visibility)
        {
			var visible = visibility ? 3 : 0;

			var targetAddress = ObjectOffset + myOffset + VisibilityOffset;
			MemoryReadWriteHandler.Instance.WriteByte(targetAddress, (byte)visible);
        }
	}
}
