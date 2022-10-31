using System.Xml.Linq;

public sealed partial class JsonParser
{
    public void ManifestParser(XElement manifest)
    {
        // Attributes
        var package = manifest.Attribute("package");
        var sharedUserId = manifest.Attribute(_androidNamespace + "sharedUserId");
        var targetSandboxVersion = manifest.Attribute(_androidNamespace + "targetSandboxVersion");
        var sharedUserLabel = manifest.Attribute(_androidNamespace + "sharedUserLabel");
        var sharedUserMaxSdkVersion = manifest.Attribute(_androidNamespace + "sharedUserMaxSdkVersion");
        var versionCode = manifest.Attribute(_androidNamespace + "versionCode");
        var versionName = manifest.Attribute(_androidNamespace + "versionName");
        var installLocation = manifest.Attribute(_androidNamespace + "installLocation");
        var compileSdkVersion = manifest.Attribute(_androidNamespace + "compileSdkVersion");
        var compileSdkVersionCodename = manifest.Attribute(_androidNamespace + "compileSdkVersionCodename");
        var platformBuildVersionCode = manifest.Attribute("platformBuildVersionCode");
        var platformBuildVersionName = manifest.Attribute("platformBuildVersionName");

        if (package is not null)
            _manifest.package = package.Value;

        if (sharedUserId is not null) _manifest.sharedUserId = sharedUserId.Value;

        if (targetSandboxVersion is not null)
        {
            _manifest.targetSandboxVersion = Convert.ToInt32(targetSandboxVersion.Value);
        }
        else
        {
            _manifest.targetSandboxVersion = 1;
        }

        if (sharedUserLabel is not null) _manifest.sharedUserLabel = sharedUserLabel.Value;

        if (sharedUserMaxSdkVersion is not null) _manifest.sharedUserMaxSdkVersion = sharedUserMaxSdkVersion.Value;

        if (versionCode is not null) _manifest.versionCode = Convert.ToInt32(versionCode.Value);

        if (versionName is not null) _manifest.versionName = versionName.Value;

        if (installLocation is not null)
        {
            _manifest.installLocation = installLocation.Value;
        }
        else
        {
            _manifest.installLocation = "internalOnly";
        }

        if (compileSdkVersion is not null) _manifest.compileSdkVersion = Convert.ToInt32(compileSdkVersion.Value);

        if (compileSdkVersionCodename is not null) _manifest.compileSdkVersionCodename = Convert.ToInt32(compileSdkVersionCodename.Value);

        if (platformBuildVersionCode is not null) _manifest.platformBuildVersionCode = Convert.ToInt32(platformBuildVersionCode.Value);

        if (platformBuildVersionName is not null) _manifest.platformBuildVersionName = Convert.ToInt32(platformBuildVersionName.Value);

        // Elements
        var usesSdk = manifest.Element("uses-sdk");
        var compatibleScreens = manifest.Element("compatible-screens");
        var instrumentations = manifest.Elements("instrumentation");
        var permissions = manifest.Elements("permission");
        var permissionGroups = manifest.Elements("permission-group");
        var permissionTrees = manifest.Elements("permission-tree");
        var queries = manifest.Elements("queries");
        var supportsGlTextures = manifest.Elements("supports-gl-texture");
        var supportsScreens = manifest.Element("supports-screens");
        var usesConfiguration = manifest.Element("uses-configuration");
        var usesFeatures = manifest.Elements("uses-feature");
        var usesPermissions = manifest.Elements("uses-permission");
        var usesPermissionSdk23s = manifest.Elements("uses-permission-sdk-23");
        var application = manifest.Element("application");

        if (usesSdk is not null)
            _manifest.usesSdk = UsesSdkParser(usesSdk);

        if (compatibleScreens is not null)
            _manifest.compatibleScreens = CompatibleScreensParser(compatibleScreens);

        foreach (var instrumentation in instrumentations)
        {
            if (_manifest.instrumentations is null)
                _manifest.instrumentations = new List<Instrumentation>();

            _manifest.instrumentations.Add(InstrumentationParser(instrumentation));
        }

        foreach (var permission in permissions)
        {
            if (_manifest.permissions is null)
                _manifest.permissions = new List<Permission>();

            _manifest.permissions.Add(PermissionParser(permission));
        }

        foreach (var permissionGroup in permissionGroups)
        {
            if (_manifest.permissionGroups is null)
                _manifest.permissionGroups = new List<PermissionGroup>();

            _manifest.permissionGroups.Add(PermissionGroupParser(permissionGroup));
        }

        foreach (var permissionTree in permissionTrees)
        {
            if (_manifest.permissionTrees is null)
                _manifest.permissionTrees = new List<PermissionTree>();

            _manifest.permissionTrees.Add(PermissionTreeParser(permissionTree));
        }

        foreach (var query in queries)
        {
            if (_manifest.queries is null) _manifest.queries = new List<Queries>();
            _manifest.queries.Add(QueriesParser(query));
        }

        foreach (var supportsGlTexture in supportsGlTextures)
        {
            if (_manifest.supportsGlTextures is null) _manifest.supportsGlTextures = new List<SupportsGlTexture>();
            _manifest.supportsGlTextures.Add(SupportGlTextureParser(supportsGlTexture));
        }

        if (supportsScreens is not null)
            _manifest.supportsScreens = SupportScreensParser(supportsScreens);

        if (usesConfiguration is not null)
            _manifest.usesConfiguration = UsesConfigurationParser(usesConfiguration);

        foreach (var usesFeature in usesFeatures)
        {
            if (_manifest.usesFeatures is null) _manifest.usesFeatures = new List<UsesFeature>();
            _manifest.usesFeatures.Add(UsesFeatureParser(usesFeature));
        }

        foreach (var usesPermission in usesPermissions)
        {
            if (_manifest.usesPermissions is null) _manifest.usesPermissions = new List<UsesPermission>();
            _manifest.usesPermissions.Add(UsesPermissionParser(usesPermission));
        }

        foreach (var usesPermissionSdk23 in usesPermissionSdk23s)
        {
            if (_manifest.usesPermissionSdk23s is null) _manifest.usesPermissionSdk23s = new List<UsesPermissionSdk23>();
            _manifest.usesPermissionSdk23s.Add(UsesPermissionSdk23Parser(usesPermissionSdk23));
        }

        if (application is not null)
            _manifest.application = ApplicationParser(application);

    }
}