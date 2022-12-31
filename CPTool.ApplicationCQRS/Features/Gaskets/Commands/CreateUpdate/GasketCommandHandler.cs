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

namespace CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate
{
    public class GasketCommandHandler : IRequestHandler<CommandGasket, GasketCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public GasketCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<GasketCommandResponse> Handle(CommandGasket request, CancellationToken cancellationToken)
        {
            var Response = new GasketCommandResponse();

            var validator = new GasketValidator(_unitofwork.RepositoryGasket);
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
                        var addcommand = _mapper.Map<AddGasket>(request);
                        var table = _mapper.Map<Gasket>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<Gasket>(table));
                        table = await _unitofwork.RepositoryGasket.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.GasketObject = _mapper.Map<CommandGasket>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryGasket.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddGasket>(request);
                            _mapper.Map(addcommand, table, typeof(AddGasket), typeof(Gasket));
                            table.AddDomainEvent(new UpdatedEvent<Gasket>(table));
                            await _unitofwork.RepositoryGasket.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.GasketObject = _mapper.Map<CommandGasket>(table);
                     
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