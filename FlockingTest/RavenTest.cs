using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlockingBackend;
using System.Collections.Generic;
/*
namespace FlockingTest {
    [TestClass]
    public class RavenTest {

        /// <summary>
        /// Testing Raven chasing only one sparrow
        /// </summary>
        [TestMethod]
        public void TestChaseRavenOneSparrow() {
            Raven r = new Raven(15f, 15f, 3f, 1f);
            Sparrow s = new Sparrow(10f, 20, 0f, 2f);

            List<Sparrow> spList = new List<Sparrow>();
            spList.Add(s);

            Vector2 result = r.ChaseSparrow(spList);

            float expX = -0.97685f;
            float expY = 0.2138846f;

            Assert.AreEqual(expX, result.Vx, 0.01);
            Assert.AreEqual(expY, result.Vy, 0.01);
        }

/// <summary>
/// Testing the chase sparrow method with no sparrow to lock onto
/// </summary>
        [TestMethod]
        public void TestChaseRavenNoSparrow() {
            Raven r = new Raven(15f, 15f, 3f, 1f);

            List<Sparrow> spList = new List<Sparrow>();

            Vector2 result = r.ChaseSparrow(spList);

            float expX = 0;
            float expY = 0;

            Assert.AreEqual(expX, result.Vx, 0.01);
            Assert.AreEqual(expY, result.Vy, 0.01);
        }

/// <summary>
/// Testing chase sparrow with a sparrow out of reach
/// </summary>
        [TestMethod]
        public void TestChaseRavenFarSparrow() {
            Raven r = new Raven(15f, 15f, 3f, 1f);
            Sparrow s = new Sparrow(100f, 100f, 0f, 2f);

            List<Sparrow> spList = new List<Sparrow>();
            spList.Add(s);

            Vector2 result = r.ChaseSparrow(spList);

            float expX = 0;
            float expY = 0;

            Assert.AreEqual(expX, result.Vx, 0.01);
            Assert.AreEqual(expY, result.Vy, 0.01);
        }

/// <summary>
/// Testing chase sparrow with multiple sparrows to lock onto
/// </summary>
        [TestMethod]
        public void TestChaseRavenMultipleSparrow() {
            Raven r = new Raven(15f, 15f, 3f, 1f);

            Sparrow s1 = new Sparrow(5f,5f,-4f,-1f);
            Sparrow s2 = new Sparrow(10f, 20f, 0f, 2f);
            Sparrow s3 = new Sparrow(170f,170f,2f,2f);

            List<Sparrow> spList = new List<Sparrow>();
            spList.Add(s1);
            spList.Add(s2);
            spList.Add(s3);

            Vector2 result = r.ChaseSparrow(spList);

            float expX = -0.97685f;
            float expY = 0.213884f;

            Assert.AreEqual(expX, result.Vx, 0.01);
            Assert.AreEqual(expY, result.Vy, 0.01);
        }
    }
}*/