public class Activity
{

    public bool? allowEmbedded { get; set; }
    public bool? allowTaskReparenting { get; set; }
    public bool? alwaysRetainTaskState { get; set; }
    public bool? autoRemoveFromRecents { get; set; }
    public string? banner { get; set; }
    public bool? clearTaskOnLaunch { get; set; }
    public string? colorMode { get; set; }
    public string? configChanges { get; set; }
    public bool? directBootAware { get; set; }
    public string? documentLaunchMode { get; set; }
    public bool? enabled { get; set; }
    public bool? excludeFromRecents { get; set; }
    public bool? exported { get; set; }
    public bool? finishOnTaskLaunch { get; set; }
    public bool? hardwareAccelerated { get; set; }
    public string? icon { get; set; }
    public bool? immersive { get; set; }
    public string? label { get; set; }
    public string? launchMode { get; set; }
    public string? lockTaskMode { get; set; }
    public int? maxRecents { get; set; }
    public float? maxAspectRatio { get; set; }
    public bool? multiprocess { get; set; }
    public string? name { get; set; }
    public bool? noHistory { get; set; }
    public string? parentActivityName { get; set; }
    public string? persistableMode { get; set; }
    public string? permission { get; set; }
    public string? process { get; set; }
    public bool? relinquishTaskIdentity { get; set; }
    public bool? resizeableActivity { get; set; }
    public string? screenOrientation { get; set; }
    public bool? showForAllUsers { get; set; }
    public bool? stateNotNeeded { get; set; }
    public bool? supportsPictureInPicture { get; set; }
    public string? taskAffinity { get; set; }
    public string? theme { get; set; }
    public string? uiOptions { get; set; }
    public string? windowSoftInputMode { get; set; }

    public List<IntentFilter>? intentFilters { get; set; }
    public List<MetaData>? metaDatas { get; set; }
    public List<Layout>? Layouts { get; set; }
}