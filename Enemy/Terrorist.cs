using System;
using System.Collections.Generic;
using System.Linq;

namespace IDFOperationFirstStrike
{
    // Creates a terrorist to follow
    public class Terrorist
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public bool IsAlive { get; set; } = true;
        public List<string> Weapons { get; set; } = new List<string>();

        public int GetWeaponScore()
        {
            int score = Weapons.Sum(w => w.ToLower() switch
            {
                "knife" => 1,
                "gun" => 2,
                "m16" => 3,
                "ak47" => 3,
                _ => 0

            });
            return score * Rank;
        }

        public override string ToString()
        {
            string status = IsAlive ? "Active" : "Died as a hobby";
            string weaponsList = string.Join(", ", Weapons);

            return $"{Name} (Rank {Rank}, {status}) - armed with: {weaponsList}";

        }


    }
}