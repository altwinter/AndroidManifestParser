using System.Xml.Linq;

public sealed partial class JsonParser
{
    public Service ServiceParser(XElement serviceElement)
    {
        var result = new Service();

        // Attribute
        var description = serviceElement.Attribute(_androidNamespace + "description");
        var directBootAware = serviceElement.Attribute(_androidNamespace + "directBootAware");
        var enabled = serviceElement.Attribute(_androidNamespace + "enabled");
        var exported = serviceElement.Attribute(_androidNamespace + "exported");
        var foregroundServiceType = serviceElement.Attribute(_androidNamespace + "foregroundServiceType");
        var icon = serviceElement.Attribute(_androidNamespace + "icon");
        var isolatedProcess = serviceElement.Attribute(_androidNamespace + "isolatedProcess");
        var label = serviceElement.Attribute(_androidNamespace + "label");
        var name = serviceElement.Attribute(_androidNamespace + "name");
        var permission = serviceElement.Attribute(_androidNamespace + "permission");
        var process = serviceElement.Attribute(_androidNamespace + "process");

        if (description != null)
            result.description = description.Value;

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

        if (foregroundServiceType != null)
            result.foregroundServiceType = foregroundServiceType.Value;


        if (icon != null)
            result.icon = icon.Value;

        if (isolatedProcess != null)
            result.isolatedProcess = Convert.ToBoolean(isolatedProcess.Value);

        if (label != null)
            result.label = label.Value;

        if (name != null)
            result.name = name.Value;

        if (permission != null)
            result.permission = permission.Value;

        if (process != null)
            result.process = process.Value;


        foreach (var elem in serviceElement.Elements())
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