using System.Drawing;

namespace ScriptFUSION.WarframeAlertTracker.Resource {
    internal static class ImageSanitizer {
        public static Bitmap Sanitize(ImageResource resource, Bitmap bitmap) {
            if (IsRelic(resource)) {
                return SanitizeRelic(bitmap);
            }

            return bitmap;
        }

        private static Bitmap SanitizeRelic(Bitmap bitmap) {
            var height = (int)(bitmap.Height * 2 / 3F);

            // Fix aspect ratio by scaling 66% in Y-axis.
            using (var resized = new Bitmap(bitmap, bitmap.Width, height)) {
                // Crop transparent edges in X-axis.
                return resized.Clone(new Rectangle((bitmap.Width - height) / 2, 0, height, height), bitmap.PixelFormat);
            }
        }

        private static bool IsRelic(ImageResource resource) {
            return resource == ImageResource.RELIC_LITH
                || resource == ImageResource.RELIC_MESO
                || resource == ImageResource.RELIC_NEO
                || resource == ImageResource.RELIC_AXI
            ;
        }
    }
}
