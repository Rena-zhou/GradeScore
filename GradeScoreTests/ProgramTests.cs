using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeScore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GradeScore.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void ReadFileAndSaveIntoListTest_EXCEPTION()
        {
            List<NameAndScore> failedReturn = Program.ReadFileAndSaveIntoList("dfdfefe");
            Assert.IsNull(failedReturn);
        }

        [TestMethod()]
        public void ReadFileAndSaveIntoListTest_SUCCESS()
        {
            string filename = Path.Combine(Environment.CurrentDirectory, "TestFiles\\names.txt");
            List<NameAndScore> successReturn = Program.ReadFileAndSaveIntoList(filename);
            successReturn.ForEach(i => Console.WriteLine(i.ToString()));
            List<NameAndScore> expectedList = new List<NameAndScore>();
            NameAndScore line1 = new NameAndScore("BUNDY", "TERESSA", 88);
            NameAndScore line2 = new NameAndScore("SMITH", "ALLAN", 70);
            NameAndScore line3 = new NameAndScore("KING", "MADISON", 88);
            NameAndScore line4 = new NameAndScore("SMITH", "FRANCIS", 85);
            expectedList.Add(line1);
            expectedList.Add(line2);
            expectedList.Add(line3);
            expectedList.Add(line4);
            CollectionAssert.AreEqual(expectedList, successReturn);
        }

        [TestMethod()]
        public void SortByScoreAndNameTest_NULL()
        {
            List<NameAndScore> returnList = Program.SortByScoreAndName(null);
            Assert.IsNull(returnList);
        }

        [TestMethod()]
        public void SortByScoreAndNameTest_NOT_NULL()
        {
            List<NameAndScore> inputList = new List<NameAndScore>();
            NameAndScore line1 = new NameAndScore("BUNDY", "TERESSA", 88);
            NameAndScore line2 = new NameAndScore("SMITH", "ALLAN", 70);
            NameAndScore line3 = new NameAndScore("KING", "MADISON", 88);
            NameAndScore line4 = new NameAndScore("SMITH", "FRANCIS", 85);
            inputList.Add(line1);
            inputList.Add(line2);
            inputList.Add(line3);
            inputList.Add(line4);
            List<NameAndScore> returnedList = Program.SortByScoreAndName(inputList);
            List<NameAndScore> expectedList = new List<NameAndScore>();
            expectedList.Add(line1);
            expectedList.Add(line3);
            expectedList.Add(line4);
            expectedList.Add(line2);
            CollectionAssert.AreEqual(returnedList, expectedList);
        }

        [TestMethod()]
        public void compareScoreAndNameTest_SortByScore_TURE()
        {
            NameAndScore line1 = new NameAndScore("SMITH", "ALLAN", 70);
            NameAndScore line2 = new NameAndScore("KING", "MADISON", 88);
            Boolean returnValue = Program.compareScoreAndName(line1, line2);
            Assert.IsTrue(returnValue);
        }

        public void compareScoreAndNameTest_SortByScore_FALSE()
        {
            NameAndScore line1 = new NameAndScore("SMITH", "ALLAN", 88);
            NameAndScore line2 = new NameAndScore("KING", "MADISON", 70);
            Boolean returnValue = Program.compareScoreAndName(line1, line2);
            Assert.IsFalse(returnValue);
        }

        [TestMethod()]
        public void compareScoreAndNameTest_SortByLastName_TRUE()
        {
            NameAndScore line1 = new NameAndScore("KING", "MADISON", 88);
            NameAndScore line2 = new NameAndScore("BUNDY", "TERESSA", 88);
            Boolean returnValue = Program.compareScoreAndName(line1, line2);
            Assert.IsTrue(returnValue);
        }

        public void compareScoreAndNameTest_SortByLastName_FALSE()
        {
            NameAndScore line1 = new NameAndScore("KING", "TERESSA", 88);
            NameAndScore line2 = new NameAndScore("BUNDY", "MADISON", 88);
            Boolean returnValue = Program.compareScoreAndName(line1, line2);
            Assert.IsFalse(returnValue);
        }

        [TestMethod()]
        public void compareScoreAndNameTest_SortByFirstName_TRUE()
        {
            NameAndScore line1 = new NameAndScore("BUNDY", "TERESSA", 88);
            NameAndScore line2 = new NameAndScore("KING", "TERESSA", 88);
            Boolean returnValue = Program.compareScoreAndName(line1, line2);
            Assert.IsTrue(returnValue);
        }

        [TestMethod()]
        public void compareScoreAndNameTest_SortByFirstName_FALSE()
        {
            NameAndScore line1 = new NameAndScore("KING", "TERESSA", 88);
            NameAndScore line2 = new NameAndScore("BUNDY", "TERESSA", 88);
            Boolean returnValue = Program.compareScoreAndName(line1, line2);
            Assert.IsFalse(returnValue);
        }
    }
}