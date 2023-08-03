using Ratchet.UI.Bindings;
using RatchetMemoryApi;
using RatchetMemoryApi.Events;
using RatchetMemoryApi.Memory.Addresses;
using RatchetMemoryApi.Memory.Items;
using RatchetMemoryApi.Memory.Weapons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ratchet.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<WeaponBinder> weaponBinding;
        private ObservableCollection<ItemBinder> itemBinding;
        private ObservableCollection<ObjectBinder> objectBinding;
        internal PositionBinder PositionBinder { get; set; } = new PositionBinder();
        private AnimationBinder AnimationBinder { get; set; }

        internal ObservableCollection<ObjectBinder> ObjectBinder 
        { 
            get
            {
                if(objectBinding == null)
                {
                    objectBinding = new ObservableCollection<ObjectBinder>();

                    for(var i = 0; i < 2000; i++)
                    {
                        var objectBinder = new ObjectBinder();
                        objectBinder.Destructible = new Destructible(i * 0x100);
                        objectBinding.Add(objectBinder);
                    }
                }
                return objectBinding;
            }
        }

        internal ObservableCollection<ItemBinder> ItemBinder
        {
            get
            {
                if(itemBinding == null)
                {
                    itemBinding = new ObservableCollection<ItemBinder>();

                    foreach(var item in ItemContainer.Items.OrderBy(x => x.Name))
                    {
                        var itemBinder = new ItemBinder()
                        {
                            Item = item
                        };
                        item.NotifyOfChanges(20);
                        itemBinder.Subscribe();
                        itemBinding.Add(itemBinder);
                    }
                }
                return itemBinding;
            }
        }

        internal ObservableCollection<WeaponBinder> WeaponBinding
        {
            get
            {
                if(weaponBinding == null)
                {
                    weaponBinding = new ObservableCollection<WeaponBinder>();

                    foreach (var weapon in WeaponsContainer.Weapons)
                    {
                        var wepBinder = new WeaponBinder
                        {
                            Weapon = weapon
                        };
                        weapon.NotifyOfChanges(20);
                        wepBinder.Subscribe();
                        weaponBinding.Add(wepBinder);
                    }
                }
                return weaponBinding;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Initialize();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + ", reattempting in 5 seconds.");
            }
        }

        private void Initialize()
        {
            WeaponGrid.ItemsSource = WeaponBinding;
            AnimationBinder = new AnimationBinder();

            var weaponIdList = new List<WeaponMap>();
            foreach (var id in Enum.GetValues(typeof(WeaponMap)))
            {
                weaponIdList.Add((WeaponMap)id);
            }
            WeaponIDs.ItemsSource = weaponIdList.OrderBy(x => x.ToString());

            ItemsGrid.ItemsSource = ItemBinder;
            ObjectGrid.ItemsSource = ObjectBinder;
        }

        private void DelayedInitalize(object src, EventArgs e)
        {
            Initialize();
        }

        private void EnableAllItemsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(var item in ItemBinder)
            {
                item.IsEnabled = true;
            }
        }

        private void DisableAllItemsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in ItemBinder)
            {
                item.IsEnabled = false;
            }
        }

        private void UnlockAllWepsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(var wep in WeaponBinding)
            {
                wep.Weapon.UnlockAndSetMaxUpgrade();
            }
        }

        private void MaxAmmoButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(var wep in WeaponBinding)
            {
                wep.Weapon.SetMaxAmmo();
            }
        }

        private void StackAllOnMeButton_Click(object sender, RoutedEventArgs e)
        {
            var x = PositionBinder.X;
            var y = PositionBinder.Y;
            var z = PositionBinder.Z;

            //var helper = new Destructible();

            //for(var i = 1; i < 10000; i++)
            //{
            //    var offset = 0x100 * i;
            //    helper.MoveTo(offset, x + 1, y + 1, z + (i * 3));
            //    helper.SetVisible(offset, true);
            //}
        }

        private void ObjectGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection = ObjectGrid.SelectedIndex;
            var item = (ObjectBinder)ObjectGrid.Items[selection];

            item.TeleportToMe = !item.TeleportToMe;
        }
    }
}
