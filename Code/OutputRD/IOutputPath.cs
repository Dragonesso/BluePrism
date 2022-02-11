using System;
using System.Collections.Generic;
using System.Text;

namespace OutputRD
{
    public interface IOutputPath
    {
        void PrintResult(IEnumerable<string> wordPath);
    }
}
