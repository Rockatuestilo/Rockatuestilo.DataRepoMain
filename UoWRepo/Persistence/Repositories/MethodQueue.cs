using System;
using System.Threading;
using System.Threading.Tasks;

namespace UoWRepo.Persistence.Repositories
{
    public class MethodQueue
    {
        private SemaphoreSlim semaphore = new SemaphoreSlim(1);
        private Timer timer;
        private bool isProcessing = false;
        private object lockObject = new object();
        private TaskCompletionSource<bool> taskCompletionSource;

        public async Task<TOutput> QueueCalls<TOutput>(Func<TOutput> method, TimeSpan interval)
        {
            await semaphore.WaitAsync();

            lock (lockObject)
            {
                if (isProcessing)
                {
                    if (taskCompletionSource == null)
                    {
                        taskCompletionSource = new TaskCompletionSource<bool>();
                        timer = new Timer(TimerCallback, null, interval, TimeSpan.FromMilliseconds(-1));
                    }

                    var task = taskCompletionSource.Task;
                    semaphore.Release();
                    task.ConfigureAwait(false).GetAwaiter().GetResult();
                    semaphore.Wait();
                }

                isProcessing = true;
            }

            try
            {
                return await Task.Run(method);
            }
            finally
            {
                lock (lockObject)
                {
                    isProcessing = false;
                    semaphore.Release();
                }
            }
        }
        public TOutput QueueCallsSync<TOutput>(Func<TOutput> method, TimeSpan interval)
        {
            semaphore.Wait();

            lock (lockObject)
            {
                if (isProcessing)
                {
                    if (taskCompletionSource == null)
                    {
                        taskCompletionSource = new TaskCompletionSource<bool>();
                        timer = new Timer(TimerCallback, null, interval, TimeSpan.FromMilliseconds(-1));
                    }

                    var task = taskCompletionSource.Task;
                    semaphore.Release();
                    task.ConfigureAwait(false).GetAwaiter().GetResult();
                    semaphore.Wait();
                }

                isProcessing = true;
            }

            try
            {
                return method();
            }
            finally
            {
                lock (lockObject)
                {
                    isProcessing = false;
                    semaphore.Release();
                }
            }
        }

        private void TimerCallback(object state)
        {
            lock (lockObject)
            {
                taskCompletionSource?.TrySetResult(true);
                taskCompletionSource = null;
                timer.Dispose();
                timer = null;
            }
        }
    }
}