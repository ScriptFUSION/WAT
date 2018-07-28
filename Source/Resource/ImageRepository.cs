using System.Drawing;
using System.Threading.Tasks;

namespace ScriptFUSION.WarframeAlertTracker.Resource {
    internal sealed class ImageRepository {
        private ResourceDownloader Downloader { get; }

        private Task<Bitmap> lith;
        private Task<Bitmap> meso;
        private Task<Bitmap> neo;
        private Task<Bitmap> axi;

        public ImageRepository(ResourceDownloader downloader) {
            Downloader = downloader;
        }

        public Task<Bitmap> Lith => lith ?? (lith = Downloader.DownloadImage(ImageResource.RELIC_LITH));
        public Task<Bitmap> Meso => meso ?? (meso = Downloader.DownloadImage(ImageResource.RELIC_MESO));
        public Task<Bitmap> Neo => neo ?? (neo = Downloader.DownloadImage(ImageResource.RELIC_NEO));
        public Task<Bitmap> Axi => axi ?? (axi = Downloader.DownloadImage(ImageResource.RELIC_AXI));
    }
}
