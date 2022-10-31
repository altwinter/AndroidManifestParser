using System.Xml.Linq;

public sealed partial class JsonParser
{
    public Data DataParser(XElement dataElement)
    {
        var result = new Data();

        // Attribute
        var scheme = dataElement.Attribute(_androidNamespace + "scheme");
        var host = dataElement.Attribute(_androidNamespace + "host");
        var port = dataElement.Attribute(_androidNamespace + "port");
        var path = dataElement.Attribute(_androidNamespace + "path");
        var pathPattern = dataElement.Attribute(_androidNamespace + "pathPattern");
        var pathPrefix = dataElement.Attribute(_androidNamespace + "pathPrefix");
        var mimeType = dataElement.Attribute(_androidNamespace + "mimeType");

        if (scheme != null)
            result.scheme = scheme.Value;

        if (host != null)
            result.host = host.Value;

        if (port != null)
            result.port = port.Value;

        if (path != null)
            result.path = path.Value;

        if (pathPattern != null)
            result.pathPattern = pathPattern.Value;

        if (pathPrefix != null)
            result.pathPrefix = pathPrefix.Value;

        if (mimeType != null)
            result.mimeType = mimeType.Value;

        return result;
    }
}