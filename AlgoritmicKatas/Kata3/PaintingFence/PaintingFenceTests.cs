using NUnit.Framework;

namespace PaintingFence
{
    public class PaintingFenceTests
    {
        [TestCase(new[] {  2, 2, 1, 2, 1}, 3)]
        [TestCase(new[] { 2, 2 }, 2)]
        [TestCase(new[] { 5 }, 1)]
        public void Tests(int[] numbers, int expected)
        {
            var result = Program.MinStrokes(numbers, 0, 0, numbers.Length - 1);

            Assert.AreEqual(expected, result);
        }
    }
}