public class Provider
{
    public string? authorities { get; set; }
    public bool? directBootAware { get; set; }
    public bool? enabled { get; set; }
    public bool? exported { get; set; }
    public bool? grantUriPermissions { get; set; }
    public string? icon { get; set; }
    public int? initOrder { get; set; }
    public string? label { get; set; }
    public bool? multiprocess { get; set; }
    public string? name { get; set; }
    public string? permission { get; set; }
    public string? process { get; set; }
    public string? readPermission { get; set; }
    public bool? syncable { get; set; }
    public string? writePermission { get; set; }

    public List<MetaData>? metaDatas { get; set; }
    public List<GrantUriPermission>? grantUriPermissionS { get; set; }
    public List<IntentFilter>? intentFilters { get; set; }
    public List<PathPermission>? pathPermissions { get; set; }
}