using System;
using System.Collections.Generic;
using Firebase;
using Firebase.Analytics;
using UnityEngine;

namespace Analytics.Runtime
{
    public class FirebaseAnalyticsService
    {
        private bool _isInitialized;

        private async void Initialize()
        {
            try
            {
                await FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
                {
                    var dependencyStatus = task.Result;
                    if (dependencyStatus == DependencyStatus.Available)
                    {
                        _isInitialized = true;
                        Debug.Log("Firebase Analytics initialized successfully");
                    }
                    else
                        Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
                });
            }
            catch (Exception e)
            {
                Debug.LogError("[FirebaseAnalyticsService::InitializeFirebase] FireBase initialization failed with exception:" +
                               $" {e.Message}");
            }
        }

        public void SendEvent(string eventName)
        {
            if (_isInitialized is false)
            {
                Debug.LogWarning($"Firebase not initialized yet. Event {eventName} not sent.");
                return;
            }

            Debug.Log($"Analytics Event: {eventName}");
            FirebaseAnalytics.LogEvent(eventName);
        }

        public void SendEvent(string eventName, Dictionary<string, string> parameters)
        {
            if (_isInitialized is false)
            {
                Debug.LogWarning($"Firebase not initialized yet. Event {eventName} not sent.");
                return;
            }

            Debug.Log($"Analytics Event: {eventName} with parameters");

            var firebaseParams = new Parameter[parameters.Count];
            var index = 0;

            foreach (var param in parameters)
            {
                firebaseParams[index++] = new Parameter(param.Key, param.Value);
                Debug.Log($"Param: {param.Key}={param.Value}");
            }

            FirebaseAnalytics.LogEvent(eventName, firebaseParams);
        }
    }
}