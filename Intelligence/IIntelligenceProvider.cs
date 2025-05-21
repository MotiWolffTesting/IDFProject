using System.Collections.Generic;

namespace IDFOperationFirstStrike
{
    public interface IIntelligenceProvider
    {
        // Gets all intelligence messages related to a specific terrorist
        List<IntelligenceMessage> GetIntelFor(Terrorist terrorist);

        // Gets the most recent intelligence message about a specific terrorist
        IntelligenceMessage GetLatestIntel(Terrorist terrorist);
    }
}