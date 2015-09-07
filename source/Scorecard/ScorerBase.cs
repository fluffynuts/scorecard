using System.Collections.Generic;
using System.Linq;

namespace Scorecard
{
    public abstract class ScorerBase
    {
        public List<Score> Scores { get; private set; }
        protected ScorerBase()
        {
            Scores = new List<Score>();
        }

        protected void AddOrIncrement(string packageName)
        {
            var existing = Scores.FirstOrDefault(s => s.PackageName == packageName);
            if (existing == null)
            {
                existing = new Score(packageName);
                Scores.Add(existing);
            }
            else
            {
                existing.UsageCount++;
            }
        }
    }
}