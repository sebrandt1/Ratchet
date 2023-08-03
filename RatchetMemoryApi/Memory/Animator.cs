using RatchetMemoryApi.Memory.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatchetMemoryApi.Memory
{
    public class Animator
    {
        private int AnimationAddress => 0x01C44C83;
        public void SetAnimation(byte value)
        {
            MemoryReadWriteHandler.Instance.WriteByte(AnimationAddress, value);
        }

        public byte GetAnimation()
        {
            return MemoryReadWriteHandler.Instance.ReadByte(AnimationAddress);
        }
    }
}
