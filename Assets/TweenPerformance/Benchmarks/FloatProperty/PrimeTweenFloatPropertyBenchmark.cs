using System;
using System.Linq;
using UnityEngine;
using PrimeTween;
using System.Collections;

namespace TweenPerformance
{
    public sealed class PrimeTweenFloatPropertyBenchmark : IBenchmark
    {
        public PrimeTweenFloatPropertyBenchmark(int count)
        {
            this.count = count;
            targets = TestClass.CreateArray(count);
        }

        readonly int count;
        readonly TestClass[] targets;

        public void Run()
        {
            foreach (var target in targets)
            {
                Tween.Custom(target, 0f, 10f, 100f, (obj, x) => obj.Value = x);
            }
        }

        public IEnumerator Setup()
        {
            PrimeTweenConfig.SetTweensCapacity(count);
            yield break;
        }

        public void TearDown()
        {
            Tween.StopAll();

            var obj = GameObject.Find("PrimeTweenManager");
            if (obj != null) UnityEngine.Object.Destroy(obj);
        }
    }

}