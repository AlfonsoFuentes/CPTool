using CPTool.Domain.Enums;

namespace CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate
{
    public class AddTaks
    {

       
        public string Name { get; set; } = string.Empty;
        public int? MWOId { get; set; }

        public int? MWOItemId { get; set; }


        public int? PurchaseOrderId { get; set; }

        public TaksType TaksType { get; set; }
        public int? DownpaymentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public TaksStatus TaksStatus { get; set; }
    }

}
