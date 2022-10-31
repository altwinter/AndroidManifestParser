using System.Xml.Linq;

public sealed partial class JsonParser
{
    public PathPermission PathPermissionParser(XElement pathPermissionElement)
    {
        var result = new PathPermission();

        // Attribute
        var path = pathPermissionElement.Attribute(_androidNamespace + "path");
        var pathPattern = pathPermissionElement.Attribute(_androidNamespace + "pathPattern");
        var pathPrefix = pathPermissionElement.Attribute(_androidNamespace + "pathPrefix");
        var permission = pathPermissionElement.Attribute(_androidNamespace + "permission");
        var readPermission = pathPermissionElement.Attribute(_androidNamespace + "readPermission");
        var writePermission = pathPermissionElement.Attribute(_androidNamespace + "writePermission");

        if (path != null)
            result.path = path.Value;

        if (pathPattern != null)
            result.pathPattern = pathPattern.Value;

        if (pathPrefix != null)
            result.pathPrefix = pathPrefix.Value;

        if (permission != null)
            result.permission = permission.Value;

        if (readPermission != null)
            result.readPermission = readPermission.Value;

        if (writePermission != null)
            result.writePermission = writePermission.Value;

        return result;
    }
}