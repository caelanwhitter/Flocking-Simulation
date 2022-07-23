using System;
using System.Collections.Generic;

namespace FlockingBackend {
    ///<summary>
    ///This class is used to represent a single raven. 
    ///</summary>
    public class Raven : Bird {
        public Raven() : base() {}
        public Raven(float px, float py, float vx, float vy): base(px,  py,  vx,  vy) {}

        ///<summary>
        ///This method is an event handler to calculate and set amountToSteer vector
        ///</summary>
        ///<param name="sparrows">List of sparrows</param>
        public override void CalculateBehaviour(List<Sparrow> sparrows) {
            amountToSteer = ChaseSparrow(sparrows);
        }


        /// <summary>
        /// This method calculates the nearest sparrow and returns a Vector2 
        /// that makes the Raven follow that sparrow
        /// </summary>
        /// <param name="sparrows">List of sparrows</param>
        /// <returns>a normalized Vector that allows the raven to follow the sparrow</returns>
        private Vector2 ChaseSparrow (List<Sparrow> sparrows) {
            Vector2 result = new Vector2(0f, 0f);
            Sparrow nearestSparrow = null;
            foreach (Sparrow sparrow in sparrows) {
                float distanceSquared = Vector2.DistanceSquared(Position, sparrow.Position);
                if (distanceSquared < World.AvoidanceRadius) {
                    if (nearestSparrow == null) {
                        nearestSparrow = sparrow;
                    } else if (distanceSquared < Vector2.DistanceSquared(Position, nearestSparrow.Position)) {
                        nearestSparrow = sparrow;
                    }
                }
            }

            if (nearestSparrow != null) {
                return Vector2.Normalize(Vector2.Normalize(nearestSparrow.Position - Position) * 3 - Velocity);
            }

            return result;
        }
    }
}