public class Receiver
{
    public bool? directBootAware { get; set; }
    public bool? enabled { get; set; }
    public bool? exported { get; set; }
    public string? icon { get; set; }
    public bool? isolatedProcess { get; set; }
    public string? label { get; set; }
    public string? name { get; set; }
    public string? permission { get; set; }
    public string? process { get; set; }

    public List<IntentFilter>? intentFilters { get; set; }
    public List<MetaData>? metaDatas { get; set; }
}