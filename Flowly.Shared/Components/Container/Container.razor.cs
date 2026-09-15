using Microsoft.AspNetCore.Components;

namespace Flowly.Shared.Components.Container;

public partial class Container
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    [Parameter]
    public ContainerAlign Align { get; set; } = default;

    [Parameter]
    public ContainerDirection Direction { get; set; } = default;

    [Parameter]
    public ContainerGap Gap { get; set; } = default;

    [Parameter]
    public ContainerSize Size { get; set; } = default;

    [Parameter]
    public string? Class { get; set; }

    private string SizeClass => Size switch
    {
        ContainerSize.Small => "max-w-3xl",
        ContainerSize.Medium => "max-w-5xl",
        ContainerSize.Large => "max-w-7xl",
        ContainerSize.Full => "max-w-none",
        _ => string.Empty
    };

    private string GapClass => Gap switch
    {
        ContainerGap.Small => "gap-2",
        ContainerGap.Medium => "gap-4",
        ContainerGap.Large => "gap-8",
        _ => string.Empty
    };


    private string DirectionClass => Direction switch
    {
        ContainerDirection.Col => "flex-col",
        ContainerDirection.Row => "flex-row",
        _ => string.Empty
    };

    private string AlignClass => Align switch
    {
        ContainerAlign.Start => "items-start justify-start",
        ContainerAlign.Center => "items-center justify-center",
        ContainerAlign.CenterPage => "min-h-screen justify-center items-center",
        ContainerAlign.End => "justify-end items-end",
        ContainerAlign.Between => "items-center justify-between",
        ContainerAlign.Around => "items-center justify-around",
        _ => string.Empty
    };

    public enum ContainerAlign
    {
        Start,
        Center,
        CenterPage,
        Between,
        Around,
        End
    }

    public enum ContainerDirection
    {
        Col,
        Row
    }

    public enum ContainerGap
    {
        Small,
        Medium,
        Large
    }

    public enum ContainerSize
    {
        Small,
        Medium,
        Large,
        Full
    }

    private const string BaseCss = "flex w-full";
    private string Css => $"{BaseCss} {AlignClass} {DirectionClass} {GapClass} {SizeClass} {Class}";
}
