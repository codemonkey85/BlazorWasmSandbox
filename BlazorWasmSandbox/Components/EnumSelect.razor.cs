namespace BlazorWasmSandbox.Components;

public partial class EnumSelect<TEnum> where TEnum : struct
{
    [Parameter]
    public TEnum SelectedValue { get; set; } = default!;

    [Parameter]
    public EventCallback<TEnum> SelectedValueChanged { get; set; }

    private Task OnSelectedValueChanged(ChangeEventArgs e) =>
        Enum.TryParse(e?.Value?.ToString(), true, out TEnum enumValue)
            ? SelectedValueChanged.InvokeAsync(enumValue)
            : SelectedValueChanged.InvokeAsync();
}
