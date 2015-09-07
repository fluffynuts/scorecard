using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PeanutButter.Utils;

namespace Scorecard
{
    public class JavascriptScorer: ScorerBase
    {
        public void Gather(IFileFinderResults finder)
        {
            finder.Paths.ForEach(p => DoScoreOn(p));
        }

        private void DoScoreOn(string path)
        {
            var json = Encoding.UTF8.GetString(File.ReadAllBytes(path));
            var asObject = JsonConvert.DeserializeObject<NPMPackageJson>(json);
            asObject.devDependencies?.Select(kvp => kvp.Key).ForEach(AddOrIncrement);
            asObject.dependencies?.Select(kvp => kvp.Key).ForEach(AddOrIncrement);
        }

    }
}
