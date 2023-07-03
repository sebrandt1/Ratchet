using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class Lancer : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.LANCER;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.LANCER;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.LANCER;
    }
}
