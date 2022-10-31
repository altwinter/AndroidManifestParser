using System.Xml.Linq;

public sealed partial class JsonParser
{
    public Layout LayoutParser(XElement layoutElement)
    {
        var result = new Layout();

        // Attribute
        var defaultHeight = layoutElement.Attribute(_androidNamespace + "defaultHeight");
        var defaultWidth = layoutElement.Attribute(_androidNamespace + "defaultWidth");
        var gravity = layoutElement.Attribute(_androidNamespace + "gravity");
        var minHeight = layoutElement.Attribute(_androidNamespace + "minHeight");
        var minWidth = layoutElement.Attribute(_androidNamespace + "minWidth");


        if (defaultHeight != null)
            result.defaultHeight = defaultHeight.Value;

        if (defaultWidth != null)
            result.defaultWidth = defaultWidth.Value;

        if (gravity != null)
            result.gravity = gravity.Value;

        if (minHeight != null)
            result.minHeight = minHeight.Value;

        if (minWidth != null)
            result.minWidth = minWidth.Value;

        return result;
    }
}