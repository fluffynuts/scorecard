using System.Collections.Generic;

namespace Scorecard
{
    public interface IFileFinderResults
    {
        IEnumerable<string> Paths { get; }
    }
}