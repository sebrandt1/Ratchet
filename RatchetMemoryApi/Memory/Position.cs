using RatchetMemoryApi.Memory.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatchetMemoryApi.Memory
{
    public class Position
    {
        private int XAddress => (int)Positions.X;
        private int YAddress => (int)Positions.Y;
        private int ZAddress => (int)Positions.Z;

        public float X => MemoryReadWriteHandler.Instance.ReadFloat(XAddress);
        public float Y => MemoryReadWriteHandler.Instance.ReadFloat(YAddress);
        public float Z => MemoryReadWriteHandler.Instance.ReadFloat(ZAddress);

        public void SetPosition(float x, float y, float z)
        {
            MemoryReadWriteHandler.Instance.WriteFloat(XAddress, x);
            MemoryReadWriteHandler.Instance.WriteFloat(YAddress, y);
            MemoryReadWriteHandler.Instance.WriteFloat(ZAddress, z);
        }

        public void AddToPosition(Positions axis, float increment)
        {
            switch(axis)
            {
                case Positions.X:
                    var currentX = MemoryReadWriteHandler.Instance.ReadFloat(XAddress);
                    MemoryReadWriteHandler.Instance.WriteFloat(XAddress, currentX + increment);
                    break;

                case Positions.Y:
                    var currentY = MemoryReadWriteHandler.Instance.ReadFloat(XAddress);
                    MemoryReadWriteHandler.Instance.WriteFloat(YAddress, currentY + increment);
                    break;

                case Positions.Z:
                    var currentZ = MemoryReadWriteHandler.Instance.ReadFloat(XAddress);
                    MemoryReadWriteHandler.Instance.WriteFloat(ZAddress, currentZ + increment);
                    break;
            }
        }

        public void FreezePosition(Positions axis)
        {
            switch(axis)
            {
                //Prevent change of pos
            }
        }
    }
}
