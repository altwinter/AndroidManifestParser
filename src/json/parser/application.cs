using System.Xml.Linq;

public sealed partial class JsonParser
{
    public Application ApplicationParser(XElement applicationElement)
    {
        var result = new Application();

        // Attribute
        var allowTaskReparenting = applicationElement.Attribute(_androidNamespace + "allowTaskReparenting");
        var allowBackup = applicationElement.Attribute(_androidNamespace + "allowBackup");
        var allowClearUserData = applicationElement.Attribute(_androidNamespace + "allowClearUserData");
        var allowNativeHeapPointerTagging = applicationElement.Attribute(_androidNamespace + "allowNativeHeapPointerTagging");
        var appCategory = applicationElement.Attribute(_androidNamespace + "appCategory");
        var backupAgent = applicationElement.Attribute(_androidNamespace + "backupAgent");
        var backupInForeground = applicationElement.Attribute(_androidNamespace + "backupInForeground");
        var banner = applicationElement.Attribute(_androidNamespace + "banner");
        var dataExtractionRules = applicationElement.Attribute(_androidNamespace + "dataExtractionRules");
        var debuggable = applicationElement.Attribute(_androidNamespace + "debuggable");
        var description = applicationElement.Attribute(_androidNamespace + "description");
        var enabled = applicationElement.Attribute(_androidNamespace + "enabled");
        var extractNativeLibs = applicationElement.Attribute(_androidNamespace + "extractNativeLibs");
        var fullBackupContent = applicationElement.Attribute(_androidNamespace + "fullBackupContent");
        var fullBackupOnly = applicationElement.Attribute(_androidNamespace + "fullBackOnly");
        var gwpAsanMode = applicationElement.Attribute(_androidNamespace + "gwpAsanMode");
        var hasCode = applicationElement.Attribute(_androidNamespace + "hasCode");
        var hasFragileUserData = applicationElement.Attribute(_androidNamespace + "hasFragileUserData");
        var hardwareAccelerated = applicationElement.Attribute(_androidNamespace + "hardwareAccelerated");
        var icon = applicationElement.Attribute(_androidNamespace + "icon");
        var isGame = applicationElement.Attribute(_androidNamespace + "isGame");
        var killAfterRestore = applicationElement.Attribute(_androidNamespace + "killAfterRestore");
        var largeHeap = applicationElement.Attribute(_androidNamespace + "largeHeap");
        var label = applicationElement.Attribute(_androidNamespace + "label");
        var logo = applicationElement.Attribute(_androidNamespace + "logo");
        var manageSpaceActivity = applicationElement.Attribute(_androidNamespace + "manageSpaceActivity");
        var name = applicationElement.Attribute(_androidNamespace + "name");
        var networkSecurityConfig = applicationElement.Attribute(_androidNamespace + "networkSecurityConfig");
        var permission = applicationElement.Attribute(_androidNamespace + "permission");
        var persistent = applicationElement.Attribute(_androidNamespace + "persistent");
        var process = applicationElement.Attribute(_androidNamespace + "process");
        var restoreAnyVersion = applicationElement.Attribute(_androidNamespace + "restoreAnyVersion");
        var requestLegacyExternalStorage = applicationElement.Attribute(_androidNamespace + "requestLegacyExternalStorage");
        var requiredAccountType = applicationElement.Attribute(_androidNamespace + "requiredAccountType");
        var resizeableActivity = applicationElement.Attribute(_androidNamespace + "resizeableActivity");
        var restrictedAccountType = applicationElement.Attribute(_androidNamespace + "restrictedAccountType");
        var supportsRtl = applicationElement.Attribute(_androidNamespace + "supportsRtl");
        var taskAffinity = applicationElement.Attribute(_androidNamespace + "taskAffinity");
        var testOnly = applicationElement.Attribute(_androidNamespace + "testOnly");
        var theme = applicationElement.Attribute(_androidNamespace + "theme");
        var uiOptions = applicationElement.Attribute(_androidNamespace + "uiOptions");
        var usesCleartextTraffic = applicationElement.Attribute(_androidNamespace + "usesCleartextTraffic");
        var vmSafeMode = applicationElement.Attribute(_androidNamespace + "vmSafeMode");


        if (allowTaskReparenting != null)
        {
            result.allowTaskReparenting = Convert.ToBoolean(allowTaskReparenting.Value);
        }
        else
        {
            result.allowTaskReparenting = false;
        }

        if (allowBackup != null)
        {
            result.allowBackup = Convert.ToBoolean(allowBackup.Value);
        }
        else
        {
            result.allowBackup = true;
        }

        if (allowClearUserData != null)
        {
            result.allowClearUserData = Convert.ToBoolean(allowClearUserData.Value);
        }
        else
        {
            result.allowClearUserData = true;
        }

        if (allowNativeHeapPointerTagging != null)
        {
            result.allowNativeHeapPointerTagging = Convert.ToBoolean(allowNativeHeapPointerTagging.Value);
        }
        else
        {
            result.allowNativeHeapPointerTagging = true;
        }

        if (appCategory != null)
            result.appCategory = appCategory.Value;

        if (backupAgent != null)
            result.backupAgent = backupAgent.Value;

        if (backupInForeground != null)
        {
            result.backupInForeground = Convert.ToBoolean(backupInForeground.Value);
        }
        else
        {
            result.backupInForeground = false;
        }

        if (banner != null)
            result.banner = banner.Value;

        if (dataExtractionRules != null)
            result.dataExtractionRules = dataExtractionRules.Value;

        if (debuggable != null)
        {
            result.debuggable = Convert.ToBoolean(debuggable.Value);
        }
        else
        {
            result.debuggable = false;
        }

        if (description != null)
            result.description = description.Value;

        if (enabled != null)
        {
            result.enabled = Convert.ToBoolean(enabled.Value);
        }
        else
        {
            result.enabled = true;
        }

        if (extractNativeLibs != null)
            result.extractNativeLibs = Convert.ToBoolean(extractNativeLibs.Value);

        if (fullBackupContent != null)
            result.fullBackupContent = fullBackupContent.Value;

        if (fullBackupOnly != null)
        {
            result.fullBackupOnly = Convert.ToBoolean(fullBackupOnly.Value);
        }
        else
        {
            result.fullBackupOnly = false;
        }

        if (gwpAsanMode != null)
        {
            result.gwpAsanMode = gwpAsanMode.Value;
        }
        else
        {
            result.gwpAsanMode = "never";
        }

        if (hasCode != null)
        {
            result.hasCode = Convert.ToBoolean(hasCode.Value);
        }
        else
        {
            result.hasCode = true;
        }

        if (hasFragileUserData != null)
        {
            result.hasFragileUserData = Convert.ToBoolean(hasFragileUserData.Value);
        }
        else
        {
            result.hasFragileUserData = false;
        }

        if (hardwareAccelerated != null)
        {
            result.hardwareAccelerated = Convert.ToBoolean(hardwareAccelerated.Value);
        }
        else
        {
            if ((_manifest.usesSdk!.targetSdkVersion >= 14) || (_manifest.usesSdk!.targetSdkVersion >= 14))
            {
                result.hardwareAccelerated = true;
            }
            else
            {
                result.hardwareAccelerated = false;
            }
        }

        if (icon != null)
            result.icon = icon.Value;

        if (isGame != null)
        {
            result.isGame = Convert.ToBoolean(isGame.Value);
        }
        else
        {
            result.isGame = false;
        }

        if (killAfterRestore != null)
        {
            result.killAfterRestore = Convert.ToBoolean(killAfterRestore.Value);
        }
        else
        {
            result.killAfterRestore = true;
        }

        if (largeHeap != null)
            result.largeHeap = Convert.ToBoolean(largeHeap.Value);

        if (label != null)
            result.label = label.Value;

        if (logo != null)
            result.logo = logo.Value;

        if (manageSpaceActivity != null)
            result.manageSpaceActivity = manageSpaceActivity.Value;

        if (name != null)
            result.name = name.Value;

        if (networkSecurityConfig != null)
            result.networkSecurityConfig = networkSecurityConfig.Value;

        if (permission != null)
            result.permission = permission.Value;

        if (persistent != null)
        {
            result.persistent = Convert.ToBoolean(persistent.Value);
        }
        else
        {
            result.persistent = false;
        }

        if (process != null)
            result.process = process.Value;

        if (restoreAnyVersion != null)
        {
            result.restoreAnyVersion = Convert.ToBoolean(restoreAnyVersion.Value);
        }
        else
        {
            result.restoreAnyVersion = false;
        }

        if (requestLegacyExternalStorage != null)
            result.requestLegacyExternalStorage = Convert.ToBoolean(requestLegacyExternalStorage.Value);

        if (requiredAccountType != null)
            result.requiredAccountType = requiredAccountType.Value;

        if (resizeableActivity != null)
        {
            result.resizeableActivity = Convert.ToBoolean(resizeableActivity.Value);
        }
        else
        {
            if (_manifest.usesSdk!.targetSdkVersion >= 24)
                result.resizeableActivity = true;
        }

        if (restrictedAccountType != null)
            result.restrictedAccountType = restrictedAccountType.Value;

        if (supportsRtl != null)
        {
            result.supportsRtl = Convert.ToBoolean(supportsRtl.Value);
        }
        else
        {
            result.supportsRtl = false;
        }

        if (taskAffinity != null)
            result.taskAffinity = taskAffinity.Value;

        if (testOnly != null)
            result.testOnly = Convert.ToBoolean(testOnly.Value);

        if (theme != null)
            result.theme = theme.Value;

        if (uiOptions != null)
        {
            result.uiOptions = uiOptions.Value;
        }
        else
        {
            result.uiOptions = "none";
        }

        if (usesCleartextTraffic != null)
        {
            result.usesCleartextTraffic = Convert.ToBoolean(usesCleartextTraffic.Value);
        }
        else
        {
            if (_manifest.usesSdk!.targetSdkVersion < 28)
            {
                result.usesCleartextTraffic = true;
            }
            else
            {
                result.usesCleartextTraffic = false;
            }
        }

        if (vmSafeMode != null)
        {
            result.vmSafeMode = Convert.ToBoolean(vmSafeMode.Value);
        }
        else
        {
            result.vmSafeMode = false;
        }

        foreach (var elem in applicationElement.Elements())
        {
            switch (elem.Name.ToString())
            {
                case "meta-data":
                    {
                        if (result.metaDatas is null) result.metaDatas = new List<MetaData>();
                        result.metaDatas.Add(MetaDataParser(elem));
                        break;
                    }
                case "activity":
                    {
                        if (result.activities is null) result.activities = new List<Activity>();
                        result.activities.Add(ActivityParser(elem));
                        break;
                    }
                case "activity-alias":
                    {
                        if (result.activityAliases is null) result.activityAliases = new List<ActivityAlias>();
                        result.activityAliases.Add(ActivityAliasParser(elem));
                        break;
                    }
                case "service":
                    {
                        if (result.services is null) result.services = new List<Service>();
                        result.services.Add(ServiceParser(elem));
                        break;
                    }
                case "receiver":
                    {
                        if (result.receivers is null) result.receivers = new List<Receiver>();
                        result.receivers.Add(ReceiverParser(elem));
                        break;
                    }
                case "profileable":
                    {
                        if (result.profileables is null) result.profileables = new List<Profileable>();
                        result.profileables.Add(ProfileableParser(elem));
                        break;
                    }
                case "provider":
                    {
                        if (result.providers is null) result.providers = new List<Provider>();
                        result.providers.Add(ProviderParser(elem));
                        break;
                    }
                case "uses-library":
                    {
                        if (result.usesLibraries is null) result.usesLibraries = new List<UsesLibrary>();
                        result.usesLibraries.Add(UsesLibraryParser(elem));
                        break;
                    }
                case "uses-native-library":
                    {
                        if (result.usesNativeLibraries is null) result.usesNativeLibraries = new List<UsesNativeLibrary>();
                        result.usesNativeLibraries.Add(UsesNativeLibraryParser(elem));
                        break;
                    }
                default:
                    break;
            }
        }

        return result;
    }
}