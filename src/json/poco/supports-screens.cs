public class SupportsScreens
{
    public bool? resizeable { get; set; }
    public bool? smallScreens { get; set; }
    public bool? normalScreens { get; set; }
    public bool? largeScreens { get; set; }
    public bool? xlargeScreens { get; set; }
    public bool? anyDensity { get; set; }
    public int? requiresSmallestWidthDp { get; set; }
    public int? compatibleWidthLimitDp { get; set; }
    public int? largestWidthLimitDp { get; set; }
}