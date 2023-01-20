
//Ryan's extra stuff

//Hudson Ward

// Kai Gidwani




























// anthony cutris

namespace GroupVersionControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            
            Console.WriteLine(LastFirst("Wedge Antilles"));

            int[] array1 = { 3, 8, 10, 1, 9, 14, -3, 0, 14, 207, 56, 98 };
            int[] array2 = { 17, 42, 3, 5, 5, 5, 8, 2, 4, 6, 1, 19 };
            Console.WriteLine($"The array {array1} has the longest sorted sequence of {LongestSortedSequence(array1)}");
            Console.WriteLine($"The array {array1} has the longest sorted sequence of {LongestSortedSequence(array1)}");
        }

        /// <summary>
        /// Accepts a first and last name and returns it in lastname first initial format
        /// </summary>
        /// <param name="name">A first and last name</param>
        /// <returns>A string of the name in lastname first initial format</returns>
        static string LastFirst(string name)
        {
            // Trim excess spaces on the name
            name = name.Trim();

            // Save index of the space to separate the string
            int spaceLocation = name.IndexOf(" ");

            // Save the Lastname, minus the space, as the first part of output
            string output = name.Substring(spaceLocation + 1);

            // Adds the comma, space, firstname initial, and period to the end of output
            output = output + ($", {name.Substring(0, 1)}.");

            // Returns finished output
            return output;
        }

        /// <summary>
        /// Determines the longest sequence of increasing numbers in the array
        /// </summary>
        /// <param name="sequence">The array in which the sequence is looked for</param>
        /// <returns>The length of the longest sequence of increasing numbers</returns>
        public static int LongestSortedSequence(int[] sequence)
        {
            int longestSequence = 0;

            if(sequence.Length == 0)
            {
                return longestSequence;
            }

            int currentSequenceLength = 1;

            //Goes through every number in the array. If the number after the one it's on is bigger than it,
            //increases the sequence length.
            //If not, it updates the longest sequence length
            for (int i = 0; i < sequence.Length - 1; i++)
            { 
                if (sequence[i + 1] >= sequence[i])
                {
                    currentSequenceLength++;
                }
                else
                {
                    if (currentSequenceLength > longestSequence)
                    {
                        longestSequence = currentSequenceLength;
                    }
                    currentSequenceLength = 1;
                }
                
            }

            return longestSequence;
            
        }
    }
}


