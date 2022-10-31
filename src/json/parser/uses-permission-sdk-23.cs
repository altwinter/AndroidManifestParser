using System.Xml.Linq;

public sealed partial class JsonParser
{
    public UsesPermissionSdk23 UsesPermissionSdk23Parser(XElement usesPermissionSdk23Element)
    {
        var result = new UsesPermissionSdk23();

        // Attribute
        var name = usesPermissionSdk23Element.Attribute(_androidNamespace + "name");
        var maxSdkVersion = usesPermissionSdk23Element.Attribute(_androidNamespace + "maxSdkVersion");

        if (name != null)
            result.name = name.Value;

        if (maxSdkVersion != null)
            result.maxSdkVersion = Convert.ToInt32(maxSdkVersion.Value);

        return result;
    }
}