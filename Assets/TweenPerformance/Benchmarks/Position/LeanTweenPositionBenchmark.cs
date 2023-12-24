using System.Collections;
using UnityEngine;

namespace TweenPerformance
{
    public class LeanTweenPositionBenchmark : IBenchmark
    {
        public LeanTweenPositionBenchmark(Transform[] transforms)
        {
            this.transforms = transforms;
        }

        readonly Transform[] transforms;

        public IEnumerator Setup()
        {
            LeanTween.init(transforms.Length);
            yield break;
        }

        public void TearDown()
        {
            LeanTween.cancelAll();
            var obj = GameObject.Find("~LeanTween");
            if (obj != null) UnityEngine.Object.Destroy(obj);
        }

        public void Run()
        {
            foreach (var transform in transforms)
            {
                LeanTween.move(transform.gameObject, Vector3.positiveInfinity, 100f);
            }
        }
    }
}