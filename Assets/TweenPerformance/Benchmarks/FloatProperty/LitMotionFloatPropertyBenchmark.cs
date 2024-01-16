using System;
using System.Collections;
using System.Linq;
using LitMotion;
using LitMotion.Adapters;
using UnityEngine;

namespace TweenPerformance
{
    public sealed class LitMotionFloatPropertyBenchmark : IBenchmark
    {
        public LitMotionFloatPropertyBenchmark(int count)
        {
            this.count = count;
            targets = TestClass.CreateArray(count);
        }

        readonly int count;
        readonly TestClass[] targets;

        public IEnumerator Setup()
        {
            MotionDispatcher.EnsureStorageCapacity<float, NoOptions, FloatMotionAdapter>(count);
            yield break;
        }

        public void Run()
        {
            foreach (var target in targets)
            {
                LMotion.Create(0f, 10f, 100f).BindWithState(target, (x, target) => target.Value = x);
            }
        }

        public void TearDown()
        {
            MotionDispatcher.Clear();
        }
    }
}