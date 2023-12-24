using System.Collections;
using Unity.Entities;
using MagicTween;

namespace TweenPerformance
{
    public sealed class MagicTweenFloatPropertyBenchmark : IBenchmark
    {
        public MagicTweenFloatPropertyBenchmark(int count)
        {
            this.count = count;
            targets = TestClass.CreateArray(count);
        }

        readonly int count;
        readonly TestClass[] targets;

        public void Run()
        {
            foreach (var target in targets)
            {
                Tween.FromTo(target, (obj, x) => obj.Value = x, 0f, 10f, 100f);
            }
        }

        public IEnumerator Setup()
        {
            MagicTween.Core.TweenDelegatesNoAllocPool<float>.Prewarm(count + 100);
            var system = World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<SimulationSystemGroup>();
            system.Enabled = true;
            yield break;
        }
        
        public void TearDown()
        {
            Tween.Clear();
            var system = World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<SimulationSystemGroup>();
            system.Enabled = false;
        }
    }

}