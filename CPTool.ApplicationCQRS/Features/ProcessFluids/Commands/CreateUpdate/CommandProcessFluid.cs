using CPTool.ApplicationCQRS.Features.PropertyPackages.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using EquipmentCalculation;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate
{
    public class CommandProcessFluid : CommandBase, IRequest<ProcessFluidCommandResponse>
    {


        public string TagLetter { get; set; } = "";
        public string PropertyPackageName => PropertyPackage == null ? "" : PropertyPackage.Name;
        public int? PropertyPackageId => PropertyPackage?.Id == 0 ? null : PropertyPackage?.Id;
        CommandPropertyPackage? _PropertyPackage;
        public CommandPropertyPackage? PropertyPackage
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
