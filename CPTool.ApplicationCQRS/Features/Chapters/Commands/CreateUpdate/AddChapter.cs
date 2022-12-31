using CPtool.ExtensionMethods;

namespace CPTool.ApplicationCQRS.Features.Chapters.Commands.CreateUpdate
{
    public class AddChapter
    {

       
        public string Name { get; set; } = string.Empty;
       
        public string LetterName => $"{Letter}-{Name}";
       
        public string? Letter { get; set; }

    }

}
