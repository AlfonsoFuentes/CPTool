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

namespace CPTool.ApplicationCQRS.Features.ContingencyItems.Commands.CreateUpdate
{
    public class ContingencyItemCommandHandler : IRequestHandler<CommandContingencyItem, ContingencyItemCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public ContingencyItemCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<ContingencyItemCommandResponse> Handle(CommandContingencyItem request, CancellationToken cancellationToken)
        {
            var Response = new ContingencyItemCommandResponse();

            var validator = new ContingencyItemValidator(_unitofwork.RepositoryContingencyItem);
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
                        var addcommand = _mapper.Map<AddContingencyItem>(request);
                        var table = _mapper.Map<ContingencyItem>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<ContingencyItem>(table));
                        table = await _unitofwork.RepositoryContingencyItem.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.ContingencyItemObject = _mapper.Map<CommandContingencyItem>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryContingencyItem.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddContingencyItem>(request);
                            _mapper.Map(addcommand, table, typeof(AddContingencyItem), typeof(ContingencyItem));
                            table.AddDomainEvent(new UpdatedEvent<ContingencyItem>(table));
                            await _unitofwork.RepositoryContingencyItem.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.ContingencyItemObject = _mapper.Map<CommandContingencyItem>(table);
                     
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