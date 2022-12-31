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

namespace CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate
{
    public class NozzleCommandHandler : IRequestHandler<CommandNozzle, NozzleCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public NozzleCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<NozzleCommandResponse> Handle(CommandNozzle request, CancellationToken cancellationToken)
        {
            var Response = new NozzleCommandResponse();

            var validator = new NozzleValidator(_unitofwork.RepositoryNozzle);
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
                        var addcommand = _mapper.Map<AddNozzle>(request);
                        var table = _mapper.Map<Nozzle>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<Nozzle>(table));
                        table = await _unitofwork.RepositoryNozzle.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.NozzleObject = _mapper.Map<CommandNozzle>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryNozzle.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddNozzle>(request);
                            _mapper.Map(addcommand, table, typeof(AddNozzle), typeof(Nozzle));
                            table.AddDomainEvent(new UpdatedEvent<Nozzle>(table));
                            await _unitofwork.RepositoryNozzle.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.NozzleObject = _mapper.Map<CommandNozzle>(table);
                     
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