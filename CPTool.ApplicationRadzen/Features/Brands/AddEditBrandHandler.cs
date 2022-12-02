using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;

namespace CPTool.ApplicationRadzen.Features.Brands
{
    internal class AddEditBrandHandler : CommandHandler<EditBrand, AddBrand, Brand>, IRequestHandler<Command<EditBrand>, IResult>
    {

        public AddEditBrandHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }
      

    }
    internal class DeleteBrandHandler : DeleteCommandHandler<EditBrand, Brand>, IRequestHandler<DeleteCommand<EditBrand>, IResult>
    {

        public DeleteBrandHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListBrandHandler : QueryListHandler<EditBrand, Brand>, IRequestHandler<QueryList<EditBrand>, List<EditBrand>>
    {

        public GetListBrandHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdBrandHandler : QueryIdHandler<EditBrand, Brand>, IRequestHandler<QueryId<EditBrand>, EditBrand>

    {


        public QueryIdBrandHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
