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

namespace CPTool.ApplicationCQRS.Features.EHSItems.Commands.CreateUpdate
{
    public class EHSItemCommandHandler : IRequestHandler<CommandEHSItem, EHSItemCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public EHSItemCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<EHSItemCommandResponse> Handle(CommandEHSItem request, CancellationToken cancellationToken)
        {
            var Response = new EHSItemCommandResponse();

            var validator = new EHSItemValidator(_unitofwork.RepositoryEHSItem);
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
                        var addcommand = _mapper.Map<AddEHSItem>(request);
                        var table = _mapper.Map<EHSItem>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<EHSItem>(table));
                        table = await _unitofwork.RepositoryEHSItem.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.EHSItemObject = _mapper.Map<CommandEHSItem>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryEHSItem.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddEHSItem>(request);
                            _mapper.Map(addcommand, table, typeof(AddEHSItem), typeof(EHSItem));
                            table.AddDomainEvent(new UpdatedEvent<EHSItem>(table));
                            await _unitofwork.RepositoryEHSItem.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.EHSItemObject = _mapper.Map<CommandEHSItem>(table);
                     
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