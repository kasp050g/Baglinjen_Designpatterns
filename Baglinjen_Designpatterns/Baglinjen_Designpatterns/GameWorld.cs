using Baglinjen_Designpatterns.Components;
using Baglinjen_Designpatterns.Builder;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Baglinjen_Designpatterns.CommandPattern;
using Baglinjen_Designpatterns.ObjectPool;
using System;

namespace Baglinjen_Designpatterns
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
		#region Instance
		private static GameWorld instance;

        public static GameWorld Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameWorld();
                }
                return instance;
            }
        }
		#endregion

		GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private List<GameObject> gameObjects = new List<GameObject>();
        public List<Collider> Colliders { get; set; } = new List<Collider>();

        public float DeltaTime { get; set; }
        private float spawnTime;
        private float cooldown = 1;

        private Random rnd = new Random();

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
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
			// TODO: Add your initialization logic here
			IsMouseVisible = true;



            Director director = new Director(new PlayerBuilder());

			gameObjects.Add(director.Construct());

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Awake();
            }
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

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Start();
            }
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
            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

			InputHandler.Instance.Execute();

			for (int i = 0; i < gameObjects.Count; i++)
			{
				gameObjects[i].Update(gameTime);
			}

            Collider[] tmpColliders = Colliders.ToArray();

            for (int i = 0; i < tmpColliders.Length; i++)
            {
                for (int j = 0; j < tmpColliders.Length; j++)
                {
                    tmpColliders[i].OnCollisionEnter(tmpColliders[j]);
                }
            }

            SpawnEnemy();

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

			for (int i = 0; i < gameObjects.Count; i++)
			{
				gameObjects[i].Draw(spriteBatch);
			}

			spriteBatch.End();

			base.Draw(gameTime);
        }

		public void AddGameObject(GameObject go)
		{
			go.Awake();
			go.Start();
			gameObjects.Add(go);

            Collider c = (Collider)go.GetComponent("Collider");

            if (c != null)
            {
                Colliders.Add(c);
            }
        }

        public void RemoveGameObject(GameObject go)
        {
            gameObjects.Remove(go);
        }

        private void SpawnEnemy()
        {
            spawnTime += DeltaTime;

            if (spawnTime >= cooldown)
            {
                GameObject go = FriendPool.Instance.GetObject();

                go.Transform.Position = new Vector2(
                    rnd.Next(0, GameWorld.Instance.GraphicsDevice.Viewport.Width),
                    rnd.Next(0, GameWorld.Instance.GraphicsDevice.Viewport.Height)
                        );

                AddGameObject(go);
                spawnTime = 0;
            }
        }
    }
}
