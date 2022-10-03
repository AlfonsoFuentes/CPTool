namespace CPTool.GenericSample
{
    internal interface IEasyEntity<TPrimaryKey>
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        TPrimaryKey Id { get; set; }
    }
}