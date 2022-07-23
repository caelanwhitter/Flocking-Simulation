using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FlockingBackend;

namespace FlockingSimulation
{
    public class RavenSprite : DrawableGameComponent
    {
        public Game1 game;
        private SpriteBatch spriteBatch;
        private Texture2D ravenTexture;
        private Raven raven;






        public RavenSprite(Game1 game, Raven raven) : base(game)
        {
            this.raven = raven;

            this.game = game;
           
        }
        public override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Png credits towards Jimmy Le
            ravenTexture = game.Content.Load<Texture2D>("raven");

        }

        public override void Update(GameTime gameTime)
        {

           // raven.Move();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
                     spriteBatch.Draw(ravenTexture, new Microsoft.Xna.Framework.Vector2(raven.Position.Vx, raven.Position.Vy), null, Color.White, raven.Rotation, new Microsoft.Xna.Framework.Vector2(10, 10), 1, SpriteEffects.None, 0f);

            spriteBatch.End();

        }
    }

}
