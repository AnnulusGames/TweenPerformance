using System.Collections;
using UnityEngine;
using Kovnir.FastTweener;
using Kovnir.FastTweener.Extension;

namespace TweenPerformance
{
    public class FastTweenerPositionBenchmark : IBenchmark
    {
        public FastTweenerPositionBenchmark(Transform[] transforms)
        {
            this.transforms = transforms;
        }

        readonly Transform[] transforms;

        public IEnumerator Setup()
        {
            var settings = new FastTweenerSettings()
            {
                DefaultEase = Ease.Linear,
                TaskPoolSize = transforms.Length,
                TransformExtensionsPoolSize = transforms.Length
            };
            FastTweener.Init(settings);
            yield break;
        }

        public void TearDown()
        {
            UnityEngine.Object.Destroy(GameObject.Find("FastTweener"));
        }

        public void Run()
        {
            foreach (var transform in transforms)
            {
                transform.TweenMove(Vector3.one, 100f);
            }
        }
    }
}