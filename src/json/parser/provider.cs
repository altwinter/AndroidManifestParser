using System.Xml.Linq;

public sealed partial class JsonParser
{
    public Provider ProviderParser(XElement providerElement)
    {
        var result = new Provider();

        // Attribute
        var authorities = providerElement.Attribute(_androidNamespace + "authorities");
        var directBootAware = providerElement.Attribute(_androidNamespace + "directBootAware");
        var enabled = providerElement.Attribute(_androidNamespace + "enabled");
        var exported = providerElement.Attribute(_androidNamespace + "exported");
        var grantUriPermissions = providerElement.Attribute(_androidNamespace + "grantUriPermissions");
        var icon = providerElement.Attribute(_androidNamespace + "icon");
        var initOrder = providerElement.Attribute(_androidNamespace + "initOrder");
        var label = providerElement.Attribute(_androidNamespace + "label");
        var multiprocess = providerElement.Attribute(_androidNamespace + "multiprocess");
        var name = providerElement.Attribute(_androidNamespace + "name");
        var permission = providerElement.Attribute(_androidNamespace + "permission");
        var process = providerElement.Attribute(_androidNamespace + "process");
        var readPermission = providerElement.Attribute(_androidNamespace + "readPermission");
        var syncable = providerElement.Attribute(_androidNamespace + "syncable");
        var writePermission = providerElement.Attribute(_androidNamespace + "writePermission");

        if (authorities != null)
            result.authorities = authorities.Value;

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

        if (exported != null)
        {
            result.exported = Convert.ToBoolean(exported.Value);
        }
        else
        {
            if (_manifest.usesSdk!.targetSdkVersion >= 17)
            {
                result.exported = false;
            }
            else
            {
                result.exported = true;
            }

        }

        if (grantUriPermissions != null)
        {
            result.grantUriPermissions = Convert.ToBoolean(grantUriPermissions.Value);
        }
        else
        {
            result.grantUriPermissions = false;
        }

        if (icon != null)
            result.icon = icon.Value;

        if (initOrder != null)
            result.initOrder = Convert.ToInt32(initOrder.Value);

        if (label != null)
            result.label = label.Value;

        if (multiprocess != null)
        {
            result.multiprocess = Convert.ToBoolean(multiprocess.Value);
        }
        else
        {
            result.multiprocess = false;
        }

        if (name != null)
            result.name = name.Value;

        if (permission != null)
            result.permission = permission.Value;

        if (process != null)
            result.process = process.Value;

        if (readPermission != null)
            result.readPermission = readPermission.Value;

        if (syncable != null)
            result.syncable = Convert.ToBoolean(syncable.Value);

        if (writePermission != null)
            result.writePermission = writePermission.Value;

        foreach (var elem in providerElement.Elements())
        {
            switch (elem.Name.ToString())
            {
                case "meta-data":
                    {
                        if (result.metaDatas is null) result.metaDatas = new List<MetaData>();
                        result.metaDatas.Add(MetaDataParser(elem));
                        break;
                    }
                case "grant-uri-permission":
                    {
                        if (result.grantUriPermissionS is null) result.grantUriPermissionS = new List<GrantUriPermission>();
                        result.grantUriPermissionS.Add(GrantUriPermissionParser(elem));
                        break;
                    }
                case "intent-filter":
                    {
                        if (result.intentFilters is null) result.intentFilters = new List<IntentFilter>();
                        result.intentFilters.Add(IntentFilterParser(elem));
                        break;
                    }
                case "path-permission":
                    {
                        if (result.pathPermissions is null) result.pathPermissions = new List<PathPermission>();
                        result.pathPermissions.Add(PathPermissionParser(elem));
                        break;
                    }
                default:
                    break;
            }
        }

        return result;
    }
}