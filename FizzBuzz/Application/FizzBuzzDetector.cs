using System.Text;

namespace FizzBuzz.Application
{
	public class FizzBuzzDetector
	{
		public FizzBuzzResult GetOverlappings(string inputString)
		{
			if (inputString == null)
			{
				throw new ArgumentNullException(nameof(inputString), "Input string cannot be null.");
			}
			if (inputString.Length < 7 || inputString.Length > 100)
			{
				throw new ArgumentOutOfRangeException(nameof(inputString),
					$"Input string length must be between 7 and 100 characters. Current length: {inputString.Length}.");
			}

			StringBuilder outputBuilder = new StringBuilder();
			int coincidenceCount = 0;
			int wordIndex = 0;

			StringBuilder currentWordBuilder = new StringBuilder();

			for (int i = 0; i < inputString.Length; i++)
			{
				char currentChar = inputString[i];

				if (char.IsLetterOrDigit(currentChar))
				{
					currentWordBuilder.Append(currentChar);
				}
				else
				{
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
						currentWordBuilder.Clear();
					}
					outputBuilder.Append(currentChar);
				}
			}

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

			return new FizzBuzzResult
			{
				Result = outputBuilder.ToString(),
				Matches = coincidenceCount
			};
		}
	}
}