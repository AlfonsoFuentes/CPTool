using CPtool.ExtensionMethods;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate
{
    public class CommandMWO : CommandBase, IRequest<MWOCommandResponse>
    {

        public int Number { get; set; }

        public int? ProjectLeaderId => ProjectLeader!.Id == 0 ? null : ProjectLeader!.Id;
        public CommandUser? ProjectLeader { get; set; } = new();
        public string ProjectLeaderName => ProjectLeader == null ? "" : ProjectLeader!.Name;

        public DateTime ApprovalDate { get; set; }

        public string CEBName => $"CEB0000{Number}";

        public string CECName => $"CEC0000{Number}";
        public string BudgetValue => Budget.ToString("C0");
        public double Budget => MWOItems!.Where(x => x.ChapterId != 1).ToList().Count == 0 ? 0 : MWOItems!.Where(x => x.ChapterId != 1)!.Sum(x => x.BudgetPrize);
        public string ExpensesValue => Expenses.ToString("C0");
        public double Expenses => MWOItems!.Where(x => x.ChapterId == 1).ToList().Count == 0 ? 0 : MWOItems!.Where(x => x.ChapterId == 1)!.Sum(x => x.BudgetPrize);
        public string AssignedValue => Assigned.ToString("C0");
        public double Assigned => Actual + Commitment;
        public string ActualValue => Actual.ToString("C0");
        public double Actual => PurchaseOrders.Count == 0 ? 0 : PurchaseOrders.Sum(x => x.ActualValue);
        public string CommitmentValue => Commitment.ToString("C0");
        public double Commitment => PurchaseOrders.Count == 0 ? 0 : PurchaseOrders.Sum(x => x.CommitmentValue);
        public string PendingValue => Pending.ToString("C0");
        public double Pending => Budget - Actual - Commitment;
        public string AssignedExpensesValue => AssignedExpenses.ToString("C0");
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

        bool _Approved = false;
        public bool Approved
        {
            get { return _Approved; }
            set
            {
                _Approved = value;
                if (_Approved)
                {
                    ApprovalDate = DateTime.UtcNow;
                }
            }
        }
        public bool ToApproved { get; set; }

    }

}
