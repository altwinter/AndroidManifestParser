using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace ParserTests
{
    [TestClass]
    public class ManifestTests
    {
        [TestMethod]
        public void InstagramResultWithoutResourcesTest()
        {
            var pathManifest = System.IO.Path.Combine(AndroidXml.DirectoryPath.Instance.CurrentProject(), @"test/resource/AndroidManifest-instagram-bin.xml");
            var pathManifestComparator = System.IO.Path.Combine(AndroidXml.DirectoryPath.Instance.CurrentProject(), @"test/result/AndroidManifest-withoutResources.xml");
            var actual = AndroidParser.Manifest(pathManifest);

            XDocument xdoc = XDocument.Load(File.OpenRead(pathManifestComparator));
            var expected = xdoc.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InstagramResultWithResourcesTest()
        {
            var pathManifest = System.IO.Path.Combine(AndroidXml.DirectoryPath.Instance.CurrentProject(), @"test/resource/AndroidManifest-instagram-bin.xml");
            var pathApk = System.IO.Path.Combine(AndroidXml.DirectoryPath.Instance.CurrentProject(), @"test/resource/Instagram_v230.0.0.20.108_apkpure.com.apk");

            var pathManifestComparator = System.IO.Path.Combine(AndroidXml.DirectoryPath.Instance.CurrentProject(), @"test/result/AndroidManifest-withResources.xml");
            var actual = AndroidParser.Manifest(pathManifest, pathApk);

            XDocument xdoc = XDocument.Load(File.OpenRead(pathManifestComparator));
            var expected = xdoc.ToString();

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void InstagramJsonResultWithoutResourcesTest()
        {
            var pathManifest = System.IO.Path.Combine(AndroidXml.DirectoryPath.Instance.CurrentProject(), @"test/resource/AndroidManifest-instagram-bin.xml");
            var pathManifestComparator = System.IO.Path.Combine(AndroidXml.DirectoryPath.Instance.CurrentProject(), @"test/result/android-json-manifest-without-resources.json");
            var actual = AndroidParser.ManifestToJson(pathManifest);

            var expected = File.ReadAllText(pathManifestComparator);

            var areEqual = JToken.DeepEquals(expected, actual);

            Assert.IsTrue(areEqual);
        }

        // [TestMethod]
        // public void InstagramJsonResultWithResourcesTest()
        // {
        //     var pathManifest = System.IO.Path.Combine(AndroidXml.DirectoryPath.Instance.CurrentProject(), @"test/resource/AndroidManifest-instagram-bin.xml");
        //     var pathApk = System.IO.Path.Combine(AndroidXml.DirectoryPath.Instance.CurrentProject(), @"test/resource/Instagram_v230.0.0.20.108_apkpure.com.apk");

        //     var pathManifestComparator = System.IO.Path.Combine(AndroidXml.DirectoryPath.Instance.CurrentProject(), @"test/result/android-json-manifest-with-resources.json");
        //     var actual = AndroidParser.ManifestToJson(pathManifest, pathApk);

        //     var expected = File.ReadAllText(pathManifestComparator);

        //     Console.WriteLine(actual);

        //     var areEqual = JToken.DeepEquals(expected, actual);

        //     Assert.IsTrue(areEqual);
        // }
    }
}