
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
    }
}


