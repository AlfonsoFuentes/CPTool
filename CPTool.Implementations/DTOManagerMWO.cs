using CPTool.Interfaces;
using System.Collections;
using System.Threading;

namespace CPTool.Implementations
{
    public class DTOManagerMWODTO2 : IDTOManager<MWODTO, MWO>, IDisposable
       
    {

        readonly IUnitOfWork _unitofwork;
        readonly IMapper _mapper;
        public List<MWODTO> List { get; set; } = new();
        public DTOManagerMWODTO2(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }


        public async Task<IResult<MWODTO>> AddUpdate(MWODTO dto, CancellationToken cancellationToken)
        {
            var mwotype =await _unitofwork.Repository<MWOType>().GetByIdAsync(dto.MWOTypeDTO.Id);
            var table = _mapper.Map<MWO>(dto);
            table.MWOType = mwotype;
            var request = dto.Id == 0 ? await _unitofwork.Repository<MWO>().AddAsync(table) : _unitofwork.Repository<MWO>().UpdateAsync(table);
            var result = await _unitofwork.CommitAndRemoveCache(cancellationToken, null);
            if (!result.Succeeded)
                return await Result<MWODTO>.FailAsync("Not created!");

            dto = _mapper.Map<MWODTO>(request);
            await UpdateList();
            return await Result<MWODTO>.SuccessAsync(dto, "Updated");


        }

        public async Task<IResult<int>> Delete(int id, CancellationToken cancellationToken)
        {

            var table = await _unitofwork.Repository<MWO>().GetByIdAsync(id);

            if (table != null)
            {
                string retorno = $"{table.Name!} removed succesfully";
                await _unitofwork.Repository<MWO>().DeleteAsync(table);
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
        public async Task<IResult<int>> Delete(MWODTO dto, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<MWO>().GetByIdAsync(dto.Id);

            if (table != null)
            {
                string retorno = $"{table.Name!} removed succesfully";
                await _unitofwork.Repository<MWO>().DeleteAsync(table);
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
        public async Task<IResult<MWODTO>> GetById(int id)
        {
            var table = await _unitofwork.Repository<MWO>().GetByIdAsync(id);

            var dto = _mapper.Map<MWODTO>(table);

            return dto == null ? await Result<MWODTO>.FailAsync("Not found!") : await Result<MWODTO>.SuccessAsync(dto, "row returned");


        }

        public async Task<List<MWODTO>> UpdateList()
        {
            var list = await _unitofwork.Repository<MWO>().GetAllAsync();

            List = _mapper.Map<List<MWODTO>>(list);
            if (PostEvent != null)  PostEvent.Invoke();
            return List;
        }

        public void Dispose()
        {


        }

        public Action PostEvent { get; set; }
    }
}