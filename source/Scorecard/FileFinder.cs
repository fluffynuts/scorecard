using System.Collections.Generic;
using System.IO;
using System.Linq;
using PeanutButter.Utils;

namespace Scorecard
{
    public class FileFinder: IFileFinderResults
    {
        public IEnumerable<string> Paths
        {
            get { return _paths.ToArray(); }
        }
        private List<string> _paths;

        public FileFinder()
        {
            _paths = new List<string>();
        }

        public void Find(string searchFolder, string fileName)
        {
            var lFileName = fileName.ToLower();
            _paths.AddRange(new List<string>(LS_R(searchFolder)
                .Where(f =>
                {
                    var parts = f.Split(new[] {'\\', '/'});
                    if (parts.Contains("node_modules")) return false;
                    if (parts.Contains("packages")) return false;
                    return parts.Last().ToLower() == lFileName;
                })));

        }

        private List<string> LS_R(string searchFolder)
        {
            var result = new List<string>(Directory.EnumerateFiles(searchFolder));
            Directory.EnumerateDirectories(searchFolder).ForEach(p =>
            {
                if (p == "." || p == "..")
                    return;
                result.AddRange(LS_R(Path.Combine(searchFolder, p)));
            });
            return result;
        }
    }
}