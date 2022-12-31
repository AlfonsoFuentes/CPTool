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

namespace CPTool.ApplicationCQRS.Features.InsulationItems.Commands.CreateUpdate
{
    public class InsulationItemCommandHandler : IRequestHandler<CommandInsulationItem, InsulationItemCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public InsulationItemCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<InsulationItemCommandResponse> Handle(CommandInsulationItem request, CancellationToken cancellationToken)
        {
            var Response = new InsulationItemCommandResponse();

            var validator = new InsulationItemValidator(_unitofwork.RepositoryInsulationItem);
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
                        var addcommand = _mapper.Map<AddInsulationItem>(request);
                        var table = _mapper.Map<InsulationItem>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<InsulationItem>(table));
                        table = await _unitofwork.RepositoryInsulationItem.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.InsulationItemObject = _mapper.Map<CommandInsulationItem>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryInsulationItem.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddInsulationItem>(request);
                            _mapper.Map(addcommand, table, typeof(AddInsulationItem), typeof(InsulationItem));
                            table.AddDomainEvent(new UpdatedEvent<InsulationItem>(table));
                            await _unitofwork.RepositoryInsulationItem.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.InsulationItemObject = _mapper.Map<CommandInsulationItem>(table);
                     
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