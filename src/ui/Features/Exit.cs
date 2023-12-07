namespace ui.Features;

internal static partial class Feature
{
    public static Task<bool> Exit(IServiceProvider sp)
    {
        return Task.FromResult(true);
    }
}
