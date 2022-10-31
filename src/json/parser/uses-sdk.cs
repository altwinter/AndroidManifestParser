using System.Xml.Linq;

public sealed partial class JsonParser
{
    public UsesSdk UsesSdkParser(XElement usesSdkElement)
    {
        var result = new UsesSdk();

        // Attribute
        var minSdkVersion = usesSdkElement.Attribute(_androidNamespace + "minSdkVersion");
        var targetSdkVersion = usesSdkElement.Attribute(_androidNamespace + "targetSdkVersion");
        var maxSdkVersion = usesSdkElement.Attribute(_androidNamespace + "maxSdkVersion");

        if (minSdkVersion != null)
        {
            result.minSdkVersion = Convert.ToInt32(minSdkVersion.Value);
        }
        else
        {
            result.minSdkVersion = 1;
        }

        if (targetSdkVersion != null)
        {
            result.targetSdkVersion = Convert.ToInt32(targetSdkVersion.Value);
        }
        else
        {
            result.targetSdkVersion = result.minSdkVersion;
        }

        if (maxSdkVersion != null)
            result.maxSdkVersion = Convert.ToInt32(maxSdkVersion.Value);


        return result;
    }
}