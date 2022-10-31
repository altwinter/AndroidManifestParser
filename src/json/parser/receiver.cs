using System.Xml.Linq;

public sealed partial class JsonParser
{
    public Receiver ReceiverParser(XElement receiverElement)
    {
        var result = new Receiver();

        // Attribute
        var directBootAware = receiverElement.Attribute(_androidNamespace + "directBootAware");
        var enabled = receiverElement.Attribute(_androidNamespace + "enabled");
        var exported = receiverElement.Attribute(_androidNamespace + "exported");
        var icon = receiverElement.Attribute(_androidNamespace + "icon");
        var label = receiverElement.Attribute(_androidNamespace + "label");
        var name = receiverElement.Attribute(_androidNamespace + "name");
        var permission = receiverElement.Attribute(_androidNamespace + "permission");
        var process = receiverElement.Attribute(_androidNamespace + "process");

        if (directBootAware != null)
        {
            result.directBootAware = Convert.ToBoolean(directBootAware.Value);
        }
        else
        {
            result.directBootAware = false;
        }

        if (enabled != null)
        {
            result.enabled = Convert.ToBoolean(enabled.Value);
        }
        else
        {
            result.enabled = true;
        }

        if (icon != null)
            result.icon = icon.Value;

        if (label != null)
            result.label = label.Value;

        if (name != null)
            result.name = name.Value;

        if (permission != null)
            result.permission = permission.Value;

        if (process != null)
            result.process = process.Value;

        foreach (var elem in receiverElement.Elements())
        {
            switch (elem.Name.ToString())
            {
                case "meta-data":
                    {
                        if (result.metaDatas is null) result.metaDatas = new List<MetaData>();
                        result.metaDatas.Add(MetaDataParser(elem));
                        break;
                    }
                case "intent-filter":
                    {
                        if (result.intentFilters is null) result.intentFilters = new List<IntentFilter>();
                        result.intentFilters.Add(IntentFilterParser(elem));
                        break;
                    }
                default:
                    break;
            }
        }

        if (exported != null)
        {
            result.exported = Convert.ToBoolean(exported.Value);
        }
        else
        {
            if (result.intentFilters is not null)
            {
                result.exported = false;
            }
            else
            {
                result.exported = true;
            }

        }
        return result;
    }
}