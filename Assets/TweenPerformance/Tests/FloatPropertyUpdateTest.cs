using System;
using System.Collections;
using NUnit.Framework;
using Unity.Entities;
using Unity.PerformanceTesting;
using UnityEngine.TestTools;

namespace TweenPerformance
{
    public abstract class FloatPropertyUpdateTestBase
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
        public IEnumerator DOTween() => MeasureHelper.RunUpdate(new DOTweenFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator GoKit() => MeasureHelper.RunUpdate(new GoKitFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator GoKitLite() => MeasureHelper.RunUpdate(new GoKitLiteFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator ZestKit() => MeasureHelper.RunUpdate(new ZestKitFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator LeanTween() => MeasureHelper.RunUpdate(new LeanTweenFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator PrimeTween() => MeasureHelper.RunUpdate(new PrimeTweenFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator UTween() => MeasureHelper.RunUpdate(new UTweenFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator AuraTween() => MeasureHelper.RunUpdate(new AuraTweenFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator AnimeRx() => MeasureHelper.RunUpdate(new AnimeRxFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator AnimeTask() => MeasureHelper.RunUpdate(new AnimeTaskFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator UnityTweens() => MeasureHelper.RunUpdate(new UnityTweensFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator FastTweener() => MeasureHelper.RunUpdate(new FastTweenerFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator MagicTween() => MeasureHelper.RunUpdate(new MagicTweenFloatPropertyBenchmark(Count));

        [UnityTest, Performance]
        public IEnumerator LitMotion() => MeasureHelper.RunUpdate(new LitMotionFloatPropertyBenchmark(Count));
    }

    public sealed class FloatPropertyUpdateTest_32000 : FloatPropertyUpdateTestBase
    {
        public override int Count => 32000;
    }

    public sealed class FloatPropertyUpdateTest_64000 : FloatPropertyUpdateTestBase
    {
        public override int Count => 64000;
    }
}