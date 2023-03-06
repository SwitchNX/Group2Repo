using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Ryan Fogarty
//A button that will be clicked by the player

namespace Nobody_Will_Hear_Them_Scream
{
    internal class Button: GameObject
    {
        private string text;
        
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        //Incomplete
        public Button():base()
        {

        }

        /// <summary>
        /// Checks the
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public bool IsClicked(MouseState ms)
        {
            return this.objectBounds.contains(ms.Position) && ms.LeftButton = ButtonState.Pressed;
        }
    }
}
