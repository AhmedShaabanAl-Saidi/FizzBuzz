namespace FizzBuzz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FizzBuzzDetector detector = new FizzBuzzDetector();

            string inputText = "Mary had a little lamb\nLittle lamb, little lamb\nMary had a little lamb\nIt's fleece was white as snow"; // Fizz = 5 , Buzz = 3 , FizzBuzz = 1 

            // Test cases

            //string inputText = "Mary had a little lamb\nLittle lamb"; // Fizz = 2 , Buzz = 1 

            //string inputText = "Mary"; // Exption thrown as input string length must be between 7 and 100 characters

            //string inputText = new string('a', 101); // Exption thrown as input string length must be between 7 and 100 characters

            //string inputText = null; // Exption thrown as input string cannot be null

            //string inputText = "!@#$%^&*()_+-=[]{}|;':\",./<>?\n!@#$%^&*()"; // Fizz = 0 , Buzz = 0 , FizzBuzz = 0

            var result = detector.GetOverlappings(inputText);

            Console.WriteLine("Output String: \n" + result["output_string"] + "\n");
            Console.WriteLine("Count: " + result["count"]);
        }
    }
}
