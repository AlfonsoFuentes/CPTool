



using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;


namespace CPTool.Application.Features.FieldLocationsFeatures.Mapping
{
    internal class FieldLocationMapping : Profile
    {
        public FieldLocationMapping()
        {
            CreateMap<FieldLocation, EditFieldLocation>();
            CreateMap<AddFieldLocation, FieldLocation>();
            CreateMap<EditFieldLocation, FieldLocation>();
            CreateMap<EditFieldLocation, AddFieldLocation>();
        }
    }
}
