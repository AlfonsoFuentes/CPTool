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

namespace CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate
{
    public class AlterationItemCommandHandler : IRequestHandler<CommandAlterationItem, AlterationItemCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public AlterationItemCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<AlterationItemCommandResponse> Handle(CommandAlterationItem request, CancellationToken cancellationToken)
        {
            var Response = new AlterationItemCommandResponse();

            var validator = new AlterationItemValidator(_unitofwork.RepositoryAlterationItem);
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
                        var addcommand = _mapper.Map<AddAlterationItem>(request);
                        var table = _mapper.Map<AlterationItem>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<AlterationItem>(table));
                        table = await _unitofwork.RepositoryAlterationItem.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.AlterationItemObject = _mapper.Map<CommandAlterationItem>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryAlterationItem.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddAlterationItem>(request);
                            _mapper.Map(addcommand, table, typeof(AddAlterationItem), typeof(AlterationItem));
                            table.AddDomainEvent(new UpdatedEvent<AlterationItem>(table));
                            await _unitofwork.RepositoryAlterationItem.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.AlterationItemObject = _mapper.Map<CommandAlterationItem>(table);
                     
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