

using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTool.Application.Features.MaterialFeatures.CreateEdit
{
    public class AddMaterial : AddCommand, IRequest<Result<int>>
    {
        public string? Abbreviation { get; set; }

        
       
    

    }
}
