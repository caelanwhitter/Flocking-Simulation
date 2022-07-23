using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FlockingBackend;

namespace FlockingSimulation
{
    public class SparrowFlockSprite : DrawableGameComponent
    {
        public Game1 game;
        private SpriteBatch spriteBatch;
        private Texture2D flockTexture;
        private List<Sparrow> sparrow;

        public SparrowFlockSprite(Game1 game,List<Sparrow> sparrow) : base(game)
        {
            this.sparrow = sparrow;
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
            flockTexture = game.Content.Load<Texture2D>("sparrow");

        }

        public override void Update(GameTime gameTime)
        {
            
           /* foreach (Sparrow sparrows in sparrow) {
                sparrows.CalculateBehaviour(sparrow);
                sparrows.Move();
            }*/
        
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (Sparrow b in sparrow)
            {
                spriteBatch.Draw(flockTexture, new Microsoft.Xna.Framework.Vector2(b.Position.Vx, b.Position.Vy), null, Color.White, b.Rotation, new Microsoft.Xna.Framework.Vector2(10, 10), 1, SpriteEffects.None, 0f);
            }
            spriteBatch.End();

        }
    }

}
