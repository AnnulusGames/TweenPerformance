using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace TweenPerformance
{
    public class DOTweenPositionBenchmark : IBenchmark
    {
        public DOTweenPositionBenchmark(Transform[] transforms)
        {
            this.transforms = transforms;
        }

        readonly Transform[] transforms;

        public IEnumerator Setup()
        {
            DOTween.Init().SetCapacity(transforms.Length + 1, 0);
            yield break;
        }

        public void TearDown()
        {
            DOTween.Clear(true);
        }

        public void Run()
        {
            foreach (var transform in transforms)
            {
                transform.DOMove(Vector3.one, 100f);
            }
        }
    }
}