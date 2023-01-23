// Anthony Curtis, 
// 01/23/2023
// Generate a random story
namespace CollaborativeStoryGenerator_G2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userChoice;
            string newStory;

            // placeholder for when we add the endings from the conflicts file
            Console.WriteLine("Welcome to the story generator!\n");

            // loop of story creation
            do
            {
                Console.Write("Please choose a type of ending to generate a story:\n" +
                          /*$*/"'{}'   '{}'   '{}'\n" +
                          /*$*/"'{}'   '{}'   '{}'\n\n" +
                          "Your choice >> ");
                userChoice = Console.ReadLine()!;

                // story shennaniganary goes here

                Console.Write("Would you like another story? Choose ‘yes’ or ‘no’ >> ");
                newStory = Console.ReadLine()!;
            } while (newStory.ToLower() != "no");
        }
    }
}