using System.Collections;
using UnityEngine;
using Uween;

namespace TweenPerformance
{
    public class UweenPositionBenchmark : IBenchmark
    {
        public UweenPositionBenchmark(Transform[] transforms)
        {
            this.transforms = transforms;
        }

        readonly Transform[] transforms;

        public IEnumerator Setup()
        {
            yield break;
        }

        public void TearDown()
        {
            foreach (var transform in transforms)
            {
                UnityEngine.Object.Destroy(transform.GetComponent<Tween>());
            }
        }

        public void Run()
        {
            foreach (var transform in transforms)
            {
                TweenXYZ.Add(transform.gameObject, 100f, Vector3.one);
            }
        }
    }
}