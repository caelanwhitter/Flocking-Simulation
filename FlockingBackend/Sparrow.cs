using System;
using System.Collections.Generic;

namespace FlockingBackend {
    ///<summary>
    ///This class is used to represent a single sparrow. 
    ///This class is just a starting point. Complete the TODO sections
    ///</summary>
    public class Sparrow : Bird { 

    ///<summary>
    ///two constructors to invoke the bird constructors
    ///</summary>
        public Sparrow() : base() {}
        public Sparrow(float px, float py, float vx, float vy): base( px,  py,  vx,  vy){}
        public override void CalculateBehaviour(List<Sparrow> sparrows) {
            amountToSteer = new Vector2(0f, 0f);
            amountToSteer = Alignment(sparrows) + Cohesion(sparrows) + Avoidance(sparrows);
        }


        ///<summary>
        ///This method is an event handler to calculate and update amountToSteer vector with the amount to steer to flee a chasing raven
        ///</summary>
        ///<param name="raven">A Raven object</param>
        public void CalculateRavenAvoidance(Raven raven) {
             amountToSteer += FleeRaven(raven);
        }

        /// <summary>
        /// this method aligns every sparrows velocity to the average of those around it
        /// </summary>
        /// <param name="sparrows">List of sparrows</param>
        /// <returns>a vector that aligns the sparrow to the average velocity</returns>
        private Vector2 Alignment (List<Sparrow> sparrows) { 
            Vector2 result = new Vector2(0f, 0f);
            int count = 0;
            foreach (Sparrow sparrow in sparrows) {
                if (Vector2.DistanceSquared(Position, sparrow.Position) < World.NeighbourRadius
                && this != sparrow) {
                    result += sparrow.Velocity;
                    count++;
                }
            }
            if(count == 0)
            {
                return new Vector2();
            }
            //Console.WriteLine(Vector2.Normalize((Vector2.Normalize(result / count) * World.MaxSpeed) - Velocity)+"align");
            return Vector2.Normalize((Vector2.Normalize(result / count) * World.MaxSpeed) - Velocity);
        }

        /// <summary>
        /// This method calculates the average position of every sparrow in the neighbouring radius
        /// and it adjusts the position of the sparrow to match it
        /// </summary>
        /// <param name="sparrows">List of sparrows</param>
        /// <returns>a vector that matches the neighbours positions</returns>
        private Vector2 Cohesion (List<Sparrow> sparrows) { 
            Vector2 result = new Vector2(0f, 0f);
            int count = 0;
            foreach (Sparrow sparrow in sparrows) {
                if (Vector2.DistanceSquared(Position, sparrow.Position) < World.NeighbourRadius
                && this != sparrow) {
                    result += sparrow.Position;
                    count++;
                }
            }
            if(count == 0)
            {
                return new Vector2();
            }
            //Console.WriteLine(Vector2.Normalize((Vector2.Normalize((result / count) - Position) * World.MaxSpeed) - Velocity)+"cohe");

            return Vector2.Normalize((Vector2.Normalize((result / count) - Position) * World.MaxSpeed) - Velocity);
        }

        /// <summary>
        /// this method adjusts the sparrows velocity so that it tries to aoid the neighbouring sparrows
        /// </summary>
        /// <param name="sparrows">List of sparrows</param>
        /// <returns>a vector that helps the sparrow avoid others</returns>
        private Vector2 Avoidance (List<Sparrow> sparrows) {
            Vector2 result = new Vector2(0f ,0f);
            int count = 0;
            foreach (Sparrow sparrow in sparrows) {
                float distanceSquared = Vector2.DistanceSquared(Position, sparrow.Position);
                if (distanceSquared < World.AvoidanceRadius
                && this != sparrow) {
                    result += (Position - sparrow.Position)/distanceSquared;
                    count++;
                }
            }
            if(count == 0)
            {
                return new Vector2();
            }
            //Console.WriteLine(Vector2.Normalize((Vector2.Normalize(result / count) * World.MaxSpeed) - Velocity)+"avoid");
            return Vector2.Normalize((Vector2.Normalize(result / count) * World.MaxSpeed) - Velocity);
        }


        /// <summary>
        /// this method calculates the amount in which a sparrow must avoid a Raven
        /// </summary>
        /// <param name="raven">a Raven object</param>
        /// <returns>a vector that helps steer the sparrow away from the Raven</returns>
        private Vector2 FleeRaven(Raven raven) {
            Vector2 result = new Vector2(0f, 0f);
            float distanceSquared = Vector2.DistanceSquared(Position, raven.Position);

            if (distanceSquared < World.AvoidanceRadius) {
                result += (Position - raven.Position) / distanceSquared;
                Console.WriteLine(Vector2.Normalize(result)* World.MaxSpeed + "flee");

                return Vector2.Normalize(result)* World.MaxSpeed;
            }
            return result; 
        }
    }
}