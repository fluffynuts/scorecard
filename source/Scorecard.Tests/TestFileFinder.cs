using NUnit.Framework;

namespace Scorecard.Tests
{
    [TestFixture]
    public class TestFileFinder
    {
        [Test]
        [Ignore("Integration")]
        public void IntegrationTestingAgainstLocalFolder()
        {
            //---------------Set up test pack-------------------
            var sut = new FileFinder();

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            sut.Find("C:\\code\\Chillisoft\\Mastery@Work", "package.json");

            //---------------Test Result -----------------------
            CollectionAssert.IsNotEmpty(sut.Paths);
        }

    }
}