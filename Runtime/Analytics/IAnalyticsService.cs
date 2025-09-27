using System.Collections.Generic;
using JetBrains.Annotations;

namespace FirebaseServices.Runtime.Analytics
{
    /// <summary>
    /// Provides an analytics service for tracking user events and behavior using Firebase Analytics.
    /// </summary>
    [UsedImplicitly]
    public interface IAnalyticsService
    {
        /// <summary>
        /// Sends an analytics event with the specified name.
        /// </summary>
        /// <param name="eventName">The name of the event to track.</param>
        [UsedImplicitly]
        void SendEvent(string eventName);

        /// <summary>
        /// Sends an analytics event with the specified name and custom parameters.
        /// </summary>
        /// <param name="eventName">The name of the event to track.</param>
        /// <param name="parameters">A dictionary containing custom parameters to include with the event.</param>
        [UsedImplicitly]
        void SendEvent(string eventName, Dictionary<string, string> parameters);
    }
}