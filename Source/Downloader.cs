using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScriptFUSION.WarframeAlertTracker {
    /// <summary>
    /// Asynchonously downloads HTTP data from multiple URLs concurrently.
    /// </summary>
    internal sealed class Downloader {
        private Func<WebClient> WebClientFactory { get; set; }

        private WebClient WebClient => WebClientFactory.Invoke();

        /// <summary>
        /// Initializes this instance with the specified WebClient factory method.
        ///
        /// A factory method is required because WebClient cannot process more than one request at once.
        /// A new client is created for every request to circumvent this issue.
        /// </summary>
        /// <param name="webClientFactory">WebClient factory method</param>
        public Downloader(Func<WebClient> webClientFactory) {
            WebClientFactory = webClientFactory;
        }

        public async Task<string> Download(string address) {
            return Encoding.UTF8.GetString(await WebClient.DownloadDataTaskAsync(address));
        }
    }
}
