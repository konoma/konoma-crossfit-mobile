
using System;
using System.Threading.Tasks;

namespace Konoma.CrossFit
{
    public interface IThreading
    {
        bool OnMainThread { get; }

        void EnqueueOnMainThread(Action action);
    }

    public static class ThreadingExtensions
    {
        public static void CheckRunningOnMainThread(this IThreading threading)
        {
            if (!threading.OnMainThread) { throw new InvalidOperationException("Must be called from the main thread"); }
        }

        public static Task ExecuteOnMainThreadAsync(this IThreading threading, Action action)
        {
            return ExecuteOnMainThreadAsync<object>(threading, () =>
            {
                action();
                return null;
            });
        }

        public static Task<T> ExecuteOnMainThreadAsync<T>(this IThreading threading, Func<T> action)
        {
            var tcs = new TaskCompletionSource<T>();

            threading.EnqueueOnMainThread(() =>
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
    }

    public static class ThreadingContextExtensions
    {
        public static IThreading GetThreading(this CrossFit.Context context) => context.GetService<IThreading>();
    }
}
