using Microsoft.JSInterop;

public class PrintService
{
    private readonly IJSRuntime _jsRuntime;

    public PrintService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task SaveAndPrintAsync()
    {
        // Perform Save Operation Here
        await SaveDataAsync();

        // Trigger Print
        await _jsRuntime.InvokeVoidAsync("printDocument");
    }

    private Task SaveDataAsync()
    {
        // Simulate saving data
        Console.WriteLine("Data saved successfully!");
        return Task.CompletedTask;
    }
}
