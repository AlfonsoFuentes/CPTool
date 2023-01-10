using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate
{
    public class BrandSupplierValidator : AbstractValidator<CommandBrandSupplier>
    {
        private readonly IRepositoryBrandSupplier _BrandSupplierRepository;
        public BrandSupplierValidator(IRepositoryBrandSupplier BrandSupplierRepository)
        {
            _BrandSupplierRepository = BrandSupplierRepository;

           

        }



       
    }
}
