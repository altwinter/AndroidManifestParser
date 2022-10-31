using System.Xml.Linq;

public sealed partial class JsonParser
{
    public Package PackageParser(XElement packageElement)
    {
        var result = new Package();

        // Attribute
        var name = packageElement.Attribute(_androidNamespace + "name");

        if (name != null)
            result.name = name.Value;

        return result;
    }
}