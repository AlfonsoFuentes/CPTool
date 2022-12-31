using CPtool.ExtensionMethods;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate
{
    public class CommandMWO : CommandBase, IRequest<MWOCommandResponse>
    {

        public int Number { get; set; }
      
        public string ProjectLeader { get; set; } = "";

        public DateTime ApprovalDate { get; set; }
    
        public string CEBName => $"CEB0000{Number}";
      
        public string CECName => $"CEC0000{Number}";
   
        public double Budget => MWOItems!.Where(x => x.ChapterId != 1).ToList().Count == 0 ? 0 : MWOItems!.Where(x => x.ChapterId != 1)!.Sum(x => x.BudgetPrize);
  
        public double Expenses => MWOItems!.Where(x => x.ChapterId == 1).ToList().Count == 0 ? 0 : MWOItems!.Where(x => x.ChapterId == 1)!.Sum(x => x.BudgetPrize);

        public double Assigned => Actual + Commitment;
        public double Actual => PurchaseOrders.Count==0?0: PurchaseOrders.Sum(x => x.ActualValue);
       
        public double Commitment => PurchaseOrders.Count == 0 ? 0 : PurchaseOrders.Sum(x => x.CommitmentValue);

        public double Pending => Budget - Actual - Commitment;
        public double AssignedExpenses => Actual + Commitment;
        public double ActualExpenses => PurchaseOrders.Count == 0 ? 0 : PurchaseOrders.Sum(x => x.ActualValueExpenses);
        public double CommitmentExpenses => PurchaseOrders.Count == 0 ? 0 : PurchaseOrders.Sum(x => x.CommitmentValueExpenses);

        public double PendingExpenses => Expenses - ActualExpenses - CommitmentExpenses;
        public int? MWOTypeId => MWOType?.Id == 0 ? null : MWOType?.Id;
        public CommandMWOType? MWOType { get; set; } = new();
      
        public string MWOTypeName => MWOType == null ? "" : MWOType!.Name;
        public List<CommandMWOItem>? MWOItems { get; set; } = new();
        public List<CommandPurchaseOrder> PurchaseOrders { get; set; } = new();
        public List<CommandUserRequirement> UserRequirements { get; set; } = new();




    }

}
