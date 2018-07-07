using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptFUSION.WarframeAlertTracker {
    internal sealed class SolNodesDownloader {
        private const string SOLNODES_URL = "https://raw.githubusercontent.com/WFCD/warframe-worldstate-data/master/data/solNodes.json";

        private Downloader Downloader { get; set; }

        public SolNodesDownloader(Downloader downloader) {
            Downloader = downloader;
        }

        public async Task<JObject> Download() {
            return JObject.Parse(await Downloader.Download(SOLNODES_URL));
        }
    }
}
