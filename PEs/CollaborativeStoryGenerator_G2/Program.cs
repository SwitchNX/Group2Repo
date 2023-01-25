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

        /// <summary>
        /// 
        /// </summary>
        static List<List<string>> LoadActor()
        {
            List<List<string>> actors = new List<List<string>>();

            StreamReader input = null;
            try
            {
                input = new StreamReader("Actor.txt");
                string line = null;


                Console.WriteLine(">> Loading data from Actor.txt...");

                // read each line of Actors.txt
                while ((line = input.ReadLine()!) != null)
                {
                    int actorsIndex = 0;
                    String[] data = line.Split(';');

                    // add each string to the individual bins of actors
                    for (int i = 0; i < 6; i++)
                    {
                        actors[actorsIndex].Add(data[i]);
                        Console.WriteLine($"   Added {data[i]} to the list.");
                    }
                    actorsIndex++;
                }

                Console.WriteLine("   Loaded all data from file. Players created.");

            }
            catch (Exception e)
            {
                Console.WriteLine(">> Error! " + e.Message);
            }
            finally
            {
                if (input != null)
                {
                    input.Close();
                }
            }

            return actors;
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