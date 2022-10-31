using System.Xml.Linq;

public sealed partial class JsonParser
{
    public PermissionGroup PermissionGroupParser(XElement permissionGroupElement)
    {
        var result = new PermissionGroup();

        // Attribute
        var description = permissionGroupElement.Attribute(_androidNamespace + "description");
        var icon = permissionGroupElement.Attribute(_androidNamespace + "icon");
        var label = permissionGroupElement.Attribute(_androidNamespace + "label");
        var name = permissionGroupElement.Attribute(_androidNamespace + "name");

        if (description is not null)
            result.description = description.Value;

        if (icon is not null)
            result.icon = icon.Value;

        if (label is not null)
            result.label = label.Value;

        if (name is not null)
            result.name = name.Value;

        return result;
    }
}