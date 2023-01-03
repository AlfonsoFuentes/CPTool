using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate
{
    public class AlterationItemValidator : AbstractValidator<CommandAlterationItem>
    {
        private readonly IRepositoryAlterationItem _AlterationItemRepository;
        public AlterationItemValidator(IRepositoryAlterationItem AlterationItemRepository)
        {
            _AlterationItemRepository = AlterationItemRepository;

           


           

        }



        private async Task<bool> NameUnique(CommandAlterationItem e, CancellationToken token)
        {
            return !await _AlterationItemRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
