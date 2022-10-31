using System.Xml.Linq;

public sealed partial class JsonParser
{
    public CompatibleScreens CompatibleScreensParser(XElement compatibleScreensElement)
    {
        var result = new CompatibleScreens();

        // Element
        var screens = compatibleScreensElement.Elements("screen");
        foreach (var screen in screens)
        {
            if (result.screens == null) result.screens = new List<Screen>();

            result.screens.Add(ScreenParser(screen));
        }

        return result;
    }
}