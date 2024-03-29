using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private TeddyBear  bear0;
        private TeddyBear bear1;
        private Rectangle drawRectangle0;
        private Explosion explosion;
        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;
       

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            bear0 = new TeddyBear(Content,"teddybear0",100,100,WINDOW_WIDTH,WINDOW_HEIGHT);
            bear1 = new TeddyBear(Content,"teddybear1",100,150,WINDOW_WIDTH,WINDOW_HEIGHT);
            explosion = new Explosion(Content);
            

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            bear0.Update();
            bear1.Update();
            if (bear1.Active && bear0.Active && bear0.DrawRectangle.Intersects(bear1.DrawRectangle))
            {
                bear0.Active = false;
                bear1.Active = false;
                Rectangle collisionRectangle = Rectangle.Intersect(bear0.DrawRectangle, bear1.DrawRectangle);
                explosion.Play(collisionRectangle.Center.X, collisionRectangle.Center.Y);
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            bear0.Draw(spriteBatch);
            bear1.Draw(spriteBatch);
            explosion.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here
            explosion.Update(gameTime);
          
            base.Draw(gameTime);
        }
    }
}
