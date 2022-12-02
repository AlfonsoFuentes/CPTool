using CPTool.Application.Features.PropertyPackageFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.PropertyPackages
{
    internal class AddEditPropertyPackageHandler : CommandHandler<EditPropertyPackage, AddPropertyPackage, PropertyPackage>, IRequestHandler<Command<EditPropertyPackage>, IResult>
    {

        public AddEditPropertyPackageHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeletePropertyPackageHandler : DeleteCommandHandler<EditPropertyPackage, PropertyPackage>, IRequestHandler<DeleteCommand<EditPropertyPackage>, IResult>
    {

        public DeletePropertyPackageHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListPropertyPackageHandler : QueryListHandler<EditPropertyPackage, PropertyPackage>, IRequestHandler<QueryList<EditPropertyPackage>, List<EditPropertyPackage>>
    {

        public GetListPropertyPackageHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdPropertyPackageHandler : QueryIdHandler<EditPropertyPackage, PropertyPackage>, IRequestHandler<QueryId<EditPropertyPackage>, EditPropertyPackage>

    {


        public QueryIdPropertyPackageHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
