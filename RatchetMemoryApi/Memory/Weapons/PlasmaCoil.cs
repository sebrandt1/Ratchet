using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class PlasmaCoil : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.PLASMA_COIL;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.PLASMA_COIL;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.PLASMA_COIL;
    }
}
