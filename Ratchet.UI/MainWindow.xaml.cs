using Ratchet.UI.Bindings;
using RatchetMemoryApi.Memory.Addresses;
using RatchetMemoryApi.Memory.Weapons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        internal PositionBinder PositionBinder { get; set; } = new PositionBinder();

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

                        weaponBinding.Add(wepBinder);
                    }
                }
                return weaponBinding;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            WeaponGrid.ItemsSource = WeaponBinding;

            var weaponIdList = new List<WeaponMap>();

            foreach(var id in Enum.GetValues(typeof(WeaponMap)))
            {
                weaponIdList.Add((WeaponMap)id);
            }

            WeaponIDs.ItemsSource = weaponIdList.OrderBy(x => x.ToString());
            PositionTypeOptions.ItemsSource = Enum.GetValues(typeof(Positions));
            PositionTypeOptions.SelectedItem = PositionBinder.SelectedIncrementPosition;
            XPosTextBox.Text = PositionBinder.X.ToString();
            YPosTextBox.Text = PositionBinder.Y.ToString();
            ZPosTextBox.Text = PositionBinder.Z.ToString();
        }

        private void IncrementPositionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!float.TryParse(IncrementPositionTextBox.Text, out var value))
            {
                MessageBox.Show($"{value} was not of type {typeof(float)}.");
                return;
            }
            this.PositionBinder.PositionIncrement = value;
        }

        private void PositionTypeOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.PositionBinder.SelectedIncrementPosition = (Positions)PositionTypeOptions.SelectedValue;
        }

        private void IncrementPositionButton_Click(object sender, RoutedEventArgs e)
        {
            if (PositionBinder.PositionIncrement <= 0)
                return;

            PositionBinder.IncrementPosition();
        }

        private void SetPositionButton_Click(object sender, RoutedEventArgs e)
        {
            PositionBinder.SetPosition(XPosTextBox.Text, YPosTextBox.Text, ZPosTextBox.Text);
        }
    }
}
