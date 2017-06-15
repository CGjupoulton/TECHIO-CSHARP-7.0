using Answer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace TechIo
{
    [TestClass]
    public class OutVarTest
    {
        private int shouldShowHint = 0;
        [TestMethod]
        public void VerifyPrintStars() 
        {
            shouldShowHint = 2;
            Assert.AreEqual ("********",   OutVarStub.PrintStars ("8"));
            shouldShowHint--;
            StringAssert.Contains (OutVarStub.PrintStars ("one"), "Cloudy");
            shouldShowHint--;
        }

        [TestCleanup()]
        public void Cleanup()
        {		
            if(shouldShowHint > 0)
            {	
                // On Failure
                Tools.Success(false);
            } 
            else
            {
                // On success
                Regex validPattern = new Regex(@"if\s*\(int\.TryParse\((.*),\s*out (?<type>int|var) (.*)\)\)");
                if(!Tools.LineMatch(@"/project/target/Exercises/OutVarStub.cs", validPattern)) 
                {                    
                    Tools.PrintMessage("out", "Fail Error: You didn't use the new C# 7.0 syntax");
                    Tools.Success(false);
                } 
                else {
                    Tools.Success(true);
                }
            }
        }
    }
}
