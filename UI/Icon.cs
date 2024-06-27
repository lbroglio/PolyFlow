using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyFlow.UI
{
    internal abstract class Icon : DrawableGameComponent
    {

        /// <summary>
        /// Images associated with this UI icon. The texture in index 0 will be displayed by default. The others will be shown when this icon
        /// is hovered over.
        /// </summary>
        private Texture2D[] _icons;

        /// <summary>
        /// Array of names of the files that point to the icon images for this icon. Should be ordered in the same order they appear on the screen
        /// </summary>
        private string[] _iconFiles;

        /// <summary>
        /// Track if this Icon is currently in the process of the opening animation
        /// </summary>
        private bool _opening = false;
        /// <summary>
        /// Track if this Icon is currently in the process of the closing animation
        /// </summary>
        private bool _closing = false;

        /// <summary>
        /// The length of this icon
        /// </summary>
        private float _length = 100;

        /// <summary>
        /// The height of an indidual clickable button under this icon
        /// </summary>
        private float _height = 100;

        /// <summary>
        /// The height of this icon when fully extended
        /// </summary>
        private float _totalHeight;


        /// <summary>
        /// The speed this icon opens and closes 
        /// </summary>
        private float _expandSpeed = 20;


        public Icon(Game game, string[] iconFiles) : base(game)
        {
            Array.Copy(iconFiles, _iconFiles, _icons.Length);
        }


        protected override void LoadContent()
        {
            _icons = new Texture2D[_iconFiles.Length];

            for (int i = 0; i < _iconFiles.Length; i++){
                _icons[i] = Game.Content.Load<Texture2D>(_iconFiles[i]);
            }
        }

        public override void Update(GameTime gameTime)
        {


            // If this icon is currently opening
            if (_opening)
            {
            }
            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
