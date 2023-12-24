using System.Collections;
using UnityEngine;
using AnimeRx;
using UniRx;

namespace TweenPerformance
{
    public class AnimeRxPositionBenchmark : IBenchmark
    {
        public AnimeRxPositionBenchmark(Transform[] transforms)
        {
            this.transforms = transforms;
            disposables = new(transforms.Length);
        }

        readonly Transform[] transforms;
        readonly CompositeDisposable disposables;

        public IEnumerator Setup() { yield break; }
        public void TearDown()
        {
            disposables.Dispose();
        }

        public void Run()
        {
            foreach (var transform in transforms)
            {
                Anime.Play(Vector3.zero, Vector3.one, Easing.Linear(100f))
                    .Subscribe(x => transform.position = x)
                    .AddTo(disposables);
            }
        }
    }
}