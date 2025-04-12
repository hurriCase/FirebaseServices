using System.Collections.Generic;

namespace Analytics.Runtime
{
    internal interface IAnalyticsService
    {
        void SendEvent(string eventName);
        void SendEvent(string eventName, Dictionary<string, string> parameters);
    }
}