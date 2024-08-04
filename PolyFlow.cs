using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PolyFlow.UI;
using PolyFlow.Utility;
using System;
using System.Collections.Generic;

namespace PolyFlow
{
    public class PolyFlow : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Rectangle topBar;
        private ShapePrimitiveProvider _provider;
        private List<ResizableComponent> _resizeOnChange;

        public PolyFlow()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += OnResize;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), _spriteBatch);

            _provider = new ShapePrimitiveProvider(this);
            Services.AddService(typeof(ShapePrimitiveProvider), _provider);

            _resizeOnChange = new List<ResizableComponent>();

            String[] tmp = new string[0];
            Icon tmp2 = new Icon(this, tmp, 30, 0);
            Components.Add(tmp2);
            _resizeOnChange.Add(tmp2);


            topBar = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, Icon.IND_HEIGHT + (2 * Icon.BUTTON_GAP));

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here

            // Draw top UI bar
            (Texture2D, Rectangle) colorRect = _provider.GetUIRect(ShapePrimitiveProvider.RectColors.BLACK);
            _spriteBatch.Draw(colorRect.Item1, topBar, colorRect.Item2, Color.White);

            base.Draw(gameTime);
            _spriteBatch.End();
        }

        public void OnResize(Object sender, EventArgs e)
        {

        }
    }
}
