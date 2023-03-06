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
    internal class Button
    {
        private string text;
        private SpriteFont font;
        private Vector2 position;
        private Vector2 size;
        
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public SpriteFont Font
        {
            get { return font; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public int X
        {
            get { return (int)position.X; }
        }

        public int Y
        {
            get { return (int)position.Y; }
        }

        public int Width
        {
            get { return (int)size.X; }
        }

        public int Height   
        {
            get { return (int)size.Y; }
        }

        //Incomplete
        public Button(Vector2 position, string text, SpriteFont font)
        {
            this.text = text;
            this.font = font;
            size = font.MeasureString(text);
            this.position = position;
        }

        /// <summary>
        /// Checks the
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public bool IsClicked(MouseState ms)
        {
            Rectangle rect = new Rectangle(X, Y, Width, Height);
            return rect.Contains(ms.Position) && ms.LeftButton == ButtonState.Pressed;
        }
    }
}
