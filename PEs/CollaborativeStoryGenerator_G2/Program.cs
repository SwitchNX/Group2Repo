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

            Setting setting;
            GenerateSettings();

            Actor actor;
            LoadActor();

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
                // Console.WriteLine($"{actorName} is a {actorJob} from {settingPlace} who {actorTrait}. {*ending based on selection*}");
                switch(userChoice.ToLower().Trim())
                {
                    case "happy":

                        break;
                    case "tragic":

                        break;
                    case "romantic":

                        break;
                    case "destructive":

                        break;
                    case "twist":

                        break;
                    case "any":

                        break;
                    default:
                        Console.WriteLine("Invalid input.\n");
                        break;
                }

                Console.Write("Would you like another story? Choose ‘yes’ or ‘no’ >> ");
                newStory = Console.ReadLine()!;
            } while (newStory.ToLower().Trim() != "no");
        }

        /// <summary>
        /// Pulls actors' info from the text files into objects
        /// </summary>
        static Actor LoadActor()
        {
            List<string> actorNames = new List<string>();
            List<string> actorJobs = new List<string>();
            List<string> actorTraits = new List<string>();

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
    }
}