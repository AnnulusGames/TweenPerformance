using System;
using System.Collections;
using System.Linq;
using Prime31.ZestKit;
using UnityEngine;

namespace TweenPerformance
{
    public sealed class ZestKitFloatPropertyBenchmark : IBenchmark
    {
        public ZestKitFloatPropertyBenchmark(int count)
        {
            targets = TestClass.CreateArray(count);
        }

        readonly TestClass[] targets;
        const string PropertyName = "Value";

        public IEnumerator Setup()
        {
            yield break;
        }

        public void Run()
        {
            foreach (var target in targets)
            {
                PropertyTweens.floatPropertyTo(target, PropertyName, 10f, 100f).start();
            }
        }

        public void TearDown()
        {
            UnityEngine.Object.Destroy(ZestKit.instance);
        }
    }
}