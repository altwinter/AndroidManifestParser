using System.Xml.Linq;

class AndroidParser
{
    // Note replace all string result value "" by ?
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

        return result;
    }

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

    public static string? ManifestToJson(string manifest)
    {
        string? result = null;
        var document = ManifestAsXDocument(manifest);
        if (document != null)
            result = JsonParser.Instance.AndroidXmlFile(document);
        return result;
    }


    public static string? ManifestToJson(string manifest, string pathApk)
    {
        string? result = null;
        var document = ManifestAsXDocument(manifest, pathApk);
        if (document != null)
            result = JsonParser.Instance.AndroidXmlFile(document);
        return result;
    }
}

