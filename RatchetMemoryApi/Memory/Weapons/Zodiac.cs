using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class Zodiac : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.ZODIAC;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.ZODIAC;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.ZODIAC;
    }
}
