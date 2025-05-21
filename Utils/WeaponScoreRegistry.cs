using System;
using System.Collections.Generic;

namespace IDFOperationFirstStrike
{
    // Registering weapon scoring system, allowing addition of weapons without modifying code
    public static class Weapon
    {
        // Dictionary to match weapons with their score
        private static Dictionary<string, int> _weaponScore = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            {"knife", 1},
            {"gun", 2},
            {"m16", 3},
            {"ak47", 3}
        };

        public static void RegisterWeapon(string weaponName, int score)
        {
            _weaponScore[weaponName.ToLower()] = score;
        }

        // Return all registered weapons score
        public static Dictionary<string, int> GetAllWeaponScore()
        {
            return new Dictionary<string, int>(_weaponScore);
        }
    }
}