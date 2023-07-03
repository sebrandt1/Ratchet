using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class HoverbombGun : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.HOVERBOMB_GUN;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.HOVERBOMB_GUN;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.HOVERBOMB_GUN;
    }
}
