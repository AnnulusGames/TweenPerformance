using System.Collections;
using AuraTween;
using UnityEngine;

namespace TweenPerformance
{
    public sealed class AuraTweenFloatPropertyBenchmark : IBenchmark
    {
        public AuraTweenFloatPropertyBenchmark(int count)
        {
            targets = TestClass.CreateArray(count);
            this.count = count;
        }

        readonly TestClass[] targets;
        readonly int count;
        TweenManager tweenManager;

        public IEnumerator Setup()
        {
            tweenManager = new GameObject().AddComponent<TweenManager>();
            yield return null;
            tweenManager.SetCapacity(count);
        }

        public void TearDown()
        {
            UnityEngine.Object.Destroy(tweenManager);
        }

        public void Run()
        {
            foreach (var target in targets)
            {
                tweenManager.Run(0f, 10f, 100f, x => target.Value = x, Easer.Linear, tweenManager);
            }
        }
    }
}