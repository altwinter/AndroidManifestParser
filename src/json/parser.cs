using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

public sealed partial class JsonParser
{
    private JsonParser()
    {
        _manifest = new Manifest();
        _androidNamespace = "http://schemas.android.com/apk/res/android";
    }

    public static JsonParser Instance
    {
        get { return Nested.instance; }
    }

    public string? AndroidXmlFile(XDocument manifest)
    {

        string? result = null;

        var manifestElem = manifest.Element("manifest");
        if (manifestElem != null)
            ManifestParser(manifestElem);

        // Convert manifest to Json
        var opt = new JsonSerializerOptions() { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
        // var manifestCopy = _manifest;
        result = JsonSerializer.Serialize(_manifest, opt);

        return result;
    }

    private readonly Manifest _manifest;
    private readonly XNamespace _androidNamespace;


    private class Nested
    {
        static Nested()
        {
        }

        internal static readonly JsonParser instance = new JsonParser();
    }
}