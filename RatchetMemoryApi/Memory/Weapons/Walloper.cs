using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class Walloper : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.WALLOPER;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.WALLOPER;

        protected override WeaponAmmo? AmmoAddress => null;
    }
}
