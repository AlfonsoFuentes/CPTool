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

namespace CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate
{
    public class MaterialCommandHandler : IRequestHandler<CommandMaterial, MaterialCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public MaterialCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<MaterialCommandResponse> Handle(CommandMaterial request, CancellationToken cancellationToken)
        {
            var Response = new MaterialCommandResponse();

            var validator = new MaterialValidator(_unitofwork.RepositoryMaterial);
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
                        var addcommand = _mapper.Map<AddMaterial>(request);
                        var table = _mapper.Map<Material>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<Material>(table));
                        table = await _unitofwork.RepositoryMaterial.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.MaterialObject = _mapper.Map<CommandMaterial>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryMaterial.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddMaterial>(request);
                            _mapper.Map(addcommand, table, typeof(AddMaterial), typeof(Material));
                            table.AddDomainEvent(new UpdatedEvent<Material>(table));
                            await _unitofwork.RepositoryMaterial.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.MaterialObject = _mapper.Map<CommandMaterial>(table);
                     
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