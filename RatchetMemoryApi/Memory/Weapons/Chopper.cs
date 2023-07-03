using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class Chopper : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.CHOPPER;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.CHOPPER;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.CHOPPER;
    }
}
