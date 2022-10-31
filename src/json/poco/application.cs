public class Application
{
    public bool? allowTaskReparenting { get; set; }
    public bool? allowBackup { get; set; }
    public bool? allowClearUserData { get; set; }
    public bool? allowNativeHeapPointerTagging { get; set; }
    public string? appCategory { get; set; }
    public string? backupAgent { get; set; }
    public bool? backupInForeground { get; set; }
    public string? banner { get; set; }
    public string? dataExtractionRules { get; set; }
    public bool? debuggable { get; set; }
    public string? description { get; set; }
    public bool? enabled { get; set; }
    public bool? extractNativeLibs { get; set; }
    public string? fullBackupContent { get; set; }
    public bool? fullBackupOnly { get; set; }
    public string? gwpAsanMode { get; set; }
    public bool? hasCode { get; set; }
    public bool? hasFragileUserData { get; set; }
    public bool? hardwareAccelerated { get; set; }
    public string? icon { get; set; }
    public bool? isGame { get; set; }
    public bool? killAfterRestore { get; set; }
    public bool? largeHeap { get; set; }
    public string? label { get; set; }
    public string? logo { get; set; }
    public string? manageSpaceActivity { get; set; }
    public string? name { get; set; }
    public string? networkSecurityConfig { get; set; }
    public string? permission { get; set; }
    public bool? persistent { get; set; }
    public string? process { get; set; }
    public bool? restoreAnyVersion { get; set; }
    public bool? requestLegacyExternalStorage { get; set; }
    public string? requiredAccountType { get; set; }
    public bool? resizeableActivity { get; set; }
    public string? restrictedAccountType { get; set; }
    public bool? supportsRtl { get; set; }
    public string? taskAffinity { get; set; }
    public bool? testOnly { get; set; }
    public string? theme { get; set; }
    public string? uiOptions { get; set; }
    public bool? usesCleartextTraffic { get; set; }
    public bool? vmSafeMode { get; set; }

    public List<Activity>? activities { get; set; }
    public List<ActivityAlias>? activityAliases { get; set; }
    public List<MetaData>? metaDatas { get; set; }
    public List<Service>? services { get; set; }
    public List<Receiver>? receivers { get; set; }
    public List<Profileable>? profileables { get; set; }
    public List<Provider>? providers { get; set; }
    public List<UsesLibrary>? usesLibraries { get; set; }
    public List<UsesNativeLibrary>? usesNativeLibraries { get; set; }
}

