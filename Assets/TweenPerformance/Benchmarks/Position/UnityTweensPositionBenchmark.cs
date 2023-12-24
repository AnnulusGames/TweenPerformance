using System.Collections;
using UnityEngine;
using Tweens;

namespace TweenPerformance
{
    public class UnityTweensPositionBenchmark : IBenchmark
    {
        public UnityTweensPositionBenchmark(Transform[] transforms)
        {
            this.transforms = transforms;
        }

        readonly Transform[] transforms;

        public IEnumerator Setup() { yield break; }

        public void TearDown()
        {
            foreach (var transform in transforms) transform.gameObject.CancelTweens();
        }

        public void Run()
        {
            foreach (var transform in transforms)
            {
                var tween = new PositionTween
                {
                    to = Vector3.one,
                    duration = 100f,
                };
                transform.gameObject.AddTween(tween);
            }
        }
    }
}