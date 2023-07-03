using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class ShieldCharger : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.SHIELD_CHARGER;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.SHIELD_CHARGER;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.SHIELD_CHARGER;
    }
}
