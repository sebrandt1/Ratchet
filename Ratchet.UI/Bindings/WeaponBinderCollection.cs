using RatchetMemoryApi.Memory.Weapons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.UI.Bindings
{
    internal class WeaponBinderCollection
    {
        public ObservableCollection<WeaponBinder> WeaponBinderList { get; set; }

        public WeaponBinderCollection()
        {
            WeaponBinderList = new ObservableCollection<WeaponBinder>();

            foreach(var weapon in WeaponsContainer.Weapons)
            {
                var wepBinder = new WeaponBinder
                {
                    Enabled = weapon.IsEnabled(),
                    Ammo = weapon.GetAmmo(),
                    GunID = weapon.GetWeaponInMySlot()
                };

                WeaponBinderList.Add(wepBinder);
            }
        }
    }
}
