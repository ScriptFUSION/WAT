using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptFUSION.WarframeAlertTracker.Resource {
    internal class ResourceDownloader {
        private Dictionary<ImageResource, string> imageResourceToAddressMapping = new Dictionary<ImageResource, string> {
            { ImageResource.RELIC_LITH, "http://content.warframe.com/MobileExport/Lotus/Interface/Icons/VoidProjections/VoidProjectionsBronzeD.png" },
            { ImageResource.RELIC_MESO, "http://content.warframe.com/MobileExport/Lotus/Interface/Icons/VoidProjections/VoidProjectionsSilverD.png" },
            { ImageResource.RELIC_NEO, "http://content.warframe.com/MobileExport/Lotus/Interface/Icons/VoidProjections/VoidProjectionsGoldD.png" },
            { ImageResource.RELIC_AXI, "http://content.warframe.com/MobileExport/Lotus/Interface/Icons/VoidProjections/VoidProjectionsIronD.png" },
        };

        private Downloader Downloader { get; set; }

        public ResourceDownloader(Downloader downloader) {
            Downloader = downloader;
        }

        public async Task<Bitmap> DownloadImage(ImageResource resource) {
            return ImageSanitizer.Sanitize(resource, new Bitmap(await Downloader.DownloadStream(imageResourceToAddressMapping[resource])));
        }
    }
}
