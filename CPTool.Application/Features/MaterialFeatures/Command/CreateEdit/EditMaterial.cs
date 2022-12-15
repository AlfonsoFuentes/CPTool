

namespace CPTool.Application.Features.MaterialFeatures.CreateEdit
{
    public class EditMaterial : EditCommand, IRequest<Result<int>>
    {
        [Report(Order = 3)]
        public string? Abbreviation { get; set; } = string.Empty;

      



    }
}
