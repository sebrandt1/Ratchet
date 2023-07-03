using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class BlitzGun : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.BLITZ_GUN;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.BLITZ_GUN;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.BLITZ_GUN;
    }
}
