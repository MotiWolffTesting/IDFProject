using System;
using System.Collections.Generic;

namespace IDFOperationFirstStrike
{
    public abstract class StrikeOption : IStrikeUnit, IFuelConsuming
    {
        public string Name { get; set; }
        public int Ammo { get; set; }
        public int Fuel { get; set; }

        // List of target the unit can be activated against
        public List<string> CanBeUsedAgainst { get; set; }

        // Abstract method to activate strike on terror target
        public abstract void Strike(Terrorist target, string officerName, IntelligenceMessage intel);

        // Decides if a unit can handle a terror target
        public bool CanStrike(string targetType) => CanBeUsedAgainst.Contains(targetType.ToLower());

        // Refuels the unit back to maximum
        public virtual void Refuel()
        {
            Fuel = 100;
            Console.WriteLine($"{Name} has been fully refueld.");
        }


        
    }
}