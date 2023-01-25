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
        Random rng = new Random();
        private string[] firstAttributes;
        private string[] secondAttributes;
       

        /// <summary>
        /// Makes a new setting with the given attributes
        /// </summary>
        /// <param name="attribute1">The first attribute of the setting</param>
        /// <param name="attribute2">The second attribute of the setting</param>
        public Setting(string[] firstAttributes, string[] secondAttributes)
        {
            this.firstAttributes = firstAttributes;
            this.secondAttributes = secondAttributes;
        }

        public string GetRandomFirstAttribute()
        {
            return firstAttributes[rng.Next(firstAttributes.Length)];
        }

        public string GetRandomSecondAttribute()
        {
            return secondAttributes[rng.Next(secondAttributes.Length)];
        }
    }
}
