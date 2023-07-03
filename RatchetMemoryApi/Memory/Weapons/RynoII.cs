using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class RynoII : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.RYNO_II;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.RYNO_II;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.RYNO_II;
    }
}
