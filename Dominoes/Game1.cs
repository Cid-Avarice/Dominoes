using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        string player1Name = "";
        bool nameEntered = false;
        Player[] players = { new Player(""), new Player("Guido", "Team 2"), new Player("Carlos"), new Player("Dario", "Team 2") };

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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
            if (!nameEntered)
                spriteBatch.DrawString(messageFont, "Welcome to Dominoes. What is your name?", new Vector2(0, 0), Color.White);
            else
            {
                for(int i = 0; i < players.Length; i++)
                {
                    float xForName = 0f;
                    float yForName = 0f;

                    switch (i)
                    {
                        case 0:
                            xForName = GraphicsDevice.Viewport.Width / 2 - messageFont.MeasureString(players[i].ToString()).Length() / 2;
                            yForName = GraphicsDevice.Viewport.Height - messageFont.MeasureString(players[i].ToString()).Y;
                            break;
                        case 1:
                            xForName = GraphicsDevice.Viewport.Width - messageFont.MeasureString(players[i].ToString()).Length();
                            yForName = GraphicsDevice.Viewport.Height / 2 - messageFont.MeasureString(players[i].ToString()).Y / 2;
                            break;
                        case 2:
                            xForName = GraphicsDevice.Viewport.Width / 2 - messageFont.MeasureString(players[i].ToString()).Length() / 2;
                            yForName = 0;
                            break;
                        default:
                            xForName = 0;
                            yForName = GraphicsDevice.Viewport.Height / 2 - messageFont.MeasureString(players[i].ToString()).Y / 2;
                            break;
                    }

                    spriteBatch.DrawString(
                        messageFont,
                        players[i].ToString(),
                        new Vector2(xForName, yForName),
                        Color.White);
                }
            }

            if(!nameEntered)
                EnteringName();

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void EnteringName()
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            Keys[] pressedKeys;
            pressedKeys = currentKeyboardState.GetPressedKeys();
            
            foreach (Keys key in pressedKeys)
            {
                if (previousKeyboardState.IsKeyUp(key))
                {
                    if (key == Keys.Back && player1Name.Length > 0)
                    {
                        // add key to the list
                        player1Name = player1Name.Substring(0, player1Name.Length - 1);
                    }
                    else if (key == Keys.Space && player1Name.Length < 20)
                    {
                        // add space
                        player1Name += " ";
                    }
                    else if (key == Keys.Enter)
                    {
                        // finished, save name
                        player1Name = player1Name.Trim();
                        nameEntered = true;
                        players[0] = new Player(player1Name);
                    }
                    else if (key >= Keys.A && key <= Keys.Z && player1Name.Length < 20)
                    {
                        player1Name += key;
                    }
                }
            }

            spriteBatch.DrawString(messageFont, player1Name, new Vector2(0, 30), Color.White);
        }
    }
}
