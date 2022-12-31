namespace CPTool.Application.Generic
{
    public class DeleteCommand<T> : IRequest<IResult>
        where T : EditCommand

    {
        public int Id { get; set; }
    }
    public class DeleteCommandHandler<T, TEntity> : IRequestHandler<DeleteCommand<T>, IResult>
       where T : EditCommand
       where TEntity : AuditableEntity
    {
        protected IUnitOfWork _unitOfWork;

        public DeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<IResult> Handle(DeleteCommand<T> request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitOfWork.Repository<TEntity>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {


                return await Result.FailAsync($"Not found {request.Id}");


            }
            _unitOfWork.Repository<TEntity>().Delete(ToDelete);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                return await Result.FailAsync($"Not deleted {request.Id}");
            }

            return await Result.SuccessAsync($"Deleted {request.Id}");
        }
    }
}
