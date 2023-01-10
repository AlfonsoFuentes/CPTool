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

namespace CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate
{
    public class BrandSupplierCommandHandler : IRequestHandler<CommandBrandSupplier, BrandSupplierCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public BrandSupplierCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<BrandSupplierCommandResponse> Handle(CommandBrandSupplier request, CancellationToken cancellationToken)
        {
            var Response = new BrandSupplierCommandResponse();

            var validator = new BrandSupplierValidator(_unitofwork.RepositoryBrandSupplier);
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
                    if (request.BrandId != 0 && request.SupplierId != 0)
                    {
                        var exist = (await _unitofwork.RepositoryBrandSupplier.GetAllAsync(x => x.BrandId == request.BrandId && x.SupplierId == request.SupplierId)).Any();

                        if (!exist)
                        {
                            var commandbrandsupplier = _mapper.Map<AddBrandSupplier>(request);
                            var table = _mapper.Map<BrandSupplier>(commandbrandsupplier);
                            table.AddDomainEvent(new CreatedEvent<BrandSupplier>(table));
                            await _unitofwork.RepositoryBrandSupplier.AddAsync(table);
                            await _unitofwork.Complete();
                           
                            Response.ResponseObject = request;


                        }

                    }
                    else if (request.BrandId != 0 && request.SupplierOriginalId != 0)
                    {
                        var table = await _unitofwork.RepositoryBrandSupplier.FirstOrDefaultAsync(
                           x => x.BrandId == request.BrandId && x.SupplierId == request.SupplierOriginalId);

                        if (table != null)
                        {
                            table!.AddDomainEvent(new DeletedEvent<BrandSupplier>(table));
                            await _unitofwork.RepositoryBrandSupplier.DeleteAsync(table);
                           await _unitofwork.Complete();

                        
                            Response.ResponseObject = request;

                        }
                    }
                    else if (request.BrandOriginalId != 0 && request.SupplierId != 0)
                    {
                        var table = (await _unitofwork.RepositoryBrandSupplier.FirstOrDefaultAsync(
                           x => x.BrandId == request.BrandOriginalId && x.SupplierId == request.SupplierId));

                        if (table != null)
                        {


                            table!.AddDomainEvent(new DeletedEvent<BrandSupplier>(table));
                            await _unitofwork.RepositoryBrandSupplier.DeleteAsync(table);
                            await _unitofwork.Complete();
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