using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace FlockingBackend
{
    ///<summary>
    ///This class is the subscriber class that each bird subscribes to. The class also raises the events to calculate movement vector and move the birds.
    ///This class is just a starting point. Complete the TODO sections
    ///</summary>
    public class Flock
    {
        /// <summary>
        /// initialization of events
        /// </summary>
        public event Delegates.CalculateMoveVector CalcMovementEvent;

        public event Delegates.CalculateRavenAvoidance CalcRavenFleeEvent;

        public event Delegates.MoveBird MoveEvent;

        

        /// <summary>
        /// Add all the methods to the specific events their meant for so that they can be called when the
        /// events are raised
        /// </summary>
        /// <param name="calcMoveVector">CalculateBehavior method</param>
        /// <param name="moveBird">MoveBird method</param>
        /// <param name="optionalCalculateAvoid">CalculateRavenAvoidance method</param>
        public void Subscribe(Delegates.CalculateMoveVector calcMoveVector, Delegates.MoveBird moveBird, [Optional]Delegates.CalculateRavenAvoidance optionalCalculateAvoid){

            CalcMovementEvent += calcMoveVector;
            MoveEvent += moveBird;
            if(optionalCalculateAvoid != null){
            CalcRavenFleeEvent += optionalCalculateAvoid;
            }else{
            }
        }

        ///<summary>
        ///This method raises the calculate and move events
        ///</summary>
        ///<param name="sparrows">List of Sparrow objects</param>
        ///<param name="raven">A Raven object</param>
        public void RaiseMoveEvents(List<Sparrow> sparrows, Raven raven)
        {
            CalcMovementEvent?.Invoke(sparrows);
            CalcRavenFleeEvent?.Invoke(raven);
            MoveEvent?.Invoke();



        }

        
    }
}