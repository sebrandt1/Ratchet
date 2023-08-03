using RatchetMemoryApi.Events;
using RatchetMemoryApi.Memory;
using RatchetMemoryApi.Memory.Addresses;
using RatchetMemoryApi.Memory.Weapons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.UI.Bindings
{
    [DataContract]
    internal class WeaponBinder : INotifyPropertyChanged
    {
        [DataMember]
        public string SlotName 
        {
            get => Weapon.GetType().Name; 
        }

        [DataMember]
        public bool Enabled 
        { 
            get => Weapon.IsEnabled(); 
            set => Weapon.SetEnabled(value); 
        }

        [DataMember]
        public int Ammo 
        { 
            get => Weapon.GetAmmo(); 
            set => Weapon.SetAmmo(value); 
        }

        [DataMember]
        public WeaponMap GunID 
        { 
            get => Weapon.GetWeaponInMySlot(); 
            set => Weapon.SetWeapon(value); 
        }

        public WeaponBase Weapon { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnWeaponUpdated(object src, WeaponUpdatedArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GunID)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ammo)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Enabled)));
        }

        public void Subscribe()
        {
            Weapon.WeaponUpdatedEvent += OnWeaponUpdated;
        }

        public void Unsubscribe()
        {
            Weapon.WeaponUpdatedEvent -= OnWeaponUpdated;
        }
    }
}
