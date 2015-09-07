using System.Diagnostics;

namespace Scorecard
{
    [DebuggerDisplay("{PackageName}: {UsageCount}")]
    public class Score
    {
        public string PackageName { get; private set; }
        public int UsageCount { get; set; }

        public Score(string packageName)
        {
            PackageName = packageName;
            UsageCount = 1;
        }

    }
}