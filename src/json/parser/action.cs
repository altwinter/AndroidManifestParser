using System.Xml.Linq;

public sealed partial class JsonParser
{
    public Action ActionParser(XElement actionElement)
    {
        var result = new Action();

        // Attribute
        var name = actionElement.Attribute(_androidNamespace + "name");

        if (name != null)
            result.name = name.Value;


        return result;
    }
}