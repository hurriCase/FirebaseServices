using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBeInternal
namespace Analytics.Runtime
{
    public interface IAnalyticsService
    {
        void SendEvent(string eventName);
        void SendEvent(string eventName, Dictionary<string, string> parameters);
    }
}