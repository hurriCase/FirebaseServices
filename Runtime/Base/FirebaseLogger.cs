using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace FirebaseServices.Runtime.Base
{
    internal static class FirebaseLogger
    {
        [Conditional("FIREBASE_LOG_ALL")]
        internal static void Log(string message)
        {
            Debug.Log(message);
        }
    }
}