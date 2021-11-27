using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace Sick_Ship
{
    class UIText : Actor
    {

        private string _text;
        private int _width;
        private int _height;
        private Font Font;
        private int _fontSize;
        private Color FontColor;

        /// <summary>
        /// Text being utalized 
        /// </summary>
        public string Text { get { return _text; } set { _text = value; } }

        /// <summary>
        /// With of the text box
        /// </summary>
        public int Width { get { return _width; } set { _width = value; } }

        /// <summary>
        /// Hiegth of the text box
        /// </summary>
        public int Height { get { return _height; } set { _height = value; } }


        /// <summary>
        /// Defulat constructor for thet creation of the UI
        /// </summary>
        /// <param name="x">x location of the UI</param>
        /// <param name="y">y location of the UI</param>
        /// <param name="name">Name of the UI</param>
        /// <param name="color">Color being used with the UI</param>
        /// <param name="width">How long it is left to right</param>
        /// <param name="height">how long top to bottom</param>
        /// <param name="fontSize">type of font being used</param>
        /// <param name="text">Whats being written for the UI</param>
        public UIText(float x, float y, string name, Color color, int width, int height, int fontSize, string text = "")
            : base( x, y, name, "")
        {
            _text = text;
            _width = width;
            _height = height;
            _fontSize = fontSize;
            Font = Raylib.LoadFont("resources/font/alagard.png");
            FontColor = Color.GOLD;


        }

        /// <summary>
        /// What gets drawn to the screen
        /// </summary>
        public override void Draw()
        {
            Rectangle textBox = new Rectangle(LocalPosition.X, LocalPosition.Y, Width, Height);
            Raylib.DrawTextRec(Font, Text, textBox, _fontSize, 1, true, FontColor);
        }


    

    }
}
