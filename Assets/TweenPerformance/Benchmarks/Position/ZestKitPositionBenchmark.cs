using System.Collections;
using UnityEngine;
using Prime31.ZestKit;

namespace TweenPerformance
{
    public class ZestKitPositionBenchmark : IBenchmark
    {
        public ZestKitPositionBenchmark(Transform[] transforms)
        {
            this.transforms = transforms;
        }

        readonly Transform[] transforms;

        public IEnumerator Setup() { yield break; }
        public void TearDown()
        {
            UnityEngine.Object.Destroy(ZestKit.instance);
        }

        public void Run()
        {
            foreach (var transform in transforms)
            {
                transform.ZKpositionTo(Vector3.one, 100f).start();
            }
        }
    }
}