using System.Xml.Linq;

public sealed partial class JsonParser
{
    public Permission PermissionParser(XElement permissionElement)
    {
        var result = new Permission();

        // Attribute
        var description = permissionElement.Attribute(_androidNamespace + "description");
        var icon = permissionElement.Attribute(_androidNamespace + "icon");
        var label = permissionElement.Attribute(_androidNamespace + "label");
        var name = permissionElement.Attribute(_androidNamespace + "name");
        var permissionGroup = permissionElement.Attribute(_androidNamespace + "permissionGroup");
        var permissionLevel = permissionElement.Attribute(_androidNamespace + "permissionLevel");

        if (description != null)
            result.description = description.Value;

        if (icon != null)
            result.icon = icon.Value;

        if (label != null)
            result.label = label.Value;

        if (name != null)
            result.name = name.Value;

        if (permissionGroup != null)
            result.permissionGroup = permissionGroup.Value;

        if (permissionLevel != null)
        {
            result.permissionLevel = permissionLevel.Value;
        }
        else
        {
            result.permissionLevel = "normal";
        }

        return result;
    }
}