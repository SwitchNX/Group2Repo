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
        /// <param name="name">The name of the actor</param>
        /// <param name="occupation">The occupation of the actor</param>
        /// <param name="trait">The trait of the actor</param>
        public Actor(string name, string occupation, string trait)
        {
            this.name = name;
            this.occupation = occupation;
            this.trait = trait;
        }
    }
}
