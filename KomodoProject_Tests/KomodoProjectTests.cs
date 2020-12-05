using System;
using DevTeamsProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoProject_Tests
{
    [TestClass]
    public class KomodoProjectTests
    {
        [TestMethod]
        public void SetName_ShouldSetCorrectString()
        {
            Developer developer = new Developer();

            developer.LastName = "Wright";

            string expected = "Wright";
            string actual = developer.LastName;

            Assert.AreEqual(expected, actual);

        }
    }
}
