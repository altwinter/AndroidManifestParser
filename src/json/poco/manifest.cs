public class Manifest
{
    public string? package { get; set; }
    public string? sharedUserId { get; set; }
    public int? targetSandboxVersion { get; set; }
    public string? sharedUserLabel { get; set; }
    public string? sharedUserMaxSdkVersion { get; set; }
    public int? versionCode { get; set; }
    public string? versionName { get; set; }
    public string? installLocation { get; set; }
    public int? compileSdkVersion { get; set; }
    public int? compileSdkVersionCodename { get; set; }
    public int? platformBuildVersionCode { get; set; }
    public int? platformBuildVersionName { get; set; }
    public Application? application { get; set; }
    public CompatibleScreens? compatibleScreens { get; set; }
    public List<Instrumentation>? instrumentations { get; set; }
    public List<Permission>? permissions { get; set; }
    public List<PermissionGroup>? permissionGroups { get; set; }
    public List<PermissionTree>? permissionTrees { get; set; }
    public List<Queries>? queries { get; set; }
    public List<SupportsGlTexture>? supportsGlTextures { get; set; }
    public SupportsScreens? supportsScreens { get; set; }
    public UsesConfiguration? usesConfiguration { get; set; }
    public List<UsesFeature>? usesFeatures { get; set; }
    public List<UsesPermission>? usesPermissions { get; set; }
    public List<UsesPermissionSdk23>? usesPermissionSdk23s { get; set; }
    public UsesSdk? usesSdk { get; set; }
}