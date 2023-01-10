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

namespace CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate
{
    public class SupplierCommandHandler : IRequestHandler<CommandSupplier, SupplierCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public SupplierCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<SupplierCommandResponse> Handle(CommandSupplier request, CancellationToken cancellationToken)
        {
            var Response = new SupplierCommandResponse();

            var validator = new SupplierValidator(_unitofwork.RepositorySupplier);
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
                        var addcommand = _mapper.Map<AddSupplier>(request);
                        var table = _mapper.Map<Supplier>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<Supplier>(table));
                        table = await _unitofwork.RepositorySupplier.AddAsync(table);
                        await _unitofwork.Complete();
                        request.Id = table.Id;
                        Response.ResponseObject = request;
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositorySupplier.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddSupplier>(request);
                            _mapper.Map(addcommand, table, typeof(AddSupplier), typeof(Supplier));
                            table.AddDomainEvent(new UpdatedEvent<Supplier>(table));
                            await _unitofwork.RepositorySupplier.UpdateAsync(table);
                            await _unitofwork.Complete();
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