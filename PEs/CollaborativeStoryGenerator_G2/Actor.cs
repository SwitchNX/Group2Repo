using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Kai Gidwani
// 1/25/22
// Actor class to hold the name, occupation, and a trait of an actor

namespace CollaborativeStoryGenerator_G2
{
    internal class Actor
    {
        // Fields

        Random rand = new Random();
        private string name;
        private string occupation;
        private string trait;


        // Parameters

        /// <summary>
        /// Returns the name of the character
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Returns the occupation of the character
        /// </summary>
        public string Ocupation { get { return occupation; } }

        /// <summary>
        /// Returns the trait of the character
        /// </summary>
        public string Trait { get { return trait; } }


        // Constructor

        /// <summary>
        /// Creates an actor object with an inputted name, an occupation, and a trait
        /// </summary>
        /// <param name="nameList">The list of potential names of the actor</param>
        /// <param name="occupationList">The list of potential occupations of the actor</param>
        /// <param name="traitList">The list of possible traits of the actor</param>
        public Actor(List<string> nameList, List<string> occupationList, List<string> traitList)
        {
            // Randomizes the choice for the name, occupation, and trait
            name = nameList[rand.Next(nameList.Count)];
            occupation = occupationList[rand.Next(occupationList.Count)];
            trait = traitList[rand.Next(traitList.Count)];
        }
    }
}
