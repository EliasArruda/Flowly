using Microsoft.AspNetCore.Components;

namespace Flowly.Shared.Components.Input;

public partial class Input
{
    [Parameter]
    public string? Value { get; set; }

    [Parameter]
    public EventCallback<string?> ValueChanged { get; set; }

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public InputAs As { get; set; } = InputAs.Blazor;

    [Parameter]
    public InputSize Size { get; set; } = InputSize.Medium;

    [Parameter]
    public InputVariant Variant { get; set; } = InputVariant.Default;

    [Parameter]
    public RenderFragment? StartIcon { get; set; }

    [Parameter]
    public RenderFragment? EndIcon { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    private string SizeClass => Size switch
    {
        InputSize.Small => "h-8 px-3 text-sm",
        InputSize.Medium => "h-10 px-3 text-sm",
        InputSize.Large => "h-12 px-4 text-base",
        _ => string.Empty
    };

    private string VariantClass => Variant switch
    {
        InputVariant.Default =>
            "border border-border bg-background",

        InputVariant.Filled =>
            "border border-transparent bg-muted",

        InputVariant.Ghost =>
            "border border-transparent bg-transparent",

        _ => string.Empty
    };

    private string IconPaddingClass => (StartIcon, EndIcon) switch
    {
        (not null, not null) => "pl-10 pr-10",
        (not null, null) => "pl-10",
        (null, not null) => "pr-10",
        _ => string.Empty
    };

    private const string BaseCss =
        "w-full rounded-md outline-none transition-colors " +
        "placeholder:text-muted-foreground " +
        "focus:border-primary disabled:cursor-not-allowed disabled:opacity-50";

    private string Css =>
        $"{BaseCss} {SizeClass} {VariantClass} {IconPaddingClass} {Class}";

    private const string FieldCss =
        "flex w-full flex-col gap-2";

    private const string LabelCss =
        "text-xs font-medium text-muted-foreground";

    private const string WrapperCss =
        "relative flex w-full items-center";

    private const string StartIconCss =
        "pointer-events-none absolute left-3 flex items-center justify-center";

    private const string EndIconCss =
        "pointer-events-none absolute right-3 flex items-center justify-center";

    private async Task HandleInput(ChangeEventArgs args)
    {
        Value = args.Value?.ToString();
        await ValueChanged.InvokeAsync(Value);
    }

    public enum InputAs
    {
        Html,
        Blazor
    }

    public enum InputSize
    {
        Small,
        Medium,
        Large
    }

    public enum InputVariant
    {
        Default,
        Filled,
        Ghost
    }
}
