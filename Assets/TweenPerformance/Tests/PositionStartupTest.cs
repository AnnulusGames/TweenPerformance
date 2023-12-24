using System;
using System.Collections;
using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;
using UnityEngine.TestTools;

namespace TweenPerformance
{
    public abstract class PositionStartupTestBase
    {
        public abstract int Count { get; }

        Transform[] transforms;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            transforms = new Transform[Count];
            for (int i = 0; i < transforms.Length; i++)
            {
                transforms[i] = new GameObject().transform;
            }
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
        public IEnumerator AnimeRx() => MeasureHelper.RunStartup(new AnimeRxPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator AnimeTask() => MeasureHelper.RunStartup(new AnimeTaskPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator AuraTween() => MeasureHelper.RunStartup(new AuraTweenPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator DOTween() => MeasureHelper.RunStartup(new DOTweenPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator FastTweener() => MeasureHelper.RunStartup(new FastTweenerPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator GoKit() => MeasureHelper.RunStartup(new GoKitPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator GoKitLite() => MeasureHelper.RunStartup(new GoKitLitePositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator iTween() => MeasureHelper.RunStartup(new ITweenPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator LeanTween() => MeasureHelper.RunStartup(new LeanTweenPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator LitMotion() => MeasureHelper.RunStartup(new LitMotionPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator MagicTween() => MeasureHelper.RunStartup(new MagicTweenPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator PrimeTween() => MeasureHelper.RunStartup(new PrimeTweenPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator UnityTweens() => MeasureHelper.RunStartup(new UnityTweensPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator UrMotion() => MeasureHelper.RunStartup(new UrMotionPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator UTween() => MeasureHelper.RunStartup(new UTweenPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator Uween() => MeasureHelper.RunStartup(new UweenPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator ZestKit() => MeasureHelper.RunStartup(new ZestKitPositionBenchmark(transforms));
    }

    public sealed class PositionStartupTest_25000 : PositionStartupTestBase
    {
        public override int Count => 25000;
    }

    public sealed class PositionStartupTest_50000 : PositionStartupTestBase
    {
        public override int Count => 50000;
    }
}