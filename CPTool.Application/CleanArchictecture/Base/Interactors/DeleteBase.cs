

namespace CPTool.ApplicationCA.Base.Interactors
{
    public class DeleteBase<TDeleteDTO, TEntity>: IDeletePort<TDeleteDTO, TEntity>
        where TDeleteDTO : DeleteCommand
         where TEntity : BaseDomainModel

    {

        private IUnitOfWork _unitofwork;

        public DeleteBase(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Result<int>> Handle(TDeleteDTO request)
        {
            var ToDelete = await _unitofwork.Repository<TEntity>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
                return await Result<int>.FailAsync($"Not found {request.Id}");


            }
            _unitofwork.Repository<TEntity>().Delete(ToDelete);
            var result = await _unitofwork.Complete();
            if (result <= 0)
            {
                return await Result<int>.FailAsync($"Not deleted {request.Id}");
            }
           
            return await Result<int>.SuccessAsync(request.Id, $"Deleted {request.Id}");
        }


    }
}
