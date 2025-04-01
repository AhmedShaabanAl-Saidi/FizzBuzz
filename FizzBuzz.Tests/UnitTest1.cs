namespace FizzBuzz.Tests
{
    [TestFixture]
    public class FizzBuzzDetectorTests
    {
        private FizzBuzzDetector _detector;

        [SetUp]
        public void Setup()
        {
            _detector = new FizzBuzzDetector();
        }

        [Test]
        public void GetOverlappings_InputIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _detector.GetOverlappings(null));
        }

        [Test]
        public void GetOverlappings_InputLengthLessThan7_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _detector.GetOverlappings("Short"));
            StringAssert.Contains("Input string length must be between 7 and 100 characters", ex.Message);
        }

        [Test]
        public void GetOverlappings_InputLengthGreaterThan100_ThrowsArgumentException()
        {
            string longString = new string('a', 101);
            var ex = Assert.Throws<ArgumentException>(() => _detector.GetOverlappings(longString));
            StringAssert.Contains("Input string length must be between 7 and 100 characters", ex.Message);
        }

        [Test]
        public void GetOverlappings_ValidInput_ReturnsCorrectOutput()
        {
            string input = "Mary had a little lamb\nLittle lamb";
            var result = _detector.GetOverlappings(input);

            string expectedOutput = "Mary had Fizz little Buzz\nFizz lamb";
            Assert.AreEqual(expectedOutput, result["output_string"]);
            Assert.AreEqual(3, result["count"]);
        }

        [Test]
        public void GetOverlappings_MultiLineInput_ReturnsCorrectOutput()
        {
            string input = "!@#$%^&*()_+-=[]{}|;':\",./<>?\n!@#$%^&*()";
            var result = _detector.GetOverlappings(input);

            string expectedOutput = "!@#$%^&*()_+-=[]{}|;':\",./<>?\n!@#$%^&*()";
            Assert.AreEqual(expectedOutput, result["output_string"]);
            Assert.AreEqual(0, result["count"]);
        }
    }
}