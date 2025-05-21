using System;
using System.Collections.Generic;

namespace IDFOperationFirstStrike
{
    public class Hermes : StrikeOption
    {
        public Hermes()
        {
            Name = "Hermes (Zik)";
            Ammo = 3;
            Fuel = 80;
            CanBeUsedAgainst = new List<string> { "people", "vehicles" };
        }

        public override void Strike(Terrorist target, string officerName, IntelligenceMessage intel)
        {
            if (Ammo <= 0)
            {
                Console.WriteLine($"Srike failed. {Name} is out of ammunition.");
                return;
            }
            if (Fuel < 5)
            {
                Console.WriteLine($"Srike failed. {Name} ran out of fuel.");
                return;
            }

            // Determine appropriate bomb type based on target location
            string bombType = intel.Location.ToLower() == "in a car" ? "anti-vehicle missile" : "precise missile";

            Console.WriteLine($"Strike: {Name} drone eliminated {target.Name} at {intel.Location} using {bombType}");
            Console.WriteLine($"Strike Details: Officer {officerName} approved the strike based on intel from {intel.Timestamp:dd:MM-yyyy HH:mm:ss}");

            Ammo--;
            Fuel -= 5;
            target.IsAlive = false;

            Console.WriteLine($"Strike Result: Target {target.Name} has been killed as a hobby. {Name} returning to base.");
            Console.WriteLine($"Status: {Name} remaining ammunition: {Ammo}, fuel: {Fuel}%");
        }

        public override void Refuel()
        {
            Fuel = 80;
            Console.WriteLine($"{Name} has been refueled to (maximum capacity)");
        }
    }
}