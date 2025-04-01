using System.Text.RegularExpressions;

namespace FizzBuzz
{
    /// <summary>
    /// A class that implements the FizzBuzz algorithm for text processing.
    /// </summary>
    public class FizzBuzzDetector
    {
        /// <summary>
        /// Replaces every third word with "Fizz" and every fifth word with "Buzz".
        /// If a word is both the third and fifth word, it is replaced with "FizzBuzz".
        /// </summary>
        /// <param name="inputString">The input string to process.</param>
        /// <returns>A dictionary containing the processed output string and count of replacements.</returns>
        public Dictionary<string, object> GetOverlappings(string inputString)
        {
            if (inputString == null)
                throw new ArgumentNullException(nameof(inputString), "Input string cannot be null");

            if (inputString.Length < 7 || inputString.Length > 100)
                throw new ArgumentException("Input string length must be between 7 and 100 characters", nameof(inputString));

            // Split input by lines
            string[] lines = inputString.Split(new string[] { "\n" }, StringSplitOptions.None);
            List<string> outputLines = new List<string>();
            int count = 0;

            // Regular expression to match alphanumeric words
            Regex alphanumericRegex = new Regex(@"[a-zA-Z0-9']+");

            // Track the word position across all lines
            int wordPosition = 0;

            foreach (string line in lines)
            {
                // Use StringBuilder to construct the output line
                System.Text.StringBuilder outputLine = new System.Text.StringBuilder();
                int lastIndex = 0;

                // Find all alphanumeric words in the line
                foreach (Match match in alphanumericRegex.Matches(line))
                {
                    // Append any text between the previous word and this word
                    outputLine.Append(line.Substring(lastIndex, match.Index - lastIndex));

                    // Increment word position for each alphanumeric word
                    wordPosition++;

                    bool isThird = wordPosition % 3 == 0;
                    bool isFifth = wordPosition % 5 == 0;

                    if (isThird && isFifth)
                    {
                        outputLine.Append("FizzBuzz");
                        count++;
                    }
                    else if (isThird)
                    {
                        outputLine.Append("Fizz");
                        count++;
                    }
                    else if (isFifth)
                    {
                        outputLine.Append("Buzz");
                        count++;
                    }
                    else
                        // Keep the original word
                        outputLine.Append(match.Value);

                    lastIndex = match.Index + match.Length;
                }

                // Append any remaining text after the last word
                outputLine.Append(line.Substring(lastIndex));

                outputLines.Add(outputLine.ToString());
            }

            return new Dictionary<string, object>
            {
                 { "output_string", string.Join("\n", outputLines) },
                 { "count", count }
            };
        }
    }
}
