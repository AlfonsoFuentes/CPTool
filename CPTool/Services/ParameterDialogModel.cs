
using CPTool.Entities;
using CPTool.Interfaces;
using System;

namespace CPTool.Services
{
    public class ParameterDialogModel
    {
        
        public string DialogTitle { get; set; }
        public DialogParameters parameters { get; set; }
        public DialogOptions options { get; set; }
    }
}
