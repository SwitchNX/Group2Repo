
//Ryan's extra stuff

//Hudson Ward
namespace GroupVersionControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Palindrome Checker

            Console.WriteLine("Enter a word:");
            String checkPalindrome = Console.ReadLine();
            checkPalindrome = checkPalindrome.Trim().ToLower();
            Boolean palindromeResult = false;
            int wordLength = checkPalindrome.Length;
            int halfLength = 0;

            if (wordLength != 0)
            {
                halfLength = wordLength / 2;
                for (int i = 0; i < halfLength; i++)
                {
                    if (checkPalindrome.Substring(i, 1).Equals(checkPalindrome.Substring(wordLength - (i + 1))) == true)
                    {
                        palindromeResult = true;
                        wordLength--;
                    } else
                    {
                        palindromeResult = false;
                        break;
                    }
                }
            }

            if (palindromeResult == true)
            {
                Console.WriteLine("That's a palindrome!");
            } else
            {
                Console.WriteLine("That's not a palindrome!");
            }
        }
    }
}