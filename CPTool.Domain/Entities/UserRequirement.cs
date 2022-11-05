﻿namespace CPTool.Domain.Entities
{
    public class UserRequirement : BaseDomainModel
    {
        public int? UserRequirementTypeId { get; set; }
        public UserRequirementType? UserRequirementType { get; set; } = null!;
      
        public int? MWOId { get; set; }
        public MWO? MWO { get; set; } = null!;

        public int? RequestedByUserId { get; set; }
        public User RequestedByUser { get; set; } = null!;
    }


}
