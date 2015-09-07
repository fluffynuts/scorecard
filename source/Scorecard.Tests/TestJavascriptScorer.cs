using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NUnit.Framework;

namespace Scorecard.Tests
{
    [TestFixture]
    public class TestJavascriptScorer
    {
        [Test]
        public void Gather_GivenNoFolders_ShouldDoNothing()
        {
            //---------------Set up test pack-------------------
            var sut = Create();
            var finder = new FileFinder();
            //---------------Assert Precondition----------------
            CollectionAssert.IsEmpty(finder.Paths);

            //---------------Execute Test ----------------------
            sut.Gather(finder);

            //---------------Test Result -----------------------
            CollectionAssert.IsEmpty(sut.Scores);
        }

        [Test]
        [Ignore("Integeration")]
        public void IntegrationTestingAgainstLocalFolder()
        {
            //---------------Set up test pack-------------------
            var finder = new FileFinder();
            finder.Find("C:\\code\\Chillisoft\\Mastery@Work", "package.json");
            var sut = new JavascriptScorer();

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            sut.Gather(finder);

            //---------------Test Result -----------------------
            CollectionAssert.IsNotEmpty(sut.Scores);
        }


        private JavascriptScorer Create()
        {
            return new JavascriptScorer();
        }
    }

    [TestFixture]
    public class TestNugetScorer
    {
        [Test]
        public void TestingXDocumentLINQ()
        {
            //---------------Set up test pack-------------------
            var xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<packages>
  <package id=""Antlr"" version=""3.4.1.9004"" targetFramework=""net451"" />
  <package id=""Autofac"" version=""3.5.0"" targetFramework=""net451"" />
  <package id=""Autofac.Mvc5"" version=""3.3.2"" targetFramework=""net451"" />
  <package id=""AutoMapper"" version=""3.2.1"" targetFramework=""net451"" />
  <package id=""CanJS.AMD"" version=""2.0.2"" targetFramework=""net45"" />
  <package id=""colorbox"" version=""1.4.29"" targetFramework=""net451"" />
  <package id=""d3"" version=""3.5.5"" targetFramework=""net451"" />
  <package id=""ErrorHandlerMvc"" version=""1.1.5"" targetFramework=""net451"" />
  <package id=""Habanero"" version=""3.09.0444-prerelease"" targetFramework=""net451"" />
  <package id=""jQuery"" version=""2.0.3"" targetFramework=""net45"" />
  <package id=""jQuery.LiveQuery"" version=""1.3.5"" targetFramework=""net451"" />
  <package id=""jQuery.Validation"" version=""1.11.1"" targetFramework=""net451"" />
  <package id=""Microsoft.AspNet.Identity.Core"" version=""1.0.0"" targetFramework=""net451"" />
  <package id=""Microsoft.AspNet.Identity.Owin"" version=""1.0.0"" targetFramework=""net451"" />
  <package id=""Microsoft.AspNet.Mvc"" version=""5.2.0"" targetFramework=""net451"" />
  <package id=""Microsoft.AspNet.Razor"" version=""3.2.0"" targetFramework=""net451"" />
  <package id=""Microsoft.AspNet.Web.Optimization"" version=""1.1.3"" targetFramework=""net45"" />
  <package id=""Microsoft.AspNet.WebApi.Client"" version=""5.1.1"" targetFramework=""net451"" />
  <package id=""Microsoft.AspNet.WebApi.Core"" version=""5.1.1"" targetFramework=""net451"" />
  <package id=""Microsoft.AspNet.WebApi.WebHost"" version=""5.1.1"" targetFramework=""net451"" />
  <package id=""Microsoft.AspNet.WebHelpers"" version=""3.2.0"" targetFramework=""net451"" />
  <package id=""Microsoft.AspNet.WebPages"" version=""3.2.0"" targetFramework=""net451"" />
  <package id=""Microsoft.AspNet.WebPages.Data"" version=""3.2.0"" targetFramework=""net451"" />
  <package id=""Microsoft.AspNet.WebPages.WebData"" version=""3.2.0"" targetFramework=""net451"" />
  <package id=""Microsoft.jQuery.Unobtrusive.Validation"" version=""3.1.2"" targetFramework=""net451"" />
  <package id=""Microsoft.Owin"" version=""2.1.0"" targetFramework=""net451"" />
  <package id=""Microsoft.Owin.Host.SystemWeb"" version=""2.1.0"" targetFramework=""net451"" />
  <package id=""Microsoft.Owin.Security"" version=""2.1.0"" targetFramework=""net451"" />
  <package id=""Microsoft.Owin.Security.Cookies"" version=""2.1.0"" targetFramework=""net451"" />
  <package id=""Microsoft.Owin.Security.OAuth"" version=""2.1.0"" targetFramework=""net451"" />
  <package id=""Microsoft.Web.Infrastructure"" version=""1.0.0.0"" targetFramework=""net45"" />
  <package id=""Microsoft.WindowsAzure.ConfigurationManager"" version=""3.1.0"" targetFramework=""net451"" />
  <package id=""Newtonsoft.Json"" version=""5.0.8"" targetFramework=""net45"" />
  <package id=""Node.js"" version=""0.10.24"" targetFramework=""net45"" />
  <package id=""Npm.js"" version=""1.3.15.7"" targetFramework=""net45"" />
  <package id=""NSass.Core"" version=""0.0.3.0"" targetFramework=""net451"" />
  <package id=""NSass.Handler"" version=""0.0.3.0"" targetFramework=""net451"" />
  <package id=""NSass.Optimization"" version=""0.0.1.0"" targetFramework=""net451"" />
  <package id=""Owin"" version=""1.0"" targetFramework=""net451"" />
  <package id=""RequireJS"" version=""2.1.8"" targetFramework=""net45"" />
  <package id=""underscore-string"" version=""2.0.3"" targetFramework=""net45"" />
  <package id=""Unofficial.Microsoft.WindowsAzure.Diagnostics"" version=""2.5.0.0"" targetFramework=""net451"" />
  <package id=""Unofficial.Microsoft.WindowsAzure.ServiceRuntime"" version=""2.5.0.0"" targetFramework=""net451"" />
  <package id=""WebGrease"" version=""1.6.0"" targetFramework=""net451"" />
</packages>";
            //---------------Assert Precondition----------------
            var doc = XDocument.Parse(xml);
            var packageNames = doc.Root.Elements().Where(e => e.Name == "package").Select(e => e.Attribute("id"));

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            CollectionAssert.IsNotEmpty(packageNames);
        }


        [Test]
        [Ignore("Integration")]
        public void IntegrationTestingAgainstLocalFileSystem()
        {
            //---------------Set up test pack-------------------
            var nugetFinder = new FileFinder();
            nugetFinder.Find("C:\\code\\SPAR\\Liquor", "packages.config");

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var scorer = new NugetScorer();
            scorer.Gather(nugetFinder);

            //---------------Test Result -----------------------
            CollectionAssert.IsNotEmpty(scorer.Scores);
        }

    }


}
