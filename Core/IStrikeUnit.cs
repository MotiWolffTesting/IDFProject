using System;

namespace IDFOperationFirstStrike
{
    public interface IStrikeUnit
    {
        string Name { get; set; }
        int Ammo { get; set; }
        int Fuel { get; set; }

        void Strike(Terrorist target, string officerName, IntelligenceMessage intel);

        bool CanStrike(string targetType);
    }
}