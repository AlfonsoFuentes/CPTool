﻿using AutoMapper;
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

namespace CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Commands.CreateUpdate
{
    public class MeasuredVariableModifierCommandHandler : IRequestHandler<CommandMeasuredVariableModifier, MeasuredVariableModifierCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public MeasuredVariableModifierCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<MeasuredVariableModifierCommandResponse> Handle(CommandMeasuredVariableModifier request, CancellationToken cancellationToken)
        {
            var Response = new MeasuredVariableModifierCommandResponse();

            var validator = new MeasuredVariableModifierValidator(_unitofwork.RepositoryMeasuredVariableModifier);
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
                        var addcommand = _mapper.Map<AddMeasuredVariableModifier>(request);
                        var table = _mapper.Map<MeasuredVariableModifier>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<MeasuredVariableModifier>(table));
                        table = await _unitofwork.RepositoryMeasuredVariableModifier.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.MeasuredVariableModifierObject = _mapper.Map<CommandMeasuredVariableModifier>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryMeasuredVariableModifier.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddMeasuredVariableModifier>(request);
                            _mapper.Map(addcommand, table, typeof(AddMeasuredVariableModifier), typeof(MeasuredVariableModifier));
                            table.AddDomainEvent(new UpdatedEvent<MeasuredVariableModifier>(table));
                            await _unitofwork.RepositoryMeasuredVariableModifier.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.MeasuredVariableModifierObject = _mapper.Map<CommandMeasuredVariableModifier>(table);
                     
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