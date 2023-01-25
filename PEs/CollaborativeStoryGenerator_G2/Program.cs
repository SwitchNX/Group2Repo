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

            ReadTextFiles();

            // placeholder for when we add the endings from the conflicts file
            Console.WriteLine("Welcome to the story generator!");

            // loop of story creation
            do
            {
                Console.Write("\nPlease choose a type of ending to generate a story:\n" +
                          /*$*/"'{happy}'   '{tragic}'   '{romantic}'\n" +
                          /*$*/"'{destructive}'   '{twist}'   '{any}'\n\n" +
                          "Your choice >> ");
                userChoice = Console.ReadLine()!.ToLower().Trim();

                // story shennaniganary goes here

                Console.Write("Would you like another story? Choose ‘yes’ or ‘no’ >> ");
                newStory = Console.ReadLine()!;
            } while (newStory.ToLower().Trim() != "no");
        }

        public static void ReadTextFiles()
        {
            StreamReader input = new StreamReader("Actor.txt");
            string actorData;

            do
            {
                actorData = input.ReadLine();
            }
            while (actorData != null);
        }
    }
}