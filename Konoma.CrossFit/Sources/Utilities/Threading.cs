
using System;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Net.Http.Headers;

namespace Konoma.CrossFit
{
    public static class Threading
    {
        #region Initialization

        static Threading()
        {
            var providerType = TypeLoader.LoadPlatformType("Konoma.CrossFit.ThreadingProvider");
            Provider = (IThreadingProvider)Activator.CreateInstance(providerType);
        }

        #endregion

        #region Dependencies

        private static readonly IThreadingProvider Provider;

        #endregion

        #region Threading Utilities

        public static bool OnMainThread => Provider.OnMainThread;

        public static void CheckRunningOnMainThread()
        {
            if (!OnMainThread) { throw new InvalidOperationException("Must be called from the main thread"); }
        }

        public static void EnqueueOnMainThread(Action action) => Provider.EnqueueOnMainThread(action);

        public static Task ExecuteOnMainThreadAsync(Action action)
        {
            return ExecuteOnMainThreadAsync<object>(() =>
            {
                action();
                return null;
            });
        }

        public static Task<T> ExecuteOnMainThreadAsync<T>(Func<T> action)
        {
            var tcs = new TaskCompletionSource<T>();

            EnqueueOnMainThread(() =>
            {
                try
                {
                    tcs.SetResult(action());
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });

            return tcs.Task;
        }

        #endregion
    }

    internal interface IThreadingProvider
    {
        bool OnMainThread { get; }

        void EnqueueOnMainThread(Action action);
    }
}
