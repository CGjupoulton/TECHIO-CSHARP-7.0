using Answer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace TechIo
{
    [TestClass]
    public class TuplesTest
    {
        private int shouldShowHint = 0;
        [TestMethod]
        public void VerifyLookupName() 
        {
            shouldShowHint = 4;
            Assert.AreEqual ("Doe",   TuplesStub.LookupName (1).LastName);
            shouldShowHint--;
            Assert.AreEqual ("John",   TuplesStub.LookupName (1).FirstName);
            shouldShowHint--;
            Assert.AreEqual (1,   TuplesStub.LookupName (1).Id);
            shouldShowHint--;
            Assert.AreEqual ((3, "Jane", "Doe"),  TuplesStub.LookupName(3));
            shouldShowHint--;
        }

        [TestCleanup()]
        public void Cleanup()
        {		
            if(shouldShowHint > 0)
            {	
                // On Failure
                Tools.PrintMessage("Hint", "You can use DB.Where(x => x.Item1 == id).First() to retrieve the correct tuple.");
                Tools.Success(false);
            }
            else
            {
                // On success
                Regex validPattern = new Regex(@"\.Where\s*\((.*)\s*=>(.*)\.Id(.*?)\)");
                if(!Tools.LineMatch(@"/project/target/Exercises/TuplesStub.cs", validPattern))
                {
                    Tools.PrintMessage("Kudos", "You could've used: DB.Where(x => x.Id == id).First(), to be more readable.");
                } else {
                    Tools.PrintMessage("out", "Perfect !");
                }
                Tools.Success(true);
            }
        }
    }
}