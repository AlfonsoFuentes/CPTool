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

namespace CPTool.ApplicationCQRS.Features.Specifications.Commands.CreateUpdate
{
    public class SpecificationCommandHandler : IRequestHandler<CommandSpecification, SpecificationCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public SpecificationCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<SpecificationCommandResponse> Handle(CommandSpecification request, CancellationToken cancellationToken)
        {
            var Response = new SpecificationCommandResponse();

            var validator = new SpecificationValidator(_unitofwork.RepositorySpecification);
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
                        var addcommand = _mapper.Map<AddSpecification>(request);
                        var table = _mapper.Map<Specification>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<Specification>(table));
                        table = await _unitofwork.RepositorySpecification.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.SpecificationObject = _mapper.Map<CommandSpecification>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositorySpecification.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddSpecification>(request);
                            _mapper.Map(addcommand, table, typeof(AddSpecification), typeof(Specification));
                            table.AddDomainEvent(new UpdatedEvent<Specification>(table));
                            await _unitofwork.RepositorySpecification.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.SpecificationObject = _mapper.Map<CommandSpecification>(table);
                     
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