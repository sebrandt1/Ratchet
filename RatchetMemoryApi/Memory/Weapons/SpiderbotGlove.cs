using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class SpiderbotGlove : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.SPIDERBOT_GLOVE;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.SPIDERBOT_GLOVE;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.SPIDERBOT_GLOVE;
    }
}
