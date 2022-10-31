using System.Xml.Linq;

public sealed partial class JsonParser
{
    public Activity ActivityParser(XElement activityElement)
    {
        var result = new Activity();

        // Attribute
        var allowEmbedded = activityElement.Attribute(_androidNamespace + "allowEmbedded");
        var allowTaskReparenting = activityElement.Attribute(_androidNamespace + "allowTaskReparenting");
        var alwaysRetainTaskState = activityElement.Attribute(_androidNamespace + "alwaysRetainTaskState");
        var autoRemoveFromRecents = activityElement.Attribute(_androidNamespace + "autoRemoveFromRecents");
        var banner = activityElement.Attribute(_androidNamespace + "banner");
        var clearTaskOnLaunch = activityElement.Attribute(_androidNamespace + "clearTaskOnLaunch");
        var colorMode = activityElement.Attribute(_androidNamespace + "colorMode");
        var configChanges = activityElement.Attribute(_androidNamespace + "configChanges");
        var directBootAware = activityElement.Attribute(_androidNamespace + "directBootAware");
        var documentLaunchMode = activityElement.Attribute(_androidNamespace + "documentLaunchMode");
        var enabled = activityElement.Attribute(_androidNamespace + "enabled");
        var excludeFromRecents = activityElement.Attribute(_androidNamespace + "excludeFromRecents");
        var exported = activityElement.Attribute(_androidNamespace + "exported");
        var finishOnTaskLaunch = activityElement.Attribute(_androidNamespace + "finishOnTaskLaunch");
        var hardwareAccelerated = activityElement.Attribute(_androidNamespace + "hardwareAccelerated");
        var icon = activityElement.Attribute(_androidNamespace + "icon");
        var immersive = activityElement.Attribute(_androidNamespace + "immersive");
        var label = activityElement.Attribute(_androidNamespace + "label");
        var launchMode = activityElement.Attribute(_androidNamespace + "launchMode");
        var lockTaskMode = activityElement.Attribute(_androidNamespace + "lockTaskMode");
        var maxRecents = activityElement.Attribute(_androidNamespace + "maxRecents");
        var maxAspectRatio = activityElement.Attribute(_androidNamespace + "maxAspectRatio");
        var multiprocess = activityElement.Attribute(_androidNamespace + "multiprocess");
        var name = activityElement.Attribute(_androidNamespace + "name");
        var noHistory = activityElement.Attribute(_androidNamespace + "noHistory");
        var parentActivityName = activityElement.Attribute(_androidNamespace + "parentActivityName");
        var persistableMode = activityElement.Attribute(_androidNamespace + "persistableMode");
        var permission = activityElement.Attribute(_androidNamespace + "permission");
        var process = activityElement.Attribute(_androidNamespace + "process");
        var relinquishTaskIdentity = activityElement.Attribute(_androidNamespace + "relinquishTashIdentity");
        var resizeableActivity = activityElement.Attribute(_androidNamespace + "resizeableActivity");
        var screenOrientation = activityElement.Attribute(_androidNamespace + "screenOrientation");
        var showForAllUsers = activityElement.Attribute(_androidNamespace + "showForAllUsers");
        var stateNotNeeded = activityElement.Attribute(_androidNamespace + "stateNotNeeded");
        var supportsPictureInPicture = activityElement.Attribute(_androidNamespace + "supportsPictureInPicture");
        var taskAffinity = activityElement.Attribute(_androidNamespace + "taskAfinity");
        var theme = activityElement.Attribute(_androidNamespace + "thems");
        var uiOptions = activityElement.Attribute(_androidNamespace + "uiOptions");
        var windowSoftInputMode = activityElement.Attribute(_androidNamespace + "windowSoftInputMode");


        if (allowEmbedded != null)
        {
            result.allowEmbedded = Convert.ToBoolean(allowEmbedded.Value);
        }
        else
        {
            result.allowEmbedded = false;
        }

        if (allowTaskReparenting != null)
        {
            result.allowTaskReparenting = Convert.ToBoolean(allowTaskReparenting.Value);
        }
        else
        {
            result.allowTaskReparenting = false;
        }

        if (alwaysRetainTaskState != null)
        {
            result.alwaysRetainTaskState = Convert.ToBoolean(alwaysRetainTaskState.Value);
        }
        else
        {
            result.alwaysRetainTaskState = false;
        }

        if (autoRemoveFromRecents != null)
            result.autoRemoveFromRecents = Convert.ToBoolean(autoRemoveFromRecents.Value);

        if (banner != null)
            result.banner = banner.Value;

        if (clearTaskOnLaunch != null)
        {
            result.clearTaskOnLaunch = Convert.ToBoolean(clearTaskOnLaunch.Value);
        }
        else
        {
            result.clearTaskOnLaunch = false;
        }

        if (colorMode != null)
            result.colorMode = colorMode.Value;

        if (configChanges != null)
            result.configChanges = configChanges.Value;

        if (directBootAware != null)
        {
            result.directBootAware = Convert.ToBoolean(directBootAware.Value);
        }
        else
        {
            result.directBootAware = false;
        }

        if (documentLaunchMode != null)
        {
            result.documentLaunchMode = documentLaunchMode.Value;
        }
        else
        {
            result.documentLaunchMode = "none";
        }

        if (enabled != null)
        {
            result.enabled = Convert.ToBoolean(enabled.Value);
        }
        else
        {
            result.enabled = true;
        }

        if (excludeFromRecents != null)
        {
            result.excludeFromRecents = Convert.ToBoolean(excludeFromRecents.Value);
        }
        else
        {
            result.excludeFromRecents = false;
        }

        if (finishOnTaskLaunch != null)
        {
            result.finishOnTaskLaunch = Convert.ToBoolean(finishOnTaskLaunch.Value);
        }
        else
        {
            result.finishOnTaskLaunch = false;
        }

        if (hardwareAccelerated != null)
        {
            result.hardwareAccelerated = Convert.ToBoolean(hardwareAccelerated.Value);
        }
        else
        {
            result.hardwareAccelerated = false;
        }

        if (icon != null)
            result.icon = icon.Value;

        if (immersive != null)
            result.immersive = Convert.ToBoolean(immersive.Value);

        if (label != null)
            result.label = label.Value;

        if (launchMode != null)
        {
            result.launchMode = launchMode.Value;
        }
        else
        {
            result.launchMode = "standard";
        }

        if (lockTaskMode != null)
        {
            result.lockTaskMode = lockTaskMode.Value;
        }
        else
        {
            result.lockTaskMode = "normal";
        }

        if (maxRecents != null)
        {
            result.maxRecents = Convert.ToInt32(maxRecents.Value);
        }
        else
        {
            result.maxRecents = 16;
        }

        if (maxAspectRatio != null)
            result.maxAspectRatio = float.Parse(maxAspectRatio.Value);

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

        if (noHistory != null)
        {
            result.noHistory = Convert.ToBoolean(noHistory.Value);
        }
        else
        {
            result.noHistory = false;
        }

        if (parentActivityName != null)
            result.parentActivityName = parentActivityName.Value;

        if (persistableMode != null)
        {
            result.persistableMode = persistableMode.Value;
        }
        else
        {
            result.persistableMode = "persistRootOnly";
        }

        if (permission != null)
            result.permission = permission.Value;

        if (process != null)
            result.process = process.Value;

        if (relinquishTaskIdentity != null)
        {
            result.relinquishTaskIdentity = Convert.ToBoolean(relinquishTaskIdentity.Value);
        }
        else
        {
            result.relinquishTaskIdentity = false;
        }

        if (resizeableActivity != null)
        {
            result.resizeableActivity = Convert.ToBoolean(resizeableActivity.Value);
        }
        else
        {
            if (_manifest.usesSdk!.targetSdkVersion >= 24)
                result.resizeableActivity = true;
        }

        if (screenOrientation != null)
        {
            result.screenOrientation = screenOrientation.Value;
        }
        else
        {
            result.screenOrientation = "unspecified";
        }

        if (showForAllUsers != null)
            result.showForAllUsers = Convert.ToBoolean(showForAllUsers.Value);


        if (stateNotNeeded != null)
        {
            result.stateNotNeeded = Convert.ToBoolean(stateNotNeeded.Value);
        }
        else
        {
            result.stateNotNeeded = false;
        }

        if (supportsPictureInPicture != null)
            result.supportsPictureInPicture = Convert.ToBoolean(supportsPictureInPicture.Value);


        if (taskAffinity != null)
            result.taskAffinity = taskAffinity.Value;

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

        if (windowSoftInputMode != null)
            result.windowSoftInputMode = windowSoftInputMode.Value;

        foreach (var elem in activityElement.Elements())
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
                case "layout":
                    {
                        if (result.Layouts is null) result.Layouts = new List<Layout>();
                        result.Layouts.Add(LayoutParser(elem));
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