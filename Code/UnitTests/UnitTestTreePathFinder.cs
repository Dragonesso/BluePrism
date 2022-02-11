using Contracts;
using LoadDictionary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeRD;

namespace UnitTests
{
    [TestClass]
    public class UnitTestTreePathFinder
    {
        [TestMethod]
        public void Test_SimplePath()
        {
            UnitTestPathFinder.Test_SimplePath(new LoadFromFile("data\\words-english.txt"), new TreePathFinder());
        }
    }
}
