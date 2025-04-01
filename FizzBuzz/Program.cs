namespace FizzBuzz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FizzBuzzDetector detector = new FizzBuzzDetector();

            string inputText = "Mary had a little lamb\nLittle lamb, little lamb\nMary had a little lamb\nIt's fleece was white as snow";

            var result = detector.GetOverlappings(inputText);

            Console.WriteLine("Output String: \n" + result["output_string"] + "\n");
            Console.WriteLine("Count: " + result["count"]);
        }
    }
}
