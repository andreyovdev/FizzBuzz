using NUnit.Framework;
using FizzBuzz.Application;

namespace FizzBuzzDetectorTests
{
	/// <summary>
	/// Contains unit tests for the <see cref="FizzBuzzDetector"/> class.
	/// These tests verify the core logic, edge cases, and input validation of the GetOverlappings method.
	/// </summary>
	[TestFixture]
	public class FizzBuzzDetectorTests
	{
		private FizzBuzzDetector _detector;

		/// <summary>
		/// Sets up the test environment before each test method is executed.
		/// Initializes a new instance of <see cref="FizzBuzzDetector"/>.
		/// </summary>
		[SetUp]
		public void Setup()
		{
			_detector = new FizzBuzzDetector();
		}

		/// <summary>
		/// Verifies the GetOverlappings method with a simple input string,
		/// checking for correct Fizz and Buzz replacements and the total count.
		/// </summary>
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

		/// <summary>
		/// Verifies the GetOverlappings method with a longer sequence of words,
		/// ensuring correct application of Fizz, Buzz, and FizzBuzz rules.
		/// </summary>
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

		/// <summary>
		/// Verifies the GetOverlappings method's ability to handle punctuation correctly,
		/// ensuring only alphanumeric words are processed for FizzBuzz logic.
		/// </summary>
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

		/// <summary>
		/// Verifies that the GetOverlappings method throws an <see cref="ArgumentNullException"/>
		/// when provided with a null input string.
		/// </summary>
		[Test]
		public void GetOverlappings_NullInput_ThrowsArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => _detector.GetOverlappings(null));
		}

		/// <summary>
		/// Verifies that the GetOverlappings method correctly processes the last word in the input string
		/// when it is not followed by a non-alphanumeric character.
		/// </summary>
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
