using Microsoft.AspNetCore.Components;

namespace Flowly.Shared.Components.Stack;

public partial class Stack
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public StackDirection Direction { get; set; } = StackDirection.Column;

    [Parameter]
    public StackAlign Align { get; set; } = StackAlign.Start;

    [Parameter]
    public StackJustify Justify { get; set; } = StackJustify.Start;

    [Parameter]
    public StackGap Gap { get; set; } = StackGap.None;

    [Parameter]
    public bool Wrap { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    private const string BaseCss = "flex";

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

    private string WrapClass => Wrap
        ? "flex-wrap"
        : string.Empty;

    private string Css =>
        $"{BaseCss} {DirectionClass} {AlignClass} {JustifyClass} {GapClass} {WrapClass} {Class}";

    public enum StackDirection
    {
        Row,
        Column
    }

    public enum StackAlign
    {
        Start,
        Center,
        End,
        Stretch
    }

    public enum StackJustify
    {
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
}
