using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public abstract class WeaponBase
    {
        protected abstract WeaponToggles EnabledAddress { get; }
        //Not all weapons have levels
        protected abstract int? LevelAddress { get; }
        protected abstract WeaponSlots UpgradeAddress { get; }
        //Not all weapons have ammo
        protected abstract WeaponAmmo? AmmoAddress { get; }

        public void SetEnabled(bool enabled)
        {
            MemoryReadWriteHandler.Instance.WriteBool((int)EnabledAddress, enabled);
        }

        public void SetLevel(int value)
        {
            if(LevelAddress != null)
            {
                MemoryReadWriteHandler.Instance.WriteInt((int)LevelAddress, value);
            }
        }

        public void SetWeapon(WeaponMap value)
        {
            MemoryReadWriteHandler.Instance.WriteByte((int)UpgradeAddress, (byte)value);
        }


        public void SetAmmo(int value)
        {
            if(AmmoAddress != null)
            {
                MemoryReadWriteHandler.Instance.WriteInt((int)AmmoAddress, value);
            }
        }

        public WeaponMap GetWeaponInMySlot()
        {
            return (WeaponMap)MemoryReadWriteHandler.Instance.ReadByte((int)UpgradeAddress);
        }

        public int GetAmmo()
        {
            if (AmmoAddress != null)
            {
                return MemoryReadWriteHandler.Instance.ReadByte((int)AmmoAddress);
            }
            return -1;
        }

        public bool IsEnabled()
        {
            return MemoryReadWriteHandler.Instance.ReadBool((int)EnabledAddress);
        }
    }
}
