using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Firebase;
using Firebase.Analytics;
using JetBrains.Annotations;
using UnityEngine;

namespace Analytics.Runtime
{
    /// <summary>
    /// Firebase implementation of the analytics service for tracking user events and behavior.
    /// </summary>
    [UsedImplicitly]
    public sealed class FirebaseAnalyticsService : IAnalyticsService
    {
        private bool _isInitialized;

        /// <summary>
        /// Initializes Firebase Analytics service asynchronously.
        /// </summary>
        /// <returns>A UniTask representing the asynchronous initialization operation.</returns>
        [UsedImplicitly]
        public async UniTask InitializeAsync()
        {
            try
            {
                await FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
                {
                    var dependencyStatus = task.Result;
                    if (dependencyStatus == DependencyStatus.Available)
                    {
                        _isInitialized = true;
                        Debug.Log("[FirebaseAnalyticsService::Initialize] Firebase Analytics initialized successfully");
                    }
                    else
                        Debug.LogError("[FirebaseAnalyticsService::Initialize] " +
                                       $"Could not resolve all Firebase dependencies: {dependencyStatus}");
                });
            }
            catch (Exception e)
            {
                Debug.LogError("[FirebaseAnalyticsService::Initialize] FireBase initialization failed with exception:" +
                               $" {e.Message}");
            }
        }

        /// <summary>
        /// Sends an analytics event with the specified name.
        /// </summary>
        /// <param name="eventName">The name of the event to track.</param>
        [UsedImplicitly]
        public void SendEvent(string eventName)
        {
            if (_isInitialized is false)
            {
                Debug.LogWarning("[FirebaseAnalyticsService::SendEvent] " +
                                 $"Firebase not initialized yet. Event {eventName} not sent.");
                return;
            }

            Debug.Log($"[FirebaseAnalyticsService::SendEvent] Analytics Event: {eventName}");
            FirebaseAnalytics.LogEvent(eventName);
        }

        /// <summary>
        /// Sends an analytics event with the specified name and custom parameters.
        /// </summary>
        /// <param name="eventName">The name of the event to track.</param>
        /// <param name="parameters">A dictionary containing custom parameters to include with the event.</param>
        [UsedImplicitly]
        public void SendEvent(string eventName, Dictionary<string, string> parameters)
        {
            if (_isInitialized is false)
            {
                Debug.LogWarning("[FirebaseAnalyticsService::SendEvent] " +
                                 $"Firebase not initialized yet. Event {eventName} not sent.");
                return;
            }

            Debug.Log($"[FirebaseAnalyticsService::SendEvent] Analytics Event: {eventName} with parameters");

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