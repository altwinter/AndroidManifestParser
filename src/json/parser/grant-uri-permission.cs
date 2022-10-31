using System.Xml.Linq;

public sealed partial class JsonParser
{
    public GrantUriPermission GrantUriPermissionParser(XElement grantUriPermissionElement)
    {
        var result = new GrantUriPermission();

        // Attribute
        var path = grantUriPermissionElement.Attribute(_androidNamespace + "path");
        var pathPattern = grantUriPermissionElement.Attribute(_androidNamespace + "pathPattern");
        var pathPrefix = grantUriPermissionElement.Attribute(_androidNamespace + "pathPrefix");

        if (path != null)
            result.path = path.Value;

        if (pathPattern != null)
            result.pathPattern = pathPattern.Value;

        if (pathPrefix != null)
            result.pathPrefix = pathPrefix.Value;

        return result;
    }
}