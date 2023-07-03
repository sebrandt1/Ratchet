using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class PulseRifle : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.PULSE_RIFLE;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.PULSE_RIFLE;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.PULSE_RIFLE;
    }
}
