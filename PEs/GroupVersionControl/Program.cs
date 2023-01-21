
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
            DiceSum();
            Console.WriteLine(PalindromeCheck());
        }

        /// <summary>
        /// Asks user for a sum of 2 dice rolls and rolls 2 dice until
        /// the sum input by the user is acheived
        /// </summary>
        static void DiceSum()
        {
            // variables for rolladge
            int diceSum;
            int randSum = 0;
            int roll1;
            int roll2;

            Random rand = new Random();

            // user input
            Console.Write("Desired dice sum: ");
            diceSum = int.Parse(Console.ReadLine()!);

            // if the user inputs an impossible result
            if(diceSum < 2 || diceSum > 12)
            {
                Console.WriteLine("Invalid sum");
            }
            else
            {
                // roll dice until the sum is the intended result
                while(randSum != diceSum)
                {
                    // the rolls and sum
                    roll1 = rand.Next(1, 7);
                    roll2 = rand.Next(1, 7);
                    randSum = roll1 + roll2;

                    // print results each time
                    Console.WriteLine($"{roll1} and {roll2} = {randSum}");
                }
            }

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
        static string PalindromeCheck()
        {
            Console.WriteLine("Enter a word:");
            String checkPalindrome = Console.ReadLine();
            checkPalindrome = checkPalindrome.Trim().ToLower();
            Boolean palindromeResult = false;
            int wordLength = checkPalindrome.Length;
            int halfLength = 0;

            if (wordLength != 0)
            {
                halfLength = wordLength / 2;
                for (int i = 0; i<halfLength; i++)
                {
                    if (checkPalindrome.Substring(i, 1).Equals(checkPalindrome.Substring(wordLength - (i + 1),1)) == true)
                    {
                        palindromeResult = true;
                    } else
                    {
                        palindromeResult = false;
                        break;
                    }
                }
            }

            if (palindromeResult == true)
            {
                return "That's a palindrome!";
            }
            else
            {
                return "That's not a palindrome!";
            }
        }
    }
}