using Konoma.CrossFit;

namespace Sample.Core
{
    public class ViewModel
    {
        private int Counter = 0;

        public int IncreaseCounter()
        {
            if (CrossFit.Shared.GetDeviceInfo().Check(DevicePlatform.iOS))
                this.Counter += 1;

            return this.Counter;
        }
    }
}
