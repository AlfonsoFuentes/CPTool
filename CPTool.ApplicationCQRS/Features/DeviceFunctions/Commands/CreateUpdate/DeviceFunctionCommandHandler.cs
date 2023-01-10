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

namespace CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate
{
    public class DeviceFunctionCommandHandler : IRequestHandler<CommandDeviceFunction, DeviceFunctionCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public DeviceFunctionCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<DeviceFunctionCommandResponse> Handle(CommandDeviceFunction request, CancellationToken cancellationToken)
        {
            var Response = new DeviceFunctionCommandResponse();

            var validator = new DeviceFunctionValidator(_unitofwork.RepositoryDeviceFunction);
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
                        var addcommand = _mapper.Map<AddDeviceFunction>(request);
                        var table = _mapper.Map<DeviceFunction>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<DeviceFunction>(table));
                        table = await _unitofwork.RepositoryDeviceFunction.AddAsync(table);
                        await _unitofwork.Complete();
                        request.Id = table.Id;
                        Response.ResponseObject = request;
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryDeviceFunction.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddDeviceFunction>(request);
                            _mapper.Map(addcommand, table, typeof(AddDeviceFunction), typeof(DeviceFunction));
                            table.AddDomainEvent(new UpdatedEvent<DeviceFunction>(table));
                            await _unitofwork.RepositoryDeviceFunction.UpdateAsync(table);
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