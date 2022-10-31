public class IntentFilter
{
    public string? icon { get; set; }
    public string? label { get; set; }
    public int? priority { get; set; }
    public int? order { get; set; }
    public bool? autoVerify { get; set; }

    public Action? action { get; set; }
    public List<Data>? datas { get; set; }
    public List<Category>? categories { get; set; }
}