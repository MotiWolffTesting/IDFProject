using System;

namespace IDFOperationFirstStrike
{
    public class StrikeReport
    {
        // Time when strike ordered
        public DateTime TimeOfOrder { get; set; }

        // Terrorist target
        public Terrorist Target { get; set; }

        // Ammo used to strike
        public string AmmoUsed { get; set; }

        // Name of commadning officer
        public string OfficerName { get; set; }

        // Intelligence that led to the strike
        public IntelligenceMessage RelatedIntel { get; set; }

        // Strike unit executed the strike
        public IStrikeUnit StrikeUnit { get; set; }

        // If was successful
        public bool WasSuccessful { get; set; }

        public StrikeReport()
        {
            TimeOfOrder = DateTime.Now;
        }

        public StrikeReport(Terrorist target, IStrikeUnit strikeUnit, string officerName, IntelligenceMessage intel, bool successful)
        {
            TimeOfOrder = DateTime.Now;
            Target = target;
            AmmoUsed = $"{strikeUnit.Name} ammunition";
            OfficerName = officerName;
            RelatedIntel = intel;
            StrikeUnit = strikeUnit;
            WasSuccessful = successful;
        }

        public override string ToString()
        {
            string result = WasSuccessful ? "successful" : "failed";
            return $"Strike at {TimeOfOrder:dd-MM-yyyy HH:mm:ss}: {OfficerName} ordered {StrikeUnit.Name} to attack {Target.Name} at {RelatedIntel.Location}. " +
                   $"Result: {result}. Ammo used: {AmmoUsed}";
        }
    }
}