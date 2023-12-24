using System.Collections;
using UnityEngine;
using MagicTween;
using Unity.Entities;
using Unity.Mathematics;

namespace TweenPerformance
{
    public class MagicTweenPositionBenchmark : IBenchmark
    {
        public MagicTweenPositionBenchmark(Transform[] transforms)
        {
            this.transforms = transforms;
        }

        readonly Transform[] transforms;

        public IEnumerator Setup()
        {
            MagicTween.Core.TweenDelegatesNoAllocPool<float3>.Prewarm(transforms.Length + 100);
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

        public void Run()
        {
            foreach (var transform in transforms)
            {
                transform.TweenPosition(Vector3.one, 100f);
            }
        }
    }
}