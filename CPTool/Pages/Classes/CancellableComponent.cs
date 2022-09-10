using ComponentBase = Microsoft.AspNetCore.Components.ComponentBase;

namespace CPTool.Pages.Classes
{
    public class CancellableComponent : ComponentBase, IDisposable
    {
        internal CancellationTokenSource _cts = new();

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }
    }
}
