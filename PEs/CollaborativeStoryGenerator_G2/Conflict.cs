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
        private string conflictText;
        private string conflictType;

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
        /// The selected conflict and ending
        /// </summary>
        public string ConflictText
        {
            get
            {
                return conflictText;
            }
        }

        /// <summary>
        /// Prints an ending randomly chosen based on the user-entered emotion.
        /// </summary>
        /// <param name="conflict1">The text of the conflict</param>
        public Conflict(string conflict1)
        {
            this.conflictText = conflictText;
        }
    }
}
