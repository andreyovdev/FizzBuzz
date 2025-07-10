using FizzBuzz.Application;
using NUnit.Framework;

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
		public void GetOverlappings_ExampleInput_ReturnsExpectedResult()
		{
			string input = "One Two Three Four Five";
			string expectedOutput = "One Two Fizz Four Buzz";
			int expectedCount = 2;

			FizzBuzzResult result = _detector.GetOverlappings(input);

			Assert.That(result.Result, Is.EqualTo(expectedOutput));
			Assert.That(result.Matches, Is.EqualTo(expectedCount));
		}

		[Test]
		public void GetOverlappings_WordsOnly_ReturnsCorrectResult()
		{
			string input = "A B C D E F G H I J K L M N O";
			string expectedOutput = "A B Fizz D Buzz Fizz G H Fizz Buzz K Fizz M N FizzBuzz";
			int expectedCount = 7;

			FizzBuzzResult result = _detector.GetOverlappings(input);

			Assert.That(result.Result, Is.EqualTo(expectedOutput));
			Assert.That(result.Matches, Is.EqualTo(expectedCount));
		}

		[Test]
		public void GetOverlappings_WithPunctuation_ReturnsCorrectResult()
		{
			string input = "First, second. Third! Fourth? Fifth.";
			string expectedOutput = "First, second. Fizz! Fourth? Buzz.";
			int expectedCount = 2;

			FizzBuzzResult result = _detector.GetOverlappings(input);

			Assert.That(result.Result, Is.EqualTo(expectedOutput));
			Assert.That(result.Matches, Is.EqualTo(expectedCount));
		}

		[Test]
		public void GetOverlappings_NullInput_ThrowsArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => _detector.GetOverlappings(null));
		}

		[Test]
		public void GetOverlappings_EndsWithWord_CorrectlyProcessesLastWord()
		{
			string input = "Alpha Beta Gamma";
			string expectedOutput = "Alpha Beta Fizz";
			int expectedCount = 1;

			FizzBuzzResult result = _detector.GetOverlappings(input);

			Assert.That(result.Result, Is.EqualTo(expectedOutput));
			Assert.That(result.Matches, Is.EqualTo(expectedCount));
		}
	}
}