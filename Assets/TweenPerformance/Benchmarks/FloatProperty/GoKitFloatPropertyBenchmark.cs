using System.Collections;

namespace TweenPerformance
{
    public sealed class GoKitFloatPropertyBenchmark : IBenchmark
    {
        public GoKitFloatPropertyBenchmark(int count)
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
            GoTweenConfig goConfig = new();

            foreach (var target in targets)
            {
                goConfig.clearProperties();
                goConfig.floatProp(PropertyName, 10f);
                Go.to(target, 100f, goConfig);
            }
        }

        public void TearDown()
        {
            foreach (var target in targets)
            {
                Go.killAllTweensWithTarget(target);
            }
            UnityEngine.Object.Destroy(Go.instance);
        }
    }
}