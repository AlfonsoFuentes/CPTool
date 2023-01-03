using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.Chapters.Commands.CreateUpdate
{
    public class ChapterValidator : AbstractValidator<CommandChapter>
    {
        private readonly IRepositoryChapter _ChapterRepository;
        public ChapterValidator(IRepositoryChapter ChapterRepository)
        {
            _ChapterRepository = ChapterRepository;

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
            return !await _ChapterRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
