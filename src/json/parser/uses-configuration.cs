using System.Xml.Linq;

public sealed partial class JsonParser
{
    public UsesConfiguration UsesConfigurationParser(XElement usesConfigurationElement)
    {
        var result = new UsesConfiguration();

        // Attribute
        var reqFiveWayNav = usesConfigurationElement.Attribute(_androidNamespace + "reqFiveWayNav");
        var reqHardKeyboard = usesConfigurationElement.Attribute(_androidNamespace + "reqHardKeyboard");
        var reqKeyboardType = usesConfigurationElement.Attribute(_androidNamespace + "reqKeyboardType");
        var reqNavigation = usesConfigurationElement.Attribute(_androidNamespace + "reqNavigation");
        var reqTouchScreen = usesConfigurationElement.Attribute(_androidNamespace + "reqTouchScreen");

        if (reqFiveWayNav != null)
            result.reqFiveWayNav = Convert.ToBoolean(reqFiveWayNav.Value);

        if (reqHardKeyboard != null)
            result.reqHardKeyboard = Convert.ToBoolean(reqHardKeyboard.Value);

        if (reqKeyboardType != null)
        {
            result.reqKeyboardType = reqKeyboardType.Value;
        }
        else
        {
            result.reqKeyboardType = "undefined";
        }

        if (reqNavigation != null)
        {
            result.reqNavigation = reqNavigation.Value;
        }
        else
        {
            result.reqNavigation = "undefined";
        }

        if (reqTouchScreen != null)
        {
            result.reqTouchScreen = reqTouchScreen.Value;
        }
        else
        {
            result.reqTouchScreen = "undefined";
        }


        return result;
    }
}