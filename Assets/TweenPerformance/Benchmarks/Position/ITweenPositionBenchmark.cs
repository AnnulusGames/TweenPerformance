using System.Collections;
using UnityEngine;

namespace TweenPerformance
{
    public class ITweenPositionBenchmark : IBenchmark
    {
        public ITweenPositionBenchmark(Transform[] transforms)
        {
            this.transforms = transforms;
        }

        readonly Transform[] transforms;

        public IEnumerator Setup() { yield break; }
        public void TearDown()
        {
            iTween.Stop();
            foreach (var transform in transforms) UnityEngine.Object.Destroy(transform.GetComponent<iTween>());
        }

        public void Run()
        {
            foreach (var transform in transforms)
            {
                iTween.MoveTo(
                    transform.gameObject,
                    iTween.Hash("position", Vector3.one, "time", 100.0f, "easeType", iTween.EaseType.linear)
                );
            }
        }
    }
}