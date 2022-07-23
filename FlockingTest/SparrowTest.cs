using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlockingBackend;
using System.Collections.Generic;
using System;
/*
namespace FlockingTest
{
    [TestClass]
    public class SparrowTest
    {

        ///<summary>
        ///This test method tests for a sparrow that has no neighbours
        ///Should return an empty vector
        ///</summary>
        [TestMethod]

        public void TestAlignmentOne()
        {
            Sparrow s = new Sparrow();

            List<Sparrow> spList = new List<Sparrow>();
            spList.Add(s);

            float expX = 0f;
            float expY = 0f;


            Vector2 result = s.Alignment(spList);

            Assert.AreEqual(expX, result.Vx, 0.01);
            Assert.AreEqual(expY, result.Vy, 0.01);
        }

               ///<summary>
        ///This test method tests alignment for multiple a sparrows that has neighbours
        ///Should return a vector that aligns the sparrows to the velocity of the others
        ///</summary>
        [TestMethod]
        public void TestAlignmentMultiple()
        {
            Sparrow s1 = new Sparrow(5f,5f,-4f,-1f);
            Sparrow s2 = new Sparrow(10f,20f,0f,2f);
            Sparrow s3 = new Sparrow(15f,15f,3f,1f);



            List<Sparrow> spList = new List<Sparrow>();
            spList.Add(s1);
            spList.Add(s2);
            spList.Add(s3);

            float expX = 0.8722f;
            float expY = 0.4890f;

            Vector2 result = s1.Alignment(spList);

            Assert.AreEqual(expX, result.Vx, 0.01);
            Assert.AreEqual(expY, result.Vy, 0.01);
        }

                ///<summary>
        ///This test method tests cohesion for a sparrow that has no neighbours
        ///Should return an empty vector
        ///</summary>
        [TestMethod]
        public void TestCohesionOne()
        {
            Sparrow s = new Sparrow();

            List<Sparrow> spList = new List<Sparrow>();
            spList.Add(s);

            float expX = 0f;
            float expY = 0f;

            Vector2 result = s.Cohesion(spList);

            Assert.AreEqual(expX, result.Vx, 0.01);
            Assert.AreEqual(expY, result.Vy, 0.01);
        }

            ///<summary>
        ///This test method tests cohesion for a sparrow that has no neighbours
        ///Should return an empty vector
        ///</summary>
        [TestMethod]
        public void TestCohesionMultiple()
        {
         

            Sparrow s1 = new Sparrow(5f,5f,-4f,-1f);
            Sparrow s2 = new Sparrow(10f,20f,0f,2f);
            Sparrow s3 = new Sparrow(15f,15f,3f,1f);
            Sparrow s4 = new Sparrow(170f,170f,2f,2f);


            List<Sparrow> spList = new List<Sparrow>();
            spList.Add(s1);
            spList.Add(s2);
            spList.Add(s3);
            spList.Add(s4);

            float expX = 0.8072f;
            float expY = 0.5902f;

            Vector2 result = s1.Cohesion(spList);

            Assert.AreEqual(expX, result.Vx, 0.01);
            Assert.AreEqual(expY, result.Vy, 0.01);
        }

/// <summary>
/// testing avoidance with only one other sparrow
/// </summary>
        [TestMethod]
        public void TestAvoidanceOne() {
            Sparrow s1 = new Sparrow(10f, 20f, 0f, 2f);
            Sparrow s2 = new Sparrow(15f, 15f, 3f, 1f);

            List<Sparrow> spList = new List<Sparrow>();
            spList.Add(s1);

            Vector2 result = s1.Avoidance(spList);

            float expX = 0f;
            float expY = 0f;

            Assert.AreEqual(expX, result.Vx, 0.01);
            Assert.AreEqual(expY, result.Vy, 0.01);
        }

/// <summary>
/// testing avoidance with multiple sparrows
/// </summary>
        [TestMethod]
        public void TestAvoidanceMultiple() {
            Sparrow s1 = new Sparrow(10f, 20f, 0f, 2f);
            Sparrow s2 = new Sparrow(15f, 15f, 3f, 1f);
            Sparrow s3 = new Sparrow(5f,5f,-4f,-1f);
            Sparrow s4 = new Sparrow(170f,170f,2f,2f);

            List<Sparrow> spList = new List<Sparrow>();
            spList.Add(s1);
            spList.Add(s2);
            spList.Add(s3);
            spList.Add(s4);

            Vector2 result = s1.Avoidance(spList);

            float expX = -0.436733f;
            float expY = 0.899590f;

            Assert.AreEqual(expX, result.Vx, 0.01);
            Assert.AreEqual(expY, result.Vy, 0.01);           
        }

/// <summary>
/// test what happens to a sparrow when they flee a raven 
/// </summary>
        [TestMethod]
        public void TestFleeRaven() {
            Sparrow s1 = new Sparrow(10f, 20f, 0f, 2f);
            Raven s2 = new Raven(15f, 15f, 3f, 1f);

            Vector2 result = s1.FleeRaven(s2);

            float expX = -2.828427f;
            float expY = 2.828427f;

            Assert.AreEqual(expX, result.Vx, 0.01);
            Assert.AreEqual(expY, result.Vy, 0.01);           
        }

            ///<summary>
        ///Test if the methods in the flock class are invoked without a raven
        ///</summary>
        [TestMethod]
        public void TestFlockSparrowNoRaven(){
            Flock flock = new Flock();
            Sparrow s1 = new Sparrow(10f, 20f, 0f, 2f);
            Sparrow s2 = new Sparrow(15f, 15f, 3f, 1f);
            Sparrow s3 = new Sparrow(5f,5f,-4f,-1f);

            List<Sparrow> spList = new List<Sparrow>();
            spList.Add(s1);
            spList.Add(s2);
            spList.Add(s3);

            Raven raven = new Raven(170f, 170f, 2f, 2f);
            Vector2 result = s1.Alignment(spList)+s1.Cohesion(spList)+s1.Avoidance(spList);

            foreach (Sparrow s in spList){

                flock.Subscribe(s.CalculateBehaviour,s.Move,s.CalculateRavenAvoidance);

            }
            flock.RaiseMoveEvents(spList, raven);

            

            float expX = -1.3311f;
            float expY = -0.5477f;

            Assert.AreEqual(expX, result.Vx, 0.01);
            Assert.AreEqual(expY, result.Vy, 0.01); 
            



        }

                    ///<summary>
        ///Test if the methods in the flock class are invoked with a raven
        ///</summary>
        [TestMethod]
        public void TestFlockSparrowRaven(){
            Flock flock = new Flock();
            Sparrow s1 = new Sparrow(10f, 20f, 0f, 2f);
            Sparrow s2 = new Sparrow(15f, 15f, 3f, 1f);

            List<Sparrow> spList = new List<Sparrow>();
            spList.Add(s1);
            spList.Add(s2);

            Raven raven = new Raven(2f,2f,-4f,-1f);
            Vector2 result = s1.Alignment(spList)+s1.Cohesion(spList)+s1.Avoidance(spList)+s1.FleeRaven(raven);
            Console.WriteLine("done");
            foreach (Sparrow s in spList){

                flock.Subscribe(s.CalculateBehaviour,s.Move,s.CalculateRavenAvoidance);

            }
            flock.Subscribe(raven.CalculateBehaviour,raven.Move);

            flock.RaiseMoveEvents(spList, raven);

            

            float expX = 2.152f;
            float expY = 2.8833f;

            Assert.AreEqual(expX, result.Vx, 0.01);
            Assert.AreEqual(expY, result.Vy, 0.01); 
            



        }
        
    }
}
*/