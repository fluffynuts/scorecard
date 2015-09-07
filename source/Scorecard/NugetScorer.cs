using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PeanutButter.Utils;

namespace Scorecard
{
    public class NugetScorer: ScorerBase
    {

        public void Gather(IFileFinderResults finder)
        {
            finder.Paths.ForEach(p =>
            {
                var packageNames = GetPackageNamesFrom(p);
                packageNames.ForEach(AddOrIncrement);
            });
        }

        private string[] GetPackageNamesFrom(string path)
        {
            var xml = Encoding.UTF8.GetString(File.ReadAllBytes(path));
            var lines = string.Join("", xml.Split(new[] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries)
                .Where(l => !l.StartsWith("<?xml"))
                .ToArray());

            var doc = XDocument.Parse(lines);
            return doc.Root.Elements()
                .Where(e => e.Name == "package")
                .Select(e => e.Attribute("id").Value)
                .ToArray();
        }
    }
}