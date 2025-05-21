using System;
using System.Collections.Generic;

namespace IDFOperationFirstStrike
{
    public class F16 : StrikeOption
    {
        public string PilotName { get; set; }

        public F16(string pilotName = "Default Pilot")
        {
            Name = "F16";
            Ammo = 8;
            Fuel = 100;
            CanBeUsedAgainst = new List<string> { "buildings" };
            PilotName = pilotName;
        }

        public override void Strike(Terrorist target, string officerName, IntelligenceMessage intel)
        {
            if (Ammo <= 0)
            {
                Console.WriteLine($"Strike failed. F-16 occupied by {PilotName} is out of ammunitaion.");
                return;
            }
            if (Fuel < 10)
            {
                Console.WriteLine($"Strike failed. F-16 occupied by {PilotName} ran out of fuel.");
                return;
            }

            Console.WriteLine($"Strike: F-16 occupied by {PilotName} attacked {target.Name} at {intel.Location}");
            Console.WriteLine($"Strike Details: Officer {officerName} approved the strike based on intel from {intel.Timestamp:dd:MM-yyyy HH:mm:ss}.");

            Ammo--;
            Fuel -= 10;
            target.IsAlive = false;

            Console.WriteLine($"Strike Result: Target {target.Name} has been killed as a hobby. F-16 returning to base.");
            Console.WriteLine($"Status: F-16 remaining ammunition: {Ammo}, fuel: {Fuel}%");
        }
    }
}