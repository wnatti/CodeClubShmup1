using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using CodeClubShmup1.Objects;
using CodeClubShmup1.Engine;
using CodeClubShmup1.Components;
using CodeClubShmup1.Scenes;

namespace CodeClubShmup1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        public static Camera camera;

        public static Rectangle screen_size
        {
           get;
           private set;
        }



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            this.IsMouseVisible = true;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            screen_size = new Rectangle(0, 0,
                graphics.GraphicsDevice.Viewport.Width,
                graphics.GraphicsDevice.Viewport.Height
                );

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

          

            Resources.Init(Content);
            DrawSys.InitSpriteBatch(spriteBatch);

            //ladataan textuurit

            Resources.LoadTexture2D("Ship");
            Resources.LoadTexture2D("Bullet");
            Resources.LoadTexture2D("Enemy");
            Resources.LoadTexture2D("Suojakilpi");
            Resources.LoadTexture2D("button");
            Resources.LoadTexture2D("perkele");
            Resources.LoadTexture2D("perkele2");

            Resources.LoadFont("SpriteFont1");

            SceneSys.ChangeScene(new GameScene());

            //tehd‰‰n oliota ja muuta vastaavaa

          
      

           
            // TODO: use this.Content to load your game content here
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
            float dt = gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            //Console.WriteLine("Enemy amount: " + enemies.Count+"\nBullet amount: "+bullets.Count);

            Input.UpdateState();

 

            // Allows the game to exit
            if (Input.IsKeyDown(Keys.Escape))
                this.Exit();

            SceneSys.Update(dt);
         

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            SceneSys.Draw();

            base.Draw(gameTime);
        }
    }
}
