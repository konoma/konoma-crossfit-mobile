
using System;
using Foundation;
using CoreFoundation;

namespace Konoma.CrossFit
{
    public class Threading : IThreading
    {
        #region Threading

        public bool OnMainThread => NSThread.IsMain;

        public void EnqueueOnMainThread(Action action) => DispatchQueue.MainQueue.DispatchAsync(action);

        #endregion
    }
}
