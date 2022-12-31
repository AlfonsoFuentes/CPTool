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

namespace CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate
{
    public class MWOTypeCommandHandler : IRequestHandler<CommandMWOType, MWOTypeCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public MWOTypeCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<MWOTypeCommandResponse> Handle(CommandMWOType request, CancellationToken cancellationToken)
        {
            var Response = new MWOTypeCommandResponse();

            var validator = new MWOTypeValidator(_unitofwork.RepositoryMWOType);
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
                        var addcommand = _mapper.Map<AddMWOType>(request);
                        var table = _mapper.Map<MWOType>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<MWOType>(table));
                        table = await _unitofwork.RepositoryMWOType.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.MWOTypeObject = _mapper.Map<CommandMWOType>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryMWOType.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddMWOType>(request);
                            _mapper.Map(addcommand, table, typeof(AddMWOType), typeof(MWOType));
                            table.AddDomainEvent(new UpdatedEvent<MWOType>(table));
                            await _unitofwork.RepositoryMWOType.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.MWOTypeObject = _mapper.Map<CommandMWOType>(table);
                     
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