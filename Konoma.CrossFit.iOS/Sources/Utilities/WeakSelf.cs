using System;
using Foundation;

namespace Konoma.CrossFit
{
    /// <summary>
    /// Small wrapper around <see cref="WeakReference{T}"/> for easier access.
    /// </summary>
    /// <typeparam name="T">The target type.</typeparam>
    public class WeakSelf<T>
        where T : class
    {
        public WeakSelf(T target)
        {
            this.Reference = new WeakReference<T>(target);
        }

        private readonly WeakReference<T> Reference;

        public T? Get() => this.Reference.TryGetTarget(out var self) ? self : null;

        public void Do(Action<T> action)
        {
            if (this.Get() is T self)
            {
                action(self);
            }
        }
    }

    /// <summary>
    /// Extensions of <see cref="NSObject"/> to support <see cref="WeakSelf{T}"/>.
    /// </summary>
    public static class NSObjectWeakSelfExtensions
    {
        /// <summary>
        /// Gets a weak reference for the receiver.
        /// </summary>
        /// <typeparam name="T">The target type.</typeparam>
        /// <param name="self">The object to get a weak reference for.</param>
        /// <returns>A weak reference for the given target.</returns>
        public static WeakSelf<T> WeakSelf<T>(this T self)
            where T : NSObject
        {
            return new WeakSelf<T>(self);
        }
    }
}
