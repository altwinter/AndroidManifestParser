using System.Xml.Linq;
using System;
using System.Diagnostics;
using System.Security;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        var pathManifest = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"test/resource/AndroidManifest-instagram-bin.xml");
        // var pathApk = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"test/resource/Instagram_v230.0.0.20.108_apkpure.com.apk");

        // var result = AndroidParser.ManifestToJson(pathManifest, pathApk);
        var result = AndroidParser.Manifest(pathManifest);
        Console.WriteLine(result);

        // var value = Convert.ToUInt32("0x0", 16);

        // Console.WriteLine("value " + value);
        // value = Convert.ToUInt32("0x00", 16);
        // Console.WriteLine("value " + value);

        // var res = AndroidParser.ManifestToJson(pathManifest);
        // if (res != null)
        // {
        //     Console.WriteLine(res);
        // }

        // AndroidXml.AttrsJsonValues.Instance.GetValue("screenDensity");
        // Console.WriteLine(ExtractResource.Instance.Extract());
    }
}