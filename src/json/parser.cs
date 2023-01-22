using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Json Parser class
/// </summary>
public sealed partial class JsonParser
{
    /// <summary>
    /// Json Parser private instance
    /// </summary>
    private JsonParser()
    {
        _manifest = new Manifest();
        _androidNamespace = "http://schemas.android.com/apk/res/android";
    }

    /// <summary>
    /// JsonParser Instance
    /// </summary>
    /// <returns>An instance of the <see cref="JsonParser"/> class.</returns>
    public static JsonParser Instance
    {
        get { return Nested.instance; }
    }

    /// <summary>
    /// Converter of XDocument to <see cref="Json"/> value 
    /// </summary>
    /// <param name="manifest">The <see cref="XDocument"/> result from the previous parsing.</param>
    /// <returns>The <see cref="string"/> representation of the basic AndroidManifest.xml file in Json format</returns>
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

    /// <summary>
    /// Nested class
    /// </summary>
    private class Nested
    {
        /// <summary>
        /// Private Nested instance
        /// </summary>
        static Nested()
        {
        }

        /// <summary>
        /// Singleton of JsonParser class
        /// </summary>
        internal static readonly JsonParser instance = new JsonParser();
    }
}