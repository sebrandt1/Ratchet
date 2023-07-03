using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class Sheepinator : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.SHEEPINATOR;

        protected override int? LevelAddress => null;

        protected override WeaponSlots UpgradeAddress => WeaponSlots.SHEEPINATOR;

        protected override WeaponAmmo? AmmoAddress => null;
    }
}
