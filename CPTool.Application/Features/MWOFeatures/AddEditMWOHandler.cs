﻿using CPTool.Application.Features.MMOTypeFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Generic;

namespace CPTool.Application.Features.MWOFeatures
{
   
    internal class AddEditMWOHandler : CommandHandler<EditMWO, AddMWO, MWO>, IRequestHandler<EditMWO, Result<int>>
    {

        public AddEditMWOHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteMWOHandler : DeleteCommandHandler<EditMWO, MWO>, IRequestHandler<DeleteCommand<EditMWO>, IResult>
    {

        public DeleteMWOHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListMWOHandler : QueryListHandler<EditMWO, MWO>, IRequestHandler<QueryList<EditMWO>, List<EditMWO>>
    {

        public GetListMWOHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditMWO>> Handle(QueryList<EditMWO> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryMWO.GetAllAsync();

            return _mapper.Map<List<EditMWO>>(list);

        }
    }
    internal class QueryIdMWOHandler : QueryIdHandler<EditMWO, MWO>, IRequestHandler<QueryId<EditMWO>, EditMWO>

    {


        public QueryIdMWOHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditMWO> Handle(QueryId<EditMWO> request, CancellationToken cancellationToken)
        {
            EditMWO result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryMWO.GetByIdAsync(request.Id);


                result = _mapper.Map<EditMWO>(table2);
            }

            return result;

        }
        internal class QueryExcelMWOHandler : QueryExcelHandler<EditMWO>, IRequestHandler<QueryExcel<EditMWO>, QueryExcel<EditMWO>>

        {


            public QueryExcelMWOHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
            { }

        }
    }
}
