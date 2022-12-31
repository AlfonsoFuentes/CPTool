using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Models.Mail;

using MediatR;
using System;
using CPTool.ApplicationCQRS.Exceptions;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using CPTool.Domain.Common;

namespace CPTool.ApplicationCQRS.Features.Chapters.Commands.CreateUpdate
{
    public class ChapterCommandHandler : IRequestHandler<CommandChapter, ChapterCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public ChapterCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<ChapterCommandResponse> Handle(CommandChapter request, CancellationToken cancellationToken)
        {
            var Response = new ChapterCommandResponse();

            var validator = new ChapterValidator(_unitofwork.RepositoryChapter);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                Response.Success = false;
                
                foreach (var error in validationResult.Errors)
                {
                    Response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (Response.Success)
            {
                try
                {
                    if (request.Id == 0)
                    {
                        var addcommand = _mapper.Map<AddChapter>(request);
                        var table = _mapper.Map<Chapter>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<Chapter>(table));
                        table = await _unitofwork.RepositoryChapter.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.ChapterObject = _mapper.Map<CommandChapter>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryChapter.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddChapter>(request);
                            _mapper.Map(addcommand, table, typeof(AddChapter), typeof(Chapter));
                            table.AddDomainEvent(new UpdatedEvent<Chapter>(table));
                            await _unitofwork.RepositoryChapter.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.ChapterObject = _mapper.Map<CommandChapter>(table);
                     
                        }


                    }
                }
                catch(Exception ex)
                {
                    Response.Message = ex.Message;
                    Response.Success = false;
                }
                
            }
            var email = new Email() { To = "alfonsofuen@gmail.com", Body = $"A new Mwo Type was created: {request}", Subject = "A new Mwo Type was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                Response.Message = ex.Message;
                //this shouldn't stop the API from doing else so this can be logged
            }


            return Response;
        }
    }
}