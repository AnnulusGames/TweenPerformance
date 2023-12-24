using System.Collections;
using UnityEngine;
using UrMotion;

namespace TweenPerformance
{
    public class UrMotionPositionBenchmark : IBenchmark
    {
        public UrMotionPositionBenchmark(Transform[] transforms)
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
                UnityEngine.Object.Destroy(transform.GetComponent<MotionBehaviourBase>());
            }
        }

        public void Run()
        {
            foreach (var transform in transforms)
            {
                transform.gameObject.MotionP3().AimAt(Vector3.one, 0.001f);
            }
        }
    }
}