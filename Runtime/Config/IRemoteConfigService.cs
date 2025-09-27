using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace FirebaseServices.Runtime.Config
{
    /// <summary>
    /// Provides remote configuration management using Firebase Remote Config.
    /// </summary>
    [UsedImplicitly]
    public interface IRemoteConfigService
    {
        /// <summary>
        /// Initializes the remote config service and fetches the latest configuration.
        /// </summary>
        /// <param name="token">Cancellation token to cancel the initialization process.</param>
        /// <returns>A task representing the initialization operation.</returns>
        [UsedImplicitly]
        UniTask InitAsync(CancellationToken token);

        /// <summary>
        /// Gets a string value for the specified configuration key.
        /// </summary>
        /// <param name="key">The configuration key to retrieve.</param>
        /// <returns>The string value associated with the key, or default value if key not found.</returns>
        [UsedImplicitly]
        string GetString(string key);
    }
}