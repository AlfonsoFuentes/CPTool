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

namespace CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate
{
    public class MWOCommandHandler : IRequestHandler<CommandMWO, MWOCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public MWOCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<MWOCommandResponse> Handle(CommandMWO request, CancellationToken cancellationToken)
        {
            var Response = new MWOCommandResponse();

            var validator = new MWOValidator(_unitofwork.RepositoryMWO);
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
                        var addcommand = _mapper.Map<AddMWO>(request);
                        var table = _mapper.Map<MWO>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<MWO>(table));
                        table = await _unitofwork.RepositoryMWO.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.MWOObject = _mapper.Map<CommandMWO>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryMWO.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddMWO>(request);
                            _mapper.Map(addcommand, table, typeof(AddMWO), typeof(MWO));
                            table.AddDomainEvent(new UpdatedEvent<MWO>(table));
                            await _unitofwork.RepositoryMWO.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.MWOObject = _mapper.Map<CommandMWO>(table);
                     
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