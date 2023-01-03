﻿using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate
{
    public class TaksValidator : AbstractValidator<CommandTaks>
    {
        private readonly IRepositoryTaks _TaksRepository;
        public TaksValidator(IRepositoryTaks TaksRepository)
        {
            _TaksRepository = TaksRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.MWO!.Id)
         .NotEqual(0).WithMessage("MWO is required.");

            RuleFor(p => p.MWO!.Id)
        .NotEqual(0).WithMessage("MWO is required.");

            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandTaks e, CancellationToken token)
        {
            return !await _TaksRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}