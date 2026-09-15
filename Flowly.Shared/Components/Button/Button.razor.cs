using Microsoft.AspNetCore.Components;

namespace Flowly.Shared.Components.Button;

public partial class Button
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
