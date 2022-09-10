﻿



using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
    
    public class MWOItemDTO : AuditableEntityDTO
    {
       
        public MWODTO? MWODTO { get; set; }
        public AlterationItemDTO? AlterationItemDTO { get; set; }
        public FoundationItemDTO? FoundationItemDTO { get; set; }
        public StructuralItemDTO? StructuralItemDTO { get; set; }
        public EquipmentItemDTO? EquipmentItemDTO { get; set; }
        public ElectricalItemDTO? ElectricalItemDTO { get; set; }
        public PipingItemDTO? PipingItemDTO { get; set; }
        public InstrumentItemDTO? InstrumentItemDTO { get; set; }
        public InsulationItemDTO? InsulationItemDTO { get; set; }
        public PaintingItemDTO? PaintingItemDTO { get; set; }
        public EHSItemDTO? EHSItemDTO { get; set; }
        public TaxesItemDTO? TaxesItemDTO { get; set; }
        public TestingItemDTO? TestingItemDTO { get; set; }
        public EngineeringCostItemDTO? EngineeringCostItemDTO { get; set; }
        public ContingencyItemDTO? ContingencyItemDTO { get; set; }
        public int Order { get; set; }
     
        public ChapterDTO? ChapterDTO { get; set; }
        public string Nomenclatore => $"{ChapterLetter}{Order}";
        public string Letter { get; set; } = "";
        string ChapterLetter => ChapterDTO == null ? Letter : ChapterDTO.Letter!;

        public int UnitaryBasePrizeId { get; set; }
        public UnitaryBasePrizeDTO? UnitaryBasePrizeDTO { get; set; }

        public int EquipmentTypeId { get; set; }
       

        public decimal BudgetPrize => UnitaryPrize * Quantity;
        public decimal RealPrize { get; set; }
        public decimal UnitaryPrize { get; set; }
        public decimal Quantity { get; set; }

       
    }





}
