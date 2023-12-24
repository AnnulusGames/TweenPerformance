using System.Collections;
using UnityEngine;

namespace TweenPerformance
{
    public class GoKitPositionBenchmark : IBenchmark
    {
        public GoKitPositionBenchmark(Transform[] transforms)
        {
            this.transforms = transforms;
        }

        readonly Transform[] transforms;

        public IEnumerator Setup() { yield break; }

        public void TearDown()
        {
            foreach (var transform in transforms)
            {
                Go.killAllTweensWithTarget(transform);
            }
            UnityEngine.Object.Destroy(Go.instance);
        }

        public void Run()
        {
            foreach (var transform in transforms)
            {
                transform.positionTo(100f, Vector3.one);
            }
        }
    }
}