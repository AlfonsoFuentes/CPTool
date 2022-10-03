


using MudBlazor;
using System;

namespace CPTool.Services
{
    public class ParameterDialogModel
    {

        public string DialogTitle { get; set; } = string.Empty;
        public DialogParameters parameters { get; set; } = null!;
        public DialogOptions options { get; set; } = null!;
    }
}
