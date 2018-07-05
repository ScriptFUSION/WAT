using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScriptFUSION.WarframeAlertTracker {
    internal sealed class Downloader {
        private WebClient Client { get; } = new WebClient();

        public async Task<string> Download(string address) {
            return Encoding.UTF8.GetString(await Client.DownloadDataTaskAsync(address));
        }
    }
}
