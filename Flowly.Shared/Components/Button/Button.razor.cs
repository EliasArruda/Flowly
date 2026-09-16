using Blazicons;
using Microsoft.AspNetCore.Components;

namespace Flowly.Shared.Components.Button;

public partial class Button
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string? Href { get; set; }

    [Parameter]
    public SvgIcon? Icon { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public ButtonIconPosition IconPosition { get; set; }

    [Parameter]
    public ButtonSize Size { get; set; }

    [Parameter]
    public ButtonTextWeight TextWeight { get; set; }

    [Parameter]
    public ButtonFontSize FontSize { get; set; }

    [Parameter]
    public ButtonPositionBorder PositionBorder { get; set; }

    [Parameter]
    public ButtonColor BorderColor { get; set; }

    [Parameter]
    public ButtonColor TextColor { get; set; }

    [Parameter]
    public ButtonGap Gap { get; set; }

    [Parameter]
    public ButtonVariant Variant { get; set; }

    private string VariantClass => Variant switch
    {
        ButtonVariant.Primary => "bg-primary hover:bg-primary-hover text-accent-foreground",
        ButtonVariant.Secondary => "bg-secondary hover:bg-secondary-hover text-muted-foreground",
        ButtonVariant.Outline => "border border-border text-foreground/70",
        ButtonVariant.Ghost => "text-muted-foreground hover:bg-surface-hover hover:text-primary/55",
        _ => string.Empty
    };

    private string ButtonGapClass => Gap switch
    {
        ButtonGap.Small => "gap-2",
        ButtonGap.Medium => "gap-4",
        ButtonGap.Large => "gap-6",
        _ => string.Empty
    };

    private string ButtonBorderColorClass => BorderColor switch
    {
        ButtonColor.Primary => "border-primary",
        ButtonColor.Secondary => "border-secondary",
        ButtonColor.Accent => "border-accent",
        ButtonColor.Muted => "border-muted-foreground",
        _ => string.Empty
    };

    private string ButtonTextColorClass => TextColor switch
    {
        ButtonColor.Primary => "text-primary",
        ButtonColor.Secondary => "text-secondary",
        ButtonColor.Accent => "text-accent",
        ButtonColor.Muted => "text-muted-foreground",
        _ => string.Empty
    };

    private string PositionBorderClass => PositionBorder switch
    {
        ButtonPositionBorder.Top => "border-t-2",
        ButtonPositionBorder.Left => "border-l-2",
        ButtonPositionBorder.Right => "border-r-2",
        ButtonPositionBorder.Bottom => "border-b-2",
        ButtonPositionBorder.FullBorder => "border-2",
        _ => string.Empty
    };

    private string TextWeightClass => TextWeight switch
    {
        ButtonTextWeight.Light => "font-light",
        ButtonTextWeight.Medium => "font-medium",
        ButtonTextWeight.Bold => "font-bold",
        _ => string.Empty
    };

    private string ButtonSizeClass => Size switch
    {
        ButtonSize.Small => "px-2 py-1",
        ButtonSize.Medium => "px-3 py-1.5",
        ButtonSize.Large => "px-4 py-2",
        _ => string.Empty
    };

    private string ButtonFontSizeClass => FontSize switch
    {
        ButtonFontSize.Small => "text-sm",
        ButtonFontSize.Medium => "text-base",
        ButtonFontSize.Large => "text-lg",
        _ => string.Empty
    };

    private const string BaseCss =
        "inline-flex items-center justify-center font-serif";

    private readonly string ActiveClassStyle = "border-b-2 border-primary";

    private string Css =>
        $"{BaseCss} {VariantClass} {ButtonSizeClass} {PositionBorderClass} {TextWeightClass} {ButtonFontSizeClass} {ButtonBorderColorClass} {ButtonTextColorClass} {ButtonGapClass} {Class}".Trim();

    public enum ButtonVariant
    {
        None,
        Primary,
        Secondary,
        Outline,
        Ghost
    }

    public enum ButtonColor
    {
        None,
        Primary,
        Secondary,
        Accent,
        Muted
    }

    public enum ButtonPositionBorder
    {
        None,
        Top,
        Left,
        Right,
        Bottom,
        FullBorder
    }

    public enum ButtonTextWeight
    {
        None,
        Light,
        Medium,
        Bold
    }

    public enum ButtonFontSize
    {
        None,
        Small,
        Medium,
        Large
    }

    public enum ButtonSize
    {
        None,
        Small,
        Medium,
        Large
    }

    public enum ButtonGap
    {
        None,
        Small,
        Medium,
        Large
    }

    public enum ButtonIconPosition
    {
        None,
        Left,
        Right
    }
}
