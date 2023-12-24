using System;
using System.Collections;
using System.Linq;
using Kovnir.FastTweener;
using UnityEngine;

namespace TweenPerformance
{
    public sealed class FastTweenerFloatPropertyBenchmark : IBenchmark
    {
        public FastTweenerFloatPropertyBenchmark(int count)
        {
            this.count = count;
            targets = TestClass.CreateArray(count);

        }

        readonly int count;
        readonly TestClass[] targets;

        public IEnumerator Setup()
        {
            var settings = new FastTweenerSettings()
            {
                DefaultEase = Ease.Linear,
                TaskPoolSize = count
            };
            FastTweener.Init(settings);
            yield break;
        }

        public void TearDown()
        {
            UnityEngine.Object.Destroy(GameObject.Find("FastTweener"));
        }

        public void Run()
        {
            foreach (var target in targets)
            {
                FastTweener.Float(0f, 10f, 100f, x => target.Value = x);
            }
        }
    }
}