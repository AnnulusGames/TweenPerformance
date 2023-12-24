using System.Collections;
using AnimeRx;
using UniRx;

namespace TweenPerformance
{
    public sealed class AnimeRxFloatPropertyBenchmark : IBenchmark
    {
        public AnimeRxFloatPropertyBenchmark(int count)
        {
            targets = TestClass.CreateArray(count);
            disposables = new(count);
        }

        readonly TestClass[] targets;
        readonly CompositeDisposable disposables;

        public IEnumerator Setup()
        {
            yield break;
        }

        public void Run()
        {
            foreach (var target in targets)
            {
                Anime.Play(0f, 10f, Easing.Linear(100f))
                    .Subscribe(x => target.Value = x)
                    .AddTo(disposables);
            }
        }

        public void TearDown()
        {
            disposables.Dispose();
        }
    }
}