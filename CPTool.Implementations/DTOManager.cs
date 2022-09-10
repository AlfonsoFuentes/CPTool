using CPTool.Interfaces;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CPTool.Implementations
{
    public class DTOManager<TDTO, T> : IDTOManager<TDTO, T>, IDisposable
        where TDTO : IAuditableEntityDTO, new()
          where T : IAuditableEntity
    {

        readonly IUnitOfWork _unitofwork;
        readonly IMapper _mapper;
        IQueryable<TDTO> QueryableList { get; set; }
        public List<TDTO> List { get; set; }
        public DTOManager(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }


        public async Task<IResult<TDTO>> AddUpdate(TDTO dto, CancellationToken cancellationToken)
        {
            var table = _mapper.Map<T>(dto);

            var request = dto.Id == 0 ? await _unitofwork.Repository<T>().AddAsync(table) : _unitofwork.Repository<T>().UpdateAsync(table);
            var result = await _unitofwork.CommitAndRemoveCache(cancellationToken, null);
            if (!result.Succeeded)
                return await Result<TDTO>.FailAsync("Not created!");

            dto = _mapper.Map<TDTO>(request);
            await UpdateList();
            return await Result<TDTO>.SuccessAsync(dto, "Updated");


        }

        public async Task<IResult<int>> Delete(int id, CancellationToken cancellationToken)
        {

            var table = await _unitofwork.Repository<T>().GetByIdAsync(id);

            if (table != null)
            {
                string retorno = $"{table.Name!} removed succesfully";
                await _unitofwork.Repository<T>().DeleteAsync(table);
                var result = await _unitofwork.CommitAndRemoveCache(cancellationToken, null);
                if (!result.Succeeded)
                {
                    return await Result<int>.FailAsync("Not Delete!");
                }
                await UpdateList();
                return await Result<int>.SuccessAsync(result.Data, retorno);
            }
            return await Result<int>.FailAsync("Not Found!");

        }
        public async Task<IResult<int>> Delete(TDTO dto, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<T>().GetByIdAsync(dto.Id);

            if (table != null)
            {
                string retorno = $"{table.Name!} removed succesfully";
                await _unitofwork.Repository<T>().DeleteAsync(table);
                var result = await _unitofwork.CommitAndRemoveCache(cancellationToken, null);
                if (!result.Succeeded)
                {
                    return await Result<int>.FailAsync("Not Delete!");
                }
                await UpdateList();
                return await Result<int>.SuccessAsync(result.Data, retorno);
            }
            return await Result<int>.FailAsync("Not Found!");
        }
        public async Task<IResult<TDTO>> GetById(int id)
        {
            var table = await _unitofwork.Repository<T>().GetByIdAsync(id);

            var dto = _mapper.Map<TDTO>(table);

            return dto == null ? await Result<TDTO>.FailAsync("Not found!") : await Result<TDTO>.SuccessAsync(dto, "row returned");


        }

        public async Task<List<TDTO>> UpdateList()
        {
            var list = await _unitofwork.Repository<T>().GetAllAsync();
            List = _mapper.Map<List<TDTO>>(list);
            QueryableList = List.AsQueryable();
         
            if (PostEvent != null)  PostEvent.Invoke();


            return List;
        }

        public void Dispose()
        {


        }
        public async Task Test(MWODTO model)
        {

        }
        public Action PostEvent { get; set; }
    }
}