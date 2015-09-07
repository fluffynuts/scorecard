using System.Collections.Generic;

namespace Scorecard
{
    public class NPMPackageJson
    {
        public Dictionary<string, string> devDependencies { get; set; }
        public Dictionary<string, string> dependencies { get; set; }
    }
}