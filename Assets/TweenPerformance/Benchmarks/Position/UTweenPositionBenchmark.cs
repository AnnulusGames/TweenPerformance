using System.Collections;
using UnityEngine;
using Aya.Tween;

namespace TweenPerformance
{
    public class UTweenPositionBenchmark : IBenchmark
    {
        public UTweenPositionBenchmark(Transform[] transforms)
        {
            this.transforms = transforms;
        }

        readonly Transform[] transforms;

        public IEnumerator Setup() { yield break; }
        public void TearDown()
        {
            UnityEngine.Object.Destroy(TweenManager.Ins);
        }

        public void Run()
        {
            foreach (var transform in transforms)
            {
                UTween.Position(transform, Vector3.one, 100f);
            }
        }
    }
}