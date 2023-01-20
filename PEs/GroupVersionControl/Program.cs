
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
            DiceSum();
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
        }
    }
}