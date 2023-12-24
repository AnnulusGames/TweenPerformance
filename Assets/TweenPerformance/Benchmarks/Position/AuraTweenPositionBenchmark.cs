using System.Collections;
using UnityEngine;
using AuraTween;

namespace TweenPerformance
{
    public class AuraTweenPositionBenchmark : IBenchmark
    {
        public AuraTweenPositionBenchmark(Transform[] transforms)
        {
            this.transforms = transforms;
        }

        readonly Transform[] transforms; TweenManager tweenManager;

        public IEnumerator Setup()
        {
            tweenManager = new GameObject().AddComponent<TweenManager>();
            yield return null;
            tweenManager.SetCapacity(transforms.Length);
        }

        public void TearDown()
        {
            UnityEngine.Object.Destroy(tweenManager);
        }

        public void Run()
        {
            foreach (var transform in transforms)
            {
                tweenManager.Run(Vector3.zero, Vector3.one, 100f, x => transform.position = x, Easer.Linear);
            }
        }
    }
}