﻿namespace CPTool.Domain.Entities
{
    public class EngineeringCostItem  : BaseDomainModel
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
