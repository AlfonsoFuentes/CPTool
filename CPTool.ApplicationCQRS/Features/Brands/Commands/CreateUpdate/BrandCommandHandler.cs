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

namespace CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate
{
    public class BrandCommandHandler : IRequestHandler<CommandBrand, BrandCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public BrandCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<BrandCommandResponse> Handle(CommandBrand request, CancellationToken cancellationToken)
        {
            var Response = new BrandCommandResponse();

            var validator = new BrandValidator(_unitofwork.RepositoryBrand);
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
                        var addcommand = _mapper.Map<AddBrand>(request);
                        var table = _mapper.Map<Brand>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<Brand>(table));
                        table = await _unitofwork.RepositoryBrand.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.BrandObject = _mapper.Map<CommandBrand>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryBrand.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddBrand>(request);
                            _mapper.Map(addcommand, table, typeof(AddBrand), typeof(Brand));
                            table.AddDomainEvent(new UpdatedEvent<Brand>(table));
                            await _unitofwork.RepositoryBrand.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.BrandObject = _mapper.Map<CommandBrand>(table);
                     
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