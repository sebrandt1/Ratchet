using RatchetMemoryApi.Events;
using RatchetMemoryApi.Memory.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratchet.UI.Bindings
{
    internal class ItemBinder : INotifyPropertyChanged
    {
        public bool IsEnabled 
        {
            get => Item.IsEnabled();
            set => Item.SetEnabled(value);
        }

        public string Name { get => Item.Name; }

        public ItemBase Item { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnStateChanged(object src, EnabledValueUpdatedArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEnabled)));
        }

        public void Subscribe()
        {
            Item.EnabledValueChangedEvent += OnStateChanged;
        }
    }
}
