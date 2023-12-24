using System;
using System.Collections;
using NUnit.Framework;
using Unity.Entities;
using Unity.PerformanceTesting;
using UnityEngine.TestTools;

namespace TweenPerformance
{
    public abstract class FloatPropertyStartUpTestBase
    {
        public abstract int Count { get; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var system = World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<SimulationSystemGroup>();
            system.Enabled = false;
        }

        [TearDown]
        public void TearDown()
        {
            GC.Collect();
        }

        [UnityTest, Performance]
        public IEnumerator DOTween() => MeasureHelper.RunStartup(new DOTweenFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator GoKit() => MeasureHelper.RunStartup(new GoKitFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator GoKitLite() => MeasureHelper.RunStartup(new GoKitLiteFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator ZestKit() => MeasureHelper.RunStartup(new ZestKitFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator LeanTween() => MeasureHelper.RunStartup(new LeanTweenFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator PrimeTween() => MeasureHelper.RunStartup(new PrimeTweenFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator UTween() => MeasureHelper.RunStartup(new UTweenFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator AuraTween() => MeasureHelper.RunStartup(new AuraTweenFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator AnimeRx() => MeasureHelper.RunStartup(new AnimeRxFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator AnimeTask() => MeasureHelper.RunStartup(new AnimeTaskFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator UnityTweens() => MeasureHelper.RunStartup(new UnityTweensFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator FastTweener() => MeasureHelper.RunStartup(new FastTweenerFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator MagicTween() => MeasureHelper.RunStartup(new MagicTweenFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator LitMotion() => MeasureHelper.RunStartup(new LitMotionFloatPropertyBenchmark(Count));
    }

    public sealed class FloatPropertyStartUpTest_32000 : FloatPropertyStartUpTestBase
    {
        public override int Count => 32000;
    }

    public sealed class FloatPropertyStartUpTest_64000 : FloatPropertyStartUpTestBase
    {
        public override int Count => 64000;
    }
}