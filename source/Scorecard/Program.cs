using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeanutButter.Utils;

namespace Scorecard
{
    class Program
    {
        static void Main(string[] args)
        {
            var nugetFinder = new FileFinder();
            var jsFinder = new FileFinder();
            Console.WriteLine("Looking for nuget packages...");
            args.ForEach(a => nugetFinder.Find(a, "packages.config"));
            Console.WriteLine("Looking for javascript packages...");
            args.ForEach(a => jsFinder.Find(a, "package.json"));

            Console.WriteLine("Scoring...");
            var nugetScorer = new NugetScorer();
            nugetScorer.Gather(nugetFinder);
            var jsScorer = new JavascriptScorer();
            jsScorer.Gather(jsFinder);

            var longestNuget = nugetScorer.Scores.Max(s => s.PackageName.Length);
            var longestJs = jsScorer.Scores.Max(s => s.PackageName.Length);
            var longest = Math.Max(longestJs, longestNuget);

            Console.WriteLine("Nuget packages:");
            nugetScorer.Scores.OrderByDescending(s => s.UsageCount).ForEach(s => PrintScore(s, longest));
            Console.WriteLine("\nJavascript packages:");
            jsScorer.Scores.OrderByDescending(s => s.UsageCount).ForEach(s => PrintScore(s, longest));
        }

        private static void PrintScore(Score score, int padTo)
        {
            var pre = score.PackageName;
            while (pre.Length < padTo + 5)
                pre += " ";
            Console.WriteLine("{0} - {1}", pre, score.UsageCount);
        }
    }
}
