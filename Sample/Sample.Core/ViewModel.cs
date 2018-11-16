
using Konoma.CrossFit;

namespace Sample.Core
{
    public class ViewModel
    {
        private int Counter = 0;

        public int IncreaseCounter()
        {
            this.Counter += 1;
            return this.Counter;
        }
    }
}
