using System.Collections;

namespace TweenPerformance
{
    public interface IBenchmark
    {
        IEnumerator Setup();
        void TearDown();
        void Run();
    }
}