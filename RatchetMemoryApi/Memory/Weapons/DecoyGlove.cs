using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class DecoyGlove : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.DECOY_GLOVE;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.DECOY_GLOVE;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.DECOY_GLOVE;
    }
}
