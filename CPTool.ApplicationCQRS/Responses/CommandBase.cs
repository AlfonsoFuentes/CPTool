namespace CPTool.ApplicationCQRS.Responses
{
    public class CommandBase
    {
        public int Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
    }

}
