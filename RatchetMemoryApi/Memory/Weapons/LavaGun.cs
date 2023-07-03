using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class LavaGun : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.LAVA_GUN;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.LAVA_GUN;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.LAVA_GUN;
    }
}
