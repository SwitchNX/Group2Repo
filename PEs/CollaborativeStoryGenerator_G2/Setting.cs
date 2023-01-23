using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ryan Fogarty
//The class of the settings of the stories

namespace CollaborativeStoryGenerator_G2
{
    internal class Setting
    {
        private string attribute1;
        private string attribute2;

        /// <summary>
        /// The first attribute of the setting
        /// </summary>
        public string Attribute1
        {
            get
            {
                return attribute1;
            }
        }

        /// <summary>
        /// The second attribute of the setting
        /// </summary>
        public string Attribute2
        {
            get
            {
                return attribute2;
            }
        }

        /// <summary>
        /// Makes a new setting with the given attributes
        /// </summary>
        /// <param name="attribute1">The first attribute of the setting</param>
        /// <param name="attribute2">The second attribute of the setting</param>
        public Setting(string attribute1, string attribute2)
        {
            this.attribute1 = attribute1;
            this.attribute2 = attribute2;
        }
    }
}
