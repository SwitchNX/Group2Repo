
//Ryan's extra stuff

namespace GroupVersionControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int[] array1 = { 3, 8, 10, 1, 9, 14, -3, 0, 14, 207, 56, 98 };
            int[] array2 = { 17, 42, 3, 5, 5, 5, 8, 2, 4, 6, 1, 19 };
            Console.WriteLine($"The array {array1} has the longest sorted sequence of { LongestSortedSequence(array1)}");
            Console.WriteLine($"The array {array1} has the longest sorted sequence of {LongestSortedSequence(array1)}");
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