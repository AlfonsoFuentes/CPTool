namespace CPTool.Application.Features.MaterialFeatures.CreateEdit
{
    public class EditMaterial : EditCommand, IRequest<Result<int>>
    {
        public string? Abbreviation { get; set; }


       


    }
}
