using System.Xml.Linq;

public sealed partial class JsonParser
{
    public UsesNativeLibrary UsesNativeLibraryParser(XElement usesNativeLibraryElement)
    {
        var result = new UsesNativeLibrary();

        // Attribute
        var name = usesNativeLibraryElement.Attribute(_androidNamespace + "name");
        var required = usesNativeLibraryElement.Attribute(_androidNamespace + "required");

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