using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace IDFOperationFirstStrike
{
    public class M109 : StrikeOption
    {
        public M109()
        {
            Name = "M109 Artillery";
            Ammo = 40;
            Fuel = 60;
            CanBeUsedAgainst = new List<string> { "open areas" };
        }

        public override void Strike(Terrorist target, string officerName, IntelligenceMessage intel)
        {
            if (Ammo < 3)
            {
                Console.WriteLine($"Srike failed. {Name} is out of ammunition.");
                return;
            }
            if (Fuel < 8)
            {
                Console.WriteLine($"Srike failed. {Name} ran out of fuel.");
                return;
            }

            Console.WriteLine($"[Strike] {Name} fired multiple artillery ammunitions on {target.Name} in {intel.Location}.");
            Console.WriteLine($"Strike Details: Officer {officerName} approved the strike based on intel from {intel.Timestamp:dd:MM-yyyy HH:mm:ss}");

            Ammo -= 3;
            Fuel -= 8;
            target.IsAlive = false;

            Console.WriteLine($"Strike Result: Target {target.Name} has been killed as a hobby.");
            Console.WriteLine($"Status: {Name} remaining ammunition: {Ammo}, fuel: {Fuel}%");
        }

        public int StrikeMulitpeleTargets(List<Terrorist> targets, string officerName, IntelligenceMessage intel)
        {
            if (targets == null || targets.Count == 0)
            {
                Console.WriteLine("Strike failed: No valid targets provided.");
                return 0;
            }

            // Can target up to 3 targets at once
            int targetCount = Math.Min(targets.Count, 3);

            if (Ammo < targetCount * 3)
            {
                Console.WriteLine($"Strike failed: {Name} has insufficient ammunition for multiple targets.");
                return 0;
            }
            if (Fuel < 15)
            {
                Console.WriteLine($"Srike failed. {Name} ran out of fuel.");
                return 0;
            }

            Console.WriteLine($"Multi-Strike: {Name} firing on {targetCount} targets in {intel.Location}.");
            Console.WriteLine($"Strike Details: Officer {officerName} approved the multi-strike.");

            int eliminationCount = 0;
            foreach (var target in targets.Take(targetCount))
            {
                target.IsAlive = false;
                eliminationCount++;
            }

            Ammo -= targetCount * 3;
            Fuel -= 15;

            Console.WriteLine($"Strike results: {eliminationCount} targets eliminated.");
            Console.WriteLine($"Status: {Name} remaining ammunition: {Ammo}, fuel: {Fuel}");

            return eliminationCount;
        }



        
    }

}