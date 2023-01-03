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
using CPTool.Domain.Enums;

namespace CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate
{
    public class TaksCommandHandler : IRequestHandler<CommandTaks, TaksCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public TaksCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<TaksCommandResponse> Handle(CommandTaks request, CancellationToken cancellationToken)
        {
            var Response = new TaksCommandResponse();

            var validator = new TaksValidator(_unitofwork.RepositoryTaks);
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
                     ReviewTaskStatus(request);
                    if (request.Id == 0)
                    {
                        var addcommand = _mapper.Map<AddTaks>(request);
                        var table = _mapper.Map<Taks>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<Taks>(table));
                        table = await _unitofwork.RepositoryTaks.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.TaksObject = _mapper.Map<CommandTaks>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryTaks.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddTaks>(request);
                            _mapper.Map(addcommand, table, typeof(AddTaks), typeof(Taks));
                            table.AddDomainEvent(new UpdatedEvent<Taks>(table));
                            await _unitofwork.RepositoryTaks.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.TaksObject = _mapper.Map<CommandTaks>(table);
                     
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
        void ReviewTaskStatus(CommandTaks Model)
        {
            if (Model.TaksType == TaksType.Manual)
            {
                if (Model.TaksStatus == TaksStatus.Draft)
                {
                    Model.TaksStatus = TaksStatus.Pending;

                }
                else if (Model.TaksStatus == TaksStatus.Pending)
                {
                    Model.TaksStatus = TaksStatus.Completed;
                    Model.CompletionDate = DateTime.Now;
                }




            }
        }
    }
}