using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace LoadDictionary
{
    public class LoadFromFile : ILoadDictionary
    {

        private string DictionaryFilePath { get; set; }
        public LoadFromFile(string dictionaryFilePath)
        {
            this.DictionaryFilePath = dictionaryFilePath;
        }

        public IEnumerable<string> GetWords(Filters filters = null)
        {
            if (!File.Exists(DictionaryFilePath))
                throw new FileNotFoundException("File nor exists: " + DictionaryFilePath);


            return (filters is null) ?
                    System.IO.File.ReadAllLines(DictionaryFilePath).Select(x => x.ToUpper()).Distinct() : 
                    System.IO.File.ReadAllLines(DictionaryFilePath).Where(w => ValidateWord(filters,w)).Select(x => x.ToUpper()).Distinct();
        }

        private bool ValidateWord(Filters filters, string word)
        {
        
            if (filters is null) return true;

            if (filters.WordLen != null && word.Length != 4) return false;

            if (filters.OnlyLetters && !Regex.IsMatch(word, @"^[a-zA-Z]+$")) return false;

            return true;
        
        }

        
    }
}
