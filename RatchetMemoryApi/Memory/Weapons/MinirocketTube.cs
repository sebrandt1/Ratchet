using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class MinirocketTube : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.MINIROCKET_TUBE;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.MINIROCKET_TUBE;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.MINIROCKET_TUBE;
    }
}
