using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyFlow.Utility
{
    internal class ShapePrimitiveProvider 
    {
        /// <summary>
        /// Enum which holds the colors available in the color strip texture
        /// </summary>
        public enum RectColors
        {
            RED,
            GREEN, 
            BLUE,
            YELLOW,
            WHITE,
            BLACK
        }

        private readonly Dictionary<RectColors, Rectangle> ENUM_LOCATION_MAP = new Dictionary<RectColors, Rectangle>
        {
            { RectColors.RED, new Rectangle(0, 0, 1, 1) },
            { RectColors.GREEN, new Rectangle(1, 0, 1, 1)},
            { RectColors.BLUE, new Rectangle(2, 0, 1, 1)},
            { RectColors.YELLOW, new Rectangle(3, 0, 1, 1)},
            { RectColors.BLACK, new Rectangle(5, 0, 1, 1)},
            { RectColors.WHITE, new Rectangle(4, 0, 1, 1)}
        };

        /// <summary>
        /// Texture which contains single color pixels which can be used for drawing the UI
        /// </summary>
        private Texture2D _colorStrip;

        public ShapePrimitiveProvider(Game game) {
            _colorStrip = game.Content.Load<Texture2D>("ColorStrip");
        }

        public (Texture2D, Rectangle) GetUIRect(RectColors color)
        {
            return (_colorStrip, ENUM_LOCATION_MAP[color]);
        }

    }
}
