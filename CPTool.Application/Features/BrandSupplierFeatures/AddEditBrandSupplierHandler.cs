using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Generic;
using CPTool.Application.Services;

namespace CPTool.Application.Features.BrandSupplierFeatures
{
    internal class AddEditBrandSupplierHandler : CommandHandler<EditBrandSupplier, AddBrandSupplier, BrandSupplier>, IRequestHandler<EditBrandSupplier, Result<int>>
    {
        public AddEditBrandSupplierHandler(IUnitOfWork unitofwork, IMapper mapper)
          : base(unitofwork, mapper)
        { }


        public override async Task<Result<int>> Handle(EditBrandSupplier command, CancellationToken cancellationToken)
        {

            if (command.BrandId != 0 && command.SupplierId != 0)
            {
                var exist = await _unitOfWork.Repository<BrandSupplier>().Any(
                    x => x.BrandId == command.BrandId && x.SupplierId == command.SupplierId);

                if (!exist)
                {
                    var commandbrandsupplier = _mapper.Map<AddBrandSupplier>(command);
                    var table = _mapper.Map<BrandSupplier>(commandbrandsupplier);

                    _unitOfWork.Repository<BrandSupplier>().Add(table);
                    await _unitOfWork.Complete();


                    return await Result<int>.SuccessAsync($"{table.Name} Added to {nameof(BrandSupplier)}");
                }

            }
            else if (command.BrandId != 0 && command.SupplierOriginalId != 0)
            {
                var table = await _unitOfWork.Repository<BrandSupplier>().FirstOrDefaultAsync(
                   x => x.BrandId == command.BrandId && x.SupplierId == command.SupplierOriginalId);

                if (table != null)
                {


                    _unitOfWork.Repository<BrandSupplier>().Delete(table);
                    await _unitOfWork.Complete();


                    return await Result<int>.SuccessAsync($"{table.Name} Added to {nameof(BrandSupplier)}");
                }
            }
            else if (command.BrandOriginalId != 0 && command.SupplierId != 0)
            {
                var table = await _unitOfWork.Repository<BrandSupplier>().FirstOrDefaultAsync(
                   x => x.BrandId == command.BrandOriginalId && x.SupplierId == command.SupplierId);

                if (table != null)
                {


                    _unitOfWork.Repository<BrandSupplier>().Delete(table);
                    await _unitOfWork.Complete();


                    return await Result<int>.SuccessAsync($"{table.Name} Added to {nameof(BrandSupplier)}");
                }
            }


            return await Result<int>.SuccessAsync($"Updated in {nameof(BrandSupplier)}");
        }

    }
    internal class DeleteBrandSupplierHandler : DeleteCommandHandler<EditBrandSupplier, BrandSupplier>, IRequestHandler<DeleteCommand<EditBrandSupplier>, IResult>
    {

        public DeleteBrandSupplierHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListBrandSupplierHandler : QueryListHandler<EditBrandSupplier, BrandSupplier>, IRequestHandler<QueryList<EditBrandSupplier>, List<EditBrandSupplier>>
    {

        public GetListBrandSupplierHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

        public override async Task<List<EditBrandSupplier>> Handle(QueryList<EditBrandSupplier> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryBrandSupplier.GetAllAsync();

            return _mapper.Map<List<EditBrandSupplier>>(list);

        }
    }
    //internal class QueryIdBrandSupplierHandler : QueryIdHandler<EditBrandSupplier, BrandSupplier>, IRequestHandler<QueryId<EditBrandSupplier>, EditBrandSupplier>

    //{


    //    public QueryIdBrandSupplierHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
    //    { }

    //}
    internal class QueryExcelBrandSupplierHandler : QueryExcelHandler<EditBrandSupplier>, IRequestHandler<QueryExcel<EditBrandSupplier>, QueryExcel<EditBrandSupplier>>

    {


        public QueryExcelBrandSupplierHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
