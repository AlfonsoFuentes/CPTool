global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.Chapters.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.Chapters.Profiles
{
    internal class ChapterMapping : Profile
    {
        public ChapterMapping()
        {
            CreateMap<Chapter, CommandChapter>();
            CreateMap<CommandChapter, Chapter>();
            CreateMap<AddChapter, Chapter>();
            CreateMap<CommandChapter, AddChapter>();
        }
    }
}
