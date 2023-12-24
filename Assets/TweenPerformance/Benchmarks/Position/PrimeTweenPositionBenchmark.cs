using System.Collections;
using UnityEngine;
using PrimeTween;

namespace TweenPerformance
{
    public class PrimeTweenPositionBenchmark : IBenchmark
    {
        public PrimeTweenPositionBenchmark(Transform[] transforms)
        {
            this.transforms = transforms;
        }

        readonly Transform[] transforms;

        public IEnumerator Setup()
        {
            PrimeTweenConfig.SetTweensCapacity(transforms.Length);
            yield break;
        }

        public void TearDown()
        {
            Tween.StopAll();
            UnityEngine.Object.Destroy(GameObject.Find("PrimeTweenManager"));
        }

        public void Run()
        {
            foreach (var transform in transforms)
            {
                Tween.Position(transform, Vector3.zero, Vector3.one, 100f);
            }
        }
    }
}