using System.Xml.Linq;

public sealed partial class JsonParser
{
    public UsesFeature UsesFeatureParser(XElement usesFeatureElement)
    {
        var result = new UsesFeature();

        // Attribute
        var name = usesFeatureElement.Attribute(_androidNamespace + "name");
        var required = usesFeatureElement.Attribute(_androidNamespace + "required");
        var glEsVersion = usesFeatureElement.Attribute(_androidNamespace + "glEsVersion");

        if (name != null)
            result.name = name.Value;

        if (required != null)
        {
            result.required = Convert.ToBoolean(required.Value);
        }
        else
        {
            result.required = true;
        }

        if (glEsVersion != null)
            result.glEsVersion = Convert.ToInt32(glEsVersion.Value, 16);

        return result;
    }
}