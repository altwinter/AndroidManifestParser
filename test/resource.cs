using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace ParserTests
{
    [TestClass]
    public class ResourcesTests
    {
        [TestMethod]
        public void ResourcesTest()
        {

            var pathApk = System.IO.Path.Combine(AndroidXml.DirectoryPath.Instance.CurrentProject(), @"test/resource/Instagram_v230.0.0.20.108_apkpure.com.apk");
            AndroidResources res = new AndroidResources(pathApk);
            var result = res.Get("@7f03000f");

            Assert.IsNotNull(result);
            Assert.AreEqual(result, "array/jobscheduler_app_module_download_ids");
        }


        [TestMethod]
        public void ResourcesAttrsTest()
        {

            var result = ExtractResource.Instance.Extract();

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void ResourcesMaskTest()
        {

            var result = AndroidXml.MaskValues.Instance.GetWindowSoftInputMode("0x33");

            Assert.AreEqual(result, "adjustNothing|stateAlwaysHidden");
        }
    }
}