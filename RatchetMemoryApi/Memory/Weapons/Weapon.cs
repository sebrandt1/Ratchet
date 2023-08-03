using RatchetMemoryApi.Events;
using RatchetMemoryApi.Memory.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

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

        public EventHandler<WeaponUpdatedArgs> WeaponUpdatedEvent;

        private int previousAmmoValue;
        private WeaponMap previousWeaponValue;
        private bool previousEnabledValue;

        private Timer memoryValueChangedTimer;

        public WeaponBase NotifyOfChanges(double checkIntervalMs)
        {
            memoryValueChangedTimer = new Timer();
            memoryValueChangedTimer.Interval = checkIntervalMs;
            memoryValueChangedTimer.AutoReset = true;
            memoryValueChangedTimer.Elapsed += CheckForWeaponChanges;
            memoryValueChangedTimer.Start();

            return this;
        }

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
                return MemoryReadWriteHandler.Instance.ReadInt((int)AmmoAddress);
            }
            return -1;
        }

        public bool IsEnabled()
        {
            return MemoryReadWriteHandler.Instance.ReadBool((int)EnabledAddress);
        }

        private void CheckForWeaponChanges(object src, EventArgs e)
        {
            var hasChanged = false;

            var ammoFromMem = GetAmmo();
            if(ammoFromMem != previousAmmoValue)
            {
                previousAmmoValue = ammoFromMem;
                hasChanged = true;
            }

            var isEnabledFromMem = IsEnabled();
            if(isEnabledFromMem != previousEnabledValue)
            {
                previousEnabledValue = isEnabledFromMem;
                hasChanged = true;
            }

            var wepFromMem = GetWeaponInMySlot();
            if(wepFromMem != previousWeaponValue)
            {
                previousWeaponValue = wepFromMem;
                hasChanged = true;
            }

            if(hasChanged)
            {
                WeaponUpdatedEvent?.Invoke(this, new WeaponUpdatedArgs()
                {
                    Ammo = ammoFromMem,
                    IsEnabled = isEnabledFromMem,
                    WeaponId = wepFromMem
                });
            }
        }

        public void SetMaxAmmo()
        {
            if(AmmoAddress != null)
            { 
                MemoryReadWriteHandler.Instance.WriteInt((int)AmmoAddress, int.MaxValue - 1);
            }
        }

        public void UnlockAndSetMaxUpgrade()
        {
            SetEnabled(true);

            var myName = GetType().Name;
            var allWepsKvp = Enum.GetValues(typeof(WeaponMap))
                                .Cast<sbyte>()
                                .Select(x => new KeyValuePair<sbyte, string>(key: x, value: Enum.GetName(typeof(WeaponMap), x).Replace("_", "")))
                                .ToList();

            var wepMatches = new List<KeyValuePair<sbyte, string>>();

            foreach(var weapon in allWepsKvp)
            {
                var myNameLower = myName.ToLower();
                var wepNameLower = weapon.Value.ToLower();

                if(wepNameLower.Contains(myNameLower))
                {
                    wepMatches.Add(weapon);
                }
            }

            if (wepMatches.Any())
            {
                sbyte? weaponToSet = wepMatches.FirstOrDefault(x => x.Value.Contains("ULTRA")).Key;
                weaponToSet = weaponToSet != 0 ? weaponToSet : wepMatches.FirstOrDefault(x => x.Value.Contains("MEGA")).Key;
                weaponToSet = weaponToSet != 0 ? weaponToSet : wepMatches.FirstOrDefault(x => x.Value.Contains("UPGRADED")).Key;
                weaponToSet = weaponToSet != 0 ? weaponToSet : wepMatches.FirstOrDefault(x => x.Value.ToLower().Contains(myName.ToLower())).Key;


                if(weaponToSet != null)
                {
                    SetWeapon((WeaponMap)weaponToSet);
                }
            }
        }
        
    }
}
