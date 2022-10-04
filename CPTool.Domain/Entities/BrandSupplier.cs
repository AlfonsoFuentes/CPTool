﻿namespace CPTool.Domain.Entities
{
    public class BrandSupplier  : BaseDomainModel
    {
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } 

    }
}
