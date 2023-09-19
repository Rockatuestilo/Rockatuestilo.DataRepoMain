using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace UoWRepo.Core.Configuration.ParallelRunning
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class SemaphoreActionsAttribute : Attribute
    {
        private static readonly Dictionary<string, SemaphoreSlim> semaphores = new Dictionary<string, SemaphoreSlim>();

        private int MaxParallelism { get; }

        public SemaphoreActionsAttribute(int maxParallelism)
        {
            MaxParallelism = maxParallelism;
        }

        public void RunWithSemaphore(Action action)
        {
            var callingMethod = new StackFrame(1).GetMethod();
            string methodName = callingMethod.Name;
            
            SemaphoreSlim semaphore;

            lock (semaphores)
            {
                if (!semaphores.TryGetValue(methodName, out semaphore))
                {
                    semaphore = new SemaphoreSlim(MaxParallelism);
                    semaphores.Add(methodName, semaphore);
                }
            }

            semaphore.Wait();

            try
            {
                action.Invoke();
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}