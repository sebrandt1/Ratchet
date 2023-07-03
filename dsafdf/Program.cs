using RatchetMemoryApi.Memory.Addresses;
using RatchetMemoryApi.Memory.Weapons;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace dsafdf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var wep in WeaponsContainer.Weapons)
            {
                var enabled = wep.IsEnabled() ? "Enabled" : "Disabled";
                Console.WriteLine($"{wep.GetType().Name}: {enabled} - {wep.GetWeaponInMySlot()}");
            }

            Console.ReadKey();
        }
    }
}
