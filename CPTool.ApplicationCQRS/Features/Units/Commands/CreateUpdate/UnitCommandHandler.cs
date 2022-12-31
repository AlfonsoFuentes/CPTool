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

namespace CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate
{
    public class UnitCommandHandler : IRequestHandler<CommandUnit, UnitCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public UnitCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<UnitCommandResponse> Handle(CommandUnit request, CancellationToken cancellationToken)
        {
            var Response = new UnitCommandResponse();

            var validator = new UnitValidator(_unitofwork.RepositoryEntityUnit);
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
                        var addcommand = _mapper.Map<AddUnit>(request);
                        var table = _mapper.Map<EntityUnit>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<EntityUnit>(table));
                        table = await _unitofwork.RepositoryEntityUnit.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.UnitObject = _mapper.Map<CommandUnit>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryEntityUnit.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddUnit>(request);
                            _mapper.Map(addcommand, table, typeof(AddUnit), typeof(EntityUnit));
                            table.AddDomainEvent(new UpdatedEvent<EntityUnit>(table));
                            await _unitofwork.RepositoryEntityUnit.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.UnitObject = _mapper.Map<CommandUnit>(table);
                     
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