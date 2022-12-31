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

namespace CPTool.ApplicationCQRS.Features.FieldLocations.Commands.CreateUpdate
{
    public class FieldLocationCommandHandler : IRequestHandler<CommandFieldLocation, FieldLocationCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public FieldLocationCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<FieldLocationCommandResponse> Handle(CommandFieldLocation request, CancellationToken cancellationToken)
        {
            var Response = new FieldLocationCommandResponse();

            var validator = new FieldLocationValidator(_unitofwork.RepositoryFieldLocation);
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
                        var addcommand = _mapper.Map<AddFieldLocation>(request);
                        var table = _mapper.Map<FieldLocation>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<FieldLocation>(table));
                        table = await _unitofwork.RepositoryFieldLocation.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.FieldLocationObject = _mapper.Map<CommandFieldLocation>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryFieldLocation.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddFieldLocation>(request);
                            _mapper.Map(addcommand, table, typeof(AddFieldLocation), typeof(FieldLocation));
                            table.AddDomainEvent(new UpdatedEvent<FieldLocation>(table));
                            await _unitofwork.RepositoryFieldLocation.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.FieldLocationObject = _mapper.Map<CommandFieldLocation>(table);
                     
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