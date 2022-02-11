using Contracts;
using LoadDictionary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class UnitTestPathFinder
    {
        public static void Test_SimplePath(ILoadDictionary dic, IWordsPathFinder finder)
        {
            
            finder.Initialize(dic.GetWords(new Filters() { WordLen = 4, OnlyLetters = true }), Utils.WordsDistance);

            var path = finder.GetPath("SAME", "COST");

            IEnumerable<string> solution = new List<string> { "SAME", "CAME", "CASE", "CAST", "COST" };

            if (!Utils.ValidatePath(path, solution))
                Assert.Fail("Word path is wrong");

        }
    }
}
