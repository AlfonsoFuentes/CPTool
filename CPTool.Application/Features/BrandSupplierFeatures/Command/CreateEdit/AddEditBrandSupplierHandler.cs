using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;

namespace CPTool.Application.Features.BrandSupplierFeatures.CreateEdit
{
    internal class AddBrandSupplierHandler : AddBaseHandler<AddBrandSupplier, BrandSupplier>, IRequestHandler<AddBrandSupplier, Result<int>>
    {


        public AddBrandSupplierHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddBrandSupplier> logger)
            : base(unitofwork, mapper, emailService, logger) { }

        public override async Task<Result<int>> Handle(AddBrandSupplier command, CancellationToken cancellationToken)
        {
            if (command.InletBy == InletBy.Brand)
            {
                var result = await SolveBrand(command.BrandCommand!);
                if (result.Succeeded)
                {
                    command.BrandCommand = result.Data;
                }


            }
            else if (command.InletBy == InletBy.Supplier)
            {
                var result = await SolveSupplier(command.SupplierCommand!);
                if (result.Succeeded)
                {
                    command.SupplierCommand = result.Data;
                }
            }
            if (command.BrandId != 0 && command.SupplierId != 0)
            {
                var exist = await _unitOfWork.Repository<BrandSupplier>().GetAsync(
                    x => x.BrandId == command.BrandCommand!.Id && x.SupplierId == command.SupplierCommand!.Id);

                if (!(exist.Count > 0))
                {
                    var table = _mapper.Map<BrandSupplier>(command);

                    _unitOfWork.Repository<BrandSupplier>().Add(table);
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
                var table = _mapper.Map<Supplier>(command);

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
