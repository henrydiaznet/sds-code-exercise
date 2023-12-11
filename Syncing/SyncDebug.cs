using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        //Here my best guess is that original Parallel.Foreach starts async tasks,
        //and doesn't wait until they complete, so the check in test might be executed before Task finishes. Parallel.ForEachAsync doesn't have that problem.
        //In general multithreading + async is confusing, bug-prone, hard to maintain, and should be avoided at all costs. Just use multithreading for CPU bound operations,
        //and async for IO operations, and you are good.
        public async Task<List<string>> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            await Parallel.ForEachAsync(items, async (i, _) => 
            {
                var r = await Task.Run(() => i).ConfigureAwait(false);
                bag.Add(r);
            });
            var list = bag.ToList();
            return list;
        }

        //I think the problem here is with multi-threading work should be balanced between threads, and duplication should be avoided.
        //ConcurrentDictionary functions as expected here, but the issue is the amount of collisions when trying to insert 
        //new keys, which stems from duplication of work between threads. So the solution would be to balance it,
        //such as with Parallel.Foreach
        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();
            var concurrentDictionary = new ConcurrentDictionary<int, string>();

            Parallel.ForEach(itemsToInitialize, new ParallelOptions { MaxDegreeOfParallelism = 3 }, i =>
            {
                concurrentDictionary.AddOrUpdate(i, getItem, (_, s) => s);
            });

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}