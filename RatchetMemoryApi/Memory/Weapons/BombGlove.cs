using RatchetMemoryApi.Memory.Addresses;
using System;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class BombGlove : WeaponBase
    {
        protected override WeaponToggles EnabledAddress => WeaponToggles.BOMB_GLOVE;

        protected override int? LevelAddress => throw new NotImplementedException();

        protected override WeaponSlots UpgradeAddress => WeaponSlots.BOMB_GLOVE;

        protected override WeaponAmmo? AmmoAddress => WeaponAmmo.BOMB_GLOVE;
    }
}
