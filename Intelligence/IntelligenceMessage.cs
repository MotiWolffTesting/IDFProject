namespace IDFOperationFirstStrike
{
    // Intelligence message containing data about terrorists
    public class IntelligenceMessage
    {
        public Terrorist Target { get; set; }
        public string Location { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"Intel on {Target.Name} at {Location}, collected at {Timestamp:dd-MM-yyyy HH:mm:ss}";
        }
    }
}