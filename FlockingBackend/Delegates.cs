using System;
using System.Collections.Generic;


namespace FlockingBackend
{
    public class Delegates
    {
        
        /// <summary>
        /// initialization of delegates
        /// </summary>
        /// <param name="sparrow">a list of Sparrows</param>
        /// <param name="raven">a raven Object</param>
        public delegate void CalculateMoveVector(List<Sparrow> sparrow);

        public delegate void MoveBird();

        public delegate void CalculateRavenAvoidance(Raven raven);


    }


}
