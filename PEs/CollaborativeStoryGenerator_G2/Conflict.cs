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
        private string conflict1;

        /// <summary>
        /// The selected conflict and ending
        /// </summary>
        public string Conflict1
        {
            get
            {
                return conflict1;
            }
        }

        /// <summary>
        /// Prints an ending randomly chosen based on the user-entered emotion.
        /// </summary>
        /// <param name="conflict1">The first attribute of the setting</param>
        public Setting(string conflict1)
        {
            this.conflict1 = conflict1;
        }
    }
}
