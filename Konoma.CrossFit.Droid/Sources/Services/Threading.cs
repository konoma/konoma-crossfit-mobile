
using System;
using Android.OS;

namespace Konoma.CrossFit
{
    public class ThreadingProvider : IThreadingProvider
    {
        #region Initialization

        public ThreadingProvider() : this(new Handler(Looper.MainLooper)) { }

        public ThreadingProvider(Handler handler)
        {
            this.Handler = handler;
        }

        #endregion

        #region Dependencies

        private readonly Handler Handler;

        #endregion

        #region Threading

        public bool OnMainThread => Looper.MainLooper.IsCurrentThread;

        public void EnqueueOnMainThread(Action action) => this.Handler.Post(action);

        #endregion
    }
}
