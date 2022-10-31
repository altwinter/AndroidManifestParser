using System.Xml.Linq;

public sealed partial class JsonParser
{
    public SupportsGlTexture SupportGlTextureParser(XElement supportsGlTextureElement)
    {
        var result = new SupportsGlTexture();

        // Attribute
        var name = supportsGlTextureElement.Attribute(_androidNamespace + "name");

        if (name != null)
            result.name = name.Value;

        return result;
    }
}