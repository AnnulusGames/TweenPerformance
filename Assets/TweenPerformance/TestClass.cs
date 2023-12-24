namespace TweenPerformance
{
    public sealed class TestClass
    {
        public float Value { get; set; }

        public static TestClass[] CreateArray(int count)
        {
            var array = new TestClass[count];
            for (int i = 0; i < array.Length; i++) array[i] = new TestClass();
            return array;
        }
    }
}