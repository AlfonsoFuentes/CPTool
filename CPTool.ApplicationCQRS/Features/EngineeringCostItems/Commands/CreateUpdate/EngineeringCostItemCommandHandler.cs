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

namespace CPTool.ApplicationCQRS.Features.EngineeringCostItems.Commands.CreateUpdate
{
    public class EngineeringCostItemCommandHandler : IRequestHandler<CommandEngineeringCostItem, EngineeringCostItemCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public EngineeringCostItemCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<EngineeringCostItemCommandResponse> Handle(CommandEngineeringCostItem request, CancellationToken cancellationToken)
        {
            var Response = new EngineeringCostItemCommandResponse();

            var validator = new EngineeringCostItemValidator(_unitofwork.RepositoryEngineeringCostItem);
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
                        var addcommand = _mapper.Map<AddEngineeringCostItem>(request);
                        var table = _mapper.Map<EngineeringCostItem>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<EngineeringCostItem>(table));
                        table = await _unitofwork.RepositoryEngineeringCostItem.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.EngineeringCostItemObject = _mapper.Map<CommandEngineeringCostItem>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryEngineeringCostItem.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddEngineeringCostItem>(request);
                            _mapper.Map(addcommand, table, typeof(AddEngineeringCostItem), typeof(EngineeringCostItem));
                            table.AddDomainEvent(new UpdatedEvent<EngineeringCostItem>(table));
                            await _unitofwork.RepositoryEngineeringCostItem.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.EngineeringCostItemObject = _mapper.Map<CommandEngineeringCostItem>(table);
                     
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