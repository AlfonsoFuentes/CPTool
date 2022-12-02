using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.Query.GetById;
using CPTool.Application.Features.PipeDiameterFeatures.Query.GetList;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.Query.GetById;
using CPTool.Application.Features.ProcessFluidFeatures.Query.GetList;
using CPTool.Application.Features.PropertyPackageFeatures.CreateEdit;
using EquipmentCalculation;

namespace CPTool.Application.Features.ProcessFluidFeatures.CreateEdit
{
    public class EditProcessFluid : EditCommand, IRequest<Result<int>>
    {
         public string TagLetter { get; set; } = "";
      
        public int? PropertyPackageId => PropertyPackage?.Id == 0 ? null : PropertyPackage?.Id;
        EditPropertyPackage? _PropertyPackage;
        public EditPropertyPackage? PropertyPackage
        {
            get

            {
                return _PropertyPackage;
            }
            set
            {
                _PropertyPackage = value;
                CreatePropertyPackage();
            }
        }
        void CreatePropertyPackage()
        {
            if (PropertyPackageId == null) return;
            switch (PropertyPackageId)
            {
                case 1:
                    PropertyPackage!.PropertyPackageCalculator = new TablasDeVapor();
                    break;
               
               
            }
        }

    }
}
