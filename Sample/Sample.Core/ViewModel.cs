
using System;
using System.Threading.Tasks;
using Konoma.CrossFit;

namespace Sample.Core
{
    public class ViewModel
    {
        private int Counter = 0;

        public int IncreaseCounter()
        {
            var increase = DeviceInfo.Current.Platform == DevicePlatform.iOS ? 10 : 20;

            Task.Run(() =>
            {
                Console.WriteLine($"0 On main thread: {Threading.OnMainThread}");

                Threading.EnqueueOnMainThread(() =>
                {
                    Console.WriteLine($"1 On main thread: {Threading.OnMainThread}");
                });

                Console.WriteLine($"2 On main thread: {Threading.OnMainThread}");
            });

            this.Counter += increase;
            return this.Counter;
        }
    }
}
