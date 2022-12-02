using CPTool.Application.Features.MaterialFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.Materials
{
    internal class AddEditMaterialHandler : CommandHandler<EditMaterial, AddMaterial, Material>, IRequestHandler<Command<EditMaterial>, IResult>
    {

        public AddEditMaterialHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteMaterialHandler : DeleteCommandHandler<EditMaterial, Material>, IRequestHandler<DeleteCommand<EditMaterial>, IResult>
    {

        public DeleteMaterialHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListMaterialHandler : QueryListHandler<EditMaterial, Material>, IRequestHandler<QueryList<EditMaterial>, List<EditMaterial>>
    {

        public GetListMaterialHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdMaterialHandler : QueryIdHandler<EditMaterial, Material>, IRequestHandler<QueryId<EditMaterial>, EditMaterial>

    {


        public QueryIdMaterialHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
