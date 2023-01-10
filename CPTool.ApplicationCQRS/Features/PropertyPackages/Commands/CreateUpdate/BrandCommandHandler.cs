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

namespace CPTool.ApplicationCQRS.Features.PropertyPackages.Commands.CreateUpdate
{
    public class PropertyPackageCommandHandler : IRequestHandler<CommandPropertyPackage, PropertyPackageCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public PropertyPackageCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<PropertyPackageCommandResponse> Handle(CommandPropertyPackage request, CancellationToken cancellationToken)
        {
            var Response = new PropertyPackageCommandResponse();

            var validator = new PropertyPackageValidator(_unitofwork.RepositoryPropertyPackage);
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
                        var addcommand = _mapper.Map<AddPropertyPackage>(request);
                        var table = _mapper.Map<PropertyPackage>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<PropertyPackage>(table));
                        table = await _unitofwork.RepositoryPropertyPackage.AddAsync(table);
                        await _unitofwork.Complete();
                        request.Id = table.Id;
                        Response.ResponseObject = request;
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryPropertyPackage.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddPropertyPackage>(request);
                            _mapper.Map(addcommand, table, typeof(AddPropertyPackage), typeof(PropertyPackage));
                            table.AddDomainEvent(new UpdatedEvent<PropertyPackage>(table));
                            await _unitofwork.RepositoryPropertyPackage.UpdateAsync(table);
                            await _unitofwork.Complete();
                            request.Id = table.Id;
                            Response.ResponseObject = request;
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