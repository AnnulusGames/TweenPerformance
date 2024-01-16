using System.Collections;
using UnityEngine;
using LitMotion;
using LitMotion.Adapters;
using LitMotion.Extensions;

namespace TweenPerformance
{
    public class LitMotionPositionBenchmark : IBenchmark
    {
        public LitMotionPositionBenchmark(Transform[] transforms)
        {
            this.transforms = transforms;
        }

        readonly Transform[] transforms;

        public IEnumerator Setup()
        {
            MotionDispatcher.EnsureStorageCapacity<Vector3, NoOptions, Vector3MotionAdapter>(transforms.Length);
            yield break;
        }

        public void TearDown()
        {
            MotionDispatcher.Clear();
        }

        public void Run()
        {
            foreach (var transform in transforms)
            {
                LMotion.Create(Vector3.zero, Vector3.one, 100f).BindToPosition(transform);
            }
        }
    }
}