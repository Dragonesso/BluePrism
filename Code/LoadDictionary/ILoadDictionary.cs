using System;
using System.Collections.Generic;
using System.Text;

namespace LoadDictionary
{
    public interface ILoadDictionary
    {
        IEnumerable<string> GetWords(Filters filters = null);
    }
}
