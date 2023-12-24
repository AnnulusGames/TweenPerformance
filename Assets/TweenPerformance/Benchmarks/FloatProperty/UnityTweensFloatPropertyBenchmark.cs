using System;
using System.Collections;
using System.Linq;
using DG.Tweening;
using Tweens;
using UnityEngine;

namespace TweenPerformance
{
    public sealed class UnityTweensFloatPropertyBenchmark : IBenchmark
    {
        public UnityTweensFloatPropertyBenchmark(int count)
        {
            this.count = count;
            targets = TestClass.CreateArray(count);
        }

        readonly int count;
        readonly TestClass[] targets;
        GameObject bindTarget;

        public IEnumerator Setup()
        {
            bindTarget = new GameObject();
            yield break;
        }

        public void Run()
        {
            foreach (var target in targets)
            {
                var tween = new FloatTween
                {
                    from = 0f,
                    to = 10f,
                    duration = 100f,
                    onUpdate = (_, value) => target.Value = value,
                };
                bindTarget.AddTween(tween);
            }
        }

        public void TearDown()
        {
            bindTarget.CancelTweens();
            UnityEngine.Object.Destroy(bindTarget);
            bindTarget = null;
        }
    }
}