

using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{

    public class MWODTO :  AuditableEntityDTO
    {
        const string ceb = "CEB0000";
        const string cec = "CEC0000";

        public int Number { get; set; }
        public string CEBName => $"{ceb}{Number}";
        public string CECName => $"{cec}{Number}";
        public string? ProjectLeader { get; set; } = "";
        public DateTime ApprovalDate { get; set; } = DateTime.Now;

        public decimal Budget { get; set; } = 0;
        public decimal Expenses { get; set; } = 0;
        public int? MWOTypeId => MWOTypeDTO?.Id;

        public  MWOTypeDTO? MWOTypeDTO { get; set; } = new();
        public List<MWOItemDTO>? MWOItemDTOs
        {
            get
            {
                var values = Details.Select(x => x as MWOItemDTO).ToList();
                return values!;
            }
            set
            {
                Details = value!.Select(x => x as AuditableEntityDTO).ToList();
            }
        }
       

    }
    





}
