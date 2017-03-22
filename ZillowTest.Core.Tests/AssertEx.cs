using System;
using System.Threading.Tasks;

namespace ZillowTest.Core.Tests
{
    public static class AssertEx
    {
        public static async Task<TException> ThrowsAsync<TException>(Func<Task> action,
          bool allowDerivedTypes = true) where TException : Exception
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                if (allowDerivedTypes && !(ex is TException))
                    throw new Exception("Delegate threw exception of type " +
                      ex.GetType().Name + ", but " + typeof(TException).Name +
                      " or a derived type was expected.", ex);
                if (!allowDerivedTypes && ex.GetType() != typeof(TException))
                    throw new Exception("Delegate threw exception of type " +
                      ex.GetType().Name + ", but " + typeof(TException).Name +
                      " was expected.", ex);
                return (TException)ex;
            }
            throw new Exception("Delegate did not throw expected exception " +
              typeof(TException).Name + ".");
        }

        /// <summary>
        /// Throw exception asynchronously in case of any error.
        /// </summary>
        /// <param name="action">function to execute.</param>
        /// <returns>Exception.</returns>
        public static Task<Exception> ThrowsAsync(Func<Task> action)
        {
            return ThrowsAsync<Exception>(action, true);
        }
    }
}
