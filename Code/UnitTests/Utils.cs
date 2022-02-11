using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    class Utils
    {
        public static int WordsDistance(string word1, string word2)
        {
            int distance = 0;
            for (int c = 0; c < word1.Length; c++)
                if (word1[c] != word2[c]) distance++;

            return distance;
        }

        public static bool ValidatePath(IEnumerable<string> solutionToValidate, IEnumerable<string> correctSolution)
        {
            if (correctSolution is null)
                return solutionToValidate is null;

            if (solutionToValidate is null || correctSolution.Count() != solutionToValidate.Count())
                return false;

            for (int i = 0; i < correctSolution.Count(); i++)
                if (correctSolution.ElementAt(i) != solutionToValidate.ElementAt(i))
                    return false;

            return true;

        }
    }
}
