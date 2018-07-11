using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScriptFUSION.WarframeAlertTracker {
    /// <summary>
    /// Asynchonously downloads HTTP data from multiple URLs concurrently.
    ///
    /// A new client is created for every request because the underling client cannot process more than one concurrently.
    /// </summary>
    internal sealed class Downloader {
        private WebClient WebClient => new WebClient {
            // Workaround: avoid hanging the UI for 10 seconds whilst searching for proxies.
            // TODO: Consider spawning a new thread instead of disabling the proxy lookup.
            Proxy = null
        };

        public async Task<string> Download(string address) {
            return Encoding.UTF8.GetString(await WebClient.DownloadDataTaskAsync(address));
        }
    }
}
