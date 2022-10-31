using System.Xml.Linq;

public sealed partial class JsonParser
{
    public ActivityAlias ActivityAliasParser(XElement activityAliasElement)
    {
        var result = new ActivityAlias();

        // Attribute
        var enabled = activityAliasElement.Attribute(_androidNamespace + "enabled");
        var exported = activityAliasElement.Attribute(_androidNamespace + "exported");
        var icon = activityAliasElement.Attribute(_androidNamespace + "icon");
        var label = activityAliasElement.Attribute(_androidNamespace + "label");
        var name = activityAliasElement.Attribute(_androidNamespace + "name");
        var permission = activityAliasElement.Attribute(_androidNamespace + "permission");
        var targetActivity = activityAliasElement.Attribute(_androidNamespace + "targetActivity");

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

        if (targetActivity != null)
            result.targetActivity = targetActivity.Value;


        foreach (var elem in activityAliasElement.Elements())
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