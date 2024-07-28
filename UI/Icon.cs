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
        private static readonly float BUTTON_GAP = 10;

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
        /// The x positon of the top left corner of this Icon on the screen
        /// </summary>
        private float _xPos = 0;

        /// <summary>
        /// The y positon of the top left corner of this Icon on the screen
        /// </summary>
        private float _yPos = 0;

        /// <summary>
        /// The length of this icon
        /// </summary>
        private float _length = 100;

        /// <summary>
        /// The height of an individual clickable button under this icon
        /// </summary>
        private float _height = 100;

        /// <summary>
        /// The height of this icon when fully extended
        /// </summary>
        private float _totalHeight;

        /// <summary>
        /// The current height this Icon is currently expanded to
        /// </summary>
        private float _currentHeight;

        /// <summary>
        /// The height of this Icon when it is completely unexpanded
        /// </summary>
        private float _baseHeight;

        /// <summary>
        /// The speed this icon opens and closes 
        /// </summary>
        private float _expandSpeed = 20;



        public Icon(Game game, string[] iconFiles) : base(game)
        {
            Array.Copy(iconFiles, _iconFiles, _icons.Length);
            _totalHeight = _icons.Length * (_height + ( 2 * BUTTON_GAP)) ;
            _baseHeight = (_height + (BUTTON_GAP * 2));
            _currentHeight = _baseHeight;

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
            // Move logic

            // If this icon is currently opening
            if (_opening)
            {
                if(_currentHeight < _totalHeight)
                {
                    if(_currentHeight + _expandSpeed > _totalHeight)
                    {
                        _currentHeight += (_totalHeight - _currentHeight);
                    }
                    else
                    {
                        _currentHeight += _expandSpeed;
                    }
                    
                }
                else
                {
                    _opening = false;
                }
            }

            //If this Icon is currently closing
            if(_closing)
            {
                if (_currentHeight > _baseHeight)
                {
                    if (_currentHeight - _expandSpeed < _totalHeight)
                    {
                        _currentHeight -= (_currentHeight - _baseHeight);
                    }
                    else
                    {
                        _currentHeight -= _expandSpeed;
                    }
                }
                else
                {
                    _closing = false;
                }
            }
            
            // Start opening or closing
            MouseState mouseState = Mouse.GetState();

            if(mouseState.X > _xPos && mouseState.X < (_xPos + _length) && mouseState.Y > (_yPos) && mouseState.Y < (_yPos + _currentHeight))
            {
                if(_currentHeight < _totalHeight)
                {
                    _opening = true;
                }
            }
            else
            {
                if(_currentHeight < _baseHeight)
                {
                    _closing = true;
                }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            Rectangle backing = new Rectangle((int)Math.Round(_xPos), (int)Math.Round(_yPos), (int)Math.Round(_length), (int)Math.Round(_currentHeight));
            ((SpriteBatch)Game.Services.GetService(typeof(SpriteBatch))).Draw();

            base.Draw(gameTime);
        }
    }
}
