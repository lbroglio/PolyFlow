using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PolyFlow.Utility;
using System;


namespace PolyFlow.UI
{   
    /// <summary>
    /// A bar which crosses the entire length of the screen
    /// </summary>
    internal class FullBar : DrawableGameComponent, ResizableComponent
    {

        /// <summary>
        /// The y position of the top left corner of this bar
        /// </summary> 
        private int _yPos;

        /// <summary>
        /// The height of this bar
        /// </summary>
        private int _height;

        /// <summary>
        /// The width of this bar
        /// </summary>
        private int _width;

        public FullBar(Game game, int y, int height) : base(game)
        {
            _yPos = y;
            _height = height;
            _width = game.GraphicsDevice.Viewport.Width;
        }

        public override void Draw(GameTime gameTime)
        {
            Rectangle backing = new Rectangle(0, _yPos, _width, _height);
            (Texture2D, Rectangle) colorRect = ((ShapePrimitiveProvider)Game.Services.GetService(typeof(ShapePrimitiveProvider))).GetUIRect(ShapePrimitiveProvider.RectColors.BLACK);
            ((SpriteBatch)Game.Services.GetService(typeof(SpriteBatch))).Draw(colorRect.Item1, backing, colorRect.Item2, Color.White);


        }

        public void OnResize()
        {
            _width = Game.GraphicsDevice.Viewport.Width;
        }
    }
}
