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

namespace CPTool.ApplicationCQRS.Features.PaintingItems.Commands.CreateUpdate
{
    public class PaintingItemCommandHandler : IRequestHandler<CommandPaintingItem, PaintingItemCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public PaintingItemCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<PaintingItemCommandResponse> Handle(CommandPaintingItem request, CancellationToken cancellationToken)
        {
            var Response = new PaintingItemCommandResponse();

            var validator = new PaintingItemValidator(_unitofwork.RepositoryPaintingItem);
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
                        var addcommand = _mapper.Map<AddPaintingItem>(request);
                        var table = _mapper.Map<PaintingItem>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<PaintingItem>(table));
                        table = await _unitofwork.RepositoryPaintingItem.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.PaintingItemObject = _mapper.Map<CommandPaintingItem>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryPaintingItem.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddPaintingItem>(request);
                            _mapper.Map(addcommand, table, typeof(AddPaintingItem), typeof(PaintingItem));
                            table.AddDomainEvent(new UpdatedEvent<PaintingItem>(table));
                            await _unitofwork.RepositoryPaintingItem.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.PaintingItemObject = _mapper.Map<CommandPaintingItem>(table);
                     
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