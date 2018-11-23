
using System;
using CoreFoundation;
using Foundation;

namespace Konoma.CrossFit
{
    public class ThreadingProvider : IThreadingProvider
    {
        #region Threading

        public bool OnMainThread => NSThread.IsMain;

        public void EnqueueOnMainThread(Action action) => DispatchQueue.MainQueue.DispatchAsync(action);

        #endregion
    }
}
