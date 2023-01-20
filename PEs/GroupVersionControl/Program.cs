
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


