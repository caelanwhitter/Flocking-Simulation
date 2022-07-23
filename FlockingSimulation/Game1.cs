using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FlockingBackend;


namespace FlockingSimulation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private World world;

        private SparrowFlockSprite SparrowFlockSprite;
        private RavenSprite RavenSprite;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            world = new World();

        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = World.Height;
            _graphics.PreferredBackBufferWidth = World.Width;
            _graphics.ApplyChanges();

            this.SparrowFlockSprite = new SparrowFlockSprite(this,this.world.Sparrow);
            this.RavenSprite = new RavenSprite(this,this.world.Raven);
            
            Components.Add(SparrowFlockSprite);
            Components.Add(RavenSprite);

            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            
            world.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
