// Anthony Curtis, Kai Gidwani, Ryan Fogarty, Hudson Ward
// 01/23/2023
// Generate a random story
namespace CollaborativeStoryGenerator_G2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // String for user choice
            string userChoice;

            // String for whether or not to continue generating stories
            string newStory;


            // ----- Generation -----

            // Generates the setting
            Setting settingList = GenerateSettings();

            //Generates the conflic
            Conflict conflictList = GenerateConflictList();

            // Generate the first actor
            Actor firstActor = LoadActor();

            // Generate the second actor
            Actor secondActor = LoadActor();


            // Starting the story generation

            Console.WriteLine("\nWelcome to the story generator!");

            // loop until the user doesn't want to generate a new story
            do
            {
                do
                {
                    // Prompt input
                    Console.Write("\nPlease choose a type of ending to generate a story:\n" +
                              /*$*/"'happy' \t'tragic'\t'romantic'\n" +
                              /*$*/"'destructive'\t'twist'\t\t'any ending'\n\n" +
                              "Your choice >> ");

                    // Read input
                    userChoice = Console.ReadLine()!.ToLower().Trim();


                } // verify that the input is valid
                while (userChoice != "happy" && userChoice != "tragic" && userChoice != "romantic" &&
                       userChoice != "destructive" && userChoice != "twist" && userChoice != "any ending");
                


                // Story print
                Console.WriteLine($"{firstActor.Name} is a {firstActor.Ocupation} who {firstActor.Trait}. " +
                    $"{secondActor.Name} is a {secondActor.Ocupation} who {secondActor.Trait}. " +
                    $"The story takes place {settingList.GetRandomFirstAttribute()} {settingList.GetRandomSecondAttribute()}. " +
                    $"Then, {conflictList.GetConflict(userChoice)}");


                Console.WriteLine(); // Newline for spacing

                // Prompt for if the user wants to make another story
                Console.Write("Would you like another story? Choose ‘yes’ or ‘no’ >> ");

                // Get input
                newStory = Console.ReadLine().ToLower().Trim();
            } while (newStory != "no");
        }

        /// <summary>
        /// Pulls actors' info from the text files into lists based
        /// on descriptors of the actors
        /// </summary>
        static Actor LoadActor()
        {
            List<string> actorNames = new List<string>();
            List<string> actorJobs = new List<string>();
            List<string> actorTraits = new List<string>();

            // Add all names, jobs, and traits to their respective lists
            StreamReader input = null;
            try
            {
                input = new StreamReader("..\\..\\..\\Actor.txt");
                string line = null;


                Console.WriteLine(">> Loading data from Actor.txt...");

                // read each line of Actors.txt
                while ((line = input.ReadLine()!) != null)
                {
                    String[] data = line.Split(';');
                    actorNames.Add(data[0]);
                    actorJobs.Add(data[1]);
                    actorTraits.Add(data[2]);
                }

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

            return new Actor(actorNames, actorJobs, actorTraits);
        }


        public static Setting GenerateSettings()
        {
            StreamReader input;
            try 
            {
                input = new StreamReader("..\\..\\..\\Settings.txt");
            }
            catch(Exception e)
            {
                Console.WriteLine("Error opening file: " + e.Message);
                return null;
            }

            //Will be every individual line in the settings text file
            string line;

            Console.WriteLine(">> Loading data from Settings.txt...");

            List<string> settingsFirstAttributes = new List<string>();
            List<string> settingsSecondAttributes = new List<string>();

            try
            {
                while ((line = input.ReadLine()) != null)
                {
                    string[] splitLine = line.Split(';');
                    settingsFirstAttributes.Add(splitLine[0]);
                    settingsSecondAttributes.Add(splitLine[1]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading file: " + e.Message);
            }

            return new Setting(settingsFirstAttributes, settingsSecondAttributes);
                      
        }

        public static Conflict GenerateConflictList()
        {
            StreamReader input;
            try
            {
                input = new StreamReader("..\\..\\..\\Conflicts.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error opening file: " + e.Message);
                return null;
            }

            Console.WriteLine(">> Loading data from Conflicts.txt...");

            List<string> conflictTexts = new List<string>();
            string line;

            try
            {
                while ((line = input.ReadLine()) != null)
                {
                    string conflictType = "";

                    string[] lineComponents = line.Split(';');

                    for (int i = 0; i < lineComponents.Length; i++)
                    {
                        conflictTexts.Add(lineComponents[i]);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading file: " + e.Message);
                return null;
            }

            return new Conflict(conflictTexts);
        }
    }
}