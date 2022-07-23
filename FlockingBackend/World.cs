using System;
using System.Collections.Generic;

namespace FlockingBackend
{
    public class World
    {
        private Flock flock;

        public static int InitialCount;
        public static int Width;
        public static int Height;
        public static int MaxSpeed;
        public static float NeighbourRadius;
        public static float AvoidanceRadius;

        /// <summary>
        /// getter for Sparrow list
        /// </summary>
        /// <value>Sparrow is the list of sparrows</value>
        public List<Sparrow> Sparrow{
            get;
        }

        /// <summary>
        /// getter for Raven
        /// </summary>
        /// <value>Raven is a raven object</value>
        public Raven Raven{
            get;
        }

        /// <summary>
        /// holds static values to use for the Flocking Simulation
        /// </summary>
        static World()
        {
            InitialCount = 150;
            Width = 1000;
            Height = 500;
            MaxSpeed = 4;
            NeighbourRadius = 100;
            AvoidanceRadius = 50;


        }

        /// <summary>
        /// Intialize a Raven, a flock and a list of Sparrows and subscribe the Raven and sparrows using the flock
        /// to all of the movement events
        /// </summary>
        public World()
        {
            Raven = new Raven();
            flock = new Flock();

            Sparrow = new List<Sparrow>();
            for (int i = 0; i < InitialCount; i++)
            {
                Sparrow sparrow = new Sparrow();
                Sparrow.Add(sparrow);
                flock.Subscribe(sparrow.CalculateBehaviour,sparrow.Move,sparrow.CalculateRavenAvoidance);

            }


            flock.Subscribe(Raven.CalculateBehaviour,Raven.Move);
        }

        /// <summary>
        /// raise the events with the list of sparrows and a raven
        /// </summary>
        public void Update()
        {
            flock.RaiseMoveEvents(Sparrow,Raven);
        }


    }
}