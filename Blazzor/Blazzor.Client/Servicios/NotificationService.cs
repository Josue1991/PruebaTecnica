using Microsoft.JSInterop;

namespace Blazzor.Client.Servicios
{
    public class NotificationService
    {
        private readonly IJSRuntime _jsRuntime;

        public NotificationService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task ShowSuccess(string message)
        {
            await _jsRuntime.InvokeVoidAsync("alert", $"? ÉXITO\n\n{message}");
        }

        public async Task ShowError(string message)
        {
            await _jsRuntime.InvokeVoidAsync("alert", $"? ERROR\n\n{message}");
        }

        public async Task ShowInfo(string message)
        {
            await _jsRuntime.InvokeVoidAsync("alert", $"?? INFORMACIÓN\n\n{message}");
        }

        public async Task ShowWarning(string message)
        {
            await _jsRuntime.InvokeVoidAsync("alert", $"?? ADVERTENCIA\n\n{message}");
        }
    }
}
