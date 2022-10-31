using System.Xml.Linq;

public sealed partial class JsonParser
{
    public Screen ScreenParser(XElement screenElement)
    {
        var result = new Screen();

        // Attribute
        var screenSize = screenElement.Attribute(_androidNamespace + "screenSize");
        var screenDensity = screenElement.Attribute(_androidNamespace + "screenDensity");

        if (screenSize != null)
            result.screenSize = screenSize.Value;


        if (screenDensity != null)
            result.screenDensity = screenDensity.Value;

        return result;
    }
}