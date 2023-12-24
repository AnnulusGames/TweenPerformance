using System;
using System.Collections;
using System.Linq;
using DG.Tweening;

namespace TweenPerformance
{
    public sealed class DOTweenFloatPropertyBenchmark : IBenchmark
    {
        public DOTweenFloatPropertyBenchmark(int count)
        {
            this.count = count;
            targets = TestClass.CreateArray(count);
        }

        readonly int count;
        readonly TestClass[] targets;

        public IEnumerator Setup()
        {
            DOTween.Init().SetCapacity(count + 1, 0);
            yield break;
        }

        public void Run()
        {
            foreach (var target in targets)
            {
                DOTween.To(() => target.Value, x => target.Value = x, 10f, 100f);
            }
        }

        public void TearDown()
        {
            DOTween.Clear(true);
        }
    }
}