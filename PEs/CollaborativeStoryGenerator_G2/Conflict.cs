using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Hudson Ward
//1/25/23
//The class that holds the conflict/ending generated in Program.cs to be returned

namespace CollaborativeStoryGenerator_G2
{
    internal class Conflict
    {
        private List<string> conflictText;
        private string conflictType;
        private Random conflictRng = new Random();

        /// <summary>
        /// The type of conflict it is (happy, tragic, etc)
        /// </summary>
        public string ConflictType
        {
            get
            {
                return conflictType;
            }
        }

        /// <summary>
        /// The constructor for the conflict sentence
        /// </summary>
        /// <param name="conflictType"> What type of conflict is present </param>
        /// <param name="conflictText"> The list of all possible conflicts </param>
        public Conflict(string conflictType, List<string> conflictText)
        {
            this.conflictType = conflictType;
            this.conflictText = conflictText;
        }

        /// <summary>
        /// Returns a conflict and ending that varies depending on the
        /// user-input ending type
        /// </summary>
        /// <returns> A random conflict and ending </returns>
        public string GetConflict()
        {
            //If statement determines which endings will be randomly chosen from
            //separated out based on type.
            if (conflictType.Equals("happy"))
            {
                return conflictText[conflictRng.Next(1, 3)];
            } else if (conflictType.Equals("tragic"))
            {
                return conflictText[conflictRng.Next(4, 6)];
            } else if (conflictType.Equals("romantic"))
            {
                return conflictText[conflictRng.Next(7, 9)];
            } else if (conflictType.Equals("destructive"))
            {
                return conflictText[conflictRng.Next(10, 12)];
            } else if (conflictType.Equals("twist"))
            {
                return conflictText[conflictRng.Next(13, 15)];
            } else
            {
                //The any option chooses from all possible endings, eliminating the
                //labels for ending types present in the txt file.

                bool viableOption = false;
                int option = 0;

                while (viableOption = false)
                {
                    option = conflictRng.Next(conflictText.Count);
                    if (option != 0 && option != 3 && option != 6 && option != 9 && option != 12)
                    {
                        viableOption= true;
                    }
                }
                return conflictText[option];
            }
            
        }
    }
}
