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
using CPTool.Domain.Enums;

namespace CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate
{
    public class DownPaymentCommandHandler : IRequestHandler<CommandDownPayment, DownPaymentCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public DownPaymentCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<DownPaymentCommandResponse> Handle(CommandDownPayment request, CancellationToken cancellationToken)
        {
            var Response = new DownPaymentCommandResponse();

            var validator = new DownPaymentValidator(_unitofwork.RepositoryDownPayment);
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
                    ReviewDownPayment(request);
                    if (request.Id == 0)
                    {
                        var addcommand = _mapper.Map<AddDownPayment>(request);
                        var table = _mapper.Map<DownPayment>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<DownPayment>(table));
                        table = await _unitofwork.RepositoryDownPayment.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.DownPaymentObject = _mapper.Map<CommandDownPayment>(table);

                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryDownPayment.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddDownPayment>(request);
                            _mapper.Map(addcommand, table, typeof(AddDownPayment), typeof(DownPayment));
                            table.AddDomainEvent(new UpdatedEvent<DownPayment>(table));
                            await _unitofwork.RepositoryDownPayment.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.DownPaymentObject = _mapper.Map<CommandDownPayment>(table);

                        }


                    }
                }
                catch (Exception ex)
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
        void ReviewDownPayment(CommandDownPayment Model)
        {
            if (Model.DownpaymentStatus == DownpaymentStatus.Draft)
            {

                Model.DownpaymentStatus = DownpaymentStatus.Created;
            }
            else if (Model.DownpaymentStatus == DownpaymentStatus.Created)
            {
                Model.ApprovedDate = DateTime.Now;
                Model.DownpaymentStatus = DownpaymentStatus.Approved;
            }

            else if (Model.DownpaymentStatus == DownpaymentStatus.Approved)
            {
                Model.RealDate = DateTime.Now;
                Model.DownpaymentStatus = DownpaymentStatus.Paid;
            }
        }
    }
}