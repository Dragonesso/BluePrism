using System;
using System.IO;
using LoadDictionary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestLoadDictionary
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException), "An unexistent file was passed")]
        public void Test_UnexistentDictionary()
        {
            ILoadDictionary d = new LoadFromFile("unexistent.file");

            d.GetWords();
        }

        [TestMethod]
        public void Test_WordsFilter()
        {
            ILoadDictionary d = new LoadFromFile("data\\words-english.txt");

            var words = d.GetWords(new Filters() {WordLen = 4, OnlyLetters = true });
        }


    }
}
