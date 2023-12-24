using System.Collections;
using System.Threading;
using UnityEngine;
using AnimeTask;

namespace TweenPerformance
{
    public class AnimeTaskPositionBenchmark : IBenchmark
    {
        public AnimeTaskPositionBenchmark(Transform[] transforms)
        {
            this.transforms = transforms;
            cts = new();
        }

        readonly Transform[] transforms;
        readonly CancellationTokenSource cts;

        public IEnumerator Setup() { yield break; }
        public void TearDown()
        {
            cts.Cancel();
        }

        public void Run()
        {
            foreach (var transform in transforms)
            {
                Easing.Create<Linear>(Vector3.one, 100f)
                    .ToGlobalPosition(transform, cancellationToken: cts.Token);
            }
        }
    }
}