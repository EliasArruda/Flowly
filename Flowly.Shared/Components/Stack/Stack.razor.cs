using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Flowly.Shared.Components.Stack;

public class Stack : ComponentBase
{
    [Parameter]
    public string As { get; set; } = "div";

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public StackDirection Direction { get; set; } = StackDirection.Column;

    [Parameter]
    public StackAlign Align { get; set; } = StackAlign.None;

    [Parameter]
    public StackJustify Justify { get; set; } = StackJustify.None;

    [Parameter]
    public StackGap Gap { get; set; } = StackGap.None;

    [Parameter]
    public StackSize Size { get; set; } = StackSize.None;

    [Parameter]
    public bool Wrap { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    private string DirectionClass => Direction switch
    {
        StackDirection.Row => "flex-row",
        StackDirection.Column => "flex-col",
        _ => string.Empty
    };

    private string AlignClass => Align switch
    {
        StackAlign.Start => "items-start",
        StackAlign.Center => "items-center",
        StackAlign.End => "items-end",
        StackAlign.Stretch => "items-stretch",
        _ => string.Empty
    };

    private string JustifyClass => Justify switch
    {
        StackJustify.Start => "justify-start",
        StackJustify.Center => "justify-center",
        StackJustify.End => "justify-end",
        StackJustify.Between => "justify-between",
        StackJustify.Around => "justify-around",
        StackJustify.Evenly => "justify-evenly",
        _ => string.Empty
    };

    private string GapClass => Gap switch
    {
        StackGap.Small => "gap-2",
        StackGap.Medium => "gap-4",
        StackGap.Large => "gap-8",
        StackGap.ExtraLarge => "gap-12",
        _ => string.Empty
    };

    private string SizeClass => Size switch
    {
        StackSize.Small => "max-w-sm",
        StackSize.Medium => "max-w-3xl",
        StackSize.Large => "max-w-5xl",
        StackSize.ExtraLarge => "max-w-7xl",
        StackSize.Full => "w-full",
        _ => string.Empty
    };

    private string WrapClass => Wrap
        ? "flex-wrap"
        : string.Empty;

    private string Css =>
        $"flex {DirectionClass} {AlignClass} {JustifyClass} {GapClass} {SizeClass} {WrapClass} {Class}".Trim();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, As);
        builder.AddAttribute(1, "class", Css);

        if (AdditionalAttributes is not null)
            builder.AddMultipleAttributes(2, AdditionalAttributes);

        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }

    public enum StackDirection
    {
        None,
        Row,
        Column
    }

    public enum StackAlign
    {
        None,
        Start,
        Center,
        End,
        Stretch
    }

    public enum StackJustify
    {
        None,
        Start,
        Center,
        End,
        Between,
        Around,
        Evenly
    }

    public enum StackGap
    {
        None,
        Small,
        Medium,
        Large,
        ExtraLarge
    }

    public enum StackSize
    {
        None,
        Small,
        Medium,
        Large,
        ExtraLarge,
        Full
    }
}
