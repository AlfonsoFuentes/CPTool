namespace CPTool.GenericSample
{
    public interface IEasySoftDeleteEntity
    {
        /// <summary>
        /// Deletion Date
        /// </summary>
        public DateTime? DeletionDate { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}