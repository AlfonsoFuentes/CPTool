
using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;
using CPTool.Application.Features.MMOTypeFeatures.CreateEdit;
using CPTool.Application.Generic;
using CPTool.Application.Services;

namespace CPTool.Application.Features.FieldLocationFeatures
{
    internal class AddEditFieldLocationHandler : CommandHandler<EditFieldLocation, AddFieldLocation, FieldLocation>, IRequestHandler<EditFieldLocation, Result<int>>
    {

        public AddEditFieldLocationHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteFieldLocationHandler : DeleteCommandHandler<EditFieldLocation, FieldLocation>, IRequestHandler<DeleteCommand<EditFieldLocation>, IResult>
    {

        public DeleteFieldLocationHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListFieldLocationHandler : QueryListHandler<EditFieldLocation, FieldLocation>, IRequestHandler<QueryList<EditFieldLocation>, List<EditFieldLocation>>
    {

        public GetListFieldLocationHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditFieldLocation>> Handle(QueryList<EditFieldLocation> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryFieldLocation.GetAllAsync();

            return _mapper.Map<List<EditFieldLocation>>(list);

        }
    }
    internal class QueryIdFieldLocationHandler : QueryIdHandler<EditFieldLocation, FieldLocation>, IRequestHandler<QueryId<EditFieldLocation>, EditFieldLocation>

    {


        public QueryIdFieldLocationHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditFieldLocation> Handle(QueryId<EditFieldLocation> request, CancellationToken cancellationToken)
        {
            EditFieldLocation result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryFieldLocation.GetByIdAsync(request.Id);


                result = _mapper.Map<EditFieldLocation>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelFieldLocationHandler : QueryExcelHandler<EditFieldLocation>, IRequestHandler<QueryExcel<EditFieldLocation>, QueryExcel<EditFieldLocation>>

    {


        public QueryExcelFieldLocationHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
