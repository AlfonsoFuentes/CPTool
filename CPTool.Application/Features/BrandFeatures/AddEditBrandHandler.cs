using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Generic;

namespace CPTool.Application.Features.BrandFeatures
{
    internal class AddEditBrandHandler : CommandHandler<EditBrand, AddBrand, Brand>, IRequestHandler<EditBrand, Result<int>>
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
        public override async Task<List<EditBrand>> Handle(QueryList<EditBrand> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryBrand.GetAllAsync();

            return _mapper.Map<List<EditBrand>>(list);

        }

    }
    internal class QueryIdBrandHandler : QueryIdHandler<EditBrand, Brand>, IRequestHandler<QueryId<EditBrand>, EditBrand>

    {


        public QueryIdBrandHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        //public override async Task<EditBrand> Handle(QueryId<EditBrand> request, CancellationToken cancellationToken)
        //{
        //    EditBrand result = new();
        //    if (request.Id != 0)
        //    {
        //        var table2 = await _unitofwork.RepositoryBrand.GetByIdAsync(request.Id);


        //        result = _mapper.Map<EditBrand>(table2);
        //    }

        //    return result;

        //}

    }
    internal class QueryExcelBrandHandler : QueryExcelHandler<EditBrand>, IRequestHandler<QueryExcel<EditBrand>, QueryExcel<EditBrand>>

    {


        public QueryExcelBrandHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
