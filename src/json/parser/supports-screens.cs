using System.Xml.Linq;

public sealed partial class JsonParser
{
    public SupportsScreens SupportScreensParser(XElement supportsScreensElement)
    {
        var result = new SupportsScreens();

        // Attribute
        var resizeable = supportsScreensElement.Attribute(_androidNamespace + "resizeable");
        var smallScreens = supportsScreensElement.Attribute(_androidNamespace + "smallScreens");
        var normalScreens = supportsScreensElement.Attribute(_androidNamespace + "normalScreens");
        var largeScreens = supportsScreensElement.Attribute(_androidNamespace + "largeScreens");
        var xlargeScreens = supportsScreensElement.Attribute(_androidNamespace + "xlargeScreens");
        var anyDensity = supportsScreensElement.Attribute(_androidNamespace + "anyDensity");
        var requiresSmallestWidthDp = supportsScreensElement.Attribute(_androidNamespace + "requiresSmallestWidthDp");
        var compatibleWidthLimitDp = supportsScreensElement.Attribute(_androidNamespace + "compatibleWidthLimitDp");
        var largestWidthLimitDp = supportsScreensElement.Attribute(_androidNamespace + "largestWidthLimitDp");

        if (resizeable != null)
        {
            result.resizeable = Convert.ToBoolean(resizeable.Value);
        }
        else
        {
            result.resizeable = true;
        }

        if (smallScreens != null)
        {
            result.smallScreens = Convert.ToBoolean(smallScreens.Value);
        }
        else
        {
            result.smallScreens = true;
        }

        if (normalScreens != null)
        {
            result.normalScreens = Convert.ToBoolean(normalScreens.Value);
        }
        else
        {
            result.normalScreens = true;
        }

        if (largeScreens != null)
            result.largeScreens = Convert.ToBoolean(largeScreens.Value);

        if (xlargeScreens != null)
            result.xlargeScreens = Convert.ToBoolean(xlargeScreens.Value);

        if (anyDensity != null)
        {
            result.anyDensity = Convert.ToBoolean(anyDensity.Value);
        }
        else
        {
            result.anyDensity = true;
        }

        if (requiresSmallestWidthDp != null)
            result.requiresSmallestWidthDp = Convert.ToInt32(requiresSmallestWidthDp.Value);

        if (compatibleWidthLimitDp != null)
            result.compatibleWidthLimitDp = Convert.ToInt32(compatibleWidthLimitDp.Value);

        if (largestWidthLimitDp != null)
            result.largestWidthLimitDp = Convert.ToInt32(largestWidthLimitDp.Value);

        return result;
    }
}