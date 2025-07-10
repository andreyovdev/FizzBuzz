namespace FizzBuzz.Application
{
	/// <summary>
	/// Represents the result of the FizzBuzz detection, containing the processed string and the count of coincidences.
	/// </summary>
	public class FizzBuzzResult
	{
		/// <summary>
		/// Gets or sets the output string with Fizz, Buzz, or FizzBuzz replacements.
		/// </summary>
		public string Result { get; set; } = null!;

		/// <summary>
		/// Gets or sets the total count of Fizz, Buzz, and FizzBuzz coincidences.
		/// </summary>
		public int Matches { get; set; }
	}
}
