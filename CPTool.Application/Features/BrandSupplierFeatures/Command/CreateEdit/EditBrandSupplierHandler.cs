﻿using CPTool.Application.Features.BrandFeatures;
using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetById;
using CPTool.Application.Features.BrandFeatures.Query.GetList;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;

namespace CPTool.Application.Features.BrandSupplierFeatures.CreateEdit
{
    internal class EditBrandSupplierHandler : AddEditBaseHandler<AddBrandSupplier, EditBrandSupplier, BrandSupplier>, IRequestHandler<EditBrandSupplier, Result<int>>
    {


        public EditBrandSupplierHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditBrandSupplier> logger)
            : base(unitofwork, mapper, logger) { }

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


                    return await Result<int>.SuccessAsync(table.Id, $"{table.Name} Added to {nameof(BrandSupplier)}");
                }

            }
            else if(command.BrandId!=0&& command.SupplierOriginalId!=0)
            {
                var table = await _unitOfWork.Repository<BrandSupplier>().FirstOrDefaultAsync(
                   x => x.BrandId == command.BrandId && x.SupplierId == command.SupplierOriginalId);

                if (table!=null)
                {
                  

                    _unitOfWork.Repository<BrandSupplier>().Delete(table);
                    await _unitOfWork.Complete();


                    return await Result<int>.SuccessAsync(table.Id, $"{table.Name} Added to {nameof(BrandSupplier)}");
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


                    return await Result<int>.SuccessAsync(table.Id, $"{table.Name} Added to {nameof(BrandSupplier)}");
                }
            }
            

            return await Result<int>.SuccessAsync(0, $"Updated in {nameof(BrandSupplier)}");
        }

        async Task<Result<EditBrand>> SolveBrand(EditBrand command)
        {
            if (command.Id == 0)
            {

                var table = _mapper.Map<Brand>(command);

                _unitOfWork.Repository<Brand>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;

                return await Result<EditBrand>.SuccessAsync(command, $"{table.Name} Added to {nameof(Brand)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<Brand>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddBrand), typeof(Brand));

                    _unitOfWork.Repository<Brand>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<EditBrand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(Brand)}");
                }
                else
                {
                    return await Result<EditBrand>.FailAsync($"{command.Name} not found");
                }
            }
        }
        async Task<Result<EditSupplier>> SolveSupplier(EditSupplier command)
        {
            if (command.Id == 0)
            {
                var commandsupplier = _mapper.Map<AddSupplier>(command);
                var table = _mapper.Map<Supplier>(commandsupplier);

                _unitOfWork.Repository<Supplier>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;

                return await Result<EditSupplier>.SuccessAsync(command, $"{table.Name} Added to {nameof(Supplier)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<Supplier>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(EditSupplier), typeof(Supplier));

                    _unitOfWork.Repository<Supplier>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<EditSupplier>.SuccessAsync(command, $"{table.Name} Updated in {nameof(Supplier)}");
                }
                else
                {
                    return await Result<EditSupplier>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
}
