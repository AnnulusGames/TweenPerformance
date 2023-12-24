using System.Collections;
using System.Linq;
using Aya.Tween;

namespace TweenPerformance
{
    public sealed class UTweenFloatPropertyBenchmark : IBenchmark
    {
        public UTweenFloatPropertyBenchmark(int count)
        {
            targets = TestClass.CreateArray(count);
        }

        readonly TestClass[] targets;

        public IEnumerator Setup()
        {
            yield break;
        }

        public void Run()
        {
            foreach (var target in targets)
            {
                UTween.Value(0f, 10f, 100f, x => target.Value = x);
            }
        }

        public void TearDown()
        {
            UnityEngine.Object.Destroy(TweenManager.Ins);
        }
    }
}