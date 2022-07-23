using System;
using System.Collections.Generic;


namespace FlockingBackend {

    public abstract class Bird {
  
        public Vector2 Position { get; protected set; }

        public Vector2 Velocity { get;  protected set; }

        protected Vector2 amountToSteer;

        ///<value> Property <c>Rotation</c> to rotate the Sparrow to face the direction it is moving toward.</value>
        public float Rotation {
            get {
                return (float)Math.Atan2(this.Velocity.Vy, this.Velocity.Vx); 
            }
        }

        /// <summary>
        /// Bird constructor
        /// </summary>
        public Bird() {
            Random random = new Random();
            Position = new Vector2(
                (float)random.Next(0, World.Width), 
                (float)random.Next(0, World.Height)
            );

            Velocity = new Vector2(
                (float)random.Next(World.MaxSpeed * -1, World.MaxSpeed),
                (float)random.Next(World.MaxSpeed * -1, World.MaxSpeed)
            );
        }

        /// <summary>
        /// Bird constructor
        /// </summary>
        /// <param name="random">A random number to place into Position and Vector</param>
        public Bird(Random random) {
            Position = new Vector2(
                (float)random.Next(0, World.Width), 
                (float)random.Next(0, World.Height)
            );

            Velocity = new Vector2(
                (float)random.Next(World.MaxSpeed * -1, World.MaxSpeed),
                (float)random.Next(World.MaxSpeed * -1, World.MaxSpeed)
            );
        }

        /// <summary>
        /// Bird Constructor
        /// </summary>
        /// <param name="px">px is the x value for position</param>
        /// <param name="py">py is the y value for position</param>
        /// <param name="vx">vx if the x value for velocity</param>
        /// <param name="vy">vy is the y value for velocity</param>
        public Bird(float px, float py, float vx, float vy) {
            Position = new Vector2(px, py);
            Velocity = new Vector2(vx, vy);
        }


        ///<summary>
        ///This method is an event handler to calculate and set amountToSteer vector using the flocking algorithm rules
        ///</summary>
        ///<param name="sparrows">List of sparrows</param>
        public abstract void CalculateBehaviour(List<Sparrow> sparrows);

        ///<summary>
        ///This method is an event handler that updates the velocity and position of a sparrow.
        ///</summary>
        public void Move() {
            Velocity += amountToSteer;
            Position += Velocity;
            AppearOnOppositeSide();
        }

        ///<summary>
        ///This method is a private helper method to make sparrows reappear on the opposite edge if they go outside the bounds of the screen
        ///</summary>
        private void AppearOnOppositeSide() { 
            if (this.Position.Vx > World.Width) {
                this.Position = new Vector2(0, this.Position.Vy);
            } else if (this.Position.Vx < 0) {
                this.Position = new Vector2(World.Width, this.Position.Vy);
            } 
            if (this.Position.Vy > World.Height) {
                this.Position = new Vector2(this.Position.Vx, 0);
            } else if (this.Position.Vy < 0) {
                this.Position = new Vector2(this.Position.Vx, World.Height);
            }
        }
    }
}