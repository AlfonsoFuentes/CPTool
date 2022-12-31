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

namespace CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate
{
    public class UserRequirementCommandHandler : IRequestHandler<CommandUserRequirement, UserRequirementCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public UserRequirementCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<UserRequirementCommandResponse> Handle(CommandUserRequirement request, CancellationToken cancellationToken)
        {
            var Response = new UserRequirementCommandResponse();

            var validator = new UserRequirementValidator(_unitofwork.RepositoryUserRequirement);
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
                        var addcommand = _mapper.Map<AddUserRequirement>(request);
                        var table = _mapper.Map<UserRequirement>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<UserRequirement>(table));
                        table = await _unitofwork.RepositoryUserRequirement.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.UserRequirementObject = _mapper.Map<CommandUserRequirement>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryUserRequirement.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddUserRequirement>(request);
                            _mapper.Map(addcommand, table, typeof(AddUserRequirement), typeof(UserRequirement));
                            table.AddDomainEvent(new UpdatedEvent<UserRequirement>(table));
                            await _unitofwork.RepositoryUserRequirement.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.UserRequirementObject = _mapper.Map<CommandUserRequirement>(table);
                     
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