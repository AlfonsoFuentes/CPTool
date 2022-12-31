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

namespace CPTool.ApplicationCQRS.Features.ElectricalItems.Commands.CreateUpdate
{
    public class ElectricalItemCommandHandler : IRequestHandler<CommandElectricalItem, ElectricalItemCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public ElectricalItemCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<ElectricalItemCommandResponse> Handle(CommandElectricalItem request, CancellationToken cancellationToken)
        {
            var Response = new ElectricalItemCommandResponse();

            var validator = new ElectricalItemValidator(_unitofwork.RepositoryElectricalItem);
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
                        var addcommand = _mapper.Map<AddElectricalItem>(request);
                        var table = _mapper.Map<ElectricalItem>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<ElectricalItem>(table));
                        table = await _unitofwork.RepositoryElectricalItem.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.ElectricalItemObject = _mapper.Map<CommandElectricalItem>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryElectricalItem.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddElectricalItem>(request);
                            _mapper.Map(addcommand, table, typeof(AddElectricalItem), typeof(ElectricalItem));
                            table.AddDomainEvent(new UpdatedEvent<ElectricalItem>(table));
                            await _unitofwork.RepositoryElectricalItem.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.ElectricalItemObject = _mapper.Map<CommandElectricalItem>(table);
                     
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