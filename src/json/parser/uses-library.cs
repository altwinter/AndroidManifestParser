using System.Xml.Linq;

public sealed partial class JsonParser
{
    public UsesLibrary UsesLibraryParser(XElement usesLibraryElement)
    {
        var result = new UsesLibrary();

        // Attribute
        var name = usesLibraryElement.Attribute(_androidNamespace + "name");
        var required = usesLibraryElement.Attribute(_androidNamespace + "required");

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


        return result;
    }
}