using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RatchetMemoryApi.Memory.Weapons
{
    public class WeaponsContainer
    {
        private static List<WeaponBase> weapons;
        public static List<WeaponBase> Weapons 
        {
            get
            {
                if(weapons == null || weapons.Count == 0)
                {
                    weapons = new List<WeaponBase>();

                    var weaponClasses = typeof(WeaponBase).Assembly.GetTypes().Where(t => t.BaseType == typeof(WeaponBase) && !t.IsAbstract);

                    foreach(var weaponClass in weaponClasses)
                    {
                        var weaponInstance = Activator.CreateInstance(weaponClass);
                        weapons.Add((WeaponBase)weaponInstance);
                    }
                }
                return weapons;
            }
        }
    }
}
