using FizzBuzz.Application;
using System.Text;

/// <summary>
/// Provides functionality to detect and replace words with "Fizz", "Buzz", or "FizzBuzz" based on their position.
/// This class processes only alphanumeric words, skipping other symbols and whitespaces.
/// </summary>
public class FizzBuzzDetector
{
	/// <summary>
	/// Processes an input string, replacing every third alphanumeric word with "Fizz", every fifth word with "Buzz",
	/// and words that are both third and fifth with "FizzBuzz".
	/// It also calculates the total number of such coincidences (Fizz, Buzz, or FizzBuzz each count as 1).
	/// </summary>
	/// <param name="inputString">The string to be processed. Must not be null and its length must be between 7 and 100 characters.</param>
	/// <returns>A <see cref="FizzBuzzResult"/> object containing the modified string and the coincidence count.</returns>
	/// <exception cref="ArgumentNullException">Thrown if the input string is null.</exception>
	/// <exception cref="ArgumentOutOfRangeException">Thrown if the input string's length is not between 7 and 100 characters.</exception>
	public FizzBuzzResult GetOverlappings(string inputString)
	{
		// Validate input string for null and length constraints.
		if (inputString == null)
		{
			throw new ArgumentNullException(nameof(inputString), "Input string cannot be null.");
		}
		if (inputString.Length < 7 || inputString.Length > 100)
		{
			throw new ArgumentOutOfRangeException(nameof(inputString),
				$"Input string length must be between 7 and 100 characters. Current length: {inputString.Length}.");
		}

		StringBuilder outputBuilder = new StringBuilder(); // Used for efficient string building.
		int coincidenceCount = 0; // Tracks the total count of Fizz, Buzz, or FizzBuzz replacements.
		int wordIndex = 0; // Increments for each alphanumeric word encountered.

		StringBuilder currentWordBuilder = new StringBuilder(); // Temporarily stores characters of the current word.

		// Iterate through each character of the input string.
		for (int i = 0; i < inputString.Length; i++)
		{
			char currentChar = inputString[i];

			// Check if the current character is part of an alphanumeric word.
			if (char.IsLetterOrDigit(currentChar))
			{
				currentWordBuilder.Append(currentChar);
			}
			else // Non-alphanumeric character (e.g., space, punctuation).
			{
				// If a word was being built, process it.
				if (currentWordBuilder.Length > 0)
				{
					wordIndex++; // Increment word counter.
					string originalWord = currentWordBuilder.ToString();
					string processedWord = originalWord; // Default to original word.

					bool isFizzPosition = (wordIndex % 3 == 0);
					bool isBuzzPosition = (wordIndex % 5 == 0);

					// Apply FizzBuzz logic based on word position.
					if (isFizzPosition && isBuzzPosition)
					{
						processedWord = "FizzBuzz";
						coincidenceCount++;
					}
					else if (isFizzPosition)
					{
						processedWord = "Fizz";
						coincidenceCount++;
					}
					else if (isBuzzPosition)
					{
						processedWord = "Buzz";
						coincidenceCount++;
					}

					outputBuilder.Append(processedWord); // Append the processed word.
					currentWordBuilder.Clear(); // Reset for the next word.
				}
				outputBuilder.Append(currentChar); // Always append the non-alphanumeric character.
			}
		}

		// Handle the last word if the string doesn't end with a non-alphanumeric character.
		if (currentWordBuilder.Length > 0)
		{
			wordIndex++;
			string originalWord = currentWordBuilder.ToString();
			string processedWord = originalWord;

			bool isFizzPosition = (wordIndex % 3 == 0);
			bool isBuzzPosition = (wordIndex % 5 == 0);

			if (isFizzPosition && isBuzzPosition)
			{
				processedWord = "FizzBuzz";
				coincidenceCount++;
			}
			else if (isFizzPosition)
			{
				processedWord = "Fizz";
				coincidenceCount++;
			}
			else if (isBuzzPosition)
			{
				processedWord = "Buzz";
				coincidenceCount++;
			}
			outputBuilder.Append(processedWord);
		}

		// Return the final result.
		return new FizzBuzzResult
		{
			Result = outputBuilder.ToString(),
			Matches = coincidenceCount
		};
	}
}