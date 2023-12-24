using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace TweenPerformance
{
    public sealed class LeanTweenFloatPropertyBenchmark : IBenchmark
    {
        public LeanTweenFloatPropertyBenchmark(int count)
        {
            this.count = count;
            targets = TestClass.CreateArray(count);
        }

        readonly int count;
        readonly TestClass[] targets;

        public IEnumerator Setup()
        {
            LeanTween.init(count);
            yield break;
        }

        public void Run()
        {
            foreach (var target in targets)
            {
                LeanTween.value(0f, 10f, 100f).setOnUpdate(x => target.Value = x);
            }
        }

        public void TearDown()
        {
            LeanTween.cancelAll();
            var obj = GameObject.Find("~LeanTween");
            if (obj != null) UnityEngine.Object.Destroy(obj);
        }
    }
}