using System;
using System.Collections.Generic;
using System.Linq;

namespace IDFOperationFirstStrike
{
    public class Aman : IIntelligenceProvider, IIntelligenceAnalyzer
    {
        // Collection of intelligence messages
        public List<IntelligenceMessage> IntelMessages { get; set; } = new List<IntelligenceMessage>();

        // Generates and stores new intelligence about a terrorist
        public void GenerateIntel(Terrorist terrorist, string location)
        {
            IntelMessages.Add(new IntelligenceMessage
            {
                Target = terrorist,
                Location = location,
                Timestamp = DateTime.Now
            });

            Console.WriteLine($"Intelligence: New intelligence generated on {terrorist.Name} at {location}.");
        }

        // Gets all intelligence messages about a specific terrorist
        public List<IntelligenceMessage> GetIntelFor(Terrorist terrorist) =>
            IntelMessages
                .Where(i => i.Target == terrorist)
                .OrderByDescending(i => i.Timestamp)
                .ToList();


        // Gets the most recent intelligence message about a specific terrorist
        public IntelligenceMessage GetLatestIntel(Terrorist terrorist) =>
            GetIntelFor(terrorist).FirstOrDefault()!;

        // Gets the terrorist with the most intelligence reports about them
        public Terrorist GetMostReportedTerrorist() =>
            IntelMessages
                .GroupBy(i => i.Target)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault()?.Key!;

        // Gets intelligence reports newer than a specified time
        public List<IntelligenceMessage> GetRecentIntel(DateTime cutoffTime) =>
            IntelMessages
                .Where(i => i.Timestamp > cutoffTime)
                .OrderByDescending(i => i.Timestamp)
                .ToList();

        // Prints a summary of all intelligence reports
        public void PrintIntelSummary()
        {
            Console.WriteLine("\nIntel Summary");
            Console.WriteLine($"Total reports: {IntelMessages.Count}");

            var terroristGroups = IntelMessages
                .GroupBy(i => i.Target)
                .OrderByDescending(g => g.Count());

            foreach (var group in terroristGroups)
            {
                var terrorist = group.Key;
                var reports = group.ToList();
                var latestReports = reports.OrderByDescending(r => r.Timestamp).First();

                Console.WriteLine($"{terrorist.Name}: {reports.Count} reports, last seen at {latestReports.Location}");
            }
        }
    }
}