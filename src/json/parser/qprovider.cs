using System.Xml.Linq;

public sealed partial class JsonParser
{
    public QProvider QProviderParser(XElement providerElement)
    {
        var result = new QProvider();

        // Attribute
        var authorities = providerElement.Attribute(_androidNamespace + "authorities");

        if (authorities != null)
            result.authorities = authorities.Value;


        return result;
    }
}