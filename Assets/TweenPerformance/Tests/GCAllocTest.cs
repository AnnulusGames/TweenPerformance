using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using Unity.Collections;
using Unity.Entities;
using Unity.PerformanceTesting;
using UnityEngine;
using UnityEngine.TestTools;

namespace TweenPerformance
{
    public sealed class GCAllocTest
    {
        Transform[] transforms;
        
        class DummyManagedComponent : IComponentData { }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            transforms = new Transform[50000];
            for (int i = 0; i < transforms.Length; i++)
            {
                transforms[i] = new GameObject().transform;
            }

            // In Unity ECS, managed components are managed as a huge array, but the process of expanding this array may affect GC Allocation measurement.
            // To avoid this, add a Dummy managed component and adjust the array size in advance.
            var world = World.DefaultGameObjectInjectionWorld;
            var archetype = world.EntityManager.CreateArchetype(ComponentType.ReadWrite<DummyManagedComponent>());
            var entities = world.EntityManager.CreateEntity(archetype, transforms.Length + 10, Allocator.Temp);
            for (int i = 0; i < entities.Length; i++)
            {
                world.EntityManager.SetComponentData(entities[i], new DummyManagedComponent());
            }
            world.EntityManager.DestroyEntity(entities);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            for (int i = 0; i < transforms.Length; i++)
            {
                UnityEngine.Object.Destroy(transforms[i].gameObject);
            }
        }

        [UnityTest, Performance]
        public IEnumerator AnimeRx() => MeasureHelper.RunGCAlloc(new AnimeRxPositionBenchmark(transforms), transforms.Length);

        [UnityTest, Performance]
        public IEnumerator AnimeTask() => MeasureHelper.RunGCAlloc(new AnimeTaskPositionBenchmark(transforms), transforms.Length);

        [UnityTest, Performance]
        public IEnumerator AuraTween() => MeasureHelper.RunGCAlloc(new AuraTweenPositionBenchmark(transforms), transforms.Length);

        [UnityTest, Performance]
        public IEnumerator DOTween() => MeasureHelper.RunGCAlloc(new DOTweenPositionBenchmark(transforms), transforms.Length);

        [UnityTest, Performance]
        public IEnumerator FastTweener() => MeasureHelper.RunGCAlloc(new FastTweenerPositionBenchmark(transforms), transforms.Length);

        [UnityTest, Performance]
        public IEnumerator GoKit() => MeasureHelper.RunGCAlloc(new GoKitPositionBenchmark(transforms), transforms.Length);

        [UnityTest, Performance]
        public IEnumerator GoKitLite() => MeasureHelper.RunGCAlloc(new GoKitLitePositionBenchmark(transforms), transforms.Length);

        [UnityTest, Performance]
        public IEnumerator iTween() => MeasureHelper.RunGCAlloc(new ITweenPositionBenchmark(transforms), transforms.Length);

        [UnityTest, Performance]
        public IEnumerator LeanTween() => MeasureHelper.RunGCAlloc(new LeanTweenPositionBenchmark(transforms), transforms.Length);

        [UnityTest, Performance]
        public IEnumerator LitMotion() => MeasureHelper.RunGCAlloc(new LitMotionPositionBenchmark(transforms), transforms.Length);

        [UnityTest, Performance]
        public IEnumerator MagicTween() => MeasureHelper.RunGCAlloc(new MagicTweenPositionBenchmark(transforms), transforms.Length);

        [UnityTest, Performance]
        public IEnumerator PrimeTween() => MeasureHelper.RunGCAlloc(new PrimeTweenPositionBenchmark(transforms), transforms.Length);

        [UnityTest, Performance]
        public IEnumerator UnityTweens() => MeasureHelper.RunGCAlloc(new UnityTweensPositionBenchmark(transforms), transforms.Length);

        [UnityTest, Performance]
        public IEnumerator UrMotion() => MeasureHelper.RunGCAlloc(new UrMotionPositionBenchmark(transforms), transforms.Length);

        [UnityTest, Performance]
        public IEnumerator UTween() => MeasureHelper.RunGCAlloc(new UTweenPositionBenchmark(transforms), transforms.Length);

        [UnityTest, Performance]
        public IEnumerator Uween() => MeasureHelper.RunGCAlloc(new UweenPositionBenchmark(transforms), transforms.Length);

        [UnityTest, Performance]
        public IEnumerator ZestKit() => MeasureHelper.RunGCAlloc(new ZestKitPositionBenchmark(transforms), transforms.Length);
    }
}