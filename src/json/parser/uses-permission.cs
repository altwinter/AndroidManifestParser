using System.Xml.Linq;

public sealed partial class JsonParser
{
    public UsesPermission UsesPermissionParser(XElement usesPermissionElement)
    {
        var result = new UsesPermission();

        // Attribute
        var name = usesPermissionElement.Attribute(_androidNamespace + "name");
        var maxSdkVersion = usesPermissionElement.Attribute(_androidNamespace + "maxSdkVersion");

        if (name != null)
            result.name = name.Value;

        if (maxSdkVersion != null)
            result.maxSdkVersion = Convert.ToInt32(maxSdkVersion.Value);

        return result;
    }
}