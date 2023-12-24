using System;
using System.Collections;
using Unity.PerformanceTesting;

namespace TweenPerformance
{
    public static class MeasureHelper
    {
        public static IEnumerator RunStartup(IBenchmark benchmark)
        {
            yield return benchmark.Setup();
            Measure.Method(benchmark.Run)
                .WarmupCount(0)
                .MeasurementCount(1)
                .Run();
            benchmark.TearDown();
        }

        public static IEnumerator RunUpdate(IBenchmark benchmark)
        {
            yield return benchmark.Setup();
            benchmark.Run();
            yield return Measure.Frames()
                .WarmupCount(3)
                .MeasurementCount(600)
                .Run();
            benchmark.TearDown();
        }

        public static IEnumerator RunGCAlloc(IBenchmark benchmark, int arrayLength)
        {
            yield return benchmark.Setup();
            GC.Collect();
            var prev = GC.GetTotalMemory(true);
            benchmark.Run();
            var current = GC.GetTotalMemory(true);
            Measure.Custom(new SampleGroup("GC.Alloc", SampleUnit.Byte), (current - prev) / arrayLength);
            benchmark.TearDown();
        }
    }
}