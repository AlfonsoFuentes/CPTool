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

namespace CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate
{
    public class UnitaryBasePrizeCommandHandler : IRequestHandler<CommandUnitaryBasePrize, UnitaryBasePrizeCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public UnitaryBasePrizeCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<UnitaryBasePrizeCommandResponse> Handle(CommandUnitaryBasePrize request, CancellationToken cancellationToken)
        {
            var Response = new UnitaryBasePrizeCommandResponse();

            var validator = new UnitaryBasePrizeValidator(_unitofwork.RepositoryUnitaryBasePrize);
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
                        var addcommand = _mapper.Map<AddUnitaryBasePrize>(request);
                        var table = _mapper.Map<UnitaryBasePrize>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<UnitaryBasePrize>(table));
                        table = await _unitofwork.RepositoryUnitaryBasePrize.AddAsync(table);
                        await _unitofwork.Complete();
                        request.Id = table.Id;
                        Response.ResponseObject = request;
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryUnitaryBasePrize.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddUnitaryBasePrize>(request);
                            _mapper.Map(addcommand, table, typeof(AddUnitaryBasePrize), typeof(UnitaryBasePrize));
                            table.AddDomainEvent(new UpdatedEvent<UnitaryBasePrize>(table));
                            await _unitofwork.RepositoryUnitaryBasePrize.UpdateAsync(table);
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