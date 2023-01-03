using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.ConnectionTypes.Commands.CreateUpdate
{
    public class ConnectionTypeValidator : AbstractValidator<CommandConnectionType>
    {
        private readonly IRepositoryConnectionType _ConnectionTypeRepository;
        public ConnectionTypeValidator(IRepositoryConnectionType ConnectionTypeRepository)
        {
            _ConnectionTypeRepository = ConnectionTypeRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandConnectionType e, CancellationToken token)
        {
            return !await _ConnectionTypeRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
