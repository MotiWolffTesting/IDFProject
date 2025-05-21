namespace IDFOperationFirstStrike
{
    public interface IIntelligenceAnalyzer
    {
        // Gets the terrorist with the most intelligence reports about them
        Terrorist GetMostReportedTerrorist();
    }
}