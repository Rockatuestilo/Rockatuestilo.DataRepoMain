using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UoWRepo.Persistence.Repositories;

public class ContextQueue
{
    private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1);
    private static readonly SemaphoreSlim semaphoreInput = new SemaphoreSlim(1);
    private static readonly SemaphoreSlim semaphoreGeneric = new SemaphoreSlim(1);

    private readonly ConcurrentDictionary<string, SemaphoreSlim> methodSemaphores = new ConcurrentDictionary<string, SemaphoreSlim>();
    
    public async Task<TOutput> Queue<TInput, TOutput>(Func<TInput, TOutput> method, TInput input)
    {
        var methodName = method.Method.ToString();

        await semaphore.WaitAsync();

        if (!methodSemaphores.ContainsKey(methodName))
        {
            methodSemaphores[methodName] = new SemaphoreSlim(1);
        }

        var methodSemaphore = methodSemaphores[methodName];

        await methodSemaphore.WaitAsync();
        semaphore.Release();

        try
        {
            return await Task.Run(() => method(input));
        }
        finally
        {
            methodSemaphore.Release();
        }
    }
    
    public async Task<TOutput> Queue<TOutput>(Func<TOutput> method)
    {
        var methodName = method.Method.ToString();

        await semaphoreGeneric.WaitAsync();

        if (!methodSemaphores.ContainsKey(methodName))
        {
            methodSemaphores[methodName] = new SemaphoreSlim(1);
        }

        var methodSemaphore = methodSemaphores[methodName];

        await methodSemaphore.WaitAsync();
        semaphoreGeneric.Release();

        try
        {
            return await Task.Run(method);
        }
        finally
        {
            methodSemaphore.Release();
        }
    }

    public async Task<IEnumerable<TEntity>> Queue<TEntity>(Func<IEnumerable<TEntity>> method)
    {
        var methodName = method.Method.ToString();

        await semaphore.WaitAsync();

        if (!methodSemaphores.ContainsKey(methodName))
        {
            methodSemaphores[methodName] = new SemaphoreSlim(1);
        }

        var methodSemaphore = methodSemaphores[methodName];

        await methodSemaphore.WaitAsync();
        semaphore.Release();

        try
        {
            return await Task.Run(method);
        }
        finally
        {
            methodSemaphore.Release();
        }
    }
}