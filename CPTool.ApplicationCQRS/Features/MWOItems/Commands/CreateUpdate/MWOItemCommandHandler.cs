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
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate;
using Azure.Core;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.FoundationItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.StructuralItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ElectricalItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EHSItems.Commands.CreateUpdate;
using System.Runtime.CompilerServices;
using CPTool.ApplicationCQRS.Features.ContingencyItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EngineeringCostItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.TestingItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.TaxesItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PaintingItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.InsulationItems.Commands.CreateUpdate;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;

namespace CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate
{
    public class MWOItemCommandHandler : IRequestHandler<CommandMWOItem, MWOItemCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public MWOItemCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<MWOItemCommandResponse> Handle(CommandMWOItem request, CancellationToken cancellationToken)
        {
            var Response = new MWOItemCommandResponse();

            var validator = new MWOItemValidator(_unitofwork.RepositoryMWOItem);
            var validationResult = await validator.ValidateAsync(request);
            var validationResultInternal = await ValidateInternalItems(request);
            if (validationResult.Errors.Count > 0|| validationResultInternal.Errors.Count>0)
            {
                Response.Success = false;

                foreach (var error in validationResult.Errors)
                {
                    Response.ValidationErrors.Add(error.ErrorMessage);
                }
                foreach (var error in validationResultInternal.Errors)
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
                        var addcommand = _mapper.Map<AddMWOItem>(request);
                        var table = _mapper.Map<MWOItem>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<MWOItem>(table));
                        table = await _unitofwork.RepositoryMWOItem.AddAsync(table);
                        await _unitofwork.Complete();
                        request.Id = table.Id;
                        Response.MWOItemObject = request;

                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryMWOItem.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<UpdateMWOItem>(request);
                            _mapper.Map(addcommand, table, typeof(UpdateMWOItem), typeof(MWOItem));
                            table.AddDomainEvent(new UpdatedEvent<MWOItem>(table));
                            await _unitofwork.RepositoryMWOItem.UpdateAsync(table);
                            await SaveInternalItem(request);
                            await _unitofwork.Complete();
                            Response.MWOItemObject = request;

                        }


                    }
                }
                catch (Exception ex)
                {
                    Response.Message = ex.Message;
                    Response.Success = false;
                    Response.ValidationErrors.Add(ex.Message);
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

       async Task<FluentValidation.Results.ValidationResult> ValidateInternalItems(CommandMWOItem request)
        {
            switch (request.Chapter!.Id)
            {
                case 1:
                    { 
                    var validator = new AlterationItemValidator(_unitofwork.RepositoryAlterationItem);
                    return await validator.ValidateAsync(request.AlterationItem!);
                    }
                   
                case 2:
                    {
                        var validator = new FoundationItemValidator(_unitofwork.RepositoryFoundationItem);
                        return await validator.ValidateAsync(request.FoundationItem!);
                    }
                case 3:
                    {
                        var validator = new StructuralItemValidator(_unitofwork.RepositoryStructuralItem);
                        return await validator.ValidateAsync(request.StructuralItem!);
                    }
                case 4:
                    {
                        var validator = new EquipmentItemValidator(_unitofwork.RepositoryMWOItemWithEquipment);
                        return await validator.ValidateAsync(request);
                    }
                case 5:
                    {
                        var validator = new ElectricalItemValidator(_unitofwork.RepositoryElectricalItem);
                        return await validator.ValidateAsync(request.ElectricalItem!);
                    }
                case 6:
                    {
                        var validator = new PipingItemValidator(_unitofwork.RepositoryMWOItemWithPiping);
                        return await validator.ValidateAsync(request);
                    }
                case 7:
                    {
                        var validator = new InstrumentItemValidator(_unitofwork.RepositoryMWOItemWithInstrument);
                        return await validator.ValidateAsync(request);
                    }
                case 8:
                    {
                        var validator = new InsulationItemValidator(_unitofwork.RepositoryInsulationItem);
                        return await validator.ValidateAsync(request.InsulationItem!);
                    }
                case 9:
                    {
                        var validator = new EHSItemValidator(_unitofwork.RepositoryEHSItem);
                        return await validator.ValidateAsync(request.EHSItem!);
                    }
                case 10:
                    {
                        var validator = new PaintingItemValidator(_unitofwork.RepositoryPaintingItem);
                        return await validator.ValidateAsync(request.PaintingItem!);
                    }
                case 11:
                    {
                        var validator = new TaxesItemValidator(_unitofwork.RepositoryTaxesItem);
                        return await validator.ValidateAsync(request.TaxesItem!);
                    }
                case 12:
                    {
                        var validator = new TestingItemValidator(_unitofwork.RepositoryTestingItem);
                        return await validator.ValidateAsync(request.TestingItem!);
                    }
                case 13:
                    {
                        var validator = new EngineeringCostItemValidator(_unitofwork.RepositoryEngineeringCostItem);
                        return await validator.ValidateAsync(request.EngineeringCostItem!);
                    }
                case 14:
                    {
                        var validator = new ContingencyItemValidator(_unitofwork.RepositoryContingencyItem);
                        return await validator.ValidateAsync(request.ContingencyItem!);
                    }

            }
            return new();
        }

        async Task SaveInternalItem(CommandMWOItem request)
        {
            switch (request.Chapter!.Id)
            {
                case 1:
                    await SaveAlteration(request);
                    break;
                case 2:
                    await SaveFoundation(request);
                    break;
                case 3:
                    await SaveStructural(request);
                    break;
                case 4:
                    await SaveEquipment(request);
                    break;
                case 5:
                    await SaveElectrical(request);
                    break;
                case 6:
                    await SavePiping(request);
                    break;
                case 7:
                    await SaveInstrument(request);
                    break;
                case 8:
                    await SaveInsulation(request);
                    break;
                case 9:
                    await SavePainting(request);
                    break;
                case 10:
                    await SaveEHS(request);
                    break;
                case 11:
                    await SaveTaxes(request);
                    break;
                case 12:
                    await SaveTesting(request);
                    break;
                case 13:
                    await SaveEngineeringCost(request);
                    break;
                case 14:
                    await SaveContingency(request);
                    break;

            }
        }

        async Task SaveProcessCondition(CommandProcessCondition request)
        {
            var table = await _unitofwork.RepositoryProcessCondition.FindAsync(request.Id);
            var addcommand = _mapper.Map<AddProcessCondition>(request);
            _mapper.Map(addcommand, table, typeof(AddProcessCondition), typeof(ProcessCondition));


            await _unitofwork.RepositoryProcessCondition.UpdateAsync(table!);
        }
        async Task SavePipeAccesories(CommandPipeAccesory request)
        {
            var table = await _unitofwork.RepositoryPipeAccesory.FindAsync(request.Id);
            var addcommand = _mapper.Map<UpdatePipeAccesory>(request);
            _mapper.Map(addcommand, table, typeof(UpdatePipeAccesory), typeof(PipeAccesory));
            await _unitofwork.RepositoryPipeAccesory.UpdateAsync(table!);
        }

        async Task SaveAlteration(CommandMWOItem request)
        {
            var table = await _unitofwork.RepositoryAlterationItem.FindAsync(request.AlterationItemId!.Value);
            var addcommand = _mapper.Map<AddAlterationItem>(request.AlterationItem);
            _mapper.Map(addcommand, table, typeof(AddAlterationItem), typeof(AlterationItem));
            await _unitofwork.RepositoryAlterationItem.UpdateAsync(table!);
        }
        async Task SaveFoundation(CommandMWOItem request)
        {
            var table = await _unitofwork.RepositoryFoundationItem.FindAsync(request.FoundationItemId!.Value);
            var addcommand = _mapper.Map<AddFoundationItem>(request.FoundationItem);
            _mapper.Map(addcommand, table, typeof(AddFoundationItem), typeof(FoundationItem));
            await _unitofwork.RepositoryFoundationItem.UpdateAsync(table!);
        }
        async Task SaveStructural(CommandMWOItem request)
        {
            var table = await _unitofwork.RepositoryStructuralItem.FindAsync(request.StructuralItemId!.Value);
            var addcommand = _mapper.Map<AddStructuralItem>(request.StructuralItem);
            _mapper.Map(addcommand, table, typeof(AddStructuralItem), typeof(StructuralItem));
            await _unitofwork.RepositoryStructuralItem.UpdateAsync(table!);
        }
        async Task SaveEquipment(CommandMWOItem request)
        {
            var table = await _unitofwork.RepositoryEquipmentItem.FindAsync(request.EquipmentItem!.Id);
            var addcommand = _mapper.Map<UpdateEquipmentItem>(request.EquipmentItem);
            _mapper.Map(addcommand, table, typeof(UpdateEquipmentItem), typeof(EquipmentItem));
            await _unitofwork.RepositoryEquipmentItem.UpdateAsync(table!);
            await SaveProcessCondition(request.EquipmentItem!.eProcessCondition!);
        }
        async Task SaveElectrical(CommandMWOItem request)
        {
            var table = await _unitofwork.RepositoryElectricalItem.FindAsync(request.ElectricalItemId!.Value);
            var addcommand = _mapper.Map<AddElectricalItem>(request.ElectricalItem);
            _mapper.Map(addcommand, table, typeof(AddElectricalItem), typeof(ElectricalItem));
            await _unitofwork.RepositoryElectricalItem.UpdateAsync(table!);
        }
        async Task SaveEHS(CommandMWOItem request)
        {
            var table = await _unitofwork.RepositoryEHSItem.FindAsync(request.EHSItemId!.Value);
            var addcommand = _mapper.Map<AddEHSItem>(request.EHSItem);
            _mapper.Map(addcommand, table, typeof(AddEHSItem), typeof(EHSItem));
            await _unitofwork.RepositoryEHSItem.UpdateAsync(table!);
        }
        async Task SavePiping(CommandMWOItem request)
        {
            var table = await _unitofwork.RepositoryPipingItem.FindAsync(request.PipingItem!.Id);
            var addcommand = _mapper.Map<UpdatePipingItem>(request.PipingItem);
            _mapper.Map(addcommand, table, typeof(UpdatePipingItem), typeof(PipingItem));
            await _unitofwork.RepositoryPipingItem.UpdateAsync(table!);
            await SaveProcessCondition(request.PipingItem!.pProcessCondition!);
            foreach (var row in request.PipingItem.PipeAccesorys)
            {
                await SavePipeAccesories(row);
            }
        }
        async Task SaveInstrument(CommandMWOItem request)
        {
            var table = await _unitofwork.RepositoryInstrumentItem.FindAsync(request.InstrumentItem!.Id);
            var addcommand = _mapper.Map<UpdateInstrumentItem>(request.InstrumentItem);
            _mapper.Map(addcommand, table, typeof(UpdateInstrumentItem), typeof(InstrumentItem));
            await _unitofwork.RepositoryInstrumentItem.UpdateAsync(table!);
            await SaveProcessCondition(request.InstrumentItem!.iProcessCondition!);
        }

        async Task SaveContingency(CommandMWOItem request)
        {
            var table = await _unitofwork.RepositoryContingencyItem.FindAsync(request.ContingencyItemId!.Value);
            var addcommand = _mapper.Map<AddContingencyItem>(request.ContingencyItem);
            _mapper.Map(addcommand, table, typeof(AddContingencyItem), typeof(ContingencyItem));
            await _unitofwork.RepositoryContingencyItem.UpdateAsync(table!);
        }
        async Task SaveEngineeringCost(CommandMWOItem request)
        {
            var table = await _unitofwork.RepositoryEngineeringCostItem.FindAsync(request.EngineeringCostItemId!.Value);
            var addcommand = _mapper.Map<AddEngineeringCostItem>(request.EngineeringCostItem);
            _mapper.Map(addcommand, table, typeof(AddEngineeringCostItem), typeof(EngineeringCostItem));
            await _unitofwork.RepositoryEngineeringCostItem.UpdateAsync(table!);
        }
        async Task SaveTesting(CommandMWOItem request)
        {
            var table = await _unitofwork.RepositoryTestingItem.FindAsync(request.TestingItemId!.Value);
            var addcommand = _mapper.Map<AddTestingItem>(request.TestingItem);
            _mapper.Map(addcommand, table, typeof(AddTestingItem), typeof(TestingItem));
            await _unitofwork.RepositoryTestingItem.UpdateAsync(table!);
        }
        async Task SaveTaxes(CommandMWOItem request)
        {
            var table = await _unitofwork.RepositoryTaxesItem.FindAsync(request.TaxesItemId!.Value);
            var addcommand = _mapper.Map<AddTaxesItem>(request.TaxesItem);
            _mapper.Map(addcommand, table, typeof(AddTaxesItem), typeof(TaxesItem));
            await _unitofwork.RepositoryTaxesItem.UpdateAsync(table!);
        }
        async Task SavePainting(CommandMWOItem request)
        {
            var table = await _unitofwork.RepositoryPaintingItem.FindAsync(request.PaintingItemId!.Value);
            var addcommand = _mapper.Map<AddPaintingItem>(request.PaintingItem);
            _mapper.Map(addcommand, table, typeof(AddPaintingItem), typeof(PaintingItem));
            await _unitofwork.RepositoryPaintingItem.UpdateAsync(table!);
        }
        async Task SaveInsulation(CommandMWOItem request)
        {
            var table = await _unitofwork.RepositoryInsulationItem.FindAsync(request.InsulationItemId!.Value);
            var addcommand = _mapper.Map<AddInsulationItem>(request.InsulationItem);
            _mapper.Map(addcommand, table, typeof(AddInsulationItem), typeof(InsulationItem));
            await _unitofwork.RepositoryInsulationItem.UpdateAsync(table!);
        }
    }
}