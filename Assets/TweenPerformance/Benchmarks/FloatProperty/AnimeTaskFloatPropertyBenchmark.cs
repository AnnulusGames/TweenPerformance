using System.Collections;
using System.Threading;
using AnimeTask;

namespace TweenPerformance
{
    public sealed class AnimeTaskFloatPropertyBenchmark : IBenchmark
    {
        public AnimeTaskFloatPropertyBenchmark(int count)
        {
            targets = TestClass.CreateArray(count);
            cts = new();
        }

        readonly TestClass[] targets;
        readonly CancellationTokenSource cts;

        public IEnumerator Setup()
        {
            yield break;
        }

        public void Run()
        {
            foreach (var target in targets)
            {
                Easing.Create<Linear>(0f, 10f, 100f).ToAction(x => target.Value = x, cancellationToken: cts.Token);
            }
        }

        public void TearDown()
        {
            cts.Cancel();
        }
    }
}