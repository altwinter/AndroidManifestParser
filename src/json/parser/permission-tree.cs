using System.Xml.Linq;

public sealed partial class JsonParser
{
    public PermissionTree PermissionTreeParser(XElement permissionTreeElement)
    {
        var result = new PermissionTree();

        // Attribute
        var icon = permissionTreeElement.Attribute(_androidNamespace + "icon");
        var label = permissionTreeElement.Attribute(_androidNamespace + "label");
        var name = permissionTreeElement.Attribute(_androidNamespace + "name");

        if (icon is not null)
            result.icon = icon.Value;

        if (label is not null)
            result.label = label.Value;

        if (name is not null)
            result.name = name.Value;

        return result;
    }
}