using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class GravityBomb : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.GRAVITY_BOMB;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.GRAVITY_BOMB;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.GRAVITY_BOMB;
    }
}
