


using MudBlazor;
using System;

namespace CPTool2.Services
{
    public class ParameterDialogModel
    {

        public string DialogTitle { get; set; } = string.Empty;
        public DialogParameters parameters { get; set; } = null!;
        public DialogOptions options { get; set; } = null!;
    }
}
