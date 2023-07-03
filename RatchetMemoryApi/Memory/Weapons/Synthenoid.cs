using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class Synthenoid : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.SYNTHENOID;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.SYNTHENOID;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.SYNTHENOID;
    }
}
