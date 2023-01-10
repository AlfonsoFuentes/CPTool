﻿using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate
{
    public class UnitaryBasePrizeValidator : AbstractValidator<CommandUnitaryBasePrize>
    {
        private readonly IRepositoryUnitaryBasePrize _Repository;
        public UnitaryBasePrizeValidator(IRepositoryUnitaryBasePrize Repository)
        {
            _Repository = Repository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandUnitaryBasePrize e, CancellationToken token)
        {
            var result = await _Repository.Any(x => x.Id != e.Id && x.Name == e.Name);
            return !result;
           
        }
    }
}
