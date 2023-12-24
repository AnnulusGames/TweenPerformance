using System;
using System.Collections;
using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;
using UnityEngine.TestTools;

namespace TweenPerformance
{
    public abstract class PositionUpdateTestBase
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
        public IEnumerator AnimeRx() => MeasureHelper.RunUpdate(new AnimeRxPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator AnimeTask() => MeasureHelper.RunUpdate(new AnimeTaskPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator AuraTween() => MeasureHelper.RunUpdate(new AuraTweenPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator DOTween() => MeasureHelper.RunUpdate(new DOTweenPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator FastTweener() => MeasureHelper.RunUpdate(new FastTweenerPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator GoKit() => MeasureHelper.RunUpdate(new GoKitPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator GoKitLite() => MeasureHelper.RunUpdate(new GoKitLitePositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator iTween() => MeasureHelper.RunUpdate(new ITweenPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator LeanTween() => MeasureHelper.RunUpdate(new LeanTweenPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator LitMotion() => MeasureHelper.RunUpdate(new LitMotionPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator MagicTween() => MeasureHelper.RunUpdate(new MagicTweenPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator PrimeTween() => MeasureHelper.RunUpdate(new PrimeTweenPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator UnityTweens() => MeasureHelper.RunUpdate(new UnityTweensPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator UrMotion() => MeasureHelper.RunUpdate(new UrMotionPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator UTween() => MeasureHelper.RunUpdate(new UTweenPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator Uween() => MeasureHelper.RunUpdate(new UweenPositionBenchmark(transforms));

        [UnityTest, Performance]
        public IEnumerator ZestKit() => MeasureHelper.RunUpdate(new ZestKitPositionBenchmark(transforms));
    }

    public sealed class PositionUpdateTest_25000 : PositionUpdateTestBase
    {
        public override int Count => 25000;
    }

    public sealed class PositionUpdateTest_50000 : PositionUpdateTestBase
    {
        public override int Count => 50000;
    }
}