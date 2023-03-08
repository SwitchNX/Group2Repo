using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Ryan Fogarty
//A string of text that will be clicked by the player

namespace Nobody_Will_Hear_Them_Scream
{
    internal class Button
    {
        // Fields

        private string text;
        private SpriteFont font;
        private Vector2 position;
        private Vector2 size;
        private Rectangle rect;


        // Properties

        /// <summary>
        /// Gets and sets the text of a button
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        /// <summary>
        /// Gets the font
        /// </summary>
        public SpriteFont Font
        {
            get { return font; }
        }

        /// <summary>
        /// Gets the position of the button
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
        }

        /// <summary>
        /// Gets the X position of the button
        /// </summary>
        public int X
        {
            get { return (int)position.X; }
        }

        /// <summary>
        /// Gets the Y position of the button
        /// </summary>
        public int Y
        {
            get { return (int)position.Y; }
        }

        /// <summary>
        /// Gets the width of the button
        /// </summary>
        public int Width
        {
            get { return (int)size.X; }
        }

        /// <summary>
        /// Gets the height of the button
        /// </summary>
        public int Height   
        {
            get { return (int)size.Y; }
        }

        /// <summary>
        /// Gets the rectangle of the button
        /// </summary>
        public Rectangle Rect
        {
            get { return rect; }
        }

        //Incomplete
        public Button(Vector2 position, string text, SpriteFont font)
        {
            this.text = text;
            this.font = font;
            size = font.MeasureString(text);
            this.position = position;
            rect = new Rectangle(X, Y, Width, Height);
        }

        /// <summary>
        /// Draws the text of the with the spritebatch and the color
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="c">The color of the buttons text</param>
        public void Draw(SpriteBatch sb, Color c)
        {
            sb.DrawString(font, text, position, c);
        }
    }
}
