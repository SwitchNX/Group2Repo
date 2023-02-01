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
        private List<string> conflictList;
        private Random conflictRng = new Random();

        /// <summary>
        /// The constructor for the conflict sentence
        /// </summary>
        /// <param name="conflictList"> The list of all possible conflicts </param>
        public Conflict(List<string> conflictList)
        {
            //this.conflictType = conflictType;
            this.conflictList = conflictList;
        }

        /// <summary>
        /// Returns a conflict and ending that varies depending on the
        /// user-input ending type
        /// </summary>
        /// <returns> A random conflict and ending </returns>
        public string GetConflict(string conflictType)
        {
            if (conflictType.Equals("happy"))
            {
                return conflictList[conflictRng.Next(1, 3)];
            } else if (conflictType.Equals("tragic"))
            {
                return conflictList[conflictRng.Next(4, 6)];
            } else if (conflictType.Equals("romantic"))
            {
                return conflictList[conflictRng.Next(7, 9)];
            } else if (conflictType.Equals("destructive"))
            {
                return conflictList[conflictRng.Next(10, 12)];
            } else if (conflictType.Equals("twist"))
            {
                return conflictList[conflictRng.Next(13, 15)];
            } else
            {
                bool viableOption = false;
                int option = 0;
                while (viableOption = false)
                {
                    option = conflictRng.Next(conflictList.Count);
                    if (option != 0 && option != 3 && option != 6 && option != 9 && option != 12)
                    {
                        viableOption= true;
                    }
                }
                return conflictList[option];
            }
            
        }
    }
}
