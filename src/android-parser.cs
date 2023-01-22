using System.Xml.Linq;

/// <summary>
/// Main Android Manifest Parser Class
/// </summary>
class AndroidParser
{

    /// <summary>
    /// Basic AndroidManifest.xml Parser
    /// </summary>
    /// <param name="manifest">The <see cref="string"/> path to the manifest binary file.</param>
    /// <returns>The <see cref="string"/> representation of the basic AndroidManifest.xml file</returns>
    public static string? Manifest(string manifest)
    {
        string? result;
        using (Stream stream = File.OpenRead(manifest))
        {
            AndroidXml.AndroidXmlReader reader = new AndroidXml.AndroidXmlReader(stream);
            reader.MoveToContent();
            XDocument document = XDocument.Load(reader);

            var first = document.Descendants().First();
            first.Add(new XAttribute(XNamespace.Xmlns + "android", "http://schemas.android.com/apk/res/android"));

            result = document.ToString();
        }

        // Note replace all string result value "" by ?
        return result;
    }

    /// <summary>
    /// Full AndroidManifest.xml Parser with @Resource resolution with aapt2
    /// </summary>
    /// <param name="manifest">The <see cref="string"/> path to the manifest binary file.</param>
    /// <param name="pathApk">The <see cref="string"/> path to the apk file.</param>
    /// <returns>The <see cref="string"/> representation of the full AndroidManifest.xml file.</returns>
    public static string? Manifest(string manifest, string pathApk)
    {
        string? result;
        using (Stream stream = File.OpenRead(manifest))
        {
            AndroidXml.AndroidXmlReader reader = new AndroidXml.AndroidXmlReader(stream, new AndroidResources(pathApk));
            reader.MoveToContent();
            XDocument document = XDocument.Load(reader);

            var first = document.Descendants().First();
            first.Add(new XAttribute(XNamespace.Xmlns + "android", "http://schemas.android.com/apk/res/android"));

            result = document.ToString();
        }

        return result;
    }

    /// <summary>
    /// Basic AndroidManifest.xml Parser
    /// </summary>
    /// <param name="manifest">The <see cref="string"/> path to the manifest binary file.</param>
    /// <returns>The <see cref="XDocument"/> representation of the basic AndroidManifest.xml file</returns>
    private static XDocument? ManifestAsXDocument(string manifest)
    {
        XDocument? result;
        using (Stream stream = File.OpenRead(manifest))
        {
            AndroidXml.AndroidXmlReader reader = new AndroidXml.AndroidXmlReader(stream);
            reader.MoveToContent();
            XDocument document = XDocument.Load(reader);

            var first = document.Descendants().First();
            first.Add(new XAttribute(XNamespace.Xmlns + "android", "http://schemas.android.com/apk/res/android"));

            result = document;
        }

        return result;
    }


    /// <summary>
    /// Full AndroidManifest.xml Parser with @Resource resolution with aapt2
    /// </summary>
    /// <param name="manifest">The <see cref="string"/> path to the manifest binary file.</param>
    /// <param name="pathApk">The <see cref="string"/> path to the apk file.</param>
    /// <returns>The <see cref="XDocument"/> representation of the full AndroidManifest.xml file.</returns>
    private static XDocument? ManifestAsXDocument(string manifest, string pathApk)
    {
        XDocument? result;
        using (Stream stream = File.OpenRead(manifest))
        {
            AndroidXml.AndroidXmlReader reader = new AndroidXml.AndroidXmlReader(stream, new AndroidResources(pathApk));
            reader.MoveToContent();
            XDocument document = XDocument.Load(reader);

            var first = document.Descendants().First();
            first.Add(new XAttribute(XNamespace.Xmlns + "android", "http://schemas.android.com/apk/res/android"));

            result = document;
        }

        return result;
    }

    /// <summary>
    /// Basic AndroidManifest.xml Parser
    /// </summary>
    /// <param name="manifest">The <see cref="string"/> path to the manifest binary file.</param>
    /// <returns>The <see cref="string"/> representation of the basic AndroidManifest.xml file in Json format</returns>
    public static string? ManifestToJson(string manifest)
    {
        string? result = null;
        var document = ManifestAsXDocument(manifest);
        if (document != null)
            result = JsonParser.Instance.AndroidXmlFile(document);
        return result;
    }

    /// <summary>
    /// Full AndroidManifest.xml Parser with @Resource resolution with aapt2
    /// </summary>
    /// <param name="manifest">The <see cref="string"/> path to the manifest binary file.</param>
    /// <param name="pathApk">The <see cref="string"/> path to the apk file.</param>
    /// <returns>The <see cref="string"/> representation of the full AndroidManifest.xml file in Json format.</returns>
    public static string? ManifestToJson(string manifest, string pathApk)
    {
        string? result = null;
        var document = ManifestAsXDocument(manifest, pathApk);
        if (document != null)
            result = JsonParser.Instance.AndroidXmlFile(document);
        return result;
    }
}

