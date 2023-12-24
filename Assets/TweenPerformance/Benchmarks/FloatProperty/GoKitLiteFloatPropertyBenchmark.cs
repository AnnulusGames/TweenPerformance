using System.Collections;
using Prime31.GoKitLite;

namespace TweenPerformance
{
    public sealed class GoKitLiteFloatPropertyBenchmark : IBenchmark
    {
        public GoKitLiteFloatPropertyBenchmark(int count)
        {
            targets = TestClass.CreateArray(count);
        }

        readonly TestClass[] targets;
        const string PropertyName = "Value";

        public IEnumerator Setup()
        {
            yield break;
        }

        public void Run()
        {
            foreach (var target in targets)
            {
                GoKitLite.instance.propertyTween(new Prime31.GoKitLite.FloatTweenProperty(target, PropertyName, 10f), 100f);
            }
        }

        public void TearDown()
        {
            UnityEngine.Object.Destroy(GoKitLite.instance);
        }
    }
}