using System;
using System.Collections.Generic;

namespace IDFOperationFirstStrike
{
    // Map locations to target types for strike selection
    public static class LocationTargetTypeMapper
    {
        // Dictionary mapping location descriptions to target types
        private static Dictionary<string, string> _locationToTargetMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"home", "building"},
            {"in a car", "vehicles"},
            {"outside", "open areas"}
        };

        // Registers a new location-to-target mapping
        public static void RegisterLocationType(string location, string targetType)
        {
            _locationToTargetMap[location.ToLower()] = targetType.ToLower();
        }

        public static string GetTargetType(string location)
        {
            return _locationToTargetMap.TryGetValue(location.ToLower(), out string targetType) ? targetType : "People";
        }

        // Returns all registered location-to-target mappings
        public static Dictionary<string, string> GetAllMapping()
        {
            return new Dictionary<string, string>(_locationToTargetMap);
        }
    }
}