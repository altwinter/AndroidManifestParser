using System.Xml.Linq;

public sealed partial class JsonParser
{
    public Category CategoryParser(XElement categoryElement)
    {
        var result = new Category();

        // Attribute
        var name = categoryElement.Attribute(_androidNamespace + "name");

        if (name != null)
            result.name = name.Value;


        return result;
    }
}