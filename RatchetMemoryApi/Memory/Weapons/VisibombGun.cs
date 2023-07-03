using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class VisibombGun : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.VISIBOMB_GUN;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.VISIBOMB_GUN;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.VISIBOMB_GUN;
    }
}
