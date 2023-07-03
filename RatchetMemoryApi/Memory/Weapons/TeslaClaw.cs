using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class TeslaClaw : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.TESLA_CLAW;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.TESLA_CLAW;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.TESLA_CLAW;
    }
}
