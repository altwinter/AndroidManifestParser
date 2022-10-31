using System.Xml.Linq;

public sealed partial class JsonParser
{
    public MetaData MetaDataParser(XElement metaDataElement)
    {
        var result = new MetaData();

        // Attribute
        var name = metaDataElement.Attribute(_androidNamespace + "name");
        var resource = metaDataElement.Attribute(_androidNamespace + "resource");
        var value = metaDataElement.Attribute(_androidNamespace + "value");

        if (name != null)
            result.name = name.Value;

        if (resource != null)
            result.resource = resource.Value;

        if (value != null)
            result.value = value.Value;

        return result;
    }
}