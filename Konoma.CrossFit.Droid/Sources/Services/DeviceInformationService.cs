using System;
using Android.App;
using Android.Content.Res;
using Android.Util;

namespace Konoma.CrossFit
{
    public class DeviceInformationService : IDeviceInformationService
    {
        private const int MinimumWidthForTablet = 600;

        public DevicePlatform Platform => DevicePlatform.Android;

        public DeviceIdiom Idiom => this._Idiom.Value;

        private Lazy<DeviceIdiom> _Idiom = new Lazy<DeviceIdiom>(LookupDeviceIdiom);

        private static DeviceIdiom LookupDeviceIdiom()
        {
            if (Application.Context.Resources?.Configuration is Configuration configuration)
            {
                var minWidth = configuration.SmallestScreenWidthDp;
                var isWide = minWidth >= MinimumWidthForTablet;
                return isWide ? DeviceIdiom.Tablet : DeviceIdiom.Phone;
            }

            if (Application.Context.Resources?.DisplayMetrics is DisplayMetrics metrics)
            {
                var minSize = Math.Min(metrics.WidthPixels, metrics.HeightPixels);
                var isWide = (minSize * metrics.Density) >= MinimumWidthForTablet;
                return isWide ? DeviceIdiom.Tablet : DeviceIdiom.Phone;
            }

            return DeviceIdiom.Unknown;
        }
    }
}
