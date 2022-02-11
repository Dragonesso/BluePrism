using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IWordsPathFinder
    {
        void Initialize(IEnumerable<string> words, Func<string, string, int> distance);

        IEnumerable<string> GetPath(string wordStart, string wordEnd);

    }
}
