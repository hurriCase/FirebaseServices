﻿using System.Collections.Generic;
using Firebase.Analytics;
using FirebaseServices.Runtime.Base;
using JetBrains.Annotations;

namespace FirebaseServices.Runtime.Analytics
{
    [UsedImplicitly]
    public sealed class AnalyticsService : IAnalyticsService
    {
        public void SendEvent(string eventName)
        {
            FirebaseLogger.Log($"[FirebaseAnalyticsService::SendEvent] Analytics Event: {eventName}");

            FirebaseAnalytics.LogEvent(eventName);
        }

        public void SendEvent(string eventName, Dictionary<string, string> parameters)
        {
            FirebaseLogger.Log($"[FirebaseAnalyticsService::SendEvent] Analytics Event: {eventName} with parameters");

            var firebaseParams = new Parameter[parameters.Count];
            var index = 0;

            foreach (var param in parameters)
            {
                firebaseParams[index++] = new Parameter(param.Key, param.Value);

                FirebaseLogger.Log($"[FirebaseAnalyticsService::SendEvent] Param: {param.Key}={param.Value}");
            }

            FirebaseAnalytics.LogEvent(eventName, firebaseParams);
        }
    }
}