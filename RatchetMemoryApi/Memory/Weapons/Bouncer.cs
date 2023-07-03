using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class Bouncer : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.BOUNCER;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.BOUNCER;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.BOUNCER;
    }
}
