using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class MiniturretGlove : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.MINITURRET_GLOVE;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.MINITURRET_GLOVE;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.MINITURRET_GLOVE;
    }
}
