using FizzBuzz.Application;

namespace FizzBuzz
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string input = Console.ReadLine()!;

			FizzBuzzDetector detector = new FizzBuzzDetector();

			FizzBuzzResult result = detector.GetOverlappings(input);

			Console.WriteLine("output string:");
			Console.WriteLine(result.Result); 
			Console.WriteLine("count:");
			Console.WriteLine(result.Matches);
		}
	}
}