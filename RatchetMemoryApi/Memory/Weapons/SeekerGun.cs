using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class SeekerGun : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.SEEKER_GUN;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.SEEKER_GUN;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.SEEKER_GUN;
    }
}
