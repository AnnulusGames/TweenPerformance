using System.Collections;
using UnityEngine;
using Prime31.GoKitLite;

namespace TweenPerformance
{
    public class GoKitLitePositionBenchmark : IBenchmark
    {
        public GoKitLitePositionBenchmark(Transform[] transforms)
        {
            this.transforms = transforms;
        }

        readonly Transform[] transforms;

        public IEnumerator Setup() { yield break; }
        public void TearDown()
        {
            UnityEngine.Object.Destroy(GoKitLite.instance);
        }

        public void Run()
        {
            foreach (var transform in transforms)
            {
                GoKitLite.instance.positionTo(transform, 100f, Vector3.one);
            }
        }
    }
}