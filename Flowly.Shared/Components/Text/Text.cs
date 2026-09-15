using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Flowly.Shared.Components.Text;

public class Text : ComponentBase
{
    [Parameter]
    public string As { get; set; } = "span";

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public TextVariant Variant { get; set; } = TextVariant.Body;

    [Parameter]
    public TextFont Font { get; set; } = TextFont.Sans;

    [Parameter]
    public TextWeight Weight { get; set; } = TextWeight.Normal;

    [Parameter]
    public TextColor Color { get; set; } = TextColor.Default;

    [Parameter]
    public TextAlign Align { get; set; } = TextAlign.Start;

    [Parameter]
    public TextLeading Leading { get; set; } = TextLeading.Normal;

    [Parameter]
    public TextTracking Tracking { get; set; } = TextTracking.Normal;

    [Parameter]
    public bool Truncate { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    private string VariantClass => Variant switch
    {
        TextVariant.Display => "text-5xl md:text-6xl",
        TextVariant.Title => "text-4xl md:text-5xl",
        TextVariant.Heading => "text-3xl",
        TextVariant.Subheading => "text-2xl",
        TextVariant.BodyLarge => "text-lg",
        TextVariant.Body => "text-base",
        TextVariant.BodySmall => "text-sm",
        TextVariant.Description => "text-base md:text-lg",
        TextVariant.Label => "text-sm",
        TextVariant.Caption => "text-xs",
        TextVariant.Overline => "text-xs uppercase",
        TextVariant.Code => "text-sm",
        _ => string.Empty
    };

    private string FontClass => Font switch
    {
        TextFont.Sans => "font-sans",
        TextFont.Serif => "font-serif",
        TextFont.Mono => "font-mono",
        _ => string.Empty
    };

    private string WeightClass => Weight switch
    {
        TextWeight.Light => "font-light",
        TextWeight.Normal => "font-normal",
        TextWeight.Medium => "font-medium",
        TextWeight.SemiBold => "font-semibold",
        TextWeight.Bold => "font-bold",
        TextWeight.Black => "font-black",
        _ => string.Empty
    };

    private string ColorClass => Color switch
    {
        TextColor.Default => "text-foreground",
        TextColor.Muted => "text-muted-foreground",
        TextColor.Primary => "text-primary",
        TextColor.Destructive => "text-destructive",
        TextColor.Inherit => "text-inherit",
        _ => string.Empty
    };

    private string AlignClass => Align switch
    {
        TextAlign.Start => "text-left",
        TextAlign.Center => "text-center",
        TextAlign.End => "text-right",
        TextAlign.Justify => "text-justify",
        _ => string.Empty
    };

    private string LeadingClass => Leading switch
    {
        TextLeading.None => "leading-none",
        TextLeading.Tight => "leading-tight",
        TextLeading.Snug => "leading-snug",
        TextLeading.Normal => "leading-normal",
        TextLeading.Relaxed => "leading-relaxed",
        TextLeading.Loose => "leading-loose",
        _ => string.Empty
    };

    private string TrackingClass => Tracking switch
    {
        TextTracking.Tighter => "tracking-tighter",
        TextTracking.Tight => "tracking-tight",
        TextTracking.Normal => "tracking-normal",
        TextTracking.Wide => "tracking-wide",
        TextTracking.Wider => "tracking-wider",
        TextTracking.Widest => "tracking-widest",
        _ => string.Empty
    };

    private string TruncateClass => Truncate
        ? "truncate"
        : string.Empty;

    private string Css =>
        $"{VariantClass} {FontClass} {WeightClass} {ColorClass} {AlignClass} {LeadingClass} {TrackingClass} {TruncateClass} {Class}".Trim();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, As);
        builder.AddAttribute(1, "class", Css);
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }

    public enum TextVariant
    {
        Display,
        Title,
        Heading,
        Subheading,
        BodyLarge,
        Body,
        BodySmall,
        Description,
        Label,
        Caption,
        Overline,
        Code
    }

    public enum TextFont
    {
        Sans,
        Serif,
        Mono
    }

    public enum TextWeight
    {
        Light,
        Normal,
        Medium,
        SemiBold,
        Bold,
        Black
    }

    public enum TextColor
    {
        Default,
        Muted,
        Primary,
        Destructive,
        Inherit
    }

    public enum TextAlign
    {
        Start,
        Center,
        End,
        Justify
    }

    public enum TextLeading
    {
        None,
        Tight,
        Snug,
        Normal,
        Relaxed,
        Loose
    }

    public enum TextTracking
    {
        Tighter,
        Tight,
        Normal,
        Wide,
        Wider,
        Widest
    }
}
