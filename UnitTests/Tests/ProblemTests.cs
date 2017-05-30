using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using OstManSysMVVM.Model;

namespace UnitTests
{
    [TestClass]
    public class ProblemTests
    {
        [TestMethod]
        public void ProblemDescriptionTest()
        {
            Problem newProblem = new Problem();
            newProblem.Header = "Header";
            newProblem.Description = "Description";
            newProblem.Note = "Note";
            string testString = newProblem.Header + newProblem.Description + newProblem.Note;
            Assert.AreEqual(testString, "HeaderDescriptionNote");
        }

        [TestMethod]
        public void ProblemApartmentIDTest()
        {
            Problem newProblem = new Problem();
            newProblem.ApartmentID = 1;
            Assert.AreEqual(1, newProblem.ApartmentID);
        }

        [TestMethod]
        public void ProblemIDTest()
        {
            Problem newProblem = new Problem();
            newProblem.ProblemID = 1;
            Assert.AreEqual(1, newProblem.ProblemID);
        }
    }
}
