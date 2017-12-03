using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Dominoes
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background;
        private SpriteFont messageFont;
        KeyboardState currentKeyboardState, previousKeyboardState;
        string name = "";
        bool nameEntered = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
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
            messageFont = Content.Load<SpriteFont>("WelcomeMessageFont");
            background = Content.Load<Texture2D>("green");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Vector2(0, 0));
            if(!nameEntered)
                spriteBatch.DrawString(messageFont, "Welcome to Dominoes. What is your name?", new Vector2(0, 0), Color.White);
            else
                spriteBatch.DrawString(messageFont, $"Welcome {name}.", new Vector2(0, 0), Color.White);

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            Keys[] pressedKeys;
            pressedKeys = currentKeyboardState.GetPressedKeys();

            if (!nameEntered)
            {
                foreach (Keys key in pressedKeys)
                {
                    if (previousKeyboardState.IsKeyUp(key))
                    {
                        if (key == Keys.Back && name.Length > 0)
                        {
                            // add key to the list
                            name = name.Substring(0, name.Length - 1);
                        }
                        else if (key == Keys.Space && name.Length < 20)
                        {
                            // add space
                            name += " ";
                        }
                        else if (key == Keys.Enter)
                        {
                            // finished, save name
                            name = name.Trim();
                            nameEntered = true;
                        }
                        else if (key >= Keys.A && key <= Keys.Z && name.Length < 20)
                        {
                            name += key;
                        }
                    }
                }

                spriteBatch.DrawString(messageFont, name, new Vector2(0, 30), Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
