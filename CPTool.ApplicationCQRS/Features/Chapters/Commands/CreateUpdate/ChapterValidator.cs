using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;
using System.Collections.Generic;

namespace CPTool.ApplicationCQRS.Features.Chapters.Commands.CreateUpdate
{
    public class ChapterValidator : AbstractValidator<CommandChapter>
    {
        private readonly IRepositoryChapter _Repository;
        public ChapterValidator(IRepositoryChapter Repository)
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



        private async Task<bool> NameUnique(CommandChapter e, CancellationToken token)
        {
            var result = await _Repository.Any(x => x.Id != e.Id && x.Name == e.Name);
            return !result;
         
        }
    }
}
