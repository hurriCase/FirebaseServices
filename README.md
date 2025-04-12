# FirebaseAnalytics Package

A simple Unity integration package that provides a straightforward way to implement Firebase Analytics in your game.

## Features

- Easy integration with Firebase Analytics SDK
- Simple event tracking with or without parameters
- Debug logging for development

## Setup

1. Install the Firebase SDK in your Unity project
2. Add the FirebaseAnalyticsService to your project
3. Initialize and use the analytics service in your game code

## Usage Example

### Initializing the Analytics Service
```csharp
using Analytics.Runtime;
using UnityEngine;

public class AnalyticsManager : MonoBehaviour
{
    private FirebaseAnalyticsService _analyticsService;
    
    private void Awake()
    {
        // Create the analytics service
        _analyticsService = new FirebaseAnalyticsService();
            
        // The service will initialize itself
    }
    
    // Track a simple event
    public void TrackLevelStart(int levelId)
    {
        var parameters = new Dictionary<string, string>
        {
            { "level_id", levelId.ToString() },
            { "difficulty", "normal" }
        };
        
        _analyticsService.SendEvent("level_start", parameters);
    }
    
    // Track an event without parameters
    public void TrackAppOpen()
    {
        _analyticsService.SendEvent("app_open");
    }
}
```

## Implementation Details

The package consists of a single `FirebaseAnalyticsService` class that handles:

- Firebase initialization
- Sending events with and without parameters
- Debug logging

### FirebaseAnalyticsService Methods

- `Initialize()`: Automatically called during instantiation to set up Firebase
- `SendEvent(string eventName)`: Sends a simple event without parameters
- `SendEvent(string eventName, Dictionary<string, string> parameters)`: Sends an event with string parameters

## Debug Information

The service includes debug logging to help with development:
- Logs when Firebase is successfully initialized
- Logs when events are sent (including parameter information)
- Logs warnings when trying to send events before initialization

## Requirements

- Firebase Unity SDK
- .NET 4.x or later

## Notes

- Make sure Firebase is properly set up in your Unity project
- The service will handle initialization automatically
- Check debug logs to ensure events are being sent properly