using Answer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace TechIo
{
    [TestClass]
    public class IsExpressionTest
    {
        private int shouldShowHint = 0;
        [TestMethod]
        public void VerifyPrintStars() 
        {
            shouldShowHint = 2;
            Assert.AreEqual ("****",   IsExpressionStub.PrintStars (4));
            shouldShowHint--;
            StringAssert.Contains (IsExpressionStub.PrintStars ("one"), "Cloudy");
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
                Tools.Success(true);
            }
        }
    }
}
